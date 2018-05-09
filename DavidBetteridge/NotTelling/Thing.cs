using System;
using System.Linq;

namespace NotTelling
{

    public class Thing
    {
        private const string payload = @"
IIIAAIVAAAAAAAXXIIIIAAAAAAAAAACXXAAAAAAAAAAAAAAAAAAAAAADXXCCAAAAAAFIZZAAAAAAAAAAAAAAAAAAAAA
MMMMMXXXXAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABBBBCCCXXAAAAAAFIZZAAAAAAAAAAAAAAAAAAAAAAA
AAAAAAAAAAAAAAAAAAAAAABBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBMMDCCCXXXXXXXXFIZZBUZZAAAAAAAAAAA
AAAAAAAAAAAAZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZBBMMMMMMMMDCCCAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
AAAAAAAAAAAAAAAAAAAAAWWWYYYYYYYYYZZZZZZZZZBMMMMMMDCCCAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWYYYYYYYYYMDCAAAAAAAAAAAAAAAAAAAAAAAFIZZBUZZAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
AAAAAAAAAAAAASSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSWWYYYYYYYBBDCCCA
AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";

        public long Do(int result)
        {
            var pi = CalculatePI();
            var trianglarNumber = (int)Math.Pow(result, Math.Sin(pi) * 2);
            var lastFactor = UseEratosthenses((int)pi);
            var firstFactorial = (int)Enumerable.Range(1, result - 1).Sum(abc => Math.Pow(abc, Math.Sin(pi) * 2));
            var leapChecker = payload
                            .Replace(System.Environment.NewLine, "")
                            .Replace("FIZZ", "AAAA")
                            .Replace("BUZZ", "AAAA")
                            .Substring(firstFactorial, trianglarNumber);
            return ThingToThingConvert(leapChecker);
        }

        private static (int a, int b, int c) NothingToSeeHereNoFibbing(int p)
        {
            if (p == 0)
                return (p, p * p, p + p);
            else
                return (0, 0, NothingToSeeHereNoFibbing(p - 1).a + NothingToSeeHereNoFibbing(p - 2).b);
        }

        private static Long ThingToThingConvert(string thing)
        {
            thing = new string(thing.Reverse().ToArray());
            var t = 1234L;
            t = t + (10000 * (thing.Length - thing.Replace("B", "").Length));
            t = t + (100 * (thing.Length - thing.Replace("C", "").Length));
            t = t + (500 * (thing.Length - thing.Replace("D", "").Length));
            t = t + (thing.Length - thing.Replace("I", "").Length);
            t = t + (1000 * (thing.Length - thing.Replace("M", "").Length));
            t = t + (5 * (thing.Length - thing.Replace("V", "").Length));
            t = t + (100000000L * (thing.Length - thing.Replace("S", "").Length));
            t = t + (10000000 * (thing.Length - thing.Replace("W", "").Length));
            t = t + (10 * (thing.Length - thing.Replace("X", "").Length));
            t = t + (1000000 * (thing.Length - thing.Replace("Y", "").Length));
            t = t + (100000 * (thing.Length - thing.Replace("Z", "").Length));
            return new Long(t);
        }

        private long UseEratosthenses(int index)
        {
            var primes = new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 20 };
            return primes[index];
        }

        private double CalculatePI()
        {
            return 1.5707963267948966;
        }

        class Long
        {
            public readonly long _l;
            public Long(long l)
            {
                _l = l;
            }

            public static implicit operator long(Long r)
            {
                return r._l - 1234;
            }
        }
    }
}
