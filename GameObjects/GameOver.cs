using System;
using System.Collections.Generic;
using System.Text;

namespace JumpGame.GameObjects
{
    public class GameOver : GameObjectsPiont
    {
        private string message { get; set; }
        private string mdate { get; set; }
        public GameOver(int PointX, int PointY, string date) : base(PointX, PointY)
        {
            message = "Game Over";
            Console.SetCursorPosition(PointX, PointY);
            Console.Write(message);
            mdate = date;
            Console.SetCursorPosition(PointX, PointY + 1);
            Console.Write("You hold on'" + date+"'");
            Console.SetCursorPosition(PointX, PointY + 2);
            Console.Write("You didn't save the family!");
        }
    }
}
