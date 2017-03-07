using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFRain
{
    class AnimatedObject
    {
        PointF location;
        PointF initialLocation;
        PointF start;
        PointF end;

        Stopwatch sw;

        Size size = new Size(10, 10);


        double d;
        double td;
        float verticalSpeed;
        float horizontalSpeed;

        public PointF Location
        {
            get { return new PointF(initialLocation.X + horizontalSpeed * (float)(sw.ElapsedMilliseconds / 1000.0f), 
                                    initialLocation.Y + verticalSpeed * (float)(sw.ElapsedMilliseconds / 1000.0f)); }
        }


        public bool Stopped
        {
            get { return ((sw.ElapsedMilliseconds / 1000.0) >= td); }
        }


        public AnimatedObject() : this(new PointF(0, 0.0f), new PointF(100, 100.0f), 1.0f)
        {

        }

        /// <summary>
        /// Rain drop is an animated graphical object that starts from screen top (y = 0) 
        /// and move down at speed (pixels / seconds).
        /// </summary>
        /// <param name="x"></param>
        /// <param name="speed"></param>
        public AnimatedObject(PointF start, PointF end, float speed)
        {
            this.start = start;
            this.end = end;
            initialLocation = start;
            location = start;
            verticalSpeed = speed;
            sw = new Stopwatch();
            sw.Start();

            d = Math.Sqrt(Math.Pow(end.X - start.X, 2) + Math.Pow(end.Y - start.Y, 2));
            td = d / speed;
            horizontalSpeed = (float)((end.X - start.X) / td);
            verticalSpeed = (float)((end.Y - start.Y) / td);
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            if (!Stopped)
                location = new PointF(  initialLocation.X + horizontalSpeed * (float)(sw.ElapsedMilliseconds / 1000.0f),
                                        initialLocation.Y + verticalSpeed * (float)(sw.ElapsedMilliseconds / 1000.0f));
            //e.Graphics.DrawLine(Pens.RosyBrown, start, end);

            e.Graphics.FillEllipse(Brushes.Blue, new Rectangle(Point.Round(location), size));
            e.Graphics.DrawEllipse(Pens.Red, new Rectangle(Point.Round(location), size));
        }

    }
}
