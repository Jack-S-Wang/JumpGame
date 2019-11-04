using System;
using System.Collections.Generic;
using System.Text;

namespace JumpGame.GameObjects
{
    public class WindowsSize
    {
        public WindowsSize(int width,int height)
        {
            Width = width;
            Height = height;
        }
        private int width;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        private int height;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

    }
}
