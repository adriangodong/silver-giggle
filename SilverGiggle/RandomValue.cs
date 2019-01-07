using System;

namespace SilverGiggle
{
    public static class RandomValue
    {
        private static Random random = new Random();
        private static readonly object randomLock = new object();

        public static Random Random
        {
            get { return random; }
            set
            {
                lock (randomLock)
                {
                    random = value;
                }
            }
        }

        public static Guid NextGuid()
        {
            return Guid.NewGuid();
        }

        public static string NextString()
        {
            return NextGuid().ToString();
        }

        public static int NextInt32()
        {
            lock (randomLock)
            {
                return random.Next();
            }
        }

        public static int NextInt32(int maxValue)
        {
            lock (randomLock)
            {
                return random.Next(maxValue);
            }
        }

        public static int NextInt32(int minValue, int maxValue)
        {
            lock (randomLock)
            {
                return random.Next(minValue, maxValue);
            }
        }

        public static double NextDouble()
        {
            lock (randomLock)
            {
                return random.NextDouble();
            }
        }

        public static long NextInt64()
        {
            return (long)(NextDouble() * long.MaxValue);
        }

        public static bool NextBoolean()
        {
            return Convert.ToBoolean(NextInt32(0, 2));
        }

        public static DateTimeOffset NextDateTimeOffset()
        {
            return new DateTimeOffset(
                (long)(NextDouble() * DateTimeOffset.MaxValue.Ticks),
                TimeSpan.Zero);
        }
    }
}
