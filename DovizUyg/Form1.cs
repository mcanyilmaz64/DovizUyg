using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DovizUyg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnDolarAl_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblDolarAl.Text;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugün = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugün);

            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            string dolarsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            string euroalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            string eursatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            LblDolarAl.Text =  dolaralis;
            LblDolarSat.Text = dolarsatis;
            LblEuroAl.Text = euroalis;
            LblEuroSat.Text = eursatis;
        }

        private void LblDolarAl_Click(object sender, EventArgs e)
        {
             
        }

        private void BtnDolarSat_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblDolarSat.Text;
        }

        private void BtnEuroAl_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblEuroAl.Text;
        }

        private void BtnEuroSat_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblEuroSat.Text;
        }

        private void BtnPro1_Click(object sender, EventArgs e)
        {
            double kur, tutar,miktar;
            
            kur = Convert.ToDouble(TxtKur.Text);
            miktar = Convert.ToDouble(TxtMiktar.Text);

            tutar = miktar * kur;
            TxtTutar.Text = tutar.ToString();
        }

        private void TxtKur_TextChanged(object sender, EventArgs e)
        {
            TxtKur.Text = TxtKur.Text.Replace(".",",");
        }

        private void BtnPro2_Click(object sender, EventArgs e)
        {
            double kur,tutar,kalan;
            int miktar;
            kur = Convert.ToDouble(TxtKur.Text);
            tutar =Convert.ToDouble(TxtTutar.Text);

            miktar = Convert.ToInt32(tutar / kur);
            TxtMiktar.Text = miktar.ToString();

            kalan = tutar%kur;           
            TxtKalan.Text = kalan.ToString();
            
        }
    }
}
