using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldProxyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWorldClient client = new HelloWorldClient("BasicHttpBinding_IHelloWorld");
            string result = client.SayHello();
            System.Console.WriteLine(result);
            System.Console.ReadLine();
        }
    }
}
