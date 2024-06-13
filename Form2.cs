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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int ctSticleScor = 0; int ctHartieScor = 0; int ctPlasticScor = 0;
        Bitmap patratTraseu; Bitmap patratOrigine;
        Bitmap triunghi;
        Bitmap imgPb1;
        Bitmap imgPb1Nemodificat; int xOrig = 0, yOrig = 0;
        Bitmap imgPb1Grid;
        Bitmap[] Meduze = new Bitmap[10];
        Bitmap[] reciclabile = new Bitmap[10];
        Point[] coordTrig = new Point[100]; int ctTrig=0;
        int[] tipTr = new int[100]; int tipTrActual = 1;
        Bitmap imgOrig, imgOrigGrid;
        Point[] coordMeduze = new Point[10]; int ctMeduze = 0;
        Point[] coordSticla = new Point[10]; int ctSticla = 0;
        Point[] coordHartie = new Point[10]; int ctHartie = 0;
        Point[] coordPlastic = new Point[10]; int ctPlastic = 0;
        int xRobot=1, yRobot=1;
        Bitmap robot;
        Bitmap imgRobot;
        Bitmap imgRobotGrid;

        int dirRobot = 0;



        bool ok = false;
        

        private void Form2_Load(object sender, EventArgs e)
        {
            patratOrigine = new Bitmap(30, 30);
            patratTraseu = new Bitmap(30, 30);

            Graphics gPatrat = Graphics.FromImage(patratOrigine);
            Graphics gPatrat1 = Graphics.FromImage(patratTraseu);
            gPatrat.Clear(Color.Orange);
            gPatrat1.Clear(Color.MediumPurple);
            // label1.Text = Form1.ctImg.ToString();
            button8.Hide();
            button9.Hide();
            button10.Hide();
            button11.Hide();
            Random rnd = new Random();
            xRobot = rnd.Next(1, 19);
            yRobot = rnd.Next(1, 9);
            label2.Text = "Sticle: " + ctSticleScor.ToString();
            label3.Text = "Hartie: " + ctHartieScor.ToString();
            label4.Text = "Plastic: " + ctPlasticScor.ToString();
            robot = new Bitmap(Form1.path + "\\Robot\\Robot.png");
            robot = new Bitmap(robot, 30, 30);
            Image imgPanel = Image.FromFile(Form1.path + "\\Wood\\Wood1.jpg");
            Image imgForm = Image.FromFile(Form1.path + "\\Wood\\Wood2.jpeg");
            triunghi = new Bitmap(30, 30);
            Graphics g = Graphics.FromImage(triunghi);
            g.Clear(Color.Transparent);
            Point[] tr = new Point[3];
            tr[0] = new Point(0, 0); tr[1] = new Point(0, 30); tr[2] = new Point(30, 0);
            g.FillPolygon(Brushes.White, tr);
            


            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = new Bitmap(triunghi, pictureBox2.Width, pictureBox2.Height);
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            checkBox1.BackColor = Color.Transparent;
            // panel1.BackgroundImage = new Bitmap(imgPanel, panel1.Width, panel1.Height);
            panel1.BackColor = Color.Transparent;
            pictureBox1.Image = new Bitmap(Form1.img[Form1.ctImg], pictureBox1.Width, pictureBox1.Height);
            this.BackgroundImage = new Bitmap(imgForm, this.Width, this.Height);
            imgPb1 = new Bitmap(pictureBox1.Image);
            imgPb1Nemodificat = new Bitmap(imgPb1);
            imgPb1Grid = new Bitmap(imgPb1);
            imgRobot = new Bitmap(imgPb1);
            
             Graphics g1 = Graphics.FromImage(imgPb1Grid);
            for (int i = 1; i <= 20; i++)
                g1.DrawLine(Pens.White, i * 30, 0, i * 30, pictureBox1.Height);
            for (int i = 1; i <= 20; i++)
                g1.DrawLine(Pens.White, 0, i * 30, pictureBox1.Width, i * 30);
            imgRobotGrid = new Bitmap(imgPb1Grid);

            for(int i=1; i<=4; i++)
            {
                Meduze[i] = new Bitmap(Form1.path + "\\Meduze\\Meduza" + i + ".png");
            }
            imgOrig = new Bitmap(imgPb1);
            imgOrigGrid = new Bitmap(imgPb1Grid);
            reciclabile[1] = new Bitmap(Form1.path + "\\MaterialeReciclabile\\Hartie.png");
            reciclabile[2] = new Bitmap(Form1.path + "\\MaterialeReciclabile\\Plastic.png");
            reciclabile[3] = new Bitmap(Form1.path + "\\MaterialeReciclabile\\Sticla.png");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            triunghi.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox2.Image = new Bitmap(triunghi,pictureBox2.Width,pictureBox2.Height);
            tipTrActual++;
            if (tipTrActual == 5)
                tipTrActual = 1;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ok == true)
                pictureBox1.Image = imgRobot;
            else
                pictureBox1.Image = imgRobotGrid;
            ok = !ok;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            StreamReader sr = new StreamReader(openFileDialog1.FileName);
            string line = "";
            Graphics g = Graphics.FromImage(imgPb1);
            Graphics g1 = Graphics.FromImage(imgPb1Grid);
            while ((line = sr.ReadLine()) != null)
            {
                string tipInamic = line.Split(' ')[0];
                char[] chr = new char[5];
                int index = 0 ;
                tipInamic.CopyTo(tipInamic.Length - 1, chr, 0, 1);
                label1.Text = chr[0].ToString();
                if(chr[0]>=48 & chr[0]<=57)
                index = Convert.ToInt32(chr[0]); index -= 48;
                int x = Convert.ToInt32(line.Split(' ')[1]);
                int y = Convert.ToInt32(line.Split(' ')[2]);
               tipInamic= tipInamic.Remove(tipInamic.Length - 1);
                label2.Text = tipInamic;
                if (tipInamic == "Meduza")
                {
                    if (index >= 0 & index <= 4)
                    {
                        g.DrawImage(new Bitmap(Meduze[index], 30, 30), x * 30, y * 30);
                        g1.DrawImage(new Bitmap(Meduze[index], 30, 30), x * 30, y * 30);
                    }
                    ctMeduze++;
                    coordMeduze[ctMeduze].X = x; coordMeduze[ctMeduze].Y = y;
                   
                }
                if(tipInamic=="Harti")
                {
                    g.DrawImage(new Bitmap(reciclabile[1], 30, 30), x * 30, y * 30);
                    g1.DrawImage(new Bitmap(reciclabile[1], 30, 30), x * 30, y * 30);
                    ctHartie++;
                    coordHartie[ctHartie].X = x; coordHartie[ctHartie].Y = y;

                }
                if (tipInamic == "Plasti")
                {
                    g.DrawImage(new Bitmap(reciclabile[2], 30, 30), x * 30, y * 30);
                    g1.DrawImage(new Bitmap(reciclabile[2], 30, 30), x * 30, y * 30);
                    ctPlastic++;
                    coordPlastic[ctPlastic].X = x; coordPlastic[ctPlastic].Y = y;
                }
                if (tipInamic == "Sticl")
                {
                    g.DrawImage(new Bitmap(reciclabile[3], 30, 30), x * 30, y * 30);
                    g1.DrawImage(new Bitmap(reciclabile[3], 30, 30), x * 30, y * 30);
                    ctSticla++;
                    coordSticla[ctSticla].X = x; coordSticla[ctSticla].Y = y;
                }
                if(tipInamic=="Robo")
                {
                    xRobot = x; yRobot = y;
                    xOrig = x; yOrig = y;
                }


                


            }
            imgRobot = new Bitmap(imgPb1);
            imgRobotGrid = new Bitmap(imgPb1Grid);
            Graphics g2 = Graphics.FromImage(imgRobot);
            Graphics g3 = Graphics.FromImage(imgRobotGrid);
            g2.DrawImage(robot, xRobot*30, yRobot*30);
            g3.DrawImage(robot, xRobot*30, yRobot*30);
            if (ok == false)
                pictureBox1.Image = imgRobot;
            else
                pictureBox1.Image = imgRobotGrid;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dirRobot == 1)
                xRobot-=1;
            if (dirRobot == 2)
                xRobot+=1;
            if (dirRobot == 3)
                yRobot-=1;
            if (dirRobot == 4)
                yRobot+=1;


            for(int i=1; i<=ctTrig; i++)
            {
                if (xRobot == coordTrig[i].X & yRobot == coordTrig[i].Y)
                {
                  //  listBox1.Items.Add("COLIZIUNE LA " + xRobot.ToString() + " " + yRobot.ToString() + " " + tipTr[i]);
                    if(dirRobot==1)
                    {
                        if (tipTr[i] == 1)
                            dirRobot = 4;
                        else if (tipTr[i] == 4)
                            dirRobot = 3;
                        else
                        {
                            dirRobot = 2;
                        }
                    }
                    else if(dirRobot==2)
                    {
                        if (tipTr[i] == 2)
                            dirRobot = 4;
                        else if (tipTr[i]==3)
                            dirRobot = 3;
                        else
                        {
                            dirRobot = 1;
                        }
                    }
                    else if(dirRobot==3)
                    {
                        if (tipTr[i] == 1)
                            dirRobot = 2;
                        else if (tipTr[i] == 2)
                            dirRobot = 1;
                        else
                        {
                            dirRobot = 4;
                        }
                    }
                    else if(dirRobot==4)
                    {
                        if (tipTr[i] == 4)
                            dirRobot = 2;
                        if (tipTr[i] == 3)
                            dirRobot = 1;
                        else
                        {
                            dirRobot = 3;
                        }
                    }

                }

            }
            if (xRobot == 19)
                dirRobot = 1;
            if (xRobot == 0)
                dirRobot = 2;
            if (yRobot == 0)
                dirRobot = 4;
            if (yRobot == 9)
                dirRobot = 3;
            
            imgRobot = new Bitmap(imgPb1);
            imgRobotGrid = new Bitmap(imgPb1Grid);
            Graphics g = Graphics.FromImage(imgRobot);
            Graphics g1 = Graphics.FromImage(imgRobotGrid);
            g.DrawImage(robot, xRobot*30, yRobot*30);
            g1.DrawImage(robot, xRobot*30, yRobot*30);
            Graphics g2 = Graphics.FromImage(imgPb1);
            Graphics g3 = Graphics.FromImage(imgPb1Grid);
            g2.DrawImage(patratTraseu, xRobot * 30, yRobot * 30);
            g3.DrawImage(patratTraseu, xRobot * 30, yRobot * 30);
            g2.DrawImage(patratOrigine, xOrig * 30, yOrig * 30);
            g3.DrawImage(patratOrigine, xOrig * 30, yOrig * 30);

            if (ok == false)
                pictureBox1.Image = imgRobot;
            else
                pictureBox1.Image = imgRobotGrid;
            

        }

//dir1 ->1,4
//dir2 ->2,3
//dir3 ->1,2
//dir4 ->4 3

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(imgPb1);
            Graphics g1 = Graphics.FromImage(imgPb1Grid);
            g.DrawImage(patratOrigine, xRobot*30, yRobot*30);
            g1.DrawImage(patratOrigine, xRobot * 30, yRobot * 30);
            timer1.Start();
            button8.Show();
            button9.Show();
            button10.Show();
            button11.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            dirRobot = 1;
            button8.Hide();
            button9.Hide();
            button10.Hide();
            button11.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dirRobot = 2; button8.Hide();
            button9.Hide();
            button10.Hide();
            button11.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dirRobot = 3; button8.Hide();
            button9.Hide();
            button10.Hide();
            button11.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            xRobot = xOrig; yRobot = yOrig; dirRobot = 0;
            if (ok == true)
                pictureBox1.Image = imgOrig;
            else
                pictureBox1.Image = imgOrigGrid;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dirRobot = 4; button8.Hide();
            button9.Hide();
            button10.Hide();
            button11.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            int x = me.X;
            int y = me.Y;
            x /= 30; y /= 30; x *= 30; y *= 30;
            Graphics g = Graphics.FromImage(imgPb1);
            Graphics g1 = Graphics.FromImage(imgPb1Grid);
            g.DrawImage(triunghi, x, y);
            g1.DrawImage(triunghi, x, y);
            ctTrig++;
            coordTrig[ctTrig].X = x/30; coordTrig[ctTrig].Y = y/30;
            tipTr[ctTrig] = tipTrActual;
            if (ok == false)
            {
                imgRobot = new Bitmap(imgPb1);
                Graphics g2 = Graphics.FromImage(imgRobot);
                g2.DrawImage(robot, xRobot*30, yRobot*30);
                pictureBox1.Image = imgRobot;
            }
            else
            {
                imgRobotGrid = new Bitmap(imgPb1Grid);
                Graphics g2 = Graphics.FromImage(imgRobotGrid);
                g2.DrawImage(robot, xRobot*30, yRobot*30);
                pictureBox1.Image = imgRobotGrid;
            }

        }
    }
}
