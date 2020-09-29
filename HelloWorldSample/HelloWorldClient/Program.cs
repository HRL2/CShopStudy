using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

// WCF 인터페이스를 공유하기 위해 참조 추가
using HelloWorldHost;
// Description : 서비스의 종점을 WCF에 알리기 위해 필요한 클래스
using System.ServiceModel.Description;

namespace HelloWorldClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost/wcf/helloworldservice");

            // 종점 생성
            ServiceEndpoint endpoint = new ServiceEndpoint(ContractDescription.GetContract(typeof(IHelloWorld)), new BasicHttpBinding(), new EndpointAddress(uri));

            // 채널 생성
            ChannelFactory<IHelloWorld> factory = new ChannelFactory<IHelloWorld>(endpoint);
            IHelloWorld proxy = factory.CreateChannel();

            // 서비스의 메소드 호출
            string result = proxy.SayHello();
            (proxy as IDisposable).Dispose();

            // 결과 출력
            System.Console.WriteLine(result);
            System.Console.ReadKey(true);
        }
    }
}
