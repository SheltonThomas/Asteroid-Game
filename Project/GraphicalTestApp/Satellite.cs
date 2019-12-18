using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Satellite : Debris
    {
        Random random = new Random();
        private Sprite _texture;
        private Bullet _bullet;
        private float _timeToShoot = .5f;
        private Timer _shootTimer;
        private float _spinRate = 0;

        public Satellite() : this(0, 0, 0, 0)
        {

        }

        public Satellite(float x, float y, float xVelocity, float yVelocity) : base(x, y)
        {
            _shootTimer = new Timer();
            _texture = new Sprite("satellite.png");
            AddChild(_texture);
            _damage = 3;

            XVelocity = xVelocity;
            YVelocity = yVelocity;

            while(_spinRate == 0)
            {
                _spinRate = random.Next(-5, 5);
            }

            OnUpdate += DetectCollision;
            OnUpdate += Spin;
            OnUpdate += Shoot;
        }
        
        // Checks to see if Satellite hits with other AABB
        public override bool DetectCollision(AABB other)
        {

            if (base.DetectCollision(other))
            {
                RemoveChild(_texture);
                return true;
            }
            else
            {
                return false;
            }
        }
         // Lets the Satellite Rotate at set speed
        public void Spin(float deltaTime)
        {
            Rotate(deltaTime * _spinRate);
        }
         // Collision check to see if Satellite is hit
        public void DetectCollision(float deltaTime)
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
        
        // What lets the Satellite shoots bullets
        public void Shoot(float deltaTime)
        {
            if (_shootTimer.Seconds >= _timeToShoot)
            {
                _shootTimer.Restart();
                Vector3 facing = new Vector3(GetM12, GetM11, 0);
                Satellite satellite = new Satellite();
                _bullet = new Bullet(XAbsolute, YAbsolute, satellite, "satelliteBullet.png");
                _bullet.X -= facing.x * 40;
                _bullet.Y -= facing.y * 40;
                _bullet.Rotate(GetRotation());
                if (Parent != null)
                {
                    Parent.AddChild(_bullet);
                }
            }
        }
    }
}
