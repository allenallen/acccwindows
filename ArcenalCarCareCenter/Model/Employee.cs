using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcenalCarCareCenter.Model
{
    class Employee
    {
        public static string EMPLOYEE_FIRST_NAME = "firstname";
        public static string EMPLOYEE_LAST_NAME = "lastname";
        public static string EMPLOYEE_ADDRESS = "address";
        public static string EMPLOYEE_CONTACT = "contact";

        private string firstName;
        private string lastName;
        private string address;
        private string contact;
        private string id;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Id { get => id; set => id = value; }

        public Employee(string id, string firstName, string lastName, string address,
                            string contact)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.Contact = contact;
            this.Id = id;
        }
    }
}
