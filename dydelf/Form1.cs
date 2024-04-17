using System.Windows.Forms;
using static dydelf.Form2;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dydelf
{
    public partial class Form1 : Form
    {
        Form2 form2;
        Form3 form3;
        public Dane dane = new Dane("3", "3", "3", "3", 5);

        public Form1()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        /*
        public void SetDane(string textX, string textY, string textD, string textK, int czas)
        {
            // Ustawienie danych w Form1
            
            // Przekazanie danych do Form3
        //    OpenForm3(dane);

            form3 = new Form3(this, dane);
           

            form3.Show();
        }
        */
        public void button2_Click(object sender, EventArgs e)
        {
            form2 = new Form2(this);
            //   dane = new Dane(form2.textX, form2.textY, form2.textD, form2.textK, form2.czas);
            form2.Show();

        }
        public void SetDane(Dane dane)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            this.dane = dane;
            this.form3 = new Form3(this, dane);
            form3.Show();

           // form3.UpdateData(dane);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            form3.Close();
        }
    }

}