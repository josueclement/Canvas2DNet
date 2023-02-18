﻿using Canvas2DNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Canvas2DNetTester.Model
{
    public class TestCanvasBehavior : Canvas2DBehavior
    {
        public override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            MessageBox.Show("double click");
        }
    }
}