using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Xml;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dydelf
{
    public partial class Form3 : Form
    { int liczK;
        int liczD;
        int time;
        public Form1 form1;
        public Dane dane;
        public Panel[,] tabela;

        System.Windows.Forms.Timer timer;
        DataGridView data;
        Panel losowanyPanel;
        Panel losowanyPanel2;

        private Random random = new Random();
        public Form3(Form1 form1, Dane dane)
        {
            InitializeComponent();
            this.form1 = form1;
            this.dane = dane;
            data = new DataGridView();
            liczK = int.Parse(dane.K);
            liczD = int.Parse(dane.D);
            tworztabele();
           
            SetTimer();

            // UpdateData(dane);
            //   textBox1.Text = dane.X;
            // textBox2.Text = dane.Y;
            //textBox3.Text = dane.D;
            //textBox4.Text = dane.K;
        }
        public void SetTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            timer.Start();

        }

        private void OnTimedEvent(object? sender, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                          e.SignalTime);
        }

        public void UpdateData(Dane dane)
        {
            //  label1.Text = dane.X;
            // label2.Text = dane.Y;
            //label3.Text = dane.D;
            //label4.Text = dane.K;
            //label5.Text = dane.Czas.ToString();
        }
        public void tworztabele()
        {
            int wartX = int.Parse(dane.X);
            int wartY = int.Parse(dane.Y);
            int startX = 50; // Początkowa pozycja X pierwszego panelu
            int startY = 50;
            int panelSize = 60;
            tabela = new Panel[wartX, wartY];
            time = form1.dane.Czas;

            for (int i = 0; i < wartX; i++)
            {
                for (int j = 0; j < wartY; j++)
                {
                    Panel panel = new Panel();
                    panel.BackColor = Color.White;
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Location = new Point(startX + i * (panelSize + 1), startY + j * (panelSize + 1));
                    panel.Size = new Size(panelSize, panelSize);
                    panel.Click += Panel_Click;
                    panel.Tag = new Point(i, j);
                    Controls.Add(panel);
                    tabela[i, j] = panel;

                }
            }
        }
        public void losujdydelf()
        {
            
            if (liczK > 0)
            {
                int wartX = int.Parse(dane.X);
                int wartY = int.Parse(dane.Y);
                int losowyX = random.Next(0, wartX); // Losujemy indeks X
                int losowyY = random.Next(0, wartY);
                int liczbDydelf = int.Parse(dane.D);

                losowanyPanel = tabela[losowyX, losowyY];
                losowanyPanel.Tag = new Point(losowyX, losowyY);
                
            }
            else
            {

                MessageBox.Show($"WYGRAŁEŚ");
            }
        }
        public void losujkrok()
        {
            if (liczD > 0)
            {
                int wartX = int.Parse(dane.X);
                int wartY = int.Parse(dane.Y);
                int losowyX1 = random.Next(0, wartX); // Losujemy indeks X
                int losowyY1 = random.Next(0, wartY);
                int liczbKrok = int.Parse(dane.K);

                losowanyPanel2 = tabela[losowyX1, losowyY1];
                losowanyPanel2.Tag = new Point(losowyX1, losowyY1);
                liczD--;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            time--;
            label1.Text = time.ToString();
            if (time == 0)
            {
                timer.Stop();
                MessageBox.Show($"CZAS MINAŁ!!!!!!!!1111111!!");
            }

        }
        private void Panel_Click(object sender, EventArgs e)
        {
            losujdydelf();
            losujkrok();
            Panel panel = sender as Panel;
            if (panel != null)
            {
                Point pozycjaPanelu = (Point)panel.Tag; // Pobieramy pozycję klikniętego panelu
                Point pozycjaWylosowanegoPanelu = (Point)losowanyPanel.Tag; // Pobieramy pozycję wylosowanego panelu
                Point pozycjaWylosowanegoPanelu2 = (Point)losowanyPanel2.Tag;
                if (pozycjaPanelu == pozycjaWylosowanegoPanelu)
                {
                    panel.BackColor = Color.Red; // Jeśli kliknięty panel jest tym samym co wylosowany, zmieniamy jego kolor na czerwony
                    MessageBox.Show($"TRAFIŁEŚ NA KROKODYLA!!!!!!!!!!!!!");
                    this.Close();
                }
                else if (pozycjaPanelu == pozycjaWylosowanegoPanelu2)
                {
                    liczK--;
                    panel.BackColor = Color.Green; // Jeśli kliknięty panel jest tym samym co wylosowany, zmieniamy jego kolor na czerwony
                }
                else
                {
                    panel.BackColor = Color.Blue;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //abel1 = form1
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"X: {dane.X}, Y: {dane.Y}, D: {dane.D}, K: {dane.K}, Czas: {dane.Czas}");
            //int x = int.Parse(dane.X);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
