using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class SpaceRock : Debris
    {
        Random random = new Random();
        private Sprite _texture;

        public SpaceRock() : this(0, 0, 0, 0)
        {

        }

        public SpaceRock(float x, float y, float xVelocity, float yVelocity) : base(x, y)
        {
            _texture = new Sprite(Enum.GetName(typeof(SpaceRocks), random.Next(6)) + ".png");
            AddChild(_texture);
            _damage = 5;

            XVelocity = xVelocity;
            YVelocity = yVelocity;

            OnUpdate += Rotate;
            OnUpdate += CheckCollision;
        }

        public override bool DetectCollision(AABB other)
        {

            if(base.DetectCollision(other))
            {
                RemoveChild(_texture);
                return true;
            }
            else
            {
               return false;
            }
        }

        public void Spin(float deltaTime)
        {
            Rotate(deltaTime * 5);
        }

        public void CheckCollision(float deltaTime)
        {
            if (Parent != null)
            {
                foreach (Actor hitCheck in Parent.GetChildren)
                {
                    if (hitCheck is Ship)
                    {
                        Ship ship = (Ship)hitCheck;
                        if (ship.DetectCollision(_hitbox, _damage))
                        {
                            RemoveChild(_texture);
                            RemoveChild(_hitbox);
                            Parent.RemoveChild(this);
                        }
                    }
                }
            }
        }

        enum SpaceRocks
        {
            greyMeteor1,
            greyMeteor2,
            greyMeteor3,
            brownMeteor1,
            brownMeteor2,
            brownMeteor3
        }
    }
}
