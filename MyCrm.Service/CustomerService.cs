using MyCrm.Data;
using MyCrm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCrm.Service
{
    public interface ICustomerService
    {
        void Insert(Customer entity);
        void Update(Customer entity);
        void Delete(Guid id);
        Customer Find(Guid id);
        IEnumerable<Customer> GetAll();
    }

    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Customer> customerRepository;
        public CustomerService(IUnitOfWork unitOfWork, IRepository<Customer> customerRepository)
        {
            this.unitOfWork = unitOfWork;
            this.customerRepository = customerRepository;
        }
        public void Delete(Guid id)
        {
            var entity = customerRepository.Find(id);
            if (entity!=null)
            {
                customerRepository.Delete(entity);
                unitOfWork.SaveChanges();
            }
        }

        public Customer Find(Guid id)
        {
            return customerRepository.Find(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return customerRepository.GetAll();
        }

        public void Insert(Customer entity)
        {
            customerRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public void Update(Customer entity)
        {
            customerRepository.Update(entity);
            unitOfWork.SaveChanges();
        }
    }
}
