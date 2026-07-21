using System;

namespace DependencyInjectionExample
{
    // Repository Interface
    interface ICustomerRepository
    {
        string FindCustomerById(int id);
    }

    // Repository Implementation
    class CustomerRepositoryImpl : ICustomerRepository
    {
        public string FindCustomerById(int id)
        {
            return "Customer Found: Barnabas (ID: " + id + ")";
        }
    }

    // Service Class
    class CustomerService
    {
        private readonly ICustomerRepository repository;

        // Constructor Injection
        public CustomerService(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public void GetCustomer(int id)
        {
            string customer = repository.FindCustomerById(id);
            Console.WriteLine(customer);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository repository =
                new CustomerRepositoryImpl();

            CustomerService service =
                new CustomerService(repository);

            service.GetCustomer(101);
        }
    }
}