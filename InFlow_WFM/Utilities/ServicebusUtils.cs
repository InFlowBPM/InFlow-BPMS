using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.WFM.Utilities
{
    /// <summary>
    /// Management functions for the service bus
    /// </summary>
    public class ServicebusUtils
    {
        //default configuration for Namespacemanager
        public string ServerFQDN { get; set; } 
        public int HttpPort { get; set; }
        public int TcpPort { get; set; }
        public string ServiceNamespace { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        private ServiceBusConnectionStringBuilder connBuilder;
        private TokenProvider localUserTokenProvider;
        private NamespaceManager namespaceManager;
        private MessagingFactory messageFactory;
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="serverFQDN"></param>
        /// <param name="serviceNamespace"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public ServicebusUtils(string serverFQDN, string serviceNamespace, string username, string password)
        {
            ServerFQDN = serverFQDN;
            HttpPort = 9355; //default http-port
            TcpPort = 9354; //default tcp-port
            ServiceNamespace = serviceNamespace;
            Username = username;
            Password = password;

            //init namespace manager
            initServiceBusConnectionStringBuilder();
            initSecurityTokenprovider();
        }

        /// <summary>
        /// create new servicebus queue
        /// </summary>
        /// <param name="name">name of the queue</param>
        /// <param name="overwrite">overwrite existing queue?</param>
        public void createQueue(string name, bool overwrite)
        {
            if(namespaceManager == null)
            {
                namespaceManager = new NamespaceManager(connBuilder.GetAbsoluteManagementEndpoints(), localUserTokenProvider);
            }

            if (namespaceManager.QueueExists(name) && overwrite)
            {
                namespaceManager.DeleteQueue(name);   
            }
            if(!namespaceManager.QueueExists(name))
            {
                namespaceManager.CreateQueue(name);
            }
        }

        /// <summary>
        /// delete servicebus queue
        /// </summary>
        /// <param name="name"></param>
        public void deleteQueue(string name)
        {
            if(namespaceManager == null)
            {
                namespaceManager = new NamespaceManager(connBuilder.GetAbsoluteManagementEndpoints(), localUserTokenProvider);
            }

            if (namespaceManager.QueueExists(name))
            {
                namespaceManager.DeleteQueue(name);
            }
        }

        /// <summary>
        /// check if servicebus queue exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool checkQueueExists(string name)
        {
            if(namespaceManager == null)
            {
                namespaceManager = new NamespaceManager(connBuilder.GetAbsoluteManagementEndpoints(), localUserTokenProvider);
            }

            return namespaceManager.QueueExists(name);
        }

        /// <summary>
        /// create new QueueClient
        /// </summary>
        /// <param name="queueName">Name of the queue</param>
        /// <returns>QueueClient for given queue</returns>
        public QueueClient createQueueClientforQueue(string queueName)
        {
            if (messageFactory == null)
            {
                messageFactory = MessagingFactory.Create(connBuilder.GetAbsoluteRuntimeEndpoints(), localUserTokenProvider);
            }

            return messageFactory.CreateQueueClient(queueName);
        }

        /// <summary>
        /// Create servicebus connectionstring
        /// </summary>
        private void initServiceBusConnectionStringBuilder()
        {
            connBuilder = new ServiceBusConnectionStringBuilder();
            connBuilder.ManagementPort = HttpPort;
            connBuilder.RuntimePort = TcpPort;

            connBuilder.Endpoints.Add(new UriBuilder()
            {
                Scheme = "sb",
                Host = ServerFQDN,
                Path = ServiceNamespace
            }.Uri);

            connBuilder.StsEndpoints.Add(new UriBuilder()
            {
                Scheme = "https",
                Host = ServerFQDN,
                Port = HttpPort,
                Path = ServiceNamespace
            }.Uri);
        }

        /// <summary>
        /// create security token
        /// </summary>
        private void initSecurityTokenprovider()
        {
            localUserTokenProvider = WindowsTokenProvider.CreateOAuthTokenProvider(
                connBuilder.StsEndpoints,
                new System.Net.NetworkCredential(Username, Password));
        }

        /// <summary>
        /// initialize namespaceManager
        /// </summary>
        private void initNamespaceManager()
        {
            namespaceManager = new NamespaceManager(connBuilder.GetAbsoluteManagementEndpoints(), localUserTokenProvider);
        }
    }
}
