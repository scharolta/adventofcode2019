using System;
using System.Collections.Generic;
using System.Linq;

namespace Dec12
{
    class Program
    {
        static void Main(string[] args)
        {
            //Moon[] moons = {
            //    new Moon(0, new int[]{ 14, 15, -1 }),
            //    new Moon(1, new int[] { 17, -3, 4 }),
            //    new Moon(2, new int[]{6, 12, -13 }),
            //    new Moon(3, new int[]{-2, 10, -8 }) };

            Moon[] moons = {
                new Moon(0, new int[]{ -1, 0, 2 }),
                new Moon(1, new int[] { 2, -10, -7 }),
                new Moon(2, new int[]{4, -8, 8 }),
                new Moon(3, new int[]{3, 5, -1 }) };

            for (int i = 1; i < 11; i++)
            {
                moons.ToList().ForEach(m => m.CalculateVelocity(moons));
                moons.ToList().ForEach(m => m.Move());
                Console.WriteLine($"Afer {i} step(s)");
                moons.ToList().ForEach(m => Console.WriteLine(m.ToString()));
            }

        }
    }

    class Moon
    {
        public Moon(int id, int[] position)
        {
            Id = id;
            Position = position;
            History = new List<int[]>();
        }
        public int Id { get; set; }
        public int[] Position { get; set; }

        public int[] Velocity { get; set; } = { 0, 0, 0 };

        public List<int[]> History { get; set; }

        public void CalculateVelocity(Moon[] moons)
        {
            var otherMoons = moons.Where(m => m.Id != Id);
            foreach (var moon in otherMoons)
            {
                for (int i = 0; i < Velocity.Length; i++)
                {
                    Velocity[i] = moon.Position[i] > Position[i] ? Velocity[i] + 1 : Velocity[i] - 1;
                }
            }
        }

        public void Move()
        {
            History.Add(Position);
            for (int i = 0; i < Position.Length; i++)
            {
                Position[i] += Velocity[i];
            }
        }

        public override string ToString()
        {
            return $"pos=<x={Position[0]}, y={Position[1]}, z={Position[2]}>, vel=<x={Velocity[0]}, y={Velocity[1]}, z={Velocity[2]}>";
        }
    }
}
