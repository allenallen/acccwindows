using ArcenalCarCareCenter.Model;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArcenalCarCareCenter
{
    public partial class Form1 : Form
    {
        private static readonly RestClient client = new RestClient("https://acccserver.herokuapp.com");
        public Form1()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var req = new RestRequest("query_employee", Method.GET);
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
            }

            MessageBox.Show(employees.First().Id);
        }
    }
}
