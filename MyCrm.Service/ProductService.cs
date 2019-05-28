using MyCrm.Data;
using MyCrm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCrm.Service
{
    public interface IProductService
    {
        void Insert(Product entity);
        void Update(Product entity);
        void Delete(Guid id);
        Product Find(Guid id);
        IEnumerable<Product> GetAll();
    }
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Product> productRepository;

        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> productRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productRepository = productRepository;
        }

        public void Delete(Guid id)
        {
            var entity = productRepository.Find(id);
            if (entity != null)
            {
                productRepository.Delete(entity);
                unitOfWork.SaveChanges();
            }
        }

        public Product Find(Guid id)
        {
            return productRepository.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public void Insert(Product entity)
        {
            productRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public void Update(Product entity)
        {
            productRepository.Update(entity);
            unitOfWork.SaveChanges();
        }
    }
}
