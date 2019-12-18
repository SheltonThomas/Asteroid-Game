using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class TankTurret : Entity
    {
        private Sprite _texture;

        public TankTurret(string path) : base(5, -20)
        {
            _texture = new Sprite(path);
            AddChild(_texture);
            OnUpdate += TurnLeft;
            OnUpdate += TurnRight;
        }

        public void TurnLeft(float deltaTime)
        {
            if (Input.IsKeyDown(262))
            {
                Rotate(deltaTime * 5);
            }
        }

        public void TurnRight(float deltaTime)
        {
            if (Input.IsKeyDown(263))
            {
                Rotate(-deltaTime * 5);
            }
        }

        public void Shoot(float deltaTime)
        {
            if (Input.IsKeyPressed(32))
            {
                Bullet bullet = new Bullet(XAbsolute, YAbsolute);
                Parent.Parent.AddChild(bullet);
            }
        }
    }
}
