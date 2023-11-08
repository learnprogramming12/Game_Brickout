using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2Prj
{
    public enum DamageLevel
    {
        Self = 0,
        Quarter,
        Third,
        Half,
        All
    }
    internal class Brick : PictureBox
    {
        public class BrickFirmnessChangeEventArgs : EventArgs 
        {
            public int Firmness;
            public DamageLevel DamageLevel;

            public BrickFirmnessChangeEventArgs(int iFirmness, DamageLevel damageLevel = DamageLevel.Self)
            {
                Firmness = iFirmness;
            }
            
        }
        public delegate void BrickFirmnessChangeEventHandler(object sender, BrickFirmnessChangeEventArgs e);
        public event BrickFirmnessChangeEventHandler BrickFirmnessChange;

        protected int _firmness;
        protected DamageLevel _damageLevel;

        public Brick(int firmness, DamageLevel level = DamageLevel.Self) 
        { 
            _firmness = firmness;
            _damageLevel = level;
        }
        public int Firmness
        {
            get { return _firmness; }
            set
            {
                _firmness = value;
                if (_firmness == 0)
                {
                    Visible = false;
                    if (BrickFirmnessChange != null)
                    {
                        BrickFirmnessChangeEventArgs args = new BrickFirmnessChangeEventArgs(_firmness);
                        this.BrickFirmnessChange(this, args);
                    }
                }
            }
        } 
        public DamageLevel DamageLevel 
        { 
            get { 
                return _damageLevel; }
            set
            {
                _damageLevel = value;
            }
        }
    }
    internal class BombBrick : Brick
    { 
        public BombBrick(DamageLevel level = DamageLevel.Quarter):base(1)
        {
            _damageLevel = level;
        }
    } 
}
