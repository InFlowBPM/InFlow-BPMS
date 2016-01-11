﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strict.InFlow.Designer.Db
{
    [ComplexType]
    public class PersistableStringCollection : PersistableScalarCollection<string>
    {
        protected override string ConvertSingleValueToRuntime(string rawValue)
        {
            return  rawValue;
        }

        protected override string ConvertSingleValueToPersistable(string value)
        {
            return value;
        }
    }

    [ComplexType]
    public abstract class PersistableScalarCollection<T> : ICollection<T>
    {

        // use a character that will not occur in the collection.
        // this can be overriden using the given abstract methods (e.g. for list of strings).
        const string DefaultValueSeperator = "|";

        readonly string[] DefaultValueSeperators = new string[] { DefaultValueSeperator };

        /// <summary>
        /// The internal data container for the list data.
        /// </summary>
        private List<T> Data { get; set; }

        public PersistableScalarCollection()
        {
            Data = new List<T>();
        }

        /// <summary>
        /// Implementors have to convert the given value raw value to the correct runtime-type.
        /// </summary>
        /// <param name="rawValue">the already seperated raw value from the database</param>
        /// <returns></returns>
        protected abstract T ConvertSingleValueToRuntime(string rawValue);

        /// <summary>
        /// Implementors should convert the given runtime value to a persistable form.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected abstract string ConvertSingleValueToPersistable(T value);

        /// <summary>
        /// Deriving classes can override the string that is used to seperate single values
        /// </summary>        
        protected virtual string ValueSeperator
        {
            get
            {
                return DefaultValueSeperator;
            }
        }

        /// <summary>
        /// Deriving classes can override the string that is used to seperate single values
        /// </summary>        
        protected virtual string[] ValueSeperators
        {
            get
            {
                return DefaultValueSeperators;
            }
        }

        /// <summary>
        /// DO NOT Modeify manually! This is only used to store/load the data.
        /// </summary>        
        public string SerializedValue
        {
            get
            {
                var serializedValue = string.Join(ValueSeperator.ToString(),
                    Data.Select(x => ConvertSingleValueToPersistable(x))
                    .ToArray());
                return serializedValue;
            }
            set
            {
                Data.Clear();

                if (string.IsNullOrEmpty(value))
                {
                    return;
                }

                Data = new List<T>(value.Split(ValueSeperators, StringSplitOptions.None)
                    .Select(x => ConvertSingleValueToRuntime(x)));
            }
        }

        #region ICollection<T> Members

        public void Add(T item)
        {
            Data.Add(item);
        }

        public void Clear()
        {
            Data.Clear();
        }

        public bool Contains(T item)
        {
            return Data.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Data.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return Data.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            return Data.Remove(item);
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        #endregion
    }
}
