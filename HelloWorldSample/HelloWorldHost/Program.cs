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
            // 추가) Base address [net.tcp]용 주소 --> http 통신 뿐만 아니라, net.tcp 통신도 가능한 서비스
            ServiceHost host = new ServiceHost(typeof(HelloWorldWCFService)
                , new Uri("http://localhost/wcf/helloworldService")
                , new Uri("net.tcp://localhost/wcf/helloworldservice"));

            // 종점 설정
            // 1) http 프로토콜 사용
            host.AddServiceEndpoint(typeof(IHelloWorld), new BasicHttpBinding(), "");
            // 2) net.tcp 프로토콜 사용
            host.AddServiceEndpoint(typeof(IHelloWorld), new NetTcpBinding(), "");

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
