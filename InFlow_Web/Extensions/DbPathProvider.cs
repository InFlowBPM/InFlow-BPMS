using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.DataContexts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace strICT.InFlow.Web.Extensions
{
    /*
    public class DbPathProvider : VirtualPathProvider
    {

        public override bool FileExists(string virtualPath)
        {
            var bo = FindBo(virtualPath);
            if (bo == null)
            {
                return base.FileExists(virtualPath);
            }
            else
            {
                return true;
            }
        }

        public override VirtualFile GetFile(string virtualPath)
        {
            var bo = FindBo(virtualPath);
            if (bo == null)
            {
                return base.GetFile(virtualPath);
            }
            else
            {
                return new DbVirtualFile(virtualPath, bo.ViewData.ToArray());
            }
        }


        private BO_BusinessObject FindBo(string virtualPath)
        {
            BODb db = new BODb();
            BO_BusinessObject bo = null;
            try
            {
                bo = db.BusinessObjects.Single(r => r.VirtualPath == virtualPath);
            }
            catch (Exception e) { }

            return bo;
        }
    }


    public class DbVirtualFile : System.Web.Hosting.VirtualFile
    {
        private byte[] data;

        public DbVirtualFile(string virtualPath, byte[] data)
            : base(virtualPath)
        {
            this.data = data;
        }

        public override System.IO.Stream Open()
        {
            return new MemoryStream(data);
        }
    }
     * */
}