using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class DebrisSpawner : Entity
    {
        Random random = new Random();
        private Debris _spawnerType;
        private Timer _debrisSpawnTimer;
        private float _debrisSpawRate = 5f;
        private Timer _activationTimer;
        private float _timeToActivate;
        private Timer _newSpawnerTimer;
        private float _timeToSpawnNewSpawner = 10;
        private bool _isActive = false;
        private bool _canSpawnMore;

        public DebrisSpawner(float timeToActivate, Debris spawnerType, bool canSpawnMore) : base(0, 0)
        {
            _canSpawnMore = canSpawnMore;
            _timeToActivate = timeToActivate;
            _activationTimer = new Timer();
            int randomType = random.Next(100);
            if(spawnerType != null)
            {
                _spawnerType = spawnerType;
            }
            else if(randomType > 44)
            {
                _spawnerType = new SpaceRock();
            }
            else
            {
                _spawnerType = new Satellite();
            }
            _debrisSpawnTimer = new Timer();

            _newSpawnerTimer = new Timer();

            OnUpdate += RandomRotate;
            OnUpdate += CreateDebris;
            OnUpdate += Activate;
            OnUpdate += CreateNewSpawners;
        }

        public void RandomRotate(float deltaTime)
        {
            Rotate(deltaTime * random.Next(100));
        }

        public void Activate(float deltaTime)
        {
            if(_activationTimer.Seconds >= _timeToActivate)
            {
                _isActive = true;
            }
        }

        public void CreateNewSpawners(float deltaTime)
        {
            if(_newSpawnerTimer.Seconds >= _timeToSpawnNewSpawner && _canSpawnMore)
            {
                //_timeToSpawnNewSpawner += 10;

                Satellite satellite = new Satellite();
                DebrisSpawner debrisSpawner = new DebrisSpawner(0, null, false);
                Parent.AddChild(debrisSpawner);

                _newSpawnerTimer.Restart();
            }
        }
        
        public void CreateDebris(float deltaTime)
        {
            if(_isActive)
            {
                if (_debrisSpawnTimer.Seconds >= _debrisSpawRate)
                {
                    _debrisSpawnTimer.Restart();
                    Vector3 facing = new Vector3(GetM12, GetM11, 0) * random.Next(50, 200);
                    if (_spawnerType is SpaceRock)
                    {
                        _spawnerType = new SpaceRock(100, 100, facing.x, facing.y);

                        int spawnLocation = random.Next(4);
                        switch (spawnLocation)
                        {
                            case 0:
                                _spawnerType.Y = 0;
                                _spawnerType.X = random.Next(1280 + 1);
                                break;

                            case 1:
                                _spawnerType.Y = 780;
                                _spawnerType.X = random.Next(1280 + 1);
                                break;

                            case 2:
                                _spawnerType.X = 0;
                                _spawnerType.Y = random.Next(780 + 1);
                                break;

                            case 3:
                                _spawnerType.X = 1280;
                                _spawnerType.Y = random.Next(780 + 1);
                                break;
                        }

                        Parent.AddChild(_spawnerType);
                    }

                    else
                    {
                        _spawnerType = new Satellite(100, 100, facing.x, facing.y);

                        int spawnLocation = random.Next(4);
                        switch (spawnLocation)
                        {
                            case 0:
                                _spawnerType.Y = 0;
                                _spawnerType.X = random.Next(1280 + 1);
                                break;

                            case 1:
                                _spawnerType.Y = 780;
                                _spawnerType.X = random.Next(1280 + 1);
                                break;

                            case 2:
                                _spawnerType.X = 0;
                                _spawnerType.Y = random.Next(780 + 1);
                                break;

                            case 3:
                                _spawnerType.X = 1280;
                                _spawnerType.Y = random.Next(780 + 1);
                                break;
                        }

                        Parent.AddChild(_spawnerType);
                    }
                }
            }
        }
    }
}
