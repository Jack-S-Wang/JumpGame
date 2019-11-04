using System;
using System.Collections.Generic;
using System.Text;

namespace JumpGame.GameObjects
{
    public class Road : GameObjectsPiont
    {
        //记录是否前一个是为hole
        private bool flage = false;
        private int width { get; set; }
        public string roadLine { get; set; }
        //记录出现空格的次数
        private int Num { get; set; }
        //记录出现实体的次数
        private int Num2 { get; set; }
        public Road(int PointX, int PointY, int Width) : base(PointX, PointY)
        {
            this.width = Width;
            roadLine = "=".PadRight(width, '=');
            Console.SetCursorPosition(PointX, PointY);
            Console.Write(roadLine);
        }
        Random random = new Random();
        List<string> li = new List<string>()
            {
                " "
        };
        private object ObjectLock = new object();
        public void SetRoad()
        {
            lock (ObjectLock)
            {
                roadLine = roadLine.Remove(0, 1);
                //为0时进行随机出现
                if (Num == 0)
                {
                    int count = random.Next(0, 10);
                    if (count>8)
                    {
                        if (!flage && Num2 >= 3)
                        {
                            Num = 1;
                            Num2 = 0;
                        }
                    }
                }
                if (Num > 0 && Num <= 6)
                {
                    roadLine += li[0];
                    Num++;
                    if (Num > 6)
                    {
                        //重新开始随机
                        Num = 0;
                        flage = true;
                    }
                }
                else
                {
                    flage = false;
                    roadLine += "=";
                    Num2++;
                }
                Console.SetCursorPosition(PointX, PointY);
                Console.Write("".PadRight(width, ' '));
                Console.SetCursorPosition(PointX, PointY);
                Console.Write(roadLine);
            }
        }
    }
}
