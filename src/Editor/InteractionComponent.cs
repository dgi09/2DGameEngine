using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Editor
{
    public class InteractionComponent
    {
        Rectangle interactionArea;

        

        public bool IsInfinet { get; set; }
        public bool Dragable { get; set; }

        public int X
        {
            get
            {
                return interactionArea.X;
            }
            set
            {
                interactionArea.X = value;
            }
        }

        public int Y
        {
            get
            {
                return interactionArea.Y;
            }
            set
            {
                interactionArea.Y = value;
            }
        }

        public int Width
        {
            get { return interactionArea.Width; }
            set { interactionArea.Width = value; }
        }

        public int Height
        {
            get { return interactionArea.Height; }
            set { interactionArea.Height = value; }
        }

        public EventHandler OnClick;
        public EventHandler OnDrag;

        public void SetPosition(Point p)
        {
            X = p.X;
            Y = p.Y;
        }


        public void Click()
        {
            if (OnClick != null)
                OnClick(this, new EventArgs());
        }
        public void Drag()
        {
            if (OnDrag != null)
                OnDrag(this, new EventArgs());
        }

        public bool IsPointInside(Point p)
        {
            return interactionArea.Contains(p);
        }


    }
}
