using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfileEngine.Core.Model.Events;
using ProfileEngine.Infrastructure;
using ServiceStack.Text;

namespace ProfileEngine
{
    /// <summary>
    /// http://www.codeproject.com/Articles/19351/HybridService-Easily-Switch-Between-Console-Applic
    /// </summary>
    class ConsoleApplication
    {
        public ConsoleApplication(string applicationPath, bool consoleMode)
        {
            //This is where your console application would be
            IoC.Init();

            Console.WriteLine("Hybrid Service Application");
            Console.WriteLine();

            StreamWriter stream =
                new StreamWriter(applicationPath + "\\output.txt", true);
            stream.WriteLine(DateTime.Now.ToString("f") + "   It works! \n");
            stream.Flush();
            stream.Close();
            stream.Dispose();

            SendTestTwitterMessages();

            Console.WriteLine(
                "I have written to " + applicationPath + "\\output.txt");
            Console.WriteLine("Press any key to exit...");
            if (consoleMode) Console.ReadKey();

            //If you need to exit the application before 
            //it reaches this point, you need to use the line below, or 
            //the service will not stop running.
            //But if you are running a socket server or something that 
            //needs to stay alive after this method has been executed, 
            //remove the line below.
            Environment.Exit(0);
        }

        private void SendTestTwitterMessages()
        {
            Console.WriteLine("Sending Twitter RT Message...");
            var message = new TelerikTweetRetweeted()
            {
                ActivityId = Guid.Empty,
                ProfileId = Guid.Empty,
                OccurredOnUtc = DateTime.UtcNow,
                Details="@ardalis RT'd @telerik: https://twitter.com/Telerik/status/373442658691477504"
            };

            var connection = GetConnection();
            connection.Open();
            var transaction = connection.BeginTransaction();

            var conversationHandle = ServiceBrokerWrapper.BeginConversation(transaction, "SBSendService", "SBReceiveService", "SBContract");
            ServiceBrokerWrapper.Send(transaction, conversationHandle, "SBMessage", Encoding.Unicode.GetBytes(message.ToJson()));


            transaction.Commit();
            connection.Close();

        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["ServiceBrokerDb"].ConnectionString);
        }


        public void Close()
        {
            //Application is exiting. This is where your cleanup code 
            //should be. For example, a socket server would need 
            //"mySocketListener.Close();"
        }
    }
}
