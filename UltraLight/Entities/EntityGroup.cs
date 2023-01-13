using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using UltraLight.Globals;

namespace UltraLight.Entities
{
    public class EntityGroup
    {
        public List<Entity> entities = new List<Entity>();

        public void Update(float dt)
        {
            for (int i = entities.Count - 1; i >= 0; i--)
            {
                if (entities[i].remove)
                {
                    entities.RemoveAt(i);
                }
            }

            foreach (Entity entity in entities)
            {
                entity.Update(dt);
                entity.Move(dt);
            }

            foreach (Entity entity in entities)
            {
                foreach (Entity ent in entities)
                {
                    if (AABB(entity, ent))
                    {
                        if (entity != ent && entity.GetType() != ent.GetType())
                        {
                            entity.hit = ent;
                        }
                    }
                }
            }

            for (int i = entities.Count - 1; i >= 0; i--)
            {
                if (entities[i].hit != null)
                {
                    entities[i].Collided();
                    entities[i].hit = null;
                }
            }
        }

        public void Add(Entity entity)
        {
            entities.Add(entity);
        }

        public void Remove(Entity entity)
        {
            foreach (Entity e in entities)
            {
                if (e == entity)
                    e.remove = true;
            }
        }

        public bool AABB(Entity a, Entity b)
        {
            float a_left = a.position.X;
            float a_top = a.position.Y;
            float a_right = a.position.X + a.width;
            float a_bottom = a.position.Y + a.height;

            float b_left = b.position.X;
            float b_top = b.position.Y;
            float b_right = b.position.X + b.width;
            float b_bottom = b.position.Y + b.height;

            if (a_top > b_bottom) return false;
            if (b_top > a_bottom) return false;
            if (a_left > b_right) return false;
            if (b_left > a_right) return false;

            return true;
        }
    }
}