using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalR.ClientApp
{
    class Program
    {
        private static bool isConnected = false;
        private static HubConnection connection = null;

        static async Task Main(string[] args)
        {
            Console.WriteLine("SignalR Client Application Started");

            connection = new HubConnectionBuilder().WithUrl("http://localhost:49897/integrationhub").Build();

            connection.On<string>("ReceiveMessage", (message) =>
            {
                var newMessage = $"{message}";
                Console.WriteLine(newMessage);
            });

            connection.On<string>("AddArtifact", (message) =>
            {
                var newMessage = $"{message}";
                Console.WriteLine(newMessage);
            });


            connection.On<string>("connections", (message) =>
            {
                var newMessage = $"{message}";
                Console.WriteLine(newMessage);
            });

            connection.On<string>("UpdateExecution", (message) =>
            {
                var newMessage = $"{message}";
                Console.WriteLine(newMessage);
            });

            try
            {
                await TryConnectAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            await connection.InvokeAsync("SendMessage","thomas","thomas2");


            connection.Closed += Connection_Closed;


            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }

        private async static Task Connection_Closed(Exception arg)
        {
            Console.WriteLine("Client Disconnected...");
            isConnected = false;
            await TryConnectAsync();
        }

        public async static Task TryConnectAsync()
        {
            while (!isConnected)
            {
                await connection.StartAsync().ContinueWith((task) =>
                {
                    isConnected = true;
                    if (task.IsCompleted)
                        Console.WriteLine("Client Connected...");
                    else
                        Console.WriteLine("There was an error opening the connection:{0}",
                                      task.Exception.GetBaseException());
                });
            }
        }
    }
}
