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
    class UI
    {
        public void StartUI(int ww, int wh, ref Rectangle u, ref Rectangle l1, ref Rectangle l2, ref Rectangle l3, ref Rectangle l4, ref Rectangle bl, ref Rectangle r1, ref Rectangle r2, ref Rectangle r3, ref Rectangle r4, ref Rectangle b, ref Rectangle rmh, ref Rectangle rh, ref Rectangle rmm, ref Rectangle rm, ref Rectangle rms, ref Rectangle rs)
        {
            u = new Rectangle(0, wh - wh / 3 - 32, ww, wh / 3 + 32);

            l2 = new Rectangle(ww / 2 - (ww / 3 - 9) / 2, u.Y + 32, ww / 3 - 9, (u.Height - 38) / 2 - 3);
            l1 = new Rectangle(l2.X - l2.Width - 6, l2.Y, l2.Width, l2.Height);
            l4 = new Rectangle(l2.X, l2.Y + l2.Height + 6, l2.Width, l2.Height);
            l3 = new Rectangle(l2.X - l2.Width - 6, l2.Y + l2.Height + 6, l2.Width, l2.Height);
            bl = new Rectangle(l1.X, l1.Y, l2.Width * 2 + 6, l2.Height * 2 + 6);

            r1 = new Rectangle(l2.X + l2.Width + 6, l2.Y, (l2.Width / 2) - 3, l2.Height);
            r2 = new Rectangle(r1.X + r1.Width + 6, r1.Y, r1.Width, r1.Height);
            r3 = new Rectangle(r1.X, r1.Y + r1.Height + 6, r1.Width, r1.Height);
            r4 = new Rectangle(r1.X + r1.Width + 6, r1.Y + r1.Height + 6, r1.Width, r1.Height);
            b = new Rectangle(r1.X, r1.Y, r1.Width * 2 + 6, r1.Height * 2 + 6);

            rmh = new Rectangle(ww / 2 - (ww / 3 - 9) / 2, u.Y + 6, ww / 3 - 9, 20);
            rh = new Rectangle(rmh.X, rmh.Y, rmh.Width, rmh.Height);
            rmm = new Rectangle(rmh.X - rmh.Width - 6, rmh.Y, rmh.Width, rmh.Height);
            rm = new Rectangle(rmm.X, rmm.Y, rmm.Width, rmm.Height);
            rms = new Rectangle(rmh.X + rmh.Width + 6, rmh.Y, rmh.Width, rmh.Height);
            rs = new Rectangle(rms.X, rms.Y, rms.Width, rms.Height);
        }
        public void UpdateR(int r, int maxr, Rectangle rmr, ref Rectangle rr, int ww, string t)
        {
            if (t == "hp")
            {
                rr.Width = r * 100 / maxr * rmr.Width / 100;
                rr.X = ww / 2 - rr.Width / 2;
            }
            else if (t == "mana")
            {
                rr.Width = r * 100 / maxr * rmr.Width / 100;
            }
            else if (t == "stamina")
            {
                rr.Width = r * 100 / maxr * rmr.Width / 100;
                rr.X = rmr.X + (rmr.Width - rr.Width);
            }
        }
        public void Move(ref string t, string k)
        {
            if ((t == "r1" && k == "S") || (t == "r4" && k == "A"))
            {
                t = "r3";
            }
            else if ((t == "r2" && k == "S") || (t == "r3" && k == "D"))
            {
                t = "r4";
            }
            else if ((t == "r3" && k == "W") || (t == "r2" && k == "A"))
            {
                t = "r1";
            }
            else if ((t == "r4" && k == "W") || (t == "r1" && k == "D"))
            {
                t = "r2";
            }
            // r1
            else if ((t == "1l1" && k == "S") || (t == "1l4" && k == "A"))
            {
                t = "1l3";
            }
            else if ((t == "1l2" && k == "S") || (t == "1l3" && k == "D"))
            {
                t = "1l4";
            }
            else if ((t == "1l3" && k == "W") || (t == "1l2" && k == "A"))
            {
                t = "1l1";
            }
            else if ((t == "1l4" && k == "W") || (t == "1l1" && k == "D"))
            {
                t = "1l2";
            }
            // r2
            else if ((t == "2l1" && k == "S") || (t == "2l4" && k == "A"))
            {
                t = "2l3";
            }
            else if ((t == "2l2" && k == "S") || (t == "2l3" && k == "D"))
            {
                t = "2l4";
            }
            else if ((t == "2l3" && k == "W") || (t == "2l2" && k == "A"))
            {
                t = "2l1";
            }
            else if ((t == "2l4" && k == "W") || (t == "2l1" && k == "D"))
            {
                t = "2l2";
            }
            // r3
            else if ((t == "3l1" && k == "S") || (t == "3l4" && k == "A"))
            {
                t = "3l3";
            }
            else if ((t == "3l2" && k == "S") || (t == "3l3" && k == "D"))
            {
                t = "3l4";
            }
            else if ((t == "3l3" && k == "W") || (t == "3l2" && k == "A"))
            {
                t = "3l1";
            }
            else if ((t == "3l4" && k == "W") || (t == "3l1" && k == "D"))
            {
                t = "3l2";
            }
        }
        public void Write(SpriteBatch spriteBatch, SpriteFont text, string t, Rectangle r1, Rectangle r2, Rectangle r3, Rectangle r4, Rectangle br, Rectangle l1, Rectangle l2, Rectangle l3, Rectangle l4)
        {
            if (t == "r1" || t == "r2" || t == "r3" || t == "r4")
            {
                spriteBatch.DrawString(text, "Mele", new Vector2(r1.X + r1.Width / 2 - text.LineSpacing * 2, r1.Y + r1.Height / 2 - text.LineSpacing), Color.White);
                spriteBatch.DrawString(text, "Spells", new Vector2(r2.X + r2.Width / 2 - text.LineSpacing * 3, r2.Y + r2.Height / 2 - text.LineSpacing), Color.White);
                spriteBatch.DrawString(text, "Bag", new Vector2(r3.X + r3.Width / 2 - text.LineSpacing * 3 / 2, r3.Y + r3.Height / 2 - text.LineSpacing), Color.White);
                spriteBatch.DrawString(text, "Quit", new Vector2(r4.X + r4.Width / 2 - text.LineSpacing * 2, r4.Y + r4.Height / 2 - text.LineSpacing), Color.White);
                if (t == "r1")
                {
                    spriteBatch.DrawString(text, ">    <", new Vector2(r1.X + r1.Width / 2 - text.LineSpacing * 3, r1.Y + r1.Height / 2 - text.LineSpacing), Color.White);
                }
                else if (t == "r2")
                {
                    spriteBatch.DrawString(text, ">      <", new Vector2(r2.X + r2.Width / 2 - text.LineSpacing * 4, r2.Y + r2.Height / 2 - text.LineSpacing), Color.White);
                }
                else if (t == "r3")
                {
                    spriteBatch.DrawString(text, ">   <", new Vector2(r3.X + r3.Width / 2 - text.LineSpacing * 5 / 2, r3.Y + r3.Height / 2 - text.LineSpacing), Color.White);
                }
                else
                {
                    spriteBatch.DrawString(text, ">    <", new Vector2(r4.X + r4.Width / 2 - text.LineSpacing * 3, r4.Y + r4.Height / 2 - text.LineSpacing), Color.White);
                }
            }
            else if (t == "1l1" || t == "1l2" || t == "1l3" || t == "1l4")
            {
                spriteBatch.DrawString(text, "Light", new Vector2(l1.X + l1.Width / 2 - text.LineSpacing * 5 / 2, l1.Y + l1.Height / 2 - text.LineSpacing), Color.White);
                spriteBatch.DrawString(text, "Heavy", new Vector2(l2.X + l2.Width / 2 - text.LineSpacing * 5 / 2, l2.Y + l2.Height / 2 - text.LineSpacing), Color.White);
                spriteBatch.DrawString(text, "Block", new Vector2(l3.X + l3.Width / 2 - text.LineSpacing * 5 / 2, l3.Y + l3.Height / 2 - text.LineSpacing), Color.White);
                spriteBatch.DrawString(text, "Disarm", new Vector2(l4.X + l4.Width / 2 - text.LineSpacing * 3, l4.Y + l4.Height / 2 - text.LineSpacing), Color.White);
                spriteBatch.DrawString(text, "Do a:", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 2, br.Y + br.Height / 3 - text.LineSpacing), Color.White);
                spriteBatch.DrawString(text, "Cost: ", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 3, br.Y + br.Height / 2 + text.LineSpacing), Color.White);
                if (t == "1l1")
                {
                    spriteBatch.DrawString(text, ">     <", new Vector2(l1.X + l1.Width / 2 - text.LineSpacing * 7 / 2, l1.Y + l1.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "Light Attack", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 6, br.Y + br.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "     0", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 3, br.Y + br.Height / 2 + text.LineSpacing), Color.Green);
                }
                else if (t == "1l2")
                {
                    spriteBatch.DrawString(text, ">     <", new Vector2(l2.X + l2.Width / 2 - text.LineSpacing * 7 / 2, l2.Y + l2.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "Heavy Attack", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 6, br.Y + br.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "     10", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 3, br.Y + br.Height / 2 + text.LineSpacing), Color.Green);
                }
                else if (t == "1l3")
                {
                    spriteBatch.DrawString(text, ">     <", new Vector2(l3.X + l3.Width / 2 - text.LineSpacing * 7 / 2, l3.Y + l3.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "Block", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 5 / 2, br.Y + br.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "     10", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 3, br.Y + br.Height / 2 + text.LineSpacing), Color.Green);
                }
                else
                {
                    spriteBatch.DrawString(text, ">      <", new Vector2(l4.X + l4.Width / 2 - text.LineSpacing * 4, l4.Y + l4.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "Disarm", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 3, br.Y + br.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "     30", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 3, br.Y + br.Height / 2 + text.LineSpacing), Color.Green);
                }
            }
            else if (t == "2l1" || t == "2l2" || t == "2l3" || t == "2l4")
            {
                spriteBatch.DrawString(text, "Fireball", new Vector2(l1.X + l1.Width / 2 - text.LineSpacing * 4, l1.Y + l1.Height / 2 - text.LineSpacing), Color.White);
                spriteBatch.DrawString(text, "Heal", new Vector2(l2.X + l2.Width / 2 - text.LineSpacing * 2, l2.Y + l2.Height / 2 - text.LineSpacing), Color.White);
                spriteBatch.DrawString(text, "Spellshield", new Vector2(l3.X + l3.Width / 2 - text.LineSpacing * 11 / 2, l3.Y + l3.Height / 2 - text.LineSpacing), Color.White);
                spriteBatch.DrawString(text, "Silence", new Vector2(l4.X + l4.Width / 2 - text.LineSpacing * 7 / 2, l4.Y + l4.Height / 2 - text.LineSpacing), Color.White);
                spriteBatch.DrawString(text, "Cast:", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 5 / 2, br.Y + br.Height / 3 - text.LineSpacing), Color.White);
                spriteBatch.DrawString(text, "Cost: ", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 3, br.Y + br.Height / 2 + text.LineSpacing), Color.White);
                if (t == "2l1")
                {
                    spriteBatch.DrawString(text, ">        <", new Vector2(l1.X + l1.Width / 2 - text.LineSpacing * 5, l1.Y + l1.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "Fireball", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 4, br.Y + br.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "     10", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 3, br.Y + br.Height / 2 + text.LineSpacing), Color.Blue);
                }
                else if (t == "2l2")
                {
                    spriteBatch.DrawString(text, ">    <", new Vector2(l2.X + l2.Width / 2 - text.LineSpacing * 3, l2.Y + l2.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "Heal", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 2, br.Y + br.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "     20", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 3, br.Y + br.Height / 2 + text.LineSpacing), Color.Blue);
                }
                else if (t == "2l3")
                {
                    spriteBatch.DrawString(text, ">           <", new Vector2(l3.X + l3.Width / 2 - text.LineSpacing * 13 / 2, l3.Y + l3.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "Spellshield", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 11 / 2, br.Y + br.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "     30", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 3, br.Y + br.Height / 2 + text.LineSpacing), Color.Blue);
                }
                else
                {
                    spriteBatch.DrawString(text, ">       <", new Vector2(l4.X + l4.Width / 2 - text.LineSpacing * 9 / 2, l4.Y + l4.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "Silence", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 7 / 2, br.Y + br.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "     30", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 3, br.Y + br.Height / 2 + text.LineSpacing), Color.Blue);
                }
            }
            else if (t == "3l1" || t == "3l2" || t == "3l3" || t == "3l4")
            {
                spriteBatch.DrawString(text, "Healing", new Vector2(l1.X + l1.Width / 2 - text.LineSpacing * 7 / 2, l1.Y + l1.Height / 2 - text.LineSpacing), Color.White);
                spriteBatch.DrawString(text, "Mana", new Vector2(l2.X + l2.Width / 2 - text.LineSpacing * 2, l2.Y + l2.Height / 2 - text.LineSpacing), Color.White);
                spriteBatch.DrawString(text, "Stamina", new Vector2(l3.X + l3.Width / 2 - text.LineSpacing * 7 / 2, l3.Y + l3.Height / 2 - text.LineSpacing), Color.White);
                spriteBatch.DrawString(text, "", new Vector2(l4.X + l4.Width / 2 - text.LineSpacing * 1, l4.Y + l4.Height / 2 - text.LineSpacing), Color.White);
                spriteBatch.DrawString(text, "Consume a:", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 5, br.Y + br.Height / 3 - text.LineSpacing), Color.White);
                spriteBatch.DrawString(text, "Restores: ", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 5, br.Y + br.Height / 2 + text.LineSpacing), Color.White);
                if (t == "3l1")
                {
                    spriteBatch.DrawString(text, ">       <", new Vector2(l1.X + l1.Width / 2 - text.LineSpacing * 9 / 2, l1.Y + l1.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "Healing Potion", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 7, br.Y + br.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "         30", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 5, br.Y + br.Height / 2 + text.LineSpacing), Color.Red);
                }
                else if (t == "3l2")
                {
                    spriteBatch.DrawString(text, ">    <", new Vector2(l2.X + l2.Width / 2 - text.LineSpacing * 3, l2.Y + l2.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "Mana Potion", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 11 / 2, br.Y + br.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "         30", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 5, br.Y + br.Height / 2 + text.LineSpacing), Color.Blue);
                }
                else if (t == "3l3")
                {
                    spriteBatch.DrawString(text, ">       <", new Vector2(l3.X + l3.Width / 2 - text.LineSpacing * 9 / 2, l3.Y + l3.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "Stamina Potion", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 7, br.Y + br.Height / 2 - text.LineSpacing), Color.White);
                    spriteBatch.DrawString(text, "         30", new Vector2(br.X + br.Width / 2 - text.LineSpacing * 5, br.Y + br.Height / 2 + text.LineSpacing), Color.Green);
                }
            }
        }
    }
}
