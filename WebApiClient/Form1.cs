using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebApiClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await RunAsync();
        }

        List<Check> list = new List<Check>();

        async Task RunAsync(int id = -1)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://hatassska.pp.ua/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;
                // New code:
                if (id!= -1)
                    response = await client.GetAsync($"api/ChecksApi/{id}");
                else
                    response = await client.GetAsync($"api/ChecksApi");

                if (response.IsSuccessStatusCode)
                {
                    if (id != -1)
                    {
                        Check product = await response.Content.ReadAsAsync<Check>();
                        list.Add(product);
                    }
                    else
                    {
                        Check[] products = await response.Content.ReadAsAsync<Check[]>();
                        list.AddRange(products);
                    }
                    listBox1.DataSource = list;

                }

                
            }
        }

        class Check
        {
            public string title { get; set; }
            public string date { get; set; }
            public string store { get; set; }
            public string neighbour { get; set; }
            public string photo { get; set; }

            public override string ToString()
            {
                return DateTime.Parse(date).ToShortDateString() + store;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            int id = (int)numericUpDown1.Value;
            await RunAsync(id);
        }
    }
}
