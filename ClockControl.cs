using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockControl
{
    public class ClockControl:Control
    {
        private Timer timer;
        private double SecTickCount;
        private double MinTickCount;
        private double HrTickCount;
        public ClockControl(): base()
        {
            this.Size = new System.Drawing.Size(200,200);
            this.Paint += ClockControl_Paint;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
            timer.Start();
            SecTickCount = 4.71239+(0.0174533 * 6) * DateTime.Now.Second;
            MinTickCount = 4.71239 + (0.0174533 * 6) * DateTime.Now.Minute;
            HrTickCount = 4.71239 + (0.0174533 * 12) * DateTime.Now.Hour;
            this.SizeChanged += ClockControl_SizeChanged;
           
            
        }

        private void ClockControl_SizeChanged(object sender, EventArgs e)
        {
            if (this.Size.Width != this.Size.Height) {
                this.Size = new Size(100, 100);            
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            SecTickCount += (0.0174533 * 6);
            MinTickCount += (0.0174533 * 6)/60;
            HrTickCount += (0.0174533 * 6)/60/60;
            //counter++;
            this.Invalidate();
        }

        private void ClockControl_Paint(object sender, PaintEventArgs e)
        {
            var Graphics = this.CreateGraphics();

            //Graphics.DrawImage(Image.FromFile("Clock.png"),new Rectangle(new Point(0,0),this.Size));
            Graphics.DrawLine(Pens.Black,new Point(this.Width/2,this.Height/2),new Point( (int)(this.Width / 2 + Math.Cos(SecTickCount) * this.Width / 2),(int)(this.Width / 2.4 + Math.Sin(SecTickCount) * this.Height / 2.4) ));
            Graphics.DrawLine(Pens.BlueViolet,new Point(this.Width/2,this.Height/2),new Point( (int)(this.Width / 2 + Math.Cos(MinTickCount) * this.Width / 2.8),(int)(this.Width / 2 + Math.Sin(MinTickCount) * this.Height / 2.8) ));
            Graphics.DrawLine(Pens.Red,new Point(this.Width/2,this.Height/2),new Point( (int)(this.Width / 2 + Math.Cos(HrTickCount) * this.Width / 3),(int)(this.Width / 2 + Math.Sin(HrTickCount) * this.Height /3) ));


            for (double i = 4.71239; i < 10.5; i += 0.523599) {
                if (i != 6.283187 && i != 4.71239 && i!= 7.853984 && i!= 9.4247810000000012)
                {
                    Graphics.FillEllipse(Brushes.Black, new Rectangle(new Point((int)(this.Width / 2.1 + Math.Cos(i) * this.Width / 2.1), (int)(this.Width / 2.1 + Math.Sin(i) * this.Height / 2.1)), new Size(10, 10)));
                }
           
            }
            Font font = new Font("Ariala",12,FontStyle.Bold);
           
            
            Graphics.DrawString("12",font,Brushes.Black,new Point(this.Width/2-12,0));
            Graphics.DrawString("3",font,Brushes.Black,new Point(this.Width-12,this.Height/2-6));
            Graphics.DrawString("6",font,Brushes.Black,new Point(this.Width/2-6,this.Height-16));
            Graphics.DrawString("9",font,Brushes.Black,new Point(0,this.Height/2-6));


        }
    }
}
