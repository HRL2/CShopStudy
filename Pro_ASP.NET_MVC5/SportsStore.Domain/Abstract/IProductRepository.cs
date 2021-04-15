using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Abstract
{
    /*
     * 레파지토리 패턴 ; 
     * IProductRepository 인터페이스에 의존하는 클래스는 데이터가 어디서 오는지, 
     * 인터페이스를 구현한 클래스가 그 데이터를 어떻게 전달하는지 알지 않아도 Product 개체들을 얻을 수 있다.
     * 
     * --> 데이터 출처 (로컬 DB 인지, API 응답인지 등) 과 관계없이 동일 인터페이스로 데이터에 접속 할 수 있음
     * 
     * 장점 1) 데이터 로직과 비즈니스 로직이 분리됨 (데이터를 사용하는 곳에서는 비즈니스 로직에만 집중 가능함)
     * 장점 2) 일관된 인터페이스를 통해 데이터를 요청할 수 있음
     * 장점 3) 어플리케이션의 ORM이 바뀌더라도 인터페이스를 통해 적용되기 때문에 유연하다.
     */
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; set; }

        void SaveProduct(Product product);

        Product DeleteProduct(int productID);
    }
}
