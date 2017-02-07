using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WFRain
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        
        List<AnimatedObject> rain = new List<AnimatedObject>();

        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                int x = rnd.Next(0, 500);
                rain.Add(new AnimatedObject(new PointF((float)rnd.Next(0, 800), (float)rnd.Next(0, 800)), new PointF((float)rnd.Next(0, 800), (float)rnd.Next(0, 800)), (float)rnd.Next(100, 400)));
            }
            rain.RemoveAll(p => p.Stopped);
            
            foreach (AnimatedObject drop in rain)
                drop.Paint(sender, e);

        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            Invalidate();
        }
    }
}
