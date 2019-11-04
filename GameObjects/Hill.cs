using System;
using System.Collections.Generic;
using System.Text;

namespace JumpGame.GameObjects
{
    public class Hill:GameObjectsPiont
    {
        
        public Hill(int PointX,int PointY) : base(PointX, PointY)
        {
            string Hills="          /\\          ";
            string Hills1 = "        --  --        ";
            string Hills2 = "       /      \\       ";
            string Hills3 = "     /        \\     ";
            Console.SetCursorPosition(PointX, PointY);
            Console.Write(Hills);
            Console.SetCursorPosition(PointX, PointY+1);
            Console.Write(Hills1);
            Console.SetCursorPosition(PointX, PointY+2);
            Console.Write(Hills2);
            Console.SetCursorPosition(PointX, PointY+3);
            Console.Write(Hills3);
        }
    }
}
