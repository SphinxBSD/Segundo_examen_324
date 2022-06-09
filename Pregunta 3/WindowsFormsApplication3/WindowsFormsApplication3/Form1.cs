using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        int pR, pG, pB;
        int[,] registro = new int[6,4];
        int m = 0;
        int textura;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.*)|*.*";
            openFileDialog1.ShowDialog();
            bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Color c = new Color();
            c = bmp.GetPixel(15, 15);
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Color c = new Color();
            c = bmp.GetPixel(e.X, e.Y);
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
            pR = c.R;
            pG = c.G;
            pB = c.B;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Color c = new Color();
            Bitmap bmpR = new Bitmap(bmp.Width,bmp.Height);
            for (int i = 0; i < bmp.Width; i++) {
                for (int j = 0; j < bmp.Height; j++) {
                    c = bmp.GetPixel(i, j);
                    bmpR.SetPixel(i, j, Color.FromArgb(c.R, 0, 0));
                }
            }
            pictureBox2.Image = bmpR;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Color c = new Color();
            Bitmap bmpR = new Bitmap(bmp.Width, bmp.Height);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    bmpR.SetPixel(i, j, Color.FromArgb(0, c.G, 0));
                }
            }
            pictureBox2.Image = bmpR;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Color c = new Color();
            Bitmap bmpR = new Bitmap(bmp.Width, bmp.Height);
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if ((c.R - 5 <= pR && pR <= c.R + 5) && (c.G - 5 <= pG && pG <= c.G + 5) && (c.B - 5 <= pB && pB <= c.B + 5))
                    {
                        bmpR.SetPixel(i, j, Color.Fuchsia);
                    }
                    else
                    {
                        bmpR.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                    }
                }
            pictureBox2.Image = bmpR;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Color c = new Color();
            int mR = 0, mG = 0, mB = 0;
            for (int i = 15; i < 25; i++)
                for (int j = 15; j < 25;j++ )
                {
                    c = bmp.GetPixel(i, j);
                }
            mR = mR / 100;
            mG = mG / 100;
            mB = mB / 100;

            textBox1.Text = mR.ToString();
            textBox2.Text = mG.ToString();
            textBox3.Text = mB.ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {
        int mR = 0, mG = 0, mB = 0; 
            Color c = new Color();
            Bitmap bmpR = new Bitmap(bmp.Width, bmp.Height);
            for (int i = 0; i < bmp.Width-10; i=i+10)
                for (int j = 0; j < bmp.Height-10; j=j+10)
                {
                    mR = 0;
                    mG = 0;
                    mB = 0; 
                    for (int ki = i; ki<i+10; ki++)
                        for (int kj = j; kj<j+10; kj++)
                        {
                            c = bmp.GetPixel(ki, kj);
                            mR = mR + c.R;
                            mG = mG + c.G;
                            mB = mB + c.B;
                        }
                    mR = mR / 100;
                    mG = mG / 100;
                    mB = mB / 100;

                    c = bmp.GetPixel(i, j);
                    if ((pR - 5 <= mR && mR <= pR + 5) && (pG - 5 <= mG && mG <= pG + 5) && (pB - 5 <= mB && mB <= pB + 5))
                    {
                        for (int ki = i; ki < i + 10; ki++)
                            for (int kj = j; kj < j + 10; kj++)
                                bmpR.SetPixel(ki, kj, Color.Fuchsia);
                    }
                    else
                    {
                        for (int ki = i; ki < i + 10; ki++)
                            for (int kj = j; kj < j + 10; kj++)
                            {
                                c = bmp.GetPixel(ki, kj);
                                bmpR.SetPixel(ki, kj, Color.FromArgb(c.R, c.G, c.B));
                            }
                        
                    }
                }
            pictureBox2.Image = bmpR;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            registro[m, 0] = textura;
            registro[m, 1] = pR;
            registro[m, 2] = pG;
            registro[m, 3] = pB;


            textBox5.Text = textBox5.Text +"TEXTURA NRO "+ registro[m, 0].ToString() + " " + registro[m, 1].ToString() + " " + registro[m, 2].ToString() + " " + registro[m, 3].ToString() + "\r\n";
            m++;
            //textBox5.Text + registro[m, 0].ToString() + " " + registro[m, 1].ToString() + " " + registro[m, 2].ToString() + " " + registro[m, 3].ToString() + "\n"
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textura = 1;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textura = 2;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textura = 3;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int mR = 0, mG = 0, mB = 0; 
            Color c = new Color();
            Bitmap bmpR = new Bitmap(bmp.Width, bmp.Height);
            for(int n=0;n<6; n++){
            if(registro[n,0]==textura){
                for (int i = 0; i < bmp.Width - 10; i = i + 10)
                {
                    for (int j = 0; j < bmp.Height-10; j=j+10)
                {
                    mR = 0;
                    mG = 0;
                    mB = 0;
                    for (int ki = i; ki<i+10; ki++)
                        for (int kj = j; kj<j+10; kj++)
                        {
                            c = bmp.GetPixel(ki, kj);
                            mR = mR + registro[n, 1];
                            mG = mG + registro[n, 2];
                            mB = mB + registro[n, 3];
                        }
                    mR = mR / 100;
                    mG = mG / 100;
                    mB = mB / 100;

                    c = bmp.GetPixel(i, j);
                    if ((registro[n,1] - 5 <= mR && mR <= registro[n,0] + 5) && (registro[n,2] - 5 <= mG && mG <= registro[n,2] + 5) && (registro[n,3] - 5 <= mB && mB <= registro[n,3] + 5))
                    {
                        for (int ki = i; ki < i + 10; ki++)
                            for (int kj = j; kj < j + 10; kj++)
                                bmpR.SetPixel(ki, kj, Color.Fuchsia);
                    }
                    else
                    {
                        for (int ki = i; ki < i + 10; ki++)
                            for (int kj = j; kj < j + 10; kj++)
                            {
                                c = bmp.GetPixel(ki, kj);
                                bmpR.SetPixel(ki, kj, Color.FromArgb(c.R, c.G, c.B));
                            }
                        
                    }
                }  
            }
                } 
            }
            pictureBox2.Image = bmpR;
        }

        }
    }

