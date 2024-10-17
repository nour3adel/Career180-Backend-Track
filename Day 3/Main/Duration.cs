using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main
{
    public class Duration
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public Duration(int hours = 0, int minutes = 0, int seconds = 0)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public override string ToString()
        {
            return $"{Hours:D2}H:{Minutes:D2}M:{Seconds:D2}S";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Duration d)
            {
                return (Hours == d.Hours && Minutes == d.Minutes && Seconds == d.Seconds);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }

        public static Duration operator +(Duration d1, Duration d2)
        {
            int totalSeconds = (d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds) +
                               (d2.Hours * 3600 + d2.Minutes * 60 + d2.Seconds);
            return FromSeconds(totalSeconds);
        }

        public static Duration operator +(Duration d, int seconds)
        {
            int totalSeconds = (d.Hours * 3600 + d.Minutes * 60 + d.Seconds) + seconds;
            return FromSeconds(totalSeconds);
        }

        public static Duration operator ++(Duration d)
        {
            return d + 60; 
        }

        public static Duration operator --(Duration d)
        {
            return d + (-60); 
        }

        public static bool operator <=(Duration d1, Duration d2)
        {
            return (d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds) <=
                   (d2.Hours * 3600 + d2.Minutes * 60 + d2.Seconds);
        }

        public static bool operator >=(Duration d1, Duration d2)
        {
            return !(d1 <= d2);
        }

        private static Duration FromSeconds(int totalSeconds)
        {
            int hours = totalSeconds / 3600;
            totalSeconds %= 3600;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            return new Duration(hours, minutes, seconds);
        }
    }
}