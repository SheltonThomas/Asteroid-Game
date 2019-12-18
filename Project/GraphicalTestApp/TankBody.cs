using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{ 
    //Used for Tank Body
    class TankBody : Entity
    {
        private Sprite _texture;
        private AABB _hitbox;
        private TankTurret _turret;

        public TankBody(int x, int y, string path) : base(x, y)
        {
            _texture = new Sprite(path);
            _hitbox = new AABB(_texture.Width, _texture.Height);
            _turret = new TankTurret("barrelBlue.png");
            
            AddChild(_texture);
            AddChild(_hitbox);
            AddChild(_turret);
            //Rotate(-50);
            OnUpdate += TurnLeft;
            OnUpdate += TurnRight;
            OnUpdate += MoveForward;
            OnUpdate += MoveBackward;
        }

        
        public TankBody(string path) : this(0, 0, path)
        {

        }

        public void MoveForward(float deltaTime)
        {
            if (Input.IsKeyDown(87))
            {
                Vector3 facing = new Vector3(GetM12, GetM11, 0) * deltaTime * -50;
                XAcceleration = facing.x * 10;
                YAcceleration = facing.y * 10;
            }
            if (Input.IsKeyReleased(87))
            {
                SetAccelerationZero();
            }
        }

        public void MoveBackward(float deltaTime)
        {
            if (Input.IsKeyDown(83))
            {
                Vector3 facing = new Vector3(GetM12, GetM11, 0) * deltaTime * 50;
                XAcceleration = facing.x * 10;
                YAcceleration = facing.y * 10;
            }
            if (Input.IsKeyReleased(83))
            {
                SetAccelerationZero();
            }
        }

        public void SetAccelerationZero()
        {
            YAcceleration = 0;
            XAcceleration = 0;
        }

        public void TurnLeft(float deltaTime)
        {
            if (Input.IsKeyDown(68))
            {
                XAcceleration = 0;
                YAcceleration = 0;
                Rotate(deltaTime * 5);
            }
        }

        public void TurnRight(float deltaTime)
        {
            if (Input.IsKeyDown(65))
            {
                XAcceleration = 0;
                YAcceleration = 0;
                Rotate(-deltaTime * 5);
            }
        }
    }
}
