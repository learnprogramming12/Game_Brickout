using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Assignment2Prj
{
    internal class BombDamage
    {
        //the bricks will disappear from around the bomb to outside if its damagelevel is not Self and All.
        static public void ResponseToBomb(Brick brick, BrickMatrix matrix)
        {
            switch(brick.DamageLevel)
            {
                case DamageLevel.Self:
                case DamageLevel.Quarter:
                case DamageLevel.Third:
                case DamageLevel.Half:
                    break;
                case DamageLevel.All:
                    for (int i = 0; i < matrix.Bricks.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.Bricks.GetLength(1); j++)
                        {
                            matrix.Bricks[i, j].Visible = false;
                        }
                    }
                    break;
            }
        }
    }
}
