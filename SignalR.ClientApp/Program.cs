using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalR.ClientApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("SignalR Client Application Started");
            HubConnection connection = new HubConnectionBuilder()
                                        .WithUrl("http://localhost:49897/integrationhub")
                                        .Build();



            //connection.On<string, string>("ReceiveMessage", (user, message) =>
            //{
            //    var newMessage = $"{user}: {message}";
            //    Console.WriteLine(newMessage);
            //});

            connection.On<string>("ReceiveMessage", (message) =>
            {
                var newMessage = $"{message}";
                Console.WriteLine(newMessage);
            });

            try
            {
                await connection.StartAsync().ContinueWith((task) =>
                {
                    if (task.IsCompleted)
                        Console.WriteLine("Client Connected");
                    else
                        Console.WriteLine("There was an error opening the connection:{0}",
                                      task.Exception.GetBaseException());
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            await connection.InvokeAsync("SendMessage","thomas","thomas2");


            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }


        public void SendMessage()
        {

        }
    }
}
