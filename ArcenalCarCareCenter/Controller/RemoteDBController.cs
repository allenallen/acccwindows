using ArcenalCarCareCenter.Model;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ArcenalCarCareCenter.Controller
{
    class RemoteDBController
    {
        private static readonly RestClient client = new RestClient("https://acccserver.herokuapp.com");

        public static void SaveJobOrder(string joNumber, string customerid, long date, List<string> employees,
                                        List<string> jobDescription, List<double> labor, List<string> parts,
                                        List<double> amount, bool isPaid, long paymentDate, bool isReleased)
        {
            JObject jo = new JObject();
            jo[JobOrder.NUMBER] = joNumber;
            jo[JobOrder.CUSTOMER_ID] = customerid;
            jo[JobOrder.DATE] = date;
            jo[JobOrder.EMPLOYEES] = JToken.FromObject(employees);
            jo[JobOrder.JOB_DESCRIPTION] = JToken.FromObject(jobDescription);
            jo[JobOrder.LABOR] = JToken.FromObject(labor);
            jo[JobOrder.PARTS] = JToken.FromObject(parts);
            jo[JobOrder.AMOUNT] = JToken.FromObject(amount);
            jo[JobOrder.IS_PAID] = isPaid;
            jo[JobOrder.PAYMENT_DATE] = paymentDate;
            jo[JobOrder.IS_RELEASED] = isReleased;

            var req = new RestRequest("new_job_order", Method.POST);
            req.AddParameter("application/json; charset=utf-8", jo, ParameterType.RequestBody);
            req.RequestFormat = DataFormat.Json;

            try
            {
                client.ExecuteAsync(req, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Logger.Write(response.Content);
                    }
                    else
                    {
                        Logger.Write(response.Content);
                    }
                });
            }
            catch (Exception error)
            {
                Logger.Write(error.Message);
            }
        }
    }
}
