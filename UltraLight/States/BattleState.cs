using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using UltraLight.Effects;
using UltraLight.Entities;
using UltraLight.Globals;
using UltraLight.UI;

namespace UltraLight.States
{
    public class BattleState : State
    {
        public Hero hero;
        public Hud hud;
        public StarField starField;
        public EntityGroup entityGroup1;
        public EntityGroup entityGroup2;
        public List<Baddie> baddies = new List<Baddie>();
        public List<Particle> particles = new List<Particle>();
        private bool win;
        public ProjectilePool projectilePool;

        public BattleState(StateStack stateStack)
        {
            entityGroup1 = new EntityGroup();
            entityGroup2 = new EntityGroup();
            hero = ShipDefs.UL1(64, 118, this);
            entityGroup1.Add(hero);
            hud = new Hud(hero);
            starField = new StarField();
            projectilePool = new ProjectilePool(this);
            this.stateStack = stateStack;
        }

        public void AddBaddies()
        {
            Baddie baddie = ShipDefs.HC(64, 20, this);
            baddies.Add(baddie);
            entityGroup1.Add(baddie);
            entityGroup2.Add(baddie);
        }

        public override bool Update(float dt)
        {
            for (int i = particles.Count - 1; i >= 0; i--)
            {
                particles[i].Update(dt);
                if (particles[i].remove)
                {
                    particles.RemoveAt(i);
                }
            }

            if (win)
            {
                if (particles.Count == 0)
                    stateStack.Push(new WinState(stateStack));
                return false;
            }
            else if (hero.hp <= 0)
            {
                if (particles.Count == 0)
                    stateStack.Push(new GameOverState(stateStack));
                return false;
            }

            starField.Update(dt);
            entityGroup1.Update(dt);
            entityGroup2.Update(dt);
            for (int i = baddies.Count - 1; i >= 0; i--)
            {
                if (baddies[i].remove)
                {
                    baddies.RemoveAt(i);
                }
                if (baddies.Count == 0)
                {
                    if (GameState.wave == 4)
                    {
                        win = true;
                    }
                    else
                    {
                        GameState.wave++;
                        stateStack.Push(new WaveTransState(stateStack));
                    }
                }
            }

            return false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            starField.Draw(spriteBatch);
            hud.Draw(spriteBatch);
            projectilePool.Draw(spriteBatch);

            if (hero.hp > 0)
                hero.Draw(spriteBatch);

            foreach (Baddie baddie in baddies)
            {
                baddie.Draw(spriteBatch);
            }
            foreach (Particle particle in particles)
            {
                particle.Draw(spriteBatch);
            }
        }

        public override void HandleInput()
        {
            if (Input.JustPressed(Keys.X))
            {
                hero.hp--;
            }

            if (Input.JustPressed(Keys.P))
            {
                stateStack.Push(new PauseState(stateStack));
            }
        }

        public void Explode(Vector2 position, bool isBlue = false, bool isSpark = false)
        {
            if (isSpark == true)
            {
                for (int i = 0; i < 20; i++)
                {
                    particles.Add(new Explosion(position, false, true));
                }
                return;
            }
            Explosion explosion = new Explosion(position, isBlue);
            explosion.sprite = Game1.myContent.Load<Texture2D>("Art/particle1");
            explosion.anim = new Animation(new int[] { 6, 6, 5, 4, 3, 2, 1, 0, 0 }, false, 0.1f);
            explosion.time = 0;
            explosion.timer = 0;
            explosion.speed = Vector2.Zero;
            particles.Add(explosion);

            for (int i = 0; i < 30; i++)
            {
                particles.Add(new Explosion(position, isBlue));
            }
        }

        public void ShockW(Vector2 position, bool isBig = false)
        {
            Shockwave shockwave = new Shockwave(position, isBig);
            particles.Add(shockwave);
        }

        public void HitSparks(Vector2 position)
        {
            Explosion exp = new Explosion(position, false, true);
            exp.speed.X = (int)Util.GetRandomNumber(-150, 150);
            exp.speed.Y = (int)Util.GetRandomNumber(-250, 0);
            particles.Add(exp);
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }
    }
}