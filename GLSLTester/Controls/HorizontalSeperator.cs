using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GLSLTester.Controls
{
    public partial class HorizontalSeperator : Control
    {
        Point startPoint, endPoint;

        public HorizontalSeperator()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            startPoint = new Point(this.ClientRectangle.X, this.ClientRectangle.Y);
            endPoint = new Point(this.ClientRectangle.X + this.ClientRectangle.Width, this.ClientRectangle.Y);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawLine(SystemPens.InactiveCaption, startPoint, endPoint);
            e.Graphics.DrawLine(Pens.White, new Point(startPoint.X, startPoint.Y + 1), new Point(endPoint.X, endPoint.Y + 1));
        }
    }
}
