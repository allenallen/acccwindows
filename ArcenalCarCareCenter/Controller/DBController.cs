using ArcenalCarCareCenter.Model;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcenalCarCareCenter.Controller
{
    class DBController
    {
        private static readonly RestClient client = new RestClient("https://acccserver.herokuapp.com");

        public static void PopulateJobOrders()
        {
            Logger.Write("requesting job orders");
            var req = new RestRequest("query_job_order", Method.GET);
            Logger.Write(req.ToString());
            IRestResponse res = client.Execute(req);
            var content = res.Content;
            JObject jRes = JObject.Parse(content);

            List<JobOrder> jo = new List<JobOrder>();

            foreach(var x in jRes)
            {
                string joNumber = x.Key;
                string customerId = x.Value[JobOrder.CUSTOMER_ID].ToString();
                long date = Convert.ToInt64(x.Value[JobOrder.DATE].ToString());
                double totalAmount = (double)x.Value[JobOrder.TOTAL_AMOUNT];
                JObject jobDescription = JObject.Parse(x.Value[JobOrder.JOB_DESCRIPTION].ToString());
                JObject employees = JObject.Parse(x.Value[JobOrder.EMPLOYEES].ToString());
                JObject parts = JObject.Parse(x.Value[JobOrder.PARTS].ToString());
                JObject labor = JObject.Parse(x.Value[JobOrder.LABOR].ToString());
                JObject amount = JObject.Parse(x.Value[JobOrder.AMOUNT].ToString());
                bool isPaid = (bool)x.Value[JobOrder.IS_PAID];
                bool isReleased = (bool)x.Value[JobOrder.IS_RELEASED];
                long paymentDate = Convert.ToInt64(x.Value[JobOrder.PAYMENT_DATE].ToString());

                List<string> jobDescriptionList = new List<string>();
                foreach(var jDesc in jobDescription)
                {
                    jobDescriptionList.Add(jDesc.Value.ToString());
                }

                List<double> laborList = new List<double>();
                foreach (var l in labor)
                {
                    laborList.Add(Convert.ToDouble(l.Value.ToString()));
                }

                List<string> partsList = new List<string>();
                foreach(var p in parts)
                {
                    partsList.Add(p.Value.ToString());
                }

                List<double> amountList = new List<double>();
                foreach(var a in amount)
                {
                    amountList.Add(Convert.ToDouble(a.Value.ToString()));
                }

                List<string> employeeList = new List<string>();
                foreach(var employee in employees)
                {
                    employeeList.Add(employee.Value.ToString());
                }

                Logger.Write("JO Number: " + joNumber);

                JobOrder j = new JobOrder(joNumber, customerId, date, employeeList, jobDescriptionList, laborList, totalAmount,
                                            isPaid,isReleased,paymentDate, partsList, amountList);
                jo.Add(j);
            }

            DB.GetInstance.JobOrders = jo;
        }

        public static void PopulateEmployees()
        {
            Logger.Write("requesting employees");
            var req = new RestRequest("query_employee", Method.GET);
            Logger.Write(req.ToString());
            IRestResponse res = client.Execute(req);
            var content = res.Content;
            JObject jRes = JObject.Parse(content);

            List<Employee> employees = new List<Employee>();

            foreach (var x in jRes)
            {
                string id = x.Key;
                string firstName = x.Value[Employee.EMPLOYEE_FIRST_NAME].ToString();
                string lastName = x.Value[Employee.EMPLOYEE_LAST_NAME].ToString();
                string address = x.Value[Employee.EMPLOYEE_ADDRESS].ToString();
                string contact = x.Value[Employee.EMPLOYEE_CONTACT].ToString();

                Employee emp = new Employee(id, firstName, lastName, address, contact);
                employees.Add(emp);
                Logger.Write(emp.FirstName + " " + emp.LastName);
            }

            DB db = DB.GetInstance;
            db.Employees = employees;
        }
    }
}
