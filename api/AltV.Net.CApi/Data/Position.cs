using System;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace AltV.Net.Data
{
    [DataContract]
    [StructLayout(LayoutKind.Sequential)]
    public struct Position : IEquatable<Position>
    {
        //TODO: migrate to System.Numerics.Vector3

        public static readonly float TOLERANCE = 0.013F; //0.01318359375F;

        public const float KEpsilon = 0.00001F;

        public static Position Zero = new Position(0, 0, 0);

        public static implicit operator Vector3(Position position)
        {
            return new Vector3
            {
                X = position.X,
                Y = position.Y,
                Z = position.Z
            };
        }

        public static implicit operator Rotation(Position position)
        {
            return new Rotation
            {
                Roll = position.X,
                Pitch = position.Y,
                Yaw = position.Z
            };
        }

        public static implicit operator Position(Vector3 vector3)
        {
            return new Position
            {
                X = vector3.X,
                Y = vector3.Y,
                Z = vector3.Z
            };
        }
        [DataMember]
        public float X;
        [DataMember]
        public float Y;
        [DataMember]
        public float Z;

        public Position()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Position(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float GetMagnitude() => MathF.Sqrt(X * X + Y * Y + Z * Z);

        public static Position Normalize(Position value)
        {
            var mag = value.GetMagnitude();
            if (mag > KEpsilon) return value / mag;
            return Zero;
        }

        // Makes this vector have a magnitude of 1.
        public void Normalize()
        {
            var mag = GetMagnitude();
            if (mag > KEpsilon)
            {
                X /= mag;
                Y /= mag;
                Z /= mag;
            }
            else
            {
                X = 0;
                Y = 0;
                Z = 0;
            }
        }

        // Returns this vector with a magnitude of 1.
        public Position Normalized => Normalize(this);

        public float Distance(Position b)
        {
            var diffX = X - b.X;
            var diffY = Y - b.Y;
            var diffZ = Z - b.Z;
            return MathF.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);
        }

        public Position ToRadians()
        {
            return new Position((X * MathF.PI) / 180, (Y * MathF.PI) / 180, (Z * MathF.PI) / 180);
        }

        public static Position operator +(Position a, Position b) => new Position(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        public static Position operator -(Position a, Position b) => new Position(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        public static Position operator -(Position a) => new Position(-a.X, -a.Y, -a.Z);

        public static Position operator *(Position a, float d) => new Position(a.X * d, a.Y * d, a.Z * d);

        public static Position operator *(float d, Position a) => new Position(a.X * d, a.Y * d, a.Z * d);

        public static Position operator /(Position a, float d) => new Position(a.X / d, a.Y / d, a.Z / d);

        public static Position Cross(Position lhs, Position rhs) => new Position(
            lhs.Y * rhs.Z - lhs.Z * rhs.Y,
            lhs.Z * rhs.X - lhs.X * rhs.Z,
            lhs.X * rhs.Y - lhs.Y * rhs.X);

        public static Position Scale(Position a, Position b) => new Position(a.X * b.X, a.Y * b.Y, a.Z * b.Z);

        // Linearly interpolates between two positions without clamping the interpolant
        public static Position LerpUnclamped(Position a, Position b, float t) =>
            new Position(
                a.X + (b.X - a.X) * t,
                a.Y + (b.Y - a.Y) * t,
                a.Z + (b.Z - a.Z) * t
            );

        public static Position MoveTowards(Position current, Position target, float maxDistanceDelta)
        {
            var toVector = target - current;
            var dist = toVector.GetMagnitude();
            if (dist <= maxDistanceDelta || dist < float.Epsilon)
                return target;
            return current + toVector / dist * maxDistanceDelta;
        }

        public override string ToString()
        {
            return $"Position(x: {X}, y: {Y}, z: {Z})";
        }

        public static bool operator ==(Position p1, Position p2)
        {
            return Math.Abs(p1.X - p2.X) < TOLERANCE && Math.Abs(p1.Y - p2.Y) < TOLERANCE &&
                   Math.Abs(p1.Z - p2.Z) < TOLERANCE;
        }

        public static bool operator !=(Position p1, Position p2)
        {
            return Math.Abs(p1.X - p2.X) >= TOLERANCE || Math.Abs(p1.Y - p2.Y) >= TOLERANCE ||
                   Math.Abs(p1.Z - p2.Z) >= TOLERANCE;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position && Math.Abs(position.X - X) < TOLERANCE && Math.Abs(position.Y - Y) < TOLERANCE &&
                       Math.Abs(position.Z - Z) < TOLERANCE;
        }

        public bool Equals(Position other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        public override int GetHashCode() => HashCode.Combine(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode());
    }
}