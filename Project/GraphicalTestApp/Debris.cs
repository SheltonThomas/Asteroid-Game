using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Debris : Entity
    {
        protected AABB _hitbox;
        protected int _damage;

        public Debris() : this(0, 0)
        {

        }

        public Debris(float x, float y) : base(x, y)
        {
            _hitbox = new AABB(XAbsolute, YAbsolute);
            AddChild(_hitbox);
            OnUpdate += WrapScreen;
        }

        public virtual bool DetectCollision(AABB other)
        {
            if(_hitbox.DetectCollision(other))
            {
                RemoveChild(_hitbox);
                if(Parent != null)
                {
                    Parent.RemoveChild(this);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void WrapScreen(float deltaTime)
        {
            if (XAbsolute < 0 - 45)
            {
                X = 1280 + 45;

            }
            if (XAbsolute > 1280 + 45)
            {
                X = 0 - 45;

            }

            if (YAbsolute < 0 - 45)
            {
                Y = 780 + 45;

            }
            if (YAbsolute > 780 + 45)
            {
                Y = 0 - 45;

            }
        }
    }
}
