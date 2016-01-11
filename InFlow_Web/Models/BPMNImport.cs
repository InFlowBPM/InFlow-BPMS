using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace strICT.InFlow.Web.Models
{
   

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL", IsNullable = true)]
        public partial class definitions
        {

            private definitionsCollaboration collaborationField;

            private definitionsDataStore[] dataStoreField;

            private definitionsItemDefinition[] itemDefinitionField;

            private definitionsMessage[] messageField;

            private definitionsProcess[] processField;

            private BPMNDiagram bPMNDiagramField;

            private string idField;

            private string targetNamespaceField;

            /// <remarks/>
            public definitionsCollaboration collaboration
            {
                get
                {
                    return this.collaborationField;
                }
                set
                {
                    this.collaborationField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("dataStore")]
            public definitionsDataStore[] dataStore
            {
                get
                {
                    return this.dataStoreField;
                }
                set
                {
                    this.dataStoreField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("itemDefinition")]
            public definitionsItemDefinition[] itemDefinition
            {
                get
                {
                    return this.itemDefinitionField;
                }
                set
                {
                    this.itemDefinitionField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("message")]
            public definitionsMessage[] message
            {
                get
                {
                    return this.messageField;
                }
                set
                {
                    this.messageField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("process")]
            public definitionsProcess[] process
            {
                get
                {
                    return this.processField;
                }
                set
                {
                    this.processField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.omg.org/spec/BPMN/20100524/DI")]
            public BPMNDiagram BPMNDiagram
            {
                get
                {
                    return this.bPMNDiagramField;
                }
                set
                {
                    this.bPMNDiagramField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string targetNamespace
            {
                get
                {
                    return this.targetNamespaceField;
                }
                set
                {
                    this.targetNamespaceField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsCollaboration
        {

            private definitionsCollaborationParticipant[] participantField;

            private definitionsCollaborationMessageFlow[] messageFlowField;

            private string idField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("participant")]
            public definitionsCollaborationParticipant[] participant
            {
                get
                {
                    return this.participantField;
                }
                set
                {
                    this.participantField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("messageFlow")]
            public definitionsCollaborationMessageFlow[] messageFlow
            {
                get
                {
                    return this.messageFlowField;
                }
                set
                {
                    this.messageFlowField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsCollaborationParticipant
        {

            private string idField;

            private string nameField;

            private string processRefField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string processRef
            {
                get
                {
                    return this.processRefField;
                }
                set
                {
                    this.processRefField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsCollaborationMessageFlow
        {

            private string idField;

            private string nameField;

            private string sourceRefField;

            private string targetRefField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string sourceRef
            {
                get
                {
                    return this.sourceRefField;
                }
                set
                {
                    this.sourceRefField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string targetRef
            {
                get
                {
                    return this.targetRefField;
                }
                set
                {
                    this.targetRefField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsDataStore
        {

            private string idField;

            private string itemSubjectRefField;

            private string nameField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string itemSubjectRef
            {
                get
                {
                    return this.itemSubjectRefField;
                }
                set
                {
                    this.itemSubjectRefField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsItemDefinition
        {

            private string idField;

            private bool isCollectionField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public bool isCollection
            {
                get
                {
                    return this.isCollectionField;
                }
                set
                {
                    this.isCollectionField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsMessage
        {

            private string idField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsProcess
        {

            private object[] itemsField;

            private string idField;

            private bool isExecutableField;

            private string nameField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("association", typeof(definitionsProcessAssociation))]
            [System.Xml.Serialization.XmlElementAttribute("dataStoreReference", typeof(definitionsProcessDataStoreReference))]
            [System.Xml.Serialization.XmlElementAttribute("intermediateCatchEvent", typeof(definitionsProcessIntermediateCatchEvent))]
            [System.Xml.Serialization.XmlElementAttribute("intermediateThrowEvent", typeof(definitionsProcessIntermediateThrowEvent))]
            [System.Xml.Serialization.XmlElementAttribute("sequenceFlow", typeof(definitionsProcessSequenceFlow))]
            [System.Xml.Serialization.XmlElementAttribute("serviceTask", typeof(definitionsProcessServiceTask))]
            [System.Xml.Serialization.XmlElementAttribute("textAnnotation", typeof(definitionsProcessTextAnnotation))]
            [System.Xml.Serialization.XmlElementAttribute("userTask", typeof(definitionsProcessUserTask))]
            public object[] Items
            {
                get
                {
                    return this.itemsField;
                }
                set
                {
                    this.itemsField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public bool isExecutable
            {
                get
                {
                    return this.isExecutableField;
                }
                set
                {
                    this.isExecutableField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsProcessAssociation
        {

            private string associationDirectionField;

            private string idField;

            private string sourceRefField;

            private string targetRefField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string associationDirection
            {
                get
                {
                    return this.associationDirectionField;
                }
                set
                {
                    this.associationDirectionField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string sourceRef
            {
                get
                {
                    return this.sourceRefField;
                }
                set
                {
                    this.sourceRefField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string targetRef
            {
                get
                {
                    return this.targetRefField;
                }
                set
                {
                    this.targetRefField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsProcessDataStoreReference
        {

            private string dataStoreRefField;

            private string idField;

            private string nameField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string dataStoreRef
            {
                get
                {
                    return this.dataStoreRefField;
                }
                set
                {
                    this.dataStoreRefField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsProcessIntermediateCatchEvent
        {

            private string incomingField;

            private string outgoingField;

            private definitionsProcessIntermediateCatchEventLinkEventDefinition linkEventDefinitionField;

            private definitionsProcessIntermediateCatchEventMessageEventDefinition messageEventDefinitionField;

            private string idField;

            private string nameField;

            /// <remarks/>
            public string incoming
            {
                get
                {
                    return this.incomingField;
                }
                set
                {
                    this.incomingField = value;
                }
            }

            /// <remarks/>
            public string outgoing
            {
                get
                {
                    return this.outgoingField;
                }
                set
                {
                    this.outgoingField = value;
                }
            }

            /// <remarks/>
            public definitionsProcessIntermediateCatchEventLinkEventDefinition linkEventDefinition
            {
                get
                {
                    return this.linkEventDefinitionField;
                }
                set
                {
                    this.linkEventDefinitionField = value;
                }
            }

            /// <remarks/>
            public definitionsProcessIntermediateCatchEventMessageEventDefinition messageEventDefinition
            {
                get
                {
                    return this.messageEventDefinitionField;
                }
                set
                {
                    this.messageEventDefinitionField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsProcessIntermediateCatchEventLinkEventDefinition
        {

            private string nameField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsProcessIntermediateCatchEventMessageEventDefinition
        {

            private string messageRefField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string messageRef
            {
                get
                {
                    return this.messageRefField;
                }
                set
                {
                    this.messageRefField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsProcessIntermediateThrowEvent
        {

            private string incomingField;

            private definitionsProcessIntermediateThrowEventLinkEventDefinition linkEventDefinitionField;

            private string outgoingField;

            private definitionsProcessIntermediateThrowEventMessageEventDefinition messageEventDefinitionField;

            private string idField;

            private string nameField;

            /// <remarks/>
            public string incoming
            {
                get
                {
                    return this.incomingField;
                }
                set
                {
                    this.incomingField = value;
                }
            }

            /// <remarks/>
            public definitionsProcessIntermediateThrowEventLinkEventDefinition linkEventDefinition
            {
                get
                {
                    return this.linkEventDefinitionField;
                }
                set
                {
                    this.linkEventDefinitionField = value;
                }
            }

            /// <remarks/>
            public string outgoing
            {
                get
                {
                    return this.outgoingField;
                }
                set
                {
                    this.outgoingField = value;
                }
            }

            /// <remarks/>
            public definitionsProcessIntermediateThrowEventMessageEventDefinition messageEventDefinition
            {
                get
                {
                    return this.messageEventDefinitionField;
                }
                set
                {
                    this.messageEventDefinitionField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsProcessIntermediateThrowEventLinkEventDefinition
        {

            private string nameField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsProcessIntermediateThrowEventMessageEventDefinition
        {

            private string messageRefField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string messageRef
            {
                get
                {
                    return this.messageRefField;
                }
                set
                {
                    this.messageRefField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsProcessSequenceFlow
        {

            private string idField;

            private string sourceRefField;

            private string targetRefField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string sourceRef
            {
                get
                {
                    return this.sourceRefField;
                }
                set
                {
                    this.sourceRefField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string targetRef
            {
                get
                {
                    return this.targetRefField;
                }
                set
                {
                    this.targetRefField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsProcessServiceTask
        {

            private string incomingField;

            private string outgoingField;

            private definitionsProcessServiceTaskIoSpecification ioSpecificationField;

            private definitionsProcessServiceTaskDataOutputAssociation dataOutputAssociationField;

            private string idField;

            private string nameField;

            /// <remarks/>
            public string incoming
            {
                get
                {
                    return this.incomingField;
                }
                set
                {
                    this.incomingField = value;
                }
            }

            /// <remarks/>
            public string outgoing
            {
                get
                {
                    return this.outgoingField;
                }
                set
                {
                    this.outgoingField = value;
                }
            }

            /// <remarks/>
            public definitionsProcessServiceTaskIoSpecification ioSpecification
            {
                get
                {
                    return this.ioSpecificationField;
                }
                set
                {
                    this.ioSpecificationField = value;
                }
            }

            /// <remarks/>
            public definitionsProcessServiceTaskDataOutputAssociation dataOutputAssociation
            {
                get
                {
                    return this.dataOutputAssociationField;
                }
                set
                {
                    this.dataOutputAssociationField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsProcessServiceTaskIoSpecification
        {

            private definitionsProcessServiceTaskIoSpecificationDataOutput dataOutputField;

            private object inputSetField;

            private definitionsProcessServiceTaskIoSpecificationOutputSet outputSetField;

            /// <remarks/>
            public definitionsProcessServiceTaskIoSpecificationDataOutput dataOutput
            {
                get
                {
                    return this.dataOutputField;
                }
                set
                {
                    this.dataOutputField = value;
                }
            }

            /// <remarks/>
            public object inputSet
            {
                get
                {
                    return this.inputSetField;
                }
                set
                {
                    this.inputSetField = value;
                }
            }

            /// <remarks/>
            public definitionsProcessServiceTaskIoSpecificationOutputSet outputSet
            {
                get
                {
                    return this.outputSetField;
                }
                set
                {
                    this.outputSetField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsProcessServiceTaskIoSpecificationDataOutput
        {

            private string idField;

            private string itemSubjectRefField;

            private string nameField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string itemSubjectRef
            {
                get
                {
                    return this.itemSubjectRefField;
                }
                set
                {
                    this.itemSubjectRefField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsProcessServiceTaskIoSpecificationOutputSet
        {

            private string dataOutputRefsField;

            /// <remarks/>
            public string dataOutputRefs
            {
                get
                {
                    return this.dataOutputRefsField;
                }
                set
                {
                    this.dataOutputRefsField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsProcessServiceTaskDataOutputAssociation
        {

            private string sourceRefField;

            private string targetRefField;

            private string idField;

            /// <remarks/>
            public string sourceRef
            {
                get
                {
                    return this.sourceRefField;
                }
                set
                {
                    this.sourceRefField = value;
                }
            }

            /// <remarks/>
            public string targetRef
            {
                get
                {
                    return this.targetRefField;
                }
                set
                {
                    this.targetRefField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsProcessTextAnnotation
        {

            private string textField;

            private string idField;

            /// <remarks/>
            public string text
            {
                get
                {
                    return this.textField;
                }
                set
                {
                    this.textField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
        public partial class definitionsProcessUserTask
        {

            private string incomingField;

            private string outgoingField;

            private string idField;

            private string nameField;

            /// <remarks/>
            public string incoming
            {
                get
                {
                    return this.incomingField;
                }
                set
                {
                    this.incomingField = value;
                }
            }

            /// <remarks/>
            public string outgoing
            {
                get
                {
                    return this.outgoingField;
                }
                set
                {
                    this.outgoingField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/DI")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.omg.org/spec/BPMN/20100524/DI", IsNullable = false)]
        public partial class BPMNDiagram
        {

            private BPMNDiagramBPMNPlane bPMNPlaneField;

            private string idField;

            private string nameField;

            /// <remarks/>
            public BPMNDiagramBPMNPlane BPMNPlane
            {
                get
                {
                    return this.bPMNPlaneField;
                }
                set
                {
                    this.bPMNPlaneField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/DI")]
        public partial class BPMNDiagramBPMNPlane
        {

            private BPMNDiagramBPMNPlaneBPMNEdge[] bPMNEdgeField;

            private BPMNDiagramBPMNPlaneBPMNShape[] bPMNShapeField;

            private string bpmnElementField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("BPMNEdge")]
            public BPMNDiagramBPMNPlaneBPMNEdge[] BPMNEdge
            {
                get
                {
                    return this.bPMNEdgeField;
                }
                set
                {
                    this.bPMNEdgeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("BPMNShape")]
            public BPMNDiagramBPMNPlaneBPMNShape[] BPMNShape
            {
                get
                {
                    return this.bPMNShapeField;
                }
                set
                {
                    this.bPMNShapeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string bpmnElement
            {
                get
                {
                    return this.bpmnElementField;
                }
                set
                {
                    this.bpmnElementField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/DI")]
        public partial class BPMNDiagramBPMNPlaneBPMNEdge
        {

            private waypoint[] waypointField;

            private object bPMNLabelField;

            private string bpmnElementField;

            private string idField;

            private string messageVisibleKindField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("waypoint", Namespace = "http://www.omg.org/spec/DD/20100524/DI")]
            public waypoint[] waypoint
            {
                get
                {
                    return this.waypointField;
                }
                set
                {
                    this.waypointField = value;
                }
            }

            /// <remarks/>
            public object BPMNLabel
            {
                get
                {
                    return this.bPMNLabelField;
                }
                set
                {
                    this.bPMNLabelField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string bpmnElement
            {
                get
                {
                    return this.bpmnElementField;
                }
                set
                {
                    this.bpmnElementField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string messageVisibleKind
            {
                get
                {
                    return this.messageVisibleKindField;
                }
                set
                {
                    this.messageVisibleKindField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/DD/20100524/DI")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.omg.org/spec/DD/20100524/DI", IsNullable = false)]
        public partial class waypoint
        {

            private ushort xField;

            private ushort yField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ushort x
            {
                get
                {
                    return this.xField;
                }
                set
                {
                    this.xField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ushort y
            {
                get
                {
                    return this.yField;
                }
                set
                {
                    this.yField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/BPMN/20100524/DI")]
        public partial class BPMNDiagramBPMNPlaneBPMNShape
        {

            private Bounds boundsField;

            private object bPMNLabelField;

            private string bpmnElementField;

            private string idField;

            private bool isHorizontalField;

            private bool isHorizontalFieldSpecified;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.omg.org/spec/DD/20100524/DC")]
            public Bounds Bounds
            {
                get
                {
                    return this.boundsField;
                }
                set
                {
                    this.boundsField = value;
                }
            }

            /// <remarks/>
            public object BPMNLabel
            {
                get
                {
                    return this.bPMNLabelField;
                }
                set
                {
                    this.bPMNLabelField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string bpmnElement
            {
                get
                {
                    return this.bpmnElementField;
                }
                set
                {
                    this.bpmnElementField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public bool isHorizontal
            {
                get
                {
                    return this.isHorizontalField;
                }
                set
                {
                    this.isHorizontalField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool isHorizontalSpecified
            {
                get
                {
                    return this.isHorizontalFieldSpecified;
                }
                set
                {
                    this.isHorizontalFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.omg.org/spec/DD/20100524/DC")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.omg.org/spec/DD/20100524/DC", IsNullable = false)]
        public partial class Bounds
        {

            private ushort heightField;

            private ushort widthField;

            private ushort xField;

            private ushort yField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ushort height
            {
                get
                {
                    return this.heightField;
                }
                set
                {
                    this.heightField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ushort width
            {
                get
                {
                    return this.widthField;
                }
                set
                {
                    this.widthField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ushort x
            {
                get
                {
                    return this.xField;
                }
                set
                {
                    this.xField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ushort y
            {
                get
                {
                    return this.yField;
                }
                set
                {
                    this.yField = value;
                }
            }
        }


    }