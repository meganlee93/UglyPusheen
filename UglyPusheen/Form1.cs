using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UglyPusheen
{
    public partial class Form1 : Form
    {
        Graphics gfx;
        int midX;
        int midY;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gfx = CreateGraphics();
            gfx.Clear(Color.Transparent);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            GraphicsPath earPath = new GraphicsPath();
            GraphicsPath footPath = new GraphicsPath();
            GraphicsPath hairPath = new GraphicsPath();

            //base
            midX = ClientSize.Width / 2;
            midY = ClientSize.Height / 2;
            Point topLeft = new Point(midX - 70, midY - 100);
            Point topRight = new Point(midX + 200, midY - 100);
            Point bottomRight = new Point(midX + 200, midY + 100);
            Point bottomLeft = new Point(midX - 100, midY + 100);
            Point[] belly = new Point[]
            {
                topLeft,
                topRight,
                bottomRight,
                bottomLeft
                //new Point((ClientSize.Width/2), (ClientSize.Height/2))
            };

            Rectangle foot1 = new Rectangle(bottomLeft.X + 40, bottomLeft.Y + 5, 25, 25);
            Rectangle foot2 = new Rectangle(foot1.X + 50, foot1.Y + 5, 25, 25);
            Rectangle foot3 = new Rectangle(foot2.X + 100, foot2.Y, 25, 25);
            Rectangle foot4 = new Rectangle(foot3.X + 50, foot3.Y - 5, 25, 25);
            float startAngle = 295.0F;
            float sweepAngle = 300.0F;
            footPath.AddArc(foot1, startAngle, sweepAngle);
            footPath.AddArc(foot2, startAngle, sweepAngle);
            footPath.AddArc(foot3, startAngle, sweepAngle);
            footPath.AddArc(foot4, startAngle, sweepAngle);
            gfx.FillPath(Brushes.Gray, footPath);

            //ears
            Point ear1 = new Point(topLeft.X, topLeft.Y);
            Point ear2 = new Point(ear1.X + 5, ear1.Y - 45);
            Point ear3 = new Point(topLeft.X + 50, topLeft.Y);

            Point[] leftEar = new Point[]
            {
                ear1,
                ear2,
                ear3
            };

            Point[] rightEar = new Point[]
            {
                new Point(ear1.X + 65, ear1.Y),
                new Point(ear1.X + 70, ear1.Y - 45),
                new Point(ear1.X + 115, ear1.Y)
            };

            earPath.AddCurve(leftEar);
            earPath.AddCurve(rightEar);
            gfx.FillPath(Brushes.Gray, earPath);

            //belly
            gfx.FillClosedCurve(Brushes.Gray, belly);

            //eyes
            Point leftEye = new Point(ear1.X + 20, ear1.Y + 20);
            Point rightEye = new Point(leftEye.X + 45, leftEye.Y);
            Size eyeball = new Size(15, 15);
            gfx.FillEllipse(Brushes.Black, new Rectangle(leftEye, eyeball));
            gfx.FillEllipse(Brushes.Black, new Rectangle(rightEye, eyeball));

            //nose
            Point[] nose1 = new Point[]
            {
                new Point(leftEye.X + eyeball.Width + 15, leftEye.Y + 10),
                new Point(leftEye.X + eyeball.Width + 12, leftEye.Y + 40),
                new Point(leftEye.X + eyeball.Width - 5, leftEye.Y + 35)
            };

            Point[] nose2 = new Point[]
            {
                new Point(leftEye.X + eyeball.Width + 15, leftEye.Y + 10),
                new Point(leftEye.X + eyeball.Width + 18, leftEye.Y + 40),
                new Point(leftEye.X + eyeball.Width + 35, leftEye.Y + 35)
            };

            gfx.DrawCurve(Pens.Black, nose1);
            gfx.DrawCurve(Pens.Black, nose2);

            //whiskers
            Point[] whisker1 = new Point[]
            {
                new Point(midX - 80, midY- 80),
                new Point(midX - 110, midY - 90),
                new Point(midX - 150, midY - 80)
            };

            Point[] whisker2 = new Point[]
            {
                new Point(midX - 80, midY - 70),
                new Point(midX - 110, midY - 80),
                new Point(midX - 150, midY - 70)
            };

            Point[] whisker3 = new Point[]
            {
                new Point(midX + 30, midY - 70),
                new Point(midX + 60, midY - 80),
                new Point(midX + 100, midY - 70)
            };

            Point[] whisker4 = new Point[]
            {
                new Point(midX + 30, midY - 80),
                new Point(midX + 60, midY - 90),
                new Point(midX + 100, midY - 80)
            };

            gfx.DrawCurve(Pens.Black, whisker1);
            gfx.DrawCurve(Pens.Black, whisker2);
            gfx.DrawCurve(Pens.Black, whisker3);
            gfx.DrawCurve(Pens.Black, whisker4);

            //tail
            Point[] tail = new Point[]
            {
                new Point(topRight.X + 30, topRight.Y + 100),
                new Point(topRight.X + 65 , topRight.Y + 80),
                new Point(topRight.X + 100, topRight.Y + 20),
                new Point(topRight.X + 110, topRight.Y + 20),
                new Point(topRight.X + 110, topRight.Y + 40),
                new Point(topRight.X + 80, topRight.Y + 100),
                new Point(topRight.X + 30, topRight.Y + 120)
            };

            gfx.FillClosedCurve(Brushes.Gray, tail);

            Point[] hair1 = new Point[]
            {
                new Point(topLeft.X + 36, topLeft.Y - 15),
                new Point(topLeft.X + 36, topLeft.Y + 10),
                new Point(topLeft.X + 42, topLeft.Y +10),
                new Point(topLeft.X + 42, topLeft.Y - 15)
            };

            Point[] hair2 = new Point[]
            {
                new Point(topLeft.X + 45, topLeft.Y - 20),
                new Point(topLeft.X + 45, topLeft.Y + 10),
                new Point(topLeft.X + 51, topLeft.Y + 10),
                new Point(topLeft.X + 51, topLeft.Y - 20)
            };

            Point[] hair3 = new Point[]
            {
                new Point(topLeft.X + 54, topLeft.Y - 19),
                new Point(topLeft.X + 54, topLeft.Y + 10),
                new Point(topLeft.X + 60, topLeft.Y + 10),
                new Point(topLeft.X + 60, topLeft.Y - 19)
            };

            hairPath.AddCurve(hair1);
            hairPath.AddCurve(hair2);
            hairPath.AddCurve(hair3);
            gfx.FillPath(Brushes.DarkGray, hairPath);
        }
    }
}
