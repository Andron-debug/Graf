using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Graf
{
    interface IDraw
    {
        void Draw(Graphics gr);
    }
    public class MyEllipse : IDraw
    {

        protected int x;
        protected int y;
        protected string number;
        protected int r = 20;
        protected int w = 1;
        protected Color c = Color.Black;
        public int R
        {
            get { return r; }
            set
            {
                r = value;
            }
        }
        public int W
        {
            get { return w; }
            set
            {
                w = value;
            }
        }

        public int X
        {
            get { return x; }
            set
            {
                x = value;
            }
        }
        public Color C
        {
            set
            {
                c = value;
            }
        }
        public int Y
        {
            get { return y; }
            set
            {
                y = value;
            }
        }
        public string N
        {
            get { return number; }
        }

        public MyEllipse(int xx, int yy, string n)
        {
            X = xx;
            Y = yy;
            number = n;
        }


        public void Draw(Graphics gr)
        {
            Font fo;
            Brush br;
            PointF point;
            fo = new Font("Arial", 10, FontStyle.Bold);
            Pen pn = new Pen(c, w);
            br = Brushes.Black;
            point = new PointF(x - r / 2, y - r / 2);
            gr.DrawEllipse(pn, x - r, y - r, 2 * r, r * 2);
            gr.DrawString(number, fo, br, point);
        }
    }
    public class Loop : IDraw
    {
        private int x;
        private int y;
        private int r = 12;
        private int w = 2;
        public Loop(MyEllipse v)
        {
            x = v.X  + v.R;
            y = v.Y  + v.R;
        }
        public void Draw(Graphics gr)
        {
            Pen pen = new Pen(Color.BlueViolet, 2);
            gr.DrawEllipse(pen, x-r+w, y-r+w, 2 * r, r * 2);
        }
    }


    public class MyLine:IDraw
    {
        protected int x1, x2, y1, y2;

        public int X1
        {
            get { return x1; }
            set { x1 = value; }
        }
        public int X2
        {
            get { return x2; }
            set { x2 = value; }
        }
        public int Y1
        {
            get { return y1; }
            set { y1 = value; }
        }
        public int Y2
        {
            get { return y2; }
            set { y2 = value; }
        }
        public MyLine(int xn, int yn, int xk, int yk)
        {
            x1 = xn;
            x2 = xk;
            y1 = yn;
            y2 = yk;
        }

        public void Draw(Graphics gr)
        {
            Pen pen = new Pen(Color.BlueViolet, 1);
            gr.DrawLine(pen, X1, Y1, X2, Y2);
        }
    }
    public class MyArrow : MyLine, IDraw
    {
        public MyArrow(int xn, int yn, int xk, int yk) : base(xn, yn, xk, yk)
        {
        }
        public new void Draw(Graphics gr)
        {
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4);
            Pen pen = new Pen(Color.BlueViolet, 1);
            pen.CustomEndCap = bigArrow;
            gr.DrawLine(pen, X1, Y1, X2, Y2);
        }
    }
}
