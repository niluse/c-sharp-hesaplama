using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "MİN: MAKS: ORTALAMA VE STANDART SAPMA HESAPLAMA";
            label2.Text = "Hesaplamak istediğiniz 10 sayıyı text box a girip butana tıklayın.";
            label3.Text = "";

            button1.AutoSize = true;
            button1.Text = "sayı ekle";
            button2.Text = "HESAPLA";

            this.BackColor = Color.AliceBlue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[] dizi = new double[10];
            double[] ortFark = new double[10]; //dizideki her sayısının ortalamaya göre farkları
            double enBuy,
                enKuc,
                ortalama,
                toplam = 0.0,
                kareTop = 0.0,   //dizideki her sayının ortalamayla farkının karelerının toplamı
                standartSapma;

            for (int i=0; i<10;i++)
                dizi[i] = Convert.ToInt32(listBox1.Items[i]);
            
            enBuy = dizi[0];
            enKuc = dizi[0];

            for (int i = 0; i < dizi.Length; i++) //en küçük, en büyük ve dizideki elemanların toplamını bulma
            {
                toplam += dizi[i];

                if (dizi[i] > enBuy)
                    enBuy = dizi[i];

                if (dizi[i] < enKuc)
                    enKuc = dizi[i];
            }
            ortalama = toplam / dizi.Length;

            for (int i = 0; i < dizi.Length; i++)
            {
                ortFark[i] = (dizi[i] - ortalama) * (dizi[i] - ortalama);
                kareTop += ortFark[i];
            }

            kareTop /= (dizi.Length - 1);
            standartSapma = Math.Sqrt(kareTop);

            label3.Text = "en büyük eleman:" + enBuy + "\nen küçük eleman:" + enKuc + "\nortalma:" + ortalama + "\nstandart sapma:" + standartSapma;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                listBox1.Items.Add(Convert.ToInt32(textBox1.Text));
            else
                MessageBox.Show("lütfen geçerli bir değer giriniz!");
            textBox1.Text = "";
        }
    }
}
