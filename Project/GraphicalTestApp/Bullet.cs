using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Bullet : Entity
    {
        private Sprite _texture;
        private AABB _hitbox; 
        private Entity _origin;
        private int _damage = 3;

        public Bullet(float x, float y, Entity origin, string path) : base(x, y)
        {
            _origin = origin;
            _texture = new Sprite(path);
            _hitbox = new AABB(_texture.Width, _texture.Height);

            AddChild(_texture);
            AddChild(_hitbox);

            OnUpdate += Move;
            OnUpdate += CheckEdge;
            OnUpdate += CheckCollision;
        }

        ~Bullet()
        {
            if (Parent != null)
            {
                Parent.RemoveChild(this);
            }

            RemoveChild(_texture);
            RemoveChild(_hitbox);
        }

        public void Move(float deltaTime)
        {
            Vector3 facing = new Vector3(GetM12, GetM11, 0) * -250;
            XVelocity = facing.x;
            YVelocity = facing.y;

            
        }

        public void CheckEdge(float deltaTime)
        {
            if (X < 0 - 45 || Y < 0 - 45 || X > 1280 + 45 || Y > 780 + 45)
            {
                Destroy();
            }
        }

        public void Destroy()
        {
            RemoveChild(_texture);
            RemoveChild(_hitbox);
            if(Parent != null)
            {
                Parent.RemoveChild(this);
            }
        }



        public void CheckCollision(float deltaTime)
        {
            if(Parent != null)
            {
                foreach(Actor hitCheck in Parent.GetChildren)
                {
                    if(hitCheck is Debris && !(_origin is Debris))
                    {
                        Debris debris = (Debris)hitCheck;
                        if (debris.DetectCollision(_hitbox))
                        {
                            Destroy();
                            if(debris is Satellite)
                            {
                                Ship.Score += 150;
                            }
                            else
                            {
                                Ship.Score += 100;
                            }
                        }
                    }
                    if(hitCheck is Ship && !(_origin is Ship))
                    {
                        Ship ship = (Ship)hitCheck;
                        if (ship.DetectCollision(_hitbox, _damage))
                        {
                            Destroy();
                        }
                    }
                    if(hitCheck is Bullet)
                    {
                        Bullet bullet = (Bullet)hitCheck;
                        if(bullet._origin is Ship && !(_origin is Ship))
                        {
                            if(_hitbox.DetectCollision(bullet._hitbox))
                            {
                                Destroy();

                                bullet.Destroy();

                                Ship.Score += 10;
                            }
                        }
                    }
                }
            }
        }
    }
}
