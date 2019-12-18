using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Matrix3
    {
        public float m11, m12, m13, m21, m22, m23, m31, m32, m33;

        public Matrix3()
        {
            m11 = 1; m12 = 0; m13 = 0;
            m21 = 0; m22 = 1; m23 = 0;
            m31 = 0; m32 = 0; m33 = 1;
        }

        public Matrix3(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
        {
            this.m11 = m11; this.m12 = m12; this.m13 = m13;
            this.m21 = m21; this.m22 = m22; this.m23 = m23;
            this.m31 = m31; this.m32 = m32; this.m33 = m33;
        }

        public Matrix3(Matrix3 other)
        {
            m11 = other.m11; m12 = other.m12; m13 = other.m13;
            m21 = other.m21; m22 = other.m22; m23 = other.m23;
            m31 = other.m31; m32 = other.m32; m33 = other.m33;
        }

        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(
                (lhs.m11 * rhs.m11) + (lhs.m12 * rhs.m21) + (lhs.m13 * rhs.m31),
                (lhs.m11 * rhs.m12) + (lhs.m12 * rhs.m22) + (lhs.m13 * rhs.m32),  //First line of matrix
                (lhs.m11 * rhs.m13) + (lhs.m12 * rhs.m23) + (lhs.m13 * rhs.m33),

                (lhs.m21 * rhs.m11) + (lhs.m22 * rhs.m21) + (lhs.m23 * rhs.m31),
                (lhs.m21 * rhs.m12) + (lhs.m22 * rhs.m22) + (lhs.m23 * rhs.m32),  //Second line of matrix
                (lhs.m21 * rhs.m13) + (lhs.m22 * rhs.m23) + (lhs.m23 * rhs.m33),

                (lhs.m31 * rhs.m11) + (lhs.m32 * rhs.m21) + (lhs.m33 * rhs.m31),
                (lhs.m31 * rhs.m12) + (lhs.m32 * rhs.m22) + (lhs.m33 * rhs.m32),  //Third line of matrix
                (lhs.m31 * rhs.m13) + (lhs.m32 * rhs.m23) + (lhs.m33 * rhs.m33));
        }

        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3(
                (lhs.m11 * rhs.x) + (lhs.m12 * rhs.y) + (lhs.m13 * rhs.z),  //X for the vector
                (lhs.m21 * rhs.x) + (lhs.m22 * rhs.y) + (lhs.m23 * rhs.z),  //Y for the vector
                (lhs.m31 * rhs.x) + (lhs.m32 * rhs.y) + (lhs.m33 * rhs.z)); //Z for the vector
        }

        public static Vector3 operator *(Vector3 rhs, Matrix3 lhs)
        {
            return new Vector3(
                (lhs.m11 * rhs.x) + (lhs.m12 * rhs.y) + (lhs.m13 * rhs.z),  //X for the vector
                (lhs.m21 * rhs.x) + (lhs.m22 * rhs.y) + (lhs.m23 * rhs.z),  //Y for the vector
                (lhs.m31 * rhs.x) + (lhs.m32 * rhs.y) + (lhs.m33 * rhs.z)); //Z for the vector
        }

        public void SetScaled(float x, float y, float z)
        {
            m11 = x; m12 = 0; m13 = 0;
            m21 = 0; m22 = y; m23 = 0;
            m31 = 0; m32 = 0; m33 = z;
        }

        public void SetScaled(Vector3 scale)
        {
            m11 = scale.x; m12 = 0; m13 = 0;
            m21 = 0; m22 = scale.y; m23 = 0;
            m31 = 0; m32 = 0; m33 = scale.z;
        }

        public void Scaled(float x, float y, float z)
        {
            Matrix3 scale = new Matrix3();
            scale.SetScaled(x, y, z);

            Set(this * scale);
        }

        public void Scaled(Vector3 scaleVector)
        {
            Matrix3 scale = new Matrix3();
            scale.SetScaled(scaleVector.x, scaleVector.y, scaleVector.z);

            Set(this * scale);
        }

        public void RotateX(double radian)
        {
            Matrix3 scale = new Matrix3();
            scale.SetRotateX(radian);

            Set(this * scale);
        }

        public void SetRotateX(double radian)
        {
            Set(1, 0, 0,
                0, (float)Math.Cos(radian), (float)-Math.Sin(radian),
                0, (float)Math.Sin(radian), (float)Math.Cos(radian));
        }

        public void RotateY(double radian)
        {
            Matrix3 scale = new Matrix3();
            scale.SetRotateY(radian);

            Set(this * scale);
        }

        public void SetRotateY(double radian)
        {
            Set((float)Math.Cos(radian), 0, (float)Math.Sin(radian),
                0, 1, 0,
                (float)-Math.Sin(radian), 0, (float)Math.Cos(radian));
        }

        public void RotateZ(double radian)
        {
            Matrix3 scale = new Matrix3();
            scale.SetRotateZ(radian);

            Set(this * scale);
        }

        public void SetRotateZ(double radian)
        {
            Set((float)Math.Cos(radian), (float)-Math.Sin(radian), 0,
                (float)Math.Sin(radian), (float)Math.Cos(radian), 0,
                0, 0, 1);
        }

        public void Set(Matrix3 scaled)
        {
            m11 = scaled.m11; m12 = scaled.m12; m13 = scaled.m13;
            m21 = scaled.m21; m22 = scaled.m22; m23 = scaled.m23;
            m31 = scaled.m31; m32 = scaled.m32; m33 = scaled.m33;
        }

        public void Set(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
        {
            this.m11 = m11; this.m12 = m12; this.m13 = m13;
            this.m21 = m21; this.m22 = m22; this.m23 = m23;
            this.m31 = m31; this.m32 = m32; this.m33 = m33;
        }

        public void SetTranslate(float x, float y, float z)
        {
            m13 = x; m23 = y; m33 = z;
        }

        public override string ToString()
        {
            return "{ " + m11 + ", " + m12 + ", " + m13 + ", \n"
                        + m21 + ", " + m22 + ", " + m23 + ", \n"
                        + m31 + ", " + m32 + ", " + m33 + " }";
        }
    }
}
