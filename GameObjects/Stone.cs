using System;
using System.Collections.Generic;
using System.Text;

namespace JumpGame.GameObjects
{
    public class Stone:GameObjectsPiont
    {
        private string body { get; set; }
        public Stone(int PointX,int PointY) : base(PointX, PointY)
        {
            body = "m";
        }
        public void setStone()
        {

        }
    }
}
