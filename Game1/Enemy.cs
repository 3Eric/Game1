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
    class Enemy
    {
        int maxhp;
        int hp;
        Rectangle u;
        Rectangle rmh;
        Rectangle rh;
        Rectangle e;
        
        public Enemy(int ww)
        {
            u = new Rectangle(ww / 2 - ww / 4, 0, ww / 2, 42);
            rmh = new Rectangle(u.X + 6, 6, u.Width - 12, 30);
            rh = new Rectangle(rmh.X, rmh.Y, rmh.Width, rmh.Height);
            e = new Rectangle(ww / 2 - ww / 12, 50, ww / 6, ww / 4);
            maxhp = 100;
            hp = maxhp;
        }

        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public int MaxHp
        {
            get { return maxhp; }
        }
        public int Rh
        {
            get { return rh.Width; }
        }
        public void UpdateR(int ww)
        {
            rh.Width = hp * 100 / maxhp * rmh.Width / 100;
            rh.X = ww / 2 - rh.Width / 2;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D p)
        {
            spriteBatch.Draw(p, u, Color.White);
            spriteBatch.Draw(p, rmh, Color.Black);
            spriteBatch.Draw(p, rh, Color.Red);
            spriteBatch.Draw(p, e, Color.Brown);
        }
    }
}
