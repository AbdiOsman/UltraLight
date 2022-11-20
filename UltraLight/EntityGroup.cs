using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace UltraLight
{
    public class EntityGroup
    {
        List<Entity> entities = new List<Entity>();

        public void Update(float dt)
        {
            foreach (Entity entity in entities)
            {
                entity.Update(dt);
                entity.Move(dt);
                foreach (Entity ent in entities)
                {
                    if (Util.Collides(entity.rect, ent.rect))
                    {
                        if(entity != ent && entity.GetType().BaseType != entity.GetType())
                        {
                            entity.hit = ent;
                        }
                    }
                }
            }

            for(int i = entities.Count -1; i >= 0; i--)
            {
                if (entities[i].hit != null)
                {
                    entities[i].Collided();
                    if (entities[i] is Baddie)
                    {
                        entities[i].remove = true;
                        entities.Remove(entities[i]);
                    }
                    entities[i].hit = null;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Entity entity in entities)
            {
                entity.Draw(spriteBatch);
            }
        }

        public void Add(Entity entity)
        {
            entities.Add(entity);
        }
    }
}
