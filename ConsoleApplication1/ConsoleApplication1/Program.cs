using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Client";
            ///
            Uri adress = new Uri("http://127.0.0.1:8000/IService");

            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress(adress);

            ChannelFactory<IService> factory = new ChannelFactory<IService>(binding, endpoint);
            IService chanel = factory.CreateChannel();
            for(;;)
            {
                try {chanel.sayHello("Hello WCF"); }
                catch(Exception r) {  }
                Thread.Sleep(100);
            }
           
                        
            Console.ReadLine();
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
            Console.WriteLine("Hello there"+enter);
        }
    }
}
