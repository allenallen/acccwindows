using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcenalCarCareCenter.Model
{
    class DB
    {
        private static DB instance;

        private DB() { }

        public static DB GetInstance
        {
            get {
                if (instance == null)
                {
                    instance = new DB();
                    
                }
                return instance;
            }
        }

        List<Employee> employees;
        List<Customer> customers;
        List<JobOrder> jobOrders;

        internal List<Employee> Employees { get => employees; set => employees = value; }
        internal List<Customer> Customers { get => customers; set => customers = value; }
        internal List<JobOrder> JobOrders { get => jobOrders; set => jobOrders = value; }
    }
}
