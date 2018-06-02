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
                                        .WithUrl("https://localhost:44337/stackstormhub")
                                        .Build();



            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var newMessage = $"{user}: {message}";
                Console.WriteLine(newMessage);
            });

            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }
    }
}
