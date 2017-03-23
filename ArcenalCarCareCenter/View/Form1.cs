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
        private static readonly HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();

            
            listBox.DataSource = new List<String>();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunAsync().Wait();
        }

        private async Task<string> GetEmployeeAsync(string url)
        {
         
            var response = await client.GetAsync("query_employee/");
            string json = null;
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
            }
            return json;
        }

        async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://acccserver.herokuapp.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            string response = await GetEmployeeAsync("");
            MessageBox.Show(response);
        }
    }
}
