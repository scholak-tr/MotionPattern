using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double g = 9.82;
            double v0 = Convert.ToDouble(textBoxSpeed.Text);
            double R0 = Convert.ToDouble(textBoxRadius.Text);
            double t = Convert.ToDouble(textBoxTime.Text);
            double delta = Convert.ToDouble(textBoxDelta.Text);


            double[] w = new double[(int)(t / delta)];
            double[] fi = new double[(int)(t / delta)];
            fi[0] = 0;
            w[0] = v0 / Math.Sqrt(g * R0);

            int i = 1;
            for (double x = delta; x < t - delta; x += delta)
            {
                w[i] = w[i - 1] - delta * Math.Sin(fi[i - 1] * Math.PI / 180) * 180 / Math.PI;
                fi[i] = fi[i - 1] + delta * w[i];
                i++;
            } 
            FormDrawPolar(fi, w, delta, t);
            FormDrawRectangular(fi, w, delta, t);

        }

        public void FormDrawPolar(double[] fi, double[] w, double delta, double t)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            int i = 0;
            for (double y = delta; y < t - delta; y += delta)
            {
                chart1.Series[0].Points.AddXY(Math.Cos(y), Math.Sin(fi[i]));
                chart1.Series[1].Points.AddXY(Math.Cos(y), Math.Sin(w[i]));
                i++;
            }
        }
            public void FormDrawRectangular(double[] fi, double[] w, double delta, double t)
            {
                chart2.Series[0].Points.Clear();
                chart2.Series[1].Points.Clear();

                int i = 0;
                for (double y = delta; y < t - delta; y += delta)
                {
                    chart2.Series[0].Points.AddXY(y, fi[i]);
                    chart2.Series[1].Points.AddXY(y, w[i]);
                    i++;
                }
            }
 
    }
}
