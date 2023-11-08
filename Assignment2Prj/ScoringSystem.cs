using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2Prj
{
    internal class ScoringSystem
    {
        //In order to add pleasure, the points are fixed according to bomb's type. In this way, players can leave the bomb to hit at the end,
        //but it increase the possiblity of failure. This is not a fair scoring system just for fun. Maybe using less time to win the game
        //is more pleasure by controlling the bouncing angle using paddle.
        public static int GetScoring(Brick brick)
        {
            if(brick == null) return 0;
            int iScoring = 0;
            switch (brick.DamageLevel)
            {
                case DamageLevel.Self:
                    {
                        iScoring += 10;
                        if (brick.Firmness <= 0)
                            iScoring += 5;
                    }
                    break;
                case DamageLevel.Quarter:
                    iScoring = 200;
                    break;
                case DamageLevel.Third:
                    iScoring = 400;
                    break;
                case DamageLevel.Half:
                    iScoring = 600;
                    break;
                case DamageLevel.All:
                    iScoring = 800;
                    break;
            }
            return iScoring;
        }
    }
}
