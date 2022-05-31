using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var input = new HelloRequest { Name = "Osama" };

            //var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //var client = new Greeter.GreeterClient(channel);

            //var reply = await client.SayHelloAsync(input);

            //Console.WriteLine(reply.Message);



            var channel = GrpcChannel.ForAddress("https://localhost:5001");

#pragma warning disable CS0436 // Type conflicts with imported type
            var customerClient = new Customer.CustomerClient(channel);
#pragma warning restore CS0436 // Type conflicts with imported type

            int userId;
            userId =Int32.Parse(Console.ReadLine());

#pragma warning disable CS0436 // Type conflicts with imported type
            var clientRequested = new CustomerLookupModel { UserId = userId };
#pragma warning restore CS0436 // Type conflicts with imported type

            var customer = await customerClient.GetCustomerInfoAsync(clientRequested);

            Console.WriteLine($"{ customer.FirstName } { customer.LastName }");
            Console.ReadLine();
        }
    }
}
