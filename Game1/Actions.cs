using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class Actions
    {
        UI ui = new UI();
        public void Damage(Enemy e, int ww, int d, string sr, ref int r, int maxr, Rectangle rmr, ref Rectangle rr, int c)
        {
            r -= c;
            ui.UpdateR(r, maxr, rmr, ref rr, ww, sr);
            e.Hp -= d;
            e.UpdateR(ww);
        }
        public void Heal(int ww, int hpg, string sr, ref int r, int mr, Rectangle rmr, ref Rectangle rr, int c, ref int hp, int maxhp, Rectangle rmh, ref Rectangle rh)
        {
            r -= c;
            ui.UpdateR(r, mr, rmr, ref rr, ww, sr);
            hp += hpg;
            if (hp > maxhp)
                hp = maxhp;
            ui.UpdateR(hp, maxhp, rmh, ref rh, ww, "hp");
        }
        public void Restore(int ww, int rg, string sr, ref int r, int mr, Rectangle rmr, ref Rectangle rr)
        {
            r += rg;
            if (r > mr)
                r = mr;
            ui.UpdateR(r, mr, rmr, ref rr, ww, sr);
        }
    }
}
