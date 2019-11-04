using System;
using System.Collections.Generic;
using System.Text;

namespace JumpGame.GameObjects
{
    public class Kidnapper : GameObjectsPiont
    {
        private string heard { get; set; }
        private string body { get; set; }
        public Kidnapper(int PointX, int PointY) : base(PointX, PointY)
        {
            heard = " O ";
            body = "^ ^";
            Console.SetCursorPosition(PointX, PointY);
            Console.Write(heard);
            Console.SetCursorPosition(PointX, PointY + 1);
            Console.Write(body);
        }
        public void setKidnapper(int count)
        {
            //清理原来的图像
            clearImage();
            string heard1 = "";
            string body1 = "";

            if (PointX + count == Console.WindowWidth - 2)
            {
                heard1 = " O";
                body1 = "^ ";
            }
            else if (PointX + count == Console.WindowWidth - 1)
            {
                heard1 = " ";
                body1 = "^";
            }
            else if (PointX + count == Console.WindowWidth)
            {
                this.PointX += count;
                return;
            }
            else
            {
                heard1 = heard;
                body1 = body;
            }
            Console.SetCursorPosition(PointX + count, PointY);
            Console.Write(heard1);
            Console.SetCursorPosition(PointX + count, PointY + 1);
            Console.Write(body1);
            this.PointX += count;
        }
        private void clearImage()
        {
            Console.SetCursorPosition(PointX, PointY);
            Console.Write("   ");
            Console.SetCursorPosition(PointX, PointY + 1);
            Console.Write("   ");
        }
    }
}
