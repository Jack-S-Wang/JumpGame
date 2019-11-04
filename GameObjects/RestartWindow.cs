using System;
using System.Collections.Generic;
using System.Text;

namespace JumpGame.GameObjects
{
    public class RestartWindow:GameObjectsPiont
    {
        private string Arrows { get; set; }
        //上移为true，下移为false
        public bool flage { get; set; }
        public RestartWindow(int PointX,int PointY):base(PointX,PointY)
        {
            
            //默认需要下移
            flage = false;
        }

        public void setArrows(bool move)
        {
            if (flage && move)
            {
                Console.SetCursorPosition(PointX, PointY + 2);
                Console.Write("  ");
                Console.SetCursorPosition(PointX, PointY + 1);
                Console.Write(Arrows);
                flage = false;
            }
            else if(!flage && !move)
            {
                Console.SetCursorPosition(PointX, PointY + 1);
                Console.Write("  ");
                Console.SetCursorPosition(PointX, PointY + 2);
                Console.Write(Arrows);
                flage = true;
            }
        }
        public void Initailze()
        {
            string Infor = "Do you want to restart?";
            Arrows = "->";
            string Y = "Yes";
            string N = "No";
            Console.SetCursorPosition(PointX, PointY);
            Console.Write(Infor);
            Console.SetCursorPosition(PointX, PointY + 1);
            Console.Write(Arrows);
            Console.SetCursorPosition(PointX + 3, PointY + 1);
            Console.Write(Y);
            Console.SetCursorPosition(PointX + 3, PointY + 2);
            Console.Write(N);
        }

        public void ClearAll()
        {
            Console.SetCursorPosition(PointX, PointY);
            Console.Write("".PadRight(23,' '));
            Console.SetCursorPosition(PointX, PointY + 2);
            Console.Write("  ");
            Console.SetCursorPosition(PointX + 3, PointY + 1);
            Console.Write("   ");
            Console.SetCursorPosition(PointX + 3, PointY + 2);
            Console.Write("  ");
        }
    }
}
