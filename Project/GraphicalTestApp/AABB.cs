using System;

namespace GraphicalTestApp
{
    class AABB : Actor
    {
        public float Width { get; set; } = 1;
        public float Height { get; set; } = 1;

        private Raylib.Color _color = Raylib.Color.GOLD;

        //Returns the Y coordinate at the top of the box
        public float Top
        {
            get { return YAbsolute - Height / 2; }
        }

        //Returns the Y coordinate at the top of the box
        public float Bottom
        {
            get { return YAbsolute + Height / 2; }
        }

        //Returns the X coordinate at the top of the box
        public float Left
        {
            get { return XAbsolute - Width / 2; }
        }

        //Returns the X coordinate at the top of the box
        public float Right
        {
            get { return XAbsolute + Width / 2; }
        }

        //Creates an AABB of the specifed size
        public AABB(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public bool DetectCollision(AABB other)
        {
            //## Implement DetectCollision(AABB) ##//
            if(((other.Left <= Right && other.Right >= Right) || (Left <= other.Right && Right >= other.Right)) 
                 && ((other.Top <= Bottom && other.Bottom >= Bottom) || (Top <= other.Bottom && Bottom >= other.Bottom)))
            {
                _color = Raylib.Color.RED;
                return true;
            }
            else
            {
                _color = Raylib.Color.GOLD;
                return false;
            }
            //return false;
        }

        public bool DetectCollision(Vector3 point)
        {
            //## Implement DetectCollision(Vector3) ##//
            return !(point.y != Top || point.x != Left || point.y != Bottom || point.x != Right);
            //return false;
        }

        //Draw the bounding box to the screen
        public override void Draw()
        {
            Raylib.Rectangle rec = new Raylib.Rectangle(Left, Top, Width, Height);
            Raylib.Raylib.DrawRectangleLinesEx(rec, 1, _color);
        }
    }
}
