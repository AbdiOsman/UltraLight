using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace UltraLight
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

        public ProjectilePool projectilePool;

        private Random rnd = new Random();

        public static Color color = Color.White;

        public BattleState(StateStack stateStack)
        {
            entityGroup1 = new EntityGroup();
            entityGroup2 = new EntityGroup();

            rnd = new Random();

            hero = ShipDefs.UL1(64, 118, this);
            entityGroup1.Add(hero);

            AddBaddies();

            hud = new Hud(hero);
            starField = new StarField();

            projectilePool = new ProjectilePool(this);

            this.stateStack = stateStack;
        }

        public void AddBaddies()
        {
            for (int i = 0; i < 3; i++)
            {
                Baddie baddie = ShipDefs.HC(20 + i * 44, -rnd.Next(20, 128), this);
                baddies.Add(baddie);
                entityGroup1.Add(baddie);
                entityGroup2.Add(baddie);
            }
        }

        public override bool Update(float dt)
        {
            starField.Update(dt);
            entityGroup1.Update(dt);
            entityGroup2.Update(dt);
            for(int i = particles.Count - 1; i >= 0; i--)
            {
                particles[i].Update(dt);
                if (particles[i].remove)
                {
                    particles.RemoveAt(i);
                }
            }

            return false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            starField.Draw(spriteBatch);
            hero.Draw(spriteBatch);
            foreach (Baddie baddie in baddies)
            {
                baddie.Draw(spriteBatch);
            }
            foreach(Particle particle in particles)
            {
                particle.Draw(spriteBatch);
            }
            projectilePool.Draw(spriteBatch);
            hud.Draw(spriteBatch);
        }

        public override void HandleInput()
        {
            if (Input.JustPressed(Keys.X))
            {
                hero.hp--;
            }
            if (hero.hp <= 0)
            {
                stateStack.Pop();
                stateStack.Push(new GameOverState(stateStack));
            }

            if (Input.JustPressed(Keys.P))
            {
                stateStack.Push(new PauseState(stateStack));
            }
        }

        public void Explode(Vector2 position)
        {
            Particle particle = new Particle(position);
            particle.sprite = Game1.myContent.Load<Texture2D>("Art/particle1");
            particle.anim = new Animation(new int[] { 6, 6, 5, 4, 3, 2, 1, 0, 0 }, false, 0.1f);
            particle.time = 0;
            particle.timer = 0;
            particle.speed = Vector2.Zero;
            particles.Add(particle);

            for (int i = 0; i < 30; i++)
            {
                particles.Add(new Particle(position));
            }
            color = Color.White;
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }
    }
}