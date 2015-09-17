using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class InteractionArea
    {
        List<InteractionComponent> entities;
        InteractionComponent dragedComponent;
        int relativeX;
        int relativeY;

        public InteractionArea()
        {
            entities = new List<InteractionComponent>();

            dragedComponent = null;
        }

        public void AddEntity(InteractionComponent entity)
        {
            entities.Add(entity);
        }

        public void RemoveEntity(InteractionComponent entity)
        {
            entities.Remove(entity);
        }

        public void PushMouseEvent(MouseEvent evt)
        {
            System.Drawing.Point p = new System.Drawing.Point();
            p.X = evt.MouseX;
            p.Y = evt.MouseY;

            if (evt.Type == EventType.Click)
            {
                for (int i = entities.Count - 1; i >= 0; i--)
                {
                    InteractionComponent entity = entities[i];

                    if (entity.IsInfinet || entities[i].IsPointInside(p))
                    {
                        entity.Click();
                        break;
                    }
                }

            }
            else if (evt.Type == EventType.Down)
            {

                for (int i = entities.Count - 1; i >= 0; i--)
                {
                    InteractionComponent entity = entities[i];

                    if (entities[i].IsPointInside(p) && entity.Dragable)
                    {
                        dragedComponent = entity;
                        relativeX = p.X - entity.X;
                        relativeY = p.Y - entity.Y;
                        break;
                    }
                }


            }
            else if (evt.Type == EventType.Move)
            {
                if (dragedComponent != null)
                {
                    dragedComponent.X = p.X - relativeX;
                    dragedComponent.Y = p.Y - relativeY;

                    dragedComponent.Drag();
                }

            }

            else if (evt.Type == EventType.Up)
            {
                dragedComponent = null;
            }

        }
    }
}
