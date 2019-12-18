using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3() : this(0, 0, 0)
        {

        }

        public Vector3(float X, float Y, float Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        public static Vector3 operator -(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.x - vec2.x, vec1.y - vec2.y, vec1.z - vec2.z);
        }

        public static Vector3 operator +(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.x + vec2.x, vec1.y + vec2.y, vec1.z + vec2.z);
        }

        public static Vector3 operator *(Vector3 vec1, float scaler)
        {
            return new Vector3(vec1.x * scaler, vec1.y * scaler, vec1.z * scaler);
        }

        public static Vector3 operator *(float scaler, Vector3 vec1)
        {
            return new Vector3(vec1.x * scaler, vec1.y * scaler, vec1.z * scaler);
        }

        public static Vector3 operator /(Vector3 vec1, float scaler)
        {
            return new Vector3(vec1.x / scaler, vec1.y / scaler, vec1.z / scaler);
        }

        public static Vector3 operator /(float scaler, Vector3 vec1)
        {
            return new Vector3(scaler / vec1.x, scaler / vec1.y, scaler / vec1.z);
        }

        //To get normalised vector:
        //Vector3 vectorName = (initiate vector);
        //float magnitudeName = vectorName.MagnitudeSqr;
        //vectorName /= magnitudeName;
        public float MagnitudeSqr()
        {
            return (x * x) + (y * y) + (z * z);
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        public float Distance(Vector3 other)
        {
            float differenceX = x - other.x;
            float differenceY = y - other.y;
            float differenceZ = z - other.z;
            return (float)Math.Sqrt((differenceX * differenceX) + (differenceY * differenceY) + (differenceZ * differenceZ));
        }

        public void Normalised()
        {
            float magnitude = Magnitude();
            x /= magnitude;
            y /= magnitude;
            z /= magnitude;
        }

        public Vector3 GetNormalised()
        {
            return (this / Magnitude());
        }

        public float GetDotProduct(Vector3 other)
        {
            return (x * other.x) + (y * other.y) + (z * other.z);
        }

        public Vector3 CrossProduct(Vector3 other)
        {
            return new Vector3((y * other.z) - (z * other.y), (z * other.x) - (x * other.z), (x * other.y) - (y * other.x));
        }

        public float Angle(Vector3 other)
        {
            Vector3 a = GetNormalised();
            Vector3 b = other.GetNormalised();

            float d = (a.x * b.x) + (a.y * b.y) + (a.z * b.z);

            return (float)Math.Acos(d);
        }
    }
}
