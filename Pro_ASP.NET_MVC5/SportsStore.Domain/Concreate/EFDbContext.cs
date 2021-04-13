using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concreate
{
    /*
     * 모델과 데이터베이스를 연결하는 컨텍스트 클래스
     * 속성의 이름 : 테이블
     * DbSet 의 형식 매개 변수 : 모델
     */
    public class EFDbContext : DbContext
    {
        // Products 테이블에서 행을 표현하는데 Entity Framework 가 Product 라는 모델 형식을 사용해야 함을 의미
        public DbSet<Product> Products { get; set; }
    }
}
