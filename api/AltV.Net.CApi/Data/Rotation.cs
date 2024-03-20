using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rotation : IEquatable<Rotation>
    {
        public static Rotation Zero = new Rotation(0, 0, 0);

        public static implicit operator Vector3(Rotation rotation)
        {
            return new Vector3
            {
                X = rotation.Roll,
                Y = rotation.Pitch,
                Z = rotation.Yaw
            };
        }

        public static implicit operator Position(Rotation rotation)
        {
            return new Position
            {
                X = rotation.Roll,
                Y = rotation.Pitch,
                Z = rotation.Yaw
            };
        }

        public static implicit operator Rotation(Vector3 vector3)
        {
            return new Rotation
            {
                Roll = vector3.X,
                Pitch = vector3.Y,
                Yaw = vector3.Z
            };
        }

        public float Roll;
        public float Pitch;
        public float Yaw;

        public Rotation()
        {
            Roll = 0;
            Pitch = 0;
            Yaw = 0;
        }

        public Rotation(float roll, float pitch, float yaw)
        {
            Roll = roll;
            Pitch = pitch;
            Yaw = yaw;
        }

        public override string ToString()
        {
            return $"Rotation(roll: {Roll}, pitch: {Pitch}, yaw: {Yaw})";
        }

        public override bool Equals(object obj)
        {
            return obj is Rotation other && Equals(other);
        }

        public bool Equals(Rotation other)
        {
            return Roll.Equals(other.Roll) && Pitch.Equals(other.Pitch) && Yaw.Equals(other.Yaw);
        }

        public Rotation ToRadians()
        {
            return new Rotation((Roll * MathF.PI) / 180, (Pitch * MathF.PI) / 180, (Yaw * MathF.PI) / 180);
        }

        public override int GetHashCode() => HashCode.Combine(Roll.GetHashCode(), Pitch.GetHashCode(), Yaw.GetHashCode());
    }
}