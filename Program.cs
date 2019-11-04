using JumpGame.GameObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace JumpGame
{
    class Program
    {
        static readonly List<Road> liR = new List<Road>();
        static readonly List<Hero> liH = new List<Hero>();
        static readonly List<Kidnapper> liK = new List<Kidnapper>();
        static readonly RestartWindow restart = new RestartWindow(55, 20);
        static bool jumped { get; set; }
        static bool jumped2 { get; set; }

        static bool jump1 { get; set; }
        static bool jump2 { get; set; }
        static DateTime time1 = DateTime.Now;
        static DateTime time2 = DateTime.Now;

        static bool state { get; set; }
        static bool state2 { get; set; }
        static bool restartF { get; set; }
        static bool escTo { get; set; }
        static bool over1 { get; set; }
        static bool over2 { get; set; }

        static bool successState1 { get; set; }
        static bool successState2 { get; set; }

        static void Main(string[] args)
        {
            Console.Title = "Please hold on!";
            Initialze();
        }

        static void PlayGame(int x, int y, int x2, int y2)
        {
            var dt = DateTime.Now;
            var d = dt - time1;
            var date = d.ToString();
            if (state && !over1)
            {
                Console.SetCursorPosition(Console.WindowWidth - 20, 2);
                Console.Write(date);
            }
            if (state2 && !over2)
            {
                Console.SetCursorPosition(Console.WindowWidth - 20, 22);
                Console.Write(date);
            }
            if (time2.AddSeconds(1) < dt)
            {
                if (state && !over1)
                {
                    liK[0].setKidnapper(1);
                    GetState1();
                    if (!state)
                    {
                        PrintPlay1(x, y);
                        over1 = true;
                        //显示Game over
                        new GameOver(30, 6, date);
                    }
                    GetSuccessState1();
                    if (successState1)
                    {
                        over1 = true;
                        //显示success Over
                        new SuccessOver(30, 6, date);
                    }
                }
                if (state2 && !over2)
                {
                    liK[1].setKidnapper(1);
                    GetState2();
                    if (!state2)
                    {
                        PrintPlay2(x2, y2);
                        over2 = true;
                        //显示Game over
                        new GameOver(30, 26, date);
                    }
                    GetSuccessState2();
                    if (successState2)
                    {
                        over1 = true;
                        //显示success Over
                        new SuccessOver(30, 26, date);
                    }
                }


                time2 = dt;
            }
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.I && jumped2)
                {
                    if (state2)
                    {
                        jump2 = true;
                        jumped2 = false;
                        liK[1].setKidnapper(-1);
                        PrintPlay2(x2, y2);
                        //跳一次走8步
                        for (int i = 0; i < 8; i++)
                        {
                            liR[1].SetRoad();
                        }
                        Thread.Sleep(500);
                        PrintPlay2(x2, y2);
                        GetState2();
                        if (!state2)
                        {
                            PrintPlay2(x2, y2 + 3);
                            over2 = true;
                            //显示Game over
                            new GameOver(30, 26, date);
                        }
                        GetSuccessState2();
                        if (successState2)
                        {
                            over1 = true;
                            //显示success Over
                            new SuccessOver(30, 26, date);
                        }
                    }
                }
                else if (key == ConsoleKey.W && jumped)
                {
                    if (state)
                    {
                        jump1 = true;
                        jumped = false;
                        liK[0].setKidnapper(-1);
                        PrintPlay1(x, y);
                        //跳一次走8步
                        for (int i = 0; i < 8; i++)
                        {
                            liR[0].SetRoad();
                        }
                        Thread.Sleep(500);
                        PrintPlay1(x, y);
                        GetState1();
                        if (!state)
                        {
                            PrintPlay1(x, y + 3);
                            over1 = true;
                            //显示Game over
                            new GameOver(30, 6, date);
                        }
                        GetSuccessState1();
                        if (successState1)
                        {
                            over1 = true;
                            //显示success Over
                            new SuccessOver(30, 6, date);
                        }
                    }
                }
                else if (key == ConsoleKey.L)
                {
                    if (state2)
                    {
                        liK[1].setKidnapper(-1);
                        PrintPlay2(x2, y2);
                        //前进一次走三步
                        for (int i = 0; i < 2; i++)
                        {
                            liR[1].SetRoad();
                        }
                        GetState2();
                        if (!state2)
                        {
                            PrintPlay2(x2, y2 + 3);
                            over2 = true;
                            //显示Game over
                            new GameOver(30, 26, date);
                        }
                        GetSuccessState2();
                        if (successState2)
                        {
                            over1 = true;
                            //显示success Over
                            new SuccessOver(30, 26, date);
                        }
                    }
                }
                else if (key == ConsoleKey.D)
                {
                    if (state)
                    {
                        liK[0].setKidnapper(-1);
                        PrintPlay1(x, y);
                        //前进一次走三步
                        for (int i = 0; i < 2; i++)
                        {
                            liR[0].SetRoad();
                        }
                        GetState1();
                        if (!state)
                        {
                            PrintPlay1(x, y + 3);
                            over1 = true;
                            //显示Game over
                            new GameOver(30, 6, date);
                        }
                        GetSuccessState1();
                        if (successState1)
                        {
                            over1 = true;
                            //显示success Over
                            new SuccessOver(30, 6, date);
                        }
                    }
                }
                else if (key == ConsoleKey.Escape)
                {
                    //出现选择重新开始或退出
                    state = false;
                    state2 = false;
                    successState1 = false;
                    successState2 = false;
                    escTo = true;
                    restart.Initailze();
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    restart.setArrows(false);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    restart.setArrows(true);
                }else if (key == ConsoleKey.Enter)
                {
                    //flage为false时则是Yes
                    if (!restart.flage && escTo)
                    {
                        restartF = true;
                        liR.Clear();
                        liH.Clear();
                        liK.Clear();
                        escTo = false;
                    }
                    else if (restart.flage && escTo)
                    {
                        restartF = false;
                        if (!over1)
                        {
                            state = true;
                        }
                        if (!over2)
                        {
                            state2 = true;
                        }
                        escTo = false;
                        restart.ClearAll();
                    }
                }
            }
        }
        static void PrintPlay1(int x, int y)
        {
            int oldY = y;
            if (jump1)
            {
                y -= 4;
                jump1 = false;
            }
            else
            {
                y = oldY;
                jumped = true;
            }
            liH[0].setHero(x, y);
        }

        static void PrintPlay2(int x, int y)
        {
            int oldY = y;
            if (jump2)
            {
                y -= 4;
                jump2 = false;
            }
            else
            {
                y = oldY;
                jumped2 = true;
            }
            liH[1].setHero(x, y);
        }

        static void Initialze()
        {
            Console.Clear();
            Console.BufferHeight = 40;
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(120, 40);
            int left = Console.WindowLeft;
            int top = Console.WindowTop;
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            jumped = true;
            jumped2 = true;
            state = true;
            state2 = true;
            successState1 = false;
            successState2 = false;
            GetHero(left, top, width, height);
            GetRoad(left, top, width, height);
            GetKidnapper(left, top, width, height);
            new Hill(5, 3);
            new Hill(18, 6);
            new Hill(50, 4);
            new Hill(75, 4);
            new Hill(90, 6);
            new Hill(5, 23);
            new Hill(18, 26);
            new Hill(50, 24);
            new Hill(75, 24);
            new Hill(90, 26);
            int x = liH[0].PointX;
            int y = liH[0].PointY;
            int x2 = liH[1].PointX;
            int y2 = liH[1].PointY;
            jump1 = false;
            jump2 = false;
            restartF = false;
            over1 = false;
            over2 = false;
            while (true)
            {
                //处理操作人员的键盘内容
                PlayGame(x, y, x2, y2);
                if (restartF)
                {
                    Console.Clear();
                    break;
                }
            }
            Initialze();
        }

        /// <summary>
        /// 设置劫匪的位置
        /// </summary>
        /// <param name="PoinX"></param>
        /// <param name="PointY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        static void GetKidnapper(int PoinX, int PointY, int width, int height)
        {
            int x = width - 10;
            int y = 10;
            liK.Add(new Kidnapper(x, y));
            liK.Add(new Kidnapper(x, y + 20));
        }
        /// <summary>
        /// 设置英雄人物的位置
        /// </summary>
        /// <param name="PointX"></param>
        /// <param name="PointY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        static void GetHero(int PointX, int PointY, int width, int height)
        {
            int StartX1 = 0;
            int StartY1 = 0;
            int StartX2 = 0;
            int StartY2 = 0;
            StartX1 = 10;
            StartX2 = 10;
            StartY1 = 12;
            StartY2 = 32;
            int startX1 = PointX + StartX1;
            int startY1 = PointY + StartY1;
            int startX2 = PointX + StartX2;
            int startY2 = PointY + StartY2;
            var hero1 = new Hero(startX1, startY1);
            var hero2 = new Hero(startX2, startY2);
            liH.Add(hero1);
            liH.Add(hero2);
        }

        /// <summary>
        /// 设置road线条
        /// </summary>
        /// <param name="PointX"></param>
        /// <param name="PointY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        static void GetRoad(int PointX, int PointY, int width, int height)
        {
            int StartX1 = 0;
            int StartY1 = 0;
            int StartX2 = 0;
            int StartY2 = 0;
            StartX1 = 0;
            StartX2 = 0;
            StartY1 = 15;
            StartY2 = 35;
            int startX1 = PointX + StartX1;
            int startY1 = PointY + StartY1;
            int startX2 = PointX + StartX2;
            int startY2 = PointY + StartY2;
            var road1 = new Road(startX1, startY1, width);
            var road2 = new Road(startX2, startY2, width);
            liR.Add(road1);
            liR.Add(road2);
        }
        /// <summary>
        /// the first hero's state
        /// </summary>
        static void GetState1()
        {
            if (liH[0].PointY + 3 == liR[0].PointY)
            {
                string s = liR[0].roadLine.Substring(liH[0].PointX+2, 1);
                if (s == " ")
                {
                    state = false;
                    return;
                }
            }
            if (liK[0].PointX == Console.WindowWidth)
                state = false;
            else
                state = true;
        }
        /// <summary>
        /// the second hero's state
        /// </summary>
        static void GetState2()
        {
            if (liH[1].PointY + 3 == liR[1].PointY)
            {
                string s = liR[1].roadLine.Substring(liH[1].PointX+2, 1);
                if (s == " ")
                {
                    state2 = false;
                    return;
                }
            }
            if (liK[1].PointX == Console.WindowWidth)
                state2 = false;
            else
                state2 = true;
        }

        /// <summary>
        /// if the hero catch the kidnapper,it's success
        /// </summary>
        static void GetSuccessState1()
        {
            if (liH[0].PointX >= liK[0].PointX)
                successState1 = true;
            else
                successState1 = false;
        }
        /// <summary>
        /// if the hero catch the kidnapper,it's success
        /// </summary>
        static void GetSuccessState2()
        {
            if (liH[1].PointX >= liK[1].PointX)
                successState2 = true;
            else
                successState2 = false;
        }
    }
}
