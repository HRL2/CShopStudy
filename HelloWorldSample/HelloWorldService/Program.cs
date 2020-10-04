using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldService
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    [ServiceContract]
    public interface IHelloWorld
    {
        [OperationContract]
        string SayHello();
    }

    public class HelloWorldWCFService : IHelloWorld
    {
        public string SayHello()
        {
            return "Test Hello WCF World";
        }
    }
}
