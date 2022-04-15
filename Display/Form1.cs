using Display.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Display
{




    public partial class Form1 : Form
    {
        private bool isDragging = false;
        private Point windowPositionPoint = new Point();
        public Form1()
        {
            InitializeComponent();
        }

     
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MouseDownHandler(object sender, MouseEventArgs e)
        {
            isDragging = true;
            windowPositionPoint.X = e.X;
            windowPositionPoint.Y = e.Y;

        }

        private void MouseUpHandler(object sender, MouseEventArgs e)
        {
            isDragging = false;
            windowPositionPoint.X = e.X;
            windowPositionPoint.Y = e.Y;
        }

        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.windowPositionPoint.X, p.Y - this.windowPositionPoint.Y);

            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            btn.Height = 100;
            btn.BackColor = Color.Salmon;
        }

        private void LeaveHandler(object sender, EventArgs e)
        {
            btn.BackColor = Color.Gray;
            btn.Height = 23;
        }
    }
}
