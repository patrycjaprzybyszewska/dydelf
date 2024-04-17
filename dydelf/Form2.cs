using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dydelf
{
    public class Dane
    {
        public string X;
        public string Y;
        public string D;
        public string K;
        public int Czas;

        public Dane(string X, string Y, string D, string K, int Czas)
        {
            this.X = X;
            this.Y = Y;
            this.D = D;
            this.K = K;
            this.Czas = Czas;

        }

    }
    public partial class Form2 : Form
    {
        Form1 form1;
        public string textX;
        public string textY;
        public string textD;
        public string textK;
        public int czas;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

      public void textBox5_TextChanged(object sender, EventArgs e)
        {
          czas = int.Parse(textBox5.Text);
            form1.dane.Czas = czas;
            //UpdateFormData();
        }
        
        public void textBox4_TextChanged(object sender, EventArgs e)
        {

            textX = textBox4.Text;
            form1.dane.X = textX;
            //UpdateFormData();

        }

        public void textBox3_TextChanged(object sender, EventArgs e)
        {

           textY = textBox3.Text;
            form1.dane.Y = textY;
            //UpdateFormData();
        }



        public void textBox2_TextChanged(object sender, EventArgs e)
        {

            textD = textBox2.Text;
            form1.dane.D = textD;
            //UpdateFormData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            textK = textBox1.Text;
            form1.dane.K = textK;
            //UpdateFormData();
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }
        /*
        private void UpdateFormData()
        {
            Form1.Dane dane = new Form1.Dane(textX, textY, textD, textK, czas);
            form1.SetDane(dane);
        }
        public void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            string textX = textBox2.Text;
            string textY = textBox3.Text;
            string textD = textBox1.Text;
            string textK = textBox4.Text;
            int czas;
            if (!int.TryParse(textBox5.Text, out czas))
            {
                MessageBox.Show("Podana wartość dla czasu nie jest liczbą całkowitą.");
               
                return;
            }

            // Przekazanie danych do Form1 przed zamknięciem Form2
            form1.SetDane(textX, textY, textD, textK, czas);
        }*/
    }


}

