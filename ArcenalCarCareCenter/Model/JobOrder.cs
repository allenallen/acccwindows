using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcenalCarCareCenter.Model
{
    class JobOrder
    {
        public static string NUMBER = "jonumber";
        public static string CUSTOMER_ID = "customerid";
        public static string DATE = "date";
        public static string EMPLOYEES = "employees";
        public static string JOB_DESCRIPTION = "jobdescription";
        public static string LABOR = "labor";
        public static string TOTAL_AMOUNT = "totalamount";
        public static string PARTS = "partsids";
        public static string IS_PAID = "ispaid";
        public static string PAYMENT_DATE = "paymentdate";
        public static string IS_RELEASED = "isreleased";
        public static string AMOUNT = "amount";

        string jobOrderNumber;
        string customerId;
        long date;
        List<string> employees;
        List<string> jobDescription;
        List<double> labor;
        List<string> parts;
        List<double> amount;
        double totalAmount;
        bool isPaid;
        bool isReleased;
        long paymentDate;

        public double TotalAmount { get => totalAmount; set => totalAmount = value; }
        public List<double> Labor { get => labor; set => labor = value; }
        public List<string> JobDescription { get => jobDescription; set => jobDescription = value; }
        public long Date { get => date; set => date = value; }
        public string CustomerId { get => customerId; set => customerId = value; }
        public string JobOrderNumber { get => jobOrderNumber; set => jobOrderNumber = value; }
        internal List<string> Employees { get => employees; set => employees = value; }
        public long PaymentDate { get => paymentDate; set => paymentDate = value; }
        public bool IsReleased { get => isReleased; set => isReleased = value; }
        public bool IsPaid { get => isPaid; set => isPaid = value; }
        public List<string> Parts { get => parts; set => parts = value; }
        public List<double> Amount { get => amount; set => amount = value; }

        public JobOrder(string jobOrderNumber, string customerId, long date, List<string> employees,
                            List<string> jobDescription, List<double> labor, double totalAmount, bool isPaid, 
                            bool isReleased, long paymentDate, List<string> parts, List<double> amount)
        {
            this.JobOrderNumber = jobOrderNumber;
            this.CustomerId = customerId;
            this.Date = date;
            this.Employees = employees;
            this.JobDescription = jobDescription;
            this.Labor = labor;
            this.TotalAmount = totalAmount;
            this.IsPaid = isPaid;
            this.IsReleased = isReleased;
            this.PaymentDate = paymentDate;
            this.Parts = parts;
            this.Amount = amount;
        }
    }
}
