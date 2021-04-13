using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concreate
{
    public class EFProductRepository : IProductRepository
    {
        // EFDbContext 의 인스턴스를 사용해 데이터베이스로부터 데이터 조회
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products 
        {
            get { return context.Products; }
            set => throw new NotImplementedException();
        }
    }
}
