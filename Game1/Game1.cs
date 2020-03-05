using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        UI ui = new UI();
        Actions ac = new Actions();
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D pixel;
        SpriteFont text;
        List<Enemy> enemies = new List<Enemy>();
        Rectangle u;
        Rectangle l1;
        Rectangle l3;
        Rectangle l2;
        Rectangle l4;
        Rectangle bl;

        Rectangle r1;
        Rectangle r3;
        Rectangle r2;
        Rectangle r4;
        Rectangle br;

        int maxhp = 100;
        int hp = 100;
        Rectangle rmh;
        Rectangle rh;
        int maxmana = 100;
        int mana = 100;
        Rectangle rmm;
        Rectangle rm;
        int maxstamina = 100;
        int stamina = 100;
        Rectangle rms;
        Rectangle rs;

        KeyboardState oldstate;
        string t;
        string ot;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ui.StartUI(Window.ClientBounds.Width, Window.ClientBounds.Height, ref u, ref l1, ref l2, ref l3, ref l4, ref bl, ref r1, ref r2, ref r3, ref r4, ref br, ref rmh, ref rh, ref rmm, ref rm, ref rms, ref rs);

            t = "r1";
            ot = "r1";

            enemies.Add(new Enemy(Window.ClientBounds.Width));

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pixel = Content.Load<Texture2D>("pixel");
            text = Content.Load<SpriteFont>("Text");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.W) && oldstate.IsKeyUp(Keys.W))
            {
                ui.Move(ref t, "W");
            }
            else if (kstate.IsKeyDown(Keys.S) && oldstate.IsKeyUp(Keys.S))
            {
                ui.Move(ref t, "S");
            }
            else if (kstate.IsKeyDown(Keys.D) && oldstate.IsKeyUp(Keys.D))
            {
                ui.Move(ref t, "D");
            }
            else if (kstate.IsKeyDown(Keys.A) && oldstate.IsKeyUp(Keys.A))
            {
                ui.Move(ref t, "A");
            }
            else if (kstate.IsKeyDown(Keys.T) && oldstate.IsKeyUp(Keys.T))
            {
                ac.Restore(Window.ClientBounds.Width, -10, "hp", ref hp, maxhp, rmh, ref rh);
                ac.Restore(Window.ClientBounds.Width, -10, "mana", ref mana, maxmana, rmm, ref rm);
                ac.Restore(Window.ClientBounds.Width, -10, "stamina", ref stamina, maxstamina, rms, ref rs);
                foreach (var e in enemies)
                {
                    ac.Damage(e, Window.ClientBounds.Width, 10, "Stamina", ref stamina, maxstamina, rms, ref rs, 0);
                }
            }
            else if (kstate.IsKeyDown(Keys.F) && oldstate.IsKeyUp(Keys.F))
            {
                ac.Restore(Window.ClientBounds.Width, maxhp, "hp", ref hp, maxhp, rmh, ref rh);
                ac.Restore(Window.ClientBounds.Width, maxmana, "mana", ref mana, maxmana, rmm, ref rm);
                ac.Restore(Window.ClientBounds.Width, maxstamina, "stamina", ref stamina, maxstamina, rms, ref rs);
                foreach (var e in enemies)
                {
                    e.Hp = e.MaxHp;
                    e.UpdateR(Window.ClientBounds.Width);
                }
            }
            else if (t == "r1" && kstate.IsKeyDown(Keys.Enter) && oldstate.IsKeyUp(Keys.Enter))
            {
                ot = t;
                t = "1l1";
            }
            else if (t == "r2" && kstate.IsKeyDown(Keys.Enter) && oldstate.IsKeyUp(Keys.Enter))
            {
                ot = t;
                t = "2l1";
            }
            else if (t == "r3" && kstate.IsKeyDown(Keys.Enter) && oldstate.IsKeyUp(Keys.Enter))
            {
                ot = t;
                t = "3l1";
            }
            else if (t == "r4" && kstate.IsKeyDown(Keys.Enter))
            {
                Exit();
            }
            else if (t == "1l1" && kstate.IsKeyDown(Keys.Enter) && oldstate.IsKeyUp(Keys.Enter))
            {
                foreach (var e in enemies)
                {
                    ac.Damage(e, Window.ClientBounds.Width, 10, "stamina", ref stamina, maxstamina, rms, ref rs, 0);
                }
                t = "r1";
            }
            else if (t == "1l2" && kstate.IsKeyDown(Keys.Enter) && oldstate.IsKeyUp(Keys.Enter) && stamina >= 10)
            {
                foreach (var e in enemies)
                {
                    ac.Damage(e, Window.ClientBounds.Width, 20, "stamina", ref stamina, maxstamina, rms, ref rs, 10);
                }
                t = "r1";
            }
            else if (t == "1l3" && kstate.IsKeyDown(Keys.Enter) && oldstate.IsKeyUp(Keys.Enter) && stamina >= 10)
            {
                stamina -= 10;
                ui.UpdateR(stamina, maxstamina, rms, ref rs, Window.ClientBounds.Width, "stamina");
                t = "r1";
            }
            else if (t == "1l4" && kstate.IsKeyDown(Keys.Enter) && oldstate.IsKeyUp(Keys.Enter) && stamina >= 30)
            {
                stamina -= 30;
                ui.UpdateR(stamina, maxstamina, rms, ref rs, Window.ClientBounds.Width, "stamina");
                t = "r1";
            }
            else if (t == "2l1" && kstate.IsKeyDown(Keys.Enter) && oldstate.IsKeyUp(Keys.Enter) && mana >= 10)
            {
                foreach (var e in enemies)
                {
                    ac.Damage(e, Window.ClientBounds.Width, 20, "mana", ref mana, maxmana, rmm, ref rm, 10);
                }
                t = "r2";
            }
            else if (t == "2l2" && kstate.IsKeyDown(Keys.Enter) && oldstate.IsKeyUp(Keys.Enter) && mana >= 20 && hp != maxhp)
            {
                ac.Heal(Window.ClientBounds.Width, 10, "mana", ref mana, maxmana, rmm, ref rm, 20, ref hp, maxhp, rmh, ref rh);
                t = "r2";
            }
            else if (t == "2l3" && kstate.IsKeyDown(Keys.Enter) && oldstate.IsKeyUp(Keys.Enter) && mana >= 30)
            {
                mana -= 30;
                ui.UpdateR(mana, maxmana, rmm, ref rm, Window.ClientBounds.Width, "mana");
                t = "r2";
            }
            else if (t == "2l4" && kstate.IsKeyDown(Keys.Enter) && oldstate.IsKeyUp(Keys.Enter) && mana >= 30)
            {
                mana -= 30;
                ui.UpdateR(mana, maxmana, rmm, ref rm, Window.ClientBounds.Width, "mana");
                t = "r2";
            }
            else if (t == "3l1" && kstate.IsKeyDown(Keys.Enter) && oldstate.IsKeyUp(Keys.Enter))
            {
                ac.Restore(Window.ClientBounds.Width, 30, "hp", ref hp, maxhp, rmh, ref rh);
                t = "r3";
            }
            else if (t == "3l2" && kstate.IsKeyDown(Keys.Enter) && oldstate.IsKeyUp(Keys.Enter))
            {
                ac.Restore(Window.ClientBounds.Width, 30, "mana", ref mana, maxmana, rmm, ref rm);
                t = "r3";
            }
            else if (t == "3l3" && kstate.IsKeyDown(Keys.Enter) && oldstate.IsKeyUp(Keys.Enter))
            {
                ac.Restore(Window.ClientBounds.Width, 30, "stamina", ref stamina, maxstamina, rms, ref rs);
                t = "r3";
            }
            else if (kstate.IsKeyDown(Keys.Back) && oldstate.IsKeyUp(Keys.Back))
            {
                t = ot;
            }
            else if (kstate.IsKeyDown(Keys.N) && oldstate.IsKeyDown(Keys.N) && enemies.Count == 0)
            {
                enemies.Add(new Enemy(Window.ClientBounds.Width));
            }
            oldstate = Keyboard.GetState();

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].Hp < 0 || enemies[i].Rh < 1)
                {
                    enemies.RemoveAt(i);
                }
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(pixel, u, Color.White);
            if (t == "r1" || t == "r2" || t == "r3" || t == "r4")
            {
                spriteBatch.Draw(pixel, bl, Color.Black);
            }
            else
            {
                spriteBatch.Draw(pixel, l1, Color.Black);
                spriteBatch.Draw(pixel, l2, Color.Black);
                spriteBatch.Draw(pixel, l3, Color.Black);
                spriteBatch.Draw(pixel, l4, Color.Black);
            }

            foreach (var e in enemies)
            {
                e.Draw(spriteBatch, pixel);
            }

            if (t == "r1" || t == "r2" || t == "r3" || t == "r4")
            {
                spriteBatch.Draw(pixel, r1, Color.Black);
                spriteBatch.Draw(pixel, r2, Color.Black);
                spriteBatch.Draw(pixel, r3, Color.Black);
                spriteBatch.Draw(pixel, r4, Color.Black);
            }
            else
            {
                spriteBatch.Draw(pixel, br, Color.Black);
            }
            ui.Write(spriteBatch, text, t, r1, r2, r3, r4, br, l1, l2, l3, l4);

            spriteBatch.Draw(pixel, rmm, Color.Black);
            spriteBatch.Draw(pixel, rmh, Color.Black);
            spriteBatch.Draw(pixel, rms, Color.Black);
            spriteBatch.Draw(pixel, rm, Color.Blue);
            spriteBatch.Draw(pixel, rh, Color.Red);
            spriteBatch.Draw(pixel, rs, Color.Green);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
