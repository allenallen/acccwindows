using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcenalCarCareCenter.Model
{
    class Customer
    {
        public static string CUSTOMER_FIRST_NAME = "firstname";
        public static string CUSTOMER_LAST_NAME = "lastname";
        public static string CUSTOMER_ADDRESS = "address";
        public static string CUSTOMER_CAR_MAKE = "carmake";
        public static string CUSTOMER_CONTACT = "contact";
        public static string CUSTOMER_PLATE = "plate";
        public static string CUSTOMER_ID = "customerid";

        private string firstName;
        private string lastName;
        private string address;
        private string carMake;
        private string contact;
        private string plate;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string CarMake { get => carMake; set => carMake = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Plate { get => plate; set => plate = value; }

        public Customer(string firstName, string lastName, string address,
                            string carMake, string contact, string plate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.CarMake = carMake;
            this.Contact = contact;
            this.Plate = plate;
        }
    }
}
