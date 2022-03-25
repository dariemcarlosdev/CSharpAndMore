using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutomersDAO
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new CustomerService();
            var result = customer.GetCustomerName(3);
            Console.WriteLine(result);
        }
    }

    //Injector Class
    public class CustomerService
    {
        readonly CustomerBL _customerBL;

        public CustomerService()
        {
            _customerBL = new CustomerBL(new CustomerDataAccess());
        }

        public string GetCustomerName(int id) {

            return _customerBL.ProcessingCustomer(3);
        }
    }

   //Client Class - Dependant Class
    public class CustomerBL
    {
        readonly ICustomerDataAccess _customerDA;

        public CustomerBL(ICustomerDataAccess customerDA)
        {
            this._customerDA = customerDA;
        }


        public string ProcessingCustomer(int id) {

            return _customerDA.GetCustomerName(id);
        }
    }


    public interface ICustomerDataAccess 
    {
        string GetCustomerName(int id);
    }

    //Service Class
    public class CustomerDataAccess : ICustomerDataAccess
    {
        public string GetCustomerName(int id)
        {
           return "Dummy Customer Name";
        }
    }
}
