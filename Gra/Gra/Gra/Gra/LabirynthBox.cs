using Gra;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gra
{
    public class LabirynthBox
    {
        bool Up;
        bool Down;
        bool Left;
        bool Right;
        string Id;
        public LabirynthBox(bool Up, bool Down, bool Left, bool Right, string id)
        {
            this.Up = Up;
            this.Down = Down;
            this.Left = Left;
            this.Right = Right;
            Id = id;
        }
        public void CheckCollision(LabirynthBox l, string wall)
        {
            if (wall == "Up")
            {
                if (l.Up == false)
                {
                    //kolizja
                }
                else
                {
                    //Przejdz w gore
                }
            }
            else if(wall == "Down")
            {
                if (l.Down == false)
                {
                    //kolizja
                }
                else{
                    //Przejdz w dol
                }
            }
            else if(wall== "Left")
            {
                if (l.Left == false)
                {
                    //kolizja
                }
                else
                {
                    //Przejdz w dol
                }
            }
            else if (wall =="Right")
            {
                if (l.Right == false)
                {
                    //kolizja
                }
                else
                {
                    //Przejdz w dol
                }
            }
        }
    }
}
