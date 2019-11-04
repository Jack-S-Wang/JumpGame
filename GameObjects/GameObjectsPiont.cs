using System;
using System.Collections.Generic;
using System.Text;

namespace JumpGame.GameObjects
{
    public class GameObjectsPiont
    {
        public GameObjectsPiont(int PointX, int PointY)
        {
            this.PointX = PointX;
            this.PointY = PointY;
        }
        public int PointX
        {
            get; set;
        }
        public int PointY
        {
            get; set;
        }
    }
}
