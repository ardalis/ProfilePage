using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ProfileEngine.Infrastructure;

namespace ProfileEngine.IntegrationTests.ServiceBroker
{
    [TestFixture]
    public class ServiceBrokerWrapperShould
    {
        /// <summary>
        /// http://blog.sqlauthority.com/2009/09/21/sql-server-intorduction-to-service-broker-and-sample-script/
        /// </summary>
        [Test]
        public void SetUpTestDatabase()
        {
            var sql = @"
CREATE DATABASE ServiceBrokerTest
GO
USE ServiceBrokerTest
GO
-- Enable Service Broker
ALTER DATABASE ServiceBrokerTest SET ENABLE_BROKER
GO
-- Create Message Type
CREATE MESSAGE TYPE SBMessage
VALIDATION = NONE
GO
-- Create Contract
CREATE CONTRACT SBContract
(SBMessage SENT BY INITIATOR)
GO
-- Create Send Queue
CREATE QUEUE SBSendQueue
GO
-- Create Receive Queue
CREATE QUEUE SBReceiveQueue
GO
-- Create Send Service on Send Queue
CREATE SERVICE SBSendService
ON QUEUE SBSendQueue (SBContract)
GO
-- Create Receive Service on Recieve Queue
CREATE SERVICE SBReceiveService
ON QUEUE SBReceiveQueue (SBContract)
GO
";
            using (var connection = GetConnection())
            {
                var cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["ServiceBrokerDb"].ConnectionString);
        }
        [Test]
        public void Work()
        {
            var connection = GetConnection();
            connection.Open();
            var transaction = connection.BeginTransaction();

            var conversationHandle =  ServiceBrokerWrapper.BeginConversation(transaction, "SBSendService", "SBReceiveService", "SBContract");
            ServiceBrokerWrapper.Send(transaction, conversationHandle, "SBMessage", Encoding.Unicode.GetBytes("Test Message"));
            
            
            transaction.Commit();
            connection.Close();


        }
    }
}