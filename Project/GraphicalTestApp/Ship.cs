using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    //Used for Tank Body
    class Ship : Entity
    {
        public static int Score { get; set; } = 0;
        private Sprite _texture;
        private AABB _hitbox;
        private Gun _turret;
        private Vector3 _scorePosition;
        private int Health { get; set; } = 100;
        private bool _gameOver = false;
        private float _timeToStart = 5;
        private Timer _timerToStart;

        public Ship(int x, int y) : base(x, y)
        {
            _timerToStart = new Timer();
            _scorePosition = new Vector3(1050, 0, 0);
            _texture = new Sprite("ship.png");
            _hitbox = new AABB(_texture.Width, _texture.Height);
            _turret = new Gun();
            _turret.X = 0;
            _turret.Y = 0;

            AddChild(_texture);
            AddChild(_hitbox);
            AddChild(_turret);

            OnDraw += DrawHealth;
            OnDraw += DrawScore;
            OnDraw += DrawTimeToBegin;

            OnUpdate += TurnLeft;
            OnUpdate += TurnRight;
            OnUpdate += MoveForward;
            OnUpdate += MoveBackward;
            OnUpdate += WrapScreen;
            OnUpdate += HealthCheck;
        }

        public void MoveForward(float deltaTime)
        {
            if (Input.IsKeyDown(87))
            {
                Vector3 facing = new Vector3(GetM12, GetM11, 0) * -100;
                XAcceleration = facing.x;
                YAcceleration = facing.y;
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
                Vector3 facing = new Vector3(GetM12, GetM11, 0) * 100;
                XAcceleration = facing.x;
                YAcceleration = facing.y;
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
                Rotate(deltaTime * 5);
            }
        }

        public void TurnRight(float deltaTime)
        {
            if (Input.IsKeyDown(65))
            {
                Rotate(-deltaTime * 5);
            }
        }

        public bool DetectCollision(AABB other, int damage)
        {
            if (_hitbox.DetectCollision(other))
            {
                Health -= damage;
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

        public void HealthCheck(float deltaTime)
        {
            if (Health <= 0)
            {
                Health = 0;
                RemoveChild(_hitbox);
                RemoveChild(_texture);
                RemoveChild(_turret);

                _scorePosition.x = 1280 / 2 - 100;
                _scorePosition.y = 780 / 2 - 150;
                _gameOver = true;

                X = 1300;
                Y = 850;
            }
        }

        public void DrawTimeToBegin()
        {
            if (_timerToStart.Seconds <= _timeToStart)
            {
                Raylib.Raylib.DrawText("Get Ready\nGame Starts in: " + Math.Round(_timeToStart - _timerToStart.Seconds, 0), 1280 / 2 - 200, 0, 38, Raylib.Color.BLACK);
            }
        }

        public void DrawHealth()
        {
            Raylib.Raylib.DrawText("Health Remaining: " + Health, 0, 740, 38, Raylib.Color.BLACK);
        }

        public void DrawScore()
        {
            Raylib.Raylib.DrawText("Your Score:\n" + Score, (int)_scorePosition.x, (int)_scorePosition.y, 38, Raylib.Color.BLACK);
            if (_gameOver)
            {
                Raylib.Raylib.DrawText("Game Over", (int)_scorePosition.x, (int)_scorePosition.y - 50, 38, Raylib.Color.BLACK);
            }
        }
    }
}
