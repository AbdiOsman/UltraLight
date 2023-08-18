using System.Collections.Generic;

namespace UltraLight.Entities
{
    public class EntityGroup
    {
        public List<Entity> entities = new List<Entity>();

        public void Update(float dt)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Update(dt);
            }

            for (int i = entities.Count - 1; i >= 0; i--)
            {
                if (entities[i].remove)
                {
                    entities.RemoveAt(i);
                }
            }
        }

        public void CollidesWith(EntityGroup entityGroup)
        {
            for (int i = entities.Count - 1; i >= 0; i--)
            {
                Entity entity1 = entities[i];
                if (entity1.remove) continue;

                for (int j = entityGroup.entities.Count - 1; j >= 0; j--)
                {
                    Entity entity2 = entityGroup.entities[j];
                    if (entity2.remove) continue;

                    if (RectCollision(entity1, entity2))
                    {
                        entity1.Collided(entity2);
                        entity2.Collided(entity1);
                    }
                }
            }
        }

        public void Add(Entity entity)
        {
            entity.group = this;
            entities.Add(entity);
        }

        public bool RectCollision(Entity a, Entity b)
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