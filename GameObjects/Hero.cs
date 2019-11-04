using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace JumpGame.GameObjects
{
    public class Hero : GameObjectsPiont
    {
        //不同的时间显示不同的脚步
        private bool flge = true;
        public Hero(int PointX, int PointY) :
            base(PointX, PointY)
        {
            setHero(this.PointX, this.PointY);
        }

        public void setHero(int PointX, int PointY)
        {
            //先清理原来坐标的英雄
            clearHero();
            this.PointX = PointX;
            this.PointY = PointY;
            string heroHHeard = "  0 ";
            string heroHBody = " 'O' ";
            Console.SetCursorPosition(PointX, PointY);
            Console.WriteLine(heroHHeard);
            Console.SetCursorPosition(PointX, PointY + 1);
            Console.WriteLine(heroHBody);
            string heroHFeet1 = " /\\ ";
            string heroHFeet2 = " || ";
            int x = PointX;
            int y = PointY;
            if (flge)
            {
                Console.SetCursorPosition(x, y + 2);
                Console.Write(heroHFeet1);
                flge = false;
            }
            else
            {
                Console.SetCursorPosition(x, y + 2);
                Console.Write(heroHFeet2);
                flge = true;
            }
        }
        private void clearHero()
        {
            Console.SetCursorPosition(PointX, PointY);
            Console.WriteLine("    ");
            Console.SetCursorPosition(PointX, PointY + 1);
            Console.WriteLine("    ");
            Console.SetCursorPosition(PointX, PointY + 2);
            Console.WriteLine("    ");
        }
    }
}
