using System.Collections.Generic;
using UltraLight.Entities;
using UltraLight.Globals;

namespace UltraLight
{
    public class EntityGroup
    {
        private List<Entity> entities = new List<Entity>();

        public void Update(float dt)
        {
            foreach (Entity entity in entities)
            {
                entity.Update(dt);
                entity.Move(dt);
            }

            foreach (Entity entity in entities)
            {
                foreach (Entity ent in entities)
                {
                    if (Util.AABB(entity.position, ent.position))
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

            for (int i = entities.Count - 1; i >= 0; i--)
            {
                if (entities[i].remove)
                {
                    entities.RemoveAt(i);
                }
            }

        }

        public void Add(Entity entity)
        {
            entities.Add(entity);
        }

        public void Remove(Entity entity)
        {
            entities.Remove(entity);
        }
    }
}