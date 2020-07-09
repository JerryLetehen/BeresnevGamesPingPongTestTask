using System;

namespace PingPong.Core
{
    [Serializable]
    public class Limits<T>
    {
        public T Min { get; private set; }
        public T Max { get; private set; }

        public Limits(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public void SetLimits(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public override string ToString()
        {
            return $"Min : {Min} | Max : {Max}";
        }

        public bool Equals(Limits<T> limits)
        {
            if (limits == null)
            {
                return false;
            }

            return Min.Equals(limits.Min) && Max.Equals(limits.Max);
        }
    }
}