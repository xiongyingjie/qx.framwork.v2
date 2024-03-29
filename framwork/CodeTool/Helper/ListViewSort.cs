﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeTool.Helper
{
    internal class ListViewSort : IComparer
    {
        private int col;
        private bool descK;

        public ListViewSort()
        {
            col = 1;
        }

        public ListViewSort(int column, object Desc)
        {
            descK = (bool) Desc;
            col = column; //当前列,0,1,2...,参数由ListView控件的ColumnClick事件传递 
        }

        public int Compare(object x, object y)
        {
            var _x = 0;
            var _y = 0;
            try
            {
                _x = int.Parse(((ListViewItem) x).SubItems[col].Text);
                _y = int.Parse(((ListViewItem) y).SubItems[col].Text);
            }
            catch (Exception exception)
            {
                col = 5;
                _x = int.Parse(((ListViewItem)x).SubItems[col].Text);
                _y = int.Parse(((ListViewItem)y).SubItems[col].Text);
            }
            var tempInt = _x - _y;
            //var tempInt = String.Compare(((ListViewItem) x).SubItems[col].Text, ((ListViewItem) y).SubItems[col].Text);
            return descK ? -tempInt : tempInt;
        }
    }
}
