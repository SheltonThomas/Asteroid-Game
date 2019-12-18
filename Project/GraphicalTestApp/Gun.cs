using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Gun : Entity
    {
        private Bullet _bullet;
        private Sprite _texture;
        private int _ammo = 5;
        private int _maxAmmo = 10;
        private float _bulletLoadingTime = 1.5f;
        private Timer _addBulletTimer = new Timer();

        public Gun() : base(0, 0)
        {
            _texture = new Sprite("gun.png");
            _texture.Y = -_texture.Height;
            AddChild(_texture);
            OnDraw += DrawAmmoCount;

            OnUpdate += TurnLeft;
            OnUpdate += TurnRight;
            OnUpdate += Shoot;
            OnUpdate += AddBullets;
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
            if (Input.IsKeyPressed(32) && _ammo > 0)
            {
                _ammo--;
                Vector3 facing = new Vector3(GetM12, GetM11, 0);
                Ship ship = (Ship)Parent;
                _bullet = new Bullet(XAbsolute, YAbsolute, ship, "bullet.png");
                _bullet.X -= facing.x * 40;
                _bullet.Y -= facing.y * 40;
                _bullet.Rotate(GetRotation());
                Parent.Parent.AddChild(_bullet);
            }
        }

        public void AddBullets(float deltaTime)
        {
            if (_ammo == _maxAmmo)
            {
                _addBulletTimer.Restart();
                return;
            }
            if (_addBulletTimer.Seconds >= _bulletLoadingTime)
            {
                _ammo++;
                _addBulletTimer.Restart();
            }
        }

        public void DrawAmmoCount()
        {
            Raylib.Raylib.DrawText("Ammo Count: " + _ammo + "/" + _maxAmmo + "\nNew Bullet in " + Math.Round((_bulletLoadingTime - _addBulletTimer.Seconds), 1), 0, 0, 38, Raylib.Color.BLACK);
        }
    }
}
