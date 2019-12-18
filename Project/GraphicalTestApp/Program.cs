using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1280, 780, "AsteroidGame");

            Actor root = new Actor();
            game.Root = root;

            Sprite backGround = new Sprite("background.png");
            backGround.X = 0;
            backGround.Y = 0;
            root.AddChild(backGround);

            Ship ship = new Ship(1280 / 2, 780 / 2);
            root.AddChild(ship);

            DebrisSpawner debrisSpawner = new DebrisSpawner(0, null, true);
            root.AddChild(debrisSpawner);

            //## Set up game here ##//

            game.Run();
        }
    }
}
