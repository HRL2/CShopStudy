using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace HelloWorldHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // host 생성, address 지정
            ServiceHost host = new ServiceHost(typeof(HelloWorldWCFService), new Uri("http://localhost/wcf/helloworldService"));

            // 종점 설정
            host.AddServiceEndpoint(typeof(IHelloWorld), new BasicHttpBinding(), "");

            // 호스트 open
            host.Open();

            // Console 에 키 입력되면 서비스 종료
            System.Console.WriteLine("press any key to stop service");
            System.Console.ReadKey(true);
            host.Close();
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
            return "Hello WCF World";
        }
    }
}
