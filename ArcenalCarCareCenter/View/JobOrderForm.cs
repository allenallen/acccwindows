using ArcenalCarCareCenter.Controller;
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
        public Form1()
        {
            InitializeComponent();
            DBController.PopulateEmployees();
            DBController.PopulateJobOrders();
            DB.GetInstance.JobOrders.Sort((x,y) => 
                        (Convert.ToInt32(x.JobOrderNumber) < Convert.ToInt32(y.JobOrderNumber)) ? 1 : -1);

            foreach(JobOrder j in DB.GetInstance.JobOrders)
            {
                Console.WriteLine("jo: " + j.JobOrderNumber);
            }

            if(DB.GetInstance.JobOrders.Count != 0)
            {
                txtJONumber.Text = (Convert.ToInt16(DB.GetInstance.JobOrders.First().JobOrderNumber) + 1).ToString();
            } else
            {
                txtJONumber.Text = "1";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string joNumber = txtJONumber.Text;
            long date = datePicker.Value.Ticks;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string address = txtAddress.Text;
            string contact = txtContact.Text;
            string plate = txtPlate.Text;
            string make = txtMake.Text;
            bool isPaid = checkBoxPaid.Checked;
            bool isReleased = checkBoxReleased.Checked;
            long paymentDate = datePayment.Value.Ticks;

            string[] jobDescription = txtJobDescription.Lines;
            string[] labor = txtLabor.Lines;
            string[] parts = txtParts.Lines;
            string[] amount = txtAmount.Lines;
            string[] employees = txtEmployees.Lines;

            List<double> laborList = new List<double>();
            List<double> amountList = new List<double>();

            foreach(string i in labor)
            {
                laborList.Add(Convert.ToDouble(i));
            }

            foreach(string i in amount)
            {
                amountList.Add(Convert.ToDouble(i));
            }

            RemoteDBController.SaveJobOrder(joNumber, "2424", date, employees.ToList(), jobDescription.ToList(),
                                            laborList, parts.ToList(), amountList, isPaid, paymentDate, isReleased);
        }
    }
}
