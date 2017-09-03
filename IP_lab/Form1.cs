using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IP_lab
{
    public partial class Form1 : Form
    {
        private Bitmap _currentBitmap;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                _currentBitmap = (Bitmap)pictureBox1.Image;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SetBrightness(Convert.ToInt32(textBox1.Text));

            //Bitmap bmap = (Bitmap)_currentBitmap.Clone();
            //Color c;
            //for (int i = 0; i < bmap.Width; i++)
            //{
            //    for (int j = 0; j < bmap.Height; j++)
            //    {
            //        c = bmap.GetPixel(i, j);
            //        int nPixelR = 0;
            //        int nPixelG = 0;
            //        int nPixelB = 0;
            //        nPixelR = c.R;
            //        nPixelG = c.G - 255;
            //        nPixelB = c.B - 255;

            //        nPixelR = Math.Max(nPixelR, 0);
            //        nPixelR = Math.Min(255, nPixelR);

            //        nPixelG = Math.Max(nPixelG, 0);
            //        nPixelG = Math.Min(255, nPixelG);

            //        nPixelB = Math.Max(nPixelB, 0);
            //        nPixelB = Math.Min(255, nPixelB);

            //        bmap.SetPixel(i, j, Color.FromArgb((byte)nPixelR,
            //          (byte)nPixelG, (byte)nPixelB));
            //    }
            //}

            //pictureBox2.Image = (Bitmap)bmap.Clone();
            //pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void SetBrightness(int brightness)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            if (brightness < -255) brightness = -255;
            if (brightness > 255) brightness = 255;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    int cR = c.R + brightness;
                    int cG = c.G + brightness;
                    int cB = c.B + brightness;

                    if (cR < 0) cR = 1;
                    if (cR > 255) cR = 255;

                    if (cG < 0) cG = 1;
                    if (cG > 255) cG = 255;

                    if (cB < 0) cB = 1;
                    if (cB > 255) cB = 255;

                    bmap.SetPixel(i, j,
        Color.FromArgb((byte)cR, (byte)cG, (byte)cB));
                }
            }

            pictureBox2.Image = (Bitmap)bmap.Clone();
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SetContrast(Convert.ToDouble(textBox1.Text));
            //Bitmap bmap = (Bitmap)_currentBitmap.Clone();
            //Color c;
            //for (int i = 0; i < bmap.Width; i++)
            //{
            //    for (int j = 0; j < bmap.Height; j++)
            //    {
            //        c = bmap.GetPixel(i, j);
            //        int nPixelR = 0;
            //        int nPixelG = 0;
            //        int nPixelB = 0;
            //        nPixelR = c.R - 255;
            //        nPixelG = c.G;
            //        nPixelB = c.B - 255;

            //        nPixelR = Math.Max(nPixelR, 0);
            //        nPixelR = Math.Min(255, nPixelR);

            //        nPixelG = Math.Max(nPixelG, 0);
            //        nPixelG = Math.Min(255, nPixelG);

            //        nPixelB = Math.Max(nPixelB, 0);
            //        nPixelB = Math.Min(255, nPixelB);

            //        bmap.SetPixel(i, j, Color.FromArgb((byte)nPixelR,
            //          (byte)nPixelG, (byte)nPixelB));
            //    }
            //}
            //pictureBox3.Image = (Bitmap)bmap.Clone();
            //pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void SetContrast(double contrast)
        {
            Bitmap bmap = (Bitmap)_currentBitmap.Clone();
            if (contrast < -100) contrast = -100;
            if (contrast > 100) contrast = 100;
            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    double pR = c.R / 255.0;
                    pR -= 0.5;
                    pR *= contrast;
                    pR += 0.5;
                    pR *= 255;
                    if (pR < 0) pR = 0;
                    if (pR > 255) pR = 255;

                    double pG = c.G / 255.0;
                    pG -= 0.5;
                    pG *= contrast;
                    pG += 0.5;
                    pG *= 255;
                    if (pG < 0) pG = 0;
                    if (pG > 255) pG = 255;

                    double pB = c.B / 255.0;
                    pB -= 0.5;
                    pB *= contrast;
                    pB += 0.5;
                    pB *= 255;
                    if (pB < 0) pB = 0;
                    if (pB > 255) pB = 255;

                    bmap.SetPixel(i, j,
        Color.FromArgb((byte)pR, (byte)pG, (byte)pB));
                }
            }
            pictureBox3.Image = (Bitmap)bmap.Clone();
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Negative
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    bmap.SetPixel(i, j, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                }
            }
            pictureBox4.Image = (Bitmap)bmap.Clone();
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bmap = (Bitmap)_currentBitmap.Clone();
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    int nPixelR = 0;
                    int nPixelG = 0;
                    int nPixelB = 0;
                    nPixelR = c.R;
                    nPixelG = c.G;
                    nPixelB = c.B;

                    int grayscale = (nPixelB + nPixelG + nPixelR) / 3;

                    bmap.SetPixel(i, j, Color.FromArgb((byte)grayscale,
                      (byte)grayscale, (byte)grayscale));
                }
            }
            pictureBox4.Image = (Bitmap)bmap.Clone();
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
