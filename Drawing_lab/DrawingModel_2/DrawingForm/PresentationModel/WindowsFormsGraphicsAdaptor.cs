﻿using DrawingModel;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingForm
{
    public class WindowsFormsGraphicsAdaptor : IGraphics
    {
        private readonly Graphics _graphics;

        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        public void ClearAll()
        {
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(
                Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }
    }
}
