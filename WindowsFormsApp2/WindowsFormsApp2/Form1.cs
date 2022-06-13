using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Bitmap image;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int red, green, blue;
            this.Refresh();
            if (image != null)
            {
                Color renk = image.GetPixel(e.X, e.Y);
                red = renk.R;
                green = renk.G;
                blue = renk.B;
                textBox6.Text = Convert.ToString(red) + "-" + Convert.ToString(green) + "-" + Convert.ToString(blue);
                panel1.BackColor = renk;
                textBox1.Text = Convert.ToString(e.X);
                textBox2.Text = Convert.ToString(e.Y);

            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                image = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = image;
            }
            Graphics.FromImage(image).DrawImage(pictureBox1.Image, 0, 0, 300, 300);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x, y;
            int red, green, blue;
            this.Refresh();
            if(image!= null)
            {
                x = Convert.ToInt32(textBox1.Text);
                y = Convert.ToInt32(textBox2.Text);
                Color renk = image.GetPixel(x, y);
                red = renk.R;
                green = renk.G;
                blue = renk.B;
                textBox6.Text= Convert.ToString(red) + "-"+ Convert.ToString(green) +"-"+Convert.ToString(blue);
                panel1.BackColor = renk;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            pictureBox1.Image = null;
            image = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = image;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int red,green,blue;
            int r,g,b;
            Color c;
            r= Convert.ToInt32(textBox3.Text);
            g= Convert.ToInt32(textBox4.Text);
            b= Convert.ToInt32(textBox5.Text);
            for(int i = 0; i < pictureBox1.Width; i++)
            {
                for(int j = 0; j < pictureBox1.Height; j++)
                {
                    c=image.GetPixel(i, j);
                    red= c.R;
                    green= c.G;
                    blue= c.B;
                    if (red == r && green == g && blue == b)
                    {
                        listBox1.Items.Add(i + "-" + j);
                    }
                    
                }
            }
            MessageBox.Show("Kayıt sayısı:" + Convert.ToString(listBox1.Items.Count));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int red, green, blue;
            int r, g, b;
            Color c;
            r = Convert.ToInt32(textBox3.Text);
            g = Convert.ToInt32(textBox4.Text);
            b = Convert.ToInt32(textBox5.Text);
            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    c = image.GetPixel(i, j);
                    red = c.R;
                    green = c.G;
                    blue = c.B;
                    if (red == r && green == g && blue == b)
                    image.SetPixel(i, j, Color.Orange);

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Color p;
            int width = image.Width;
            int height = image.Height;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                   

                    p = image.GetPixel(x, y);


                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;


                    int avg = (r + g + b) / 3;


                    image.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                    listBox1.Items.Add("grayscale:"+avg);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Color p;
            int width = image.Width;
            int height = image.Height;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {


                    p = image.GetPixel(x, y);


                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;


                    int avg = (r + g + b) / 3;
                    if (avg <= 127)
                    {   
                        r = 0;
                        g = 0;
                        b = 0;
                        image.SetPixel(x, y, Color.FromArgb(r, g, b));
                        listBox1.Items.Add("red:" + r + "green:" + g + "blue:" + b);

                    }
                    else
                    {
                        r = 255;
                        g = 255;
                        b = 255;
                        image.SetPixel(x, y, Color.FromArgb(r, g, b));
                        listBox1.Items.Add("red:" + r + "green:" + g + "blue:" + b);
                    }


                   
                }
            }
        }
    }
}
