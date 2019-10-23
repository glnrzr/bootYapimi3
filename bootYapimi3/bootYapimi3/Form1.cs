using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;


namespace bootYapimi3
{
    public partial class Form1 : Form
    {

        public String html;
        public Uri Url;

        public Form1()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {


            //VeriAl("https://www.hindawi.com/journals/aaa/2019/9072690/", "//*[@id='content']/div[2]/div[2]/div[4]/p[1]",  listBox1);
            //VeriAl("https://www.hindawi.com/journals/aaa/2019/5787329/", " //*[@id='content']/div[2]/div[2]/div[4]/p[1]", listBox1);
            //VeriAl("https://www.hindawi.com/journals/aaa/2019/5129013/", " //*[@id='content']/div[2]/div[2]/div[4]/p[1]", listBox1);


            VeriAl("https://www.hindawi.com/journals/aaa/2019/5129013/", " //*[@id='content']/div[2]/div[2]/div[4]", listBox1);

            //listBox1.Size= listBox1.PreferredSize;
            //listBox1.Items.AddRange(System.IO.File.ReadAllLines("c:\a.txt"));
            //System.IO.File.AppendAllText("c:\\a.txt", listBox1.Text);
        }
        public void VeriAl(String url, String XPath, ListBox CikanSonuc) {


            try
            {
                Url = new Uri(url);
            }
            catch (UriFormatException)
            {
                if (MessageBox.Show("Hatalı Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }
            }
            catch (ArgumentNullException) {

                if (MessageBox.Show("Hatalı Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                { 


                }
           }

            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            try
            {
                html = client.DownloadString(url);

            }
            catch (WebException) {

                if (MessageBox.Show("Hatalı Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                }
            }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            try
            {
                CikanSonuc.Items.Add(doc.DocumentNode.SelectSingleNode(XPath).InnerText);
            }
            catch (NullReferenceException)
            {

                if (MessageBox.Show("Hatalı XPath", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) ;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
