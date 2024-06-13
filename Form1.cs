using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ONTI_2022
{
    public partial class Form1 : Form
    {
        public static string path="";
        public static Image[] img= new Image[10];
        public static string[] parole = new string[10];
        public static int ctImg = 0;
        public Form1()
        {
            InitializeComponent();
        }
        void functie()
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            path = System.IO.Directory.GetCurrentDirectory();
            path += "\\OTI_2022_C#_resurse\\";
           // label1.Text = path;
            for(int i=1; i<=5; i++)
            {
                img[i] = Image.FromFile(path + "\\Background\\Back" + i + ".jpg");
            }
            pictureBox1.Image = new Bitmap(img[1], pictureBox1.Width, pictureBox1.Height);
            pictureBox2.Image = new Bitmap(img[2], pictureBox2.Width, pictureBox2.Height);
            pictureBox3.Image = new Bitmap(img[3], pictureBox3.Width, pictureBox3.Height);
            pictureBox4.Image = new Bitmap(img[4], pictureBox4.Width, pictureBox4.Height);
            pictureBox5.Image = new Bitmap(img[5], pictureBox5.Width, pictureBox5.Height);

            StreamReader sr = new StreamReader(path + "useri.txt");
            string line = "";
            int ct = 0;
            while ((line = sr.ReadLine()) != null)
            {
                comboBox1.Items.Add(line.Split(' ')[0]);
                parole[ct++] = line.Split(' ')[1];
            }

            pictureBox2.Click +=new EventHandler(pictureBox1_Click);
            pictureBox3.Click += new EventHandler(pictureBox1_Click);
            pictureBox4.Click += new EventHandler(pictureBox1_Click);
            pictureBox5.Click += new EventHandler(pictureBox1_Click);


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (ctImg == 0)
            {
                ctImg = 1;
            }
            if (textBox1.Text == parole[comboBox1.SelectedIndex])
            {
                Form2 frm2 = new Form2();
                frm2.Text = "Interferente ECO - " + comboBox1.Text;
                frm2.Show();
                
            }
            else
            {
                MessageBox.Show("Parola incorecta!");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ctImg = 2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ctImg = 3;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ctImg = 4;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ctImg = 5;
        }
    }
}
