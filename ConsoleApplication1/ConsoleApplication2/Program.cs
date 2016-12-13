using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Server";

            // Uri adress = new Uri("http://127.0.0.1:8000/IService1");

            //BasicHttpBinding binding = new BasicHttpBinding();

            Type contract = typeof(IService);

            ServiceHost host = new ServiceHost(typeof(IService), new Uri("http://127.0.0.1:8000/IService"));
            host.AddServiceEndpoint(typeof(IService), new BasicHttpBinding(), "");
            host.Open();

            Console.WriteLine("Solution is ready");
            Console.ReadLine();
            host.Close();
        }
    }
    [ServiceContract]
    interface IService
    {
        [OperationContract]
        void sayHello(string enter);
    }
    class Service : IService
    {
        public void sayHello(string enter)
        {
            Console.WriteLine("Hello there" + enter);
        }
    }
}
