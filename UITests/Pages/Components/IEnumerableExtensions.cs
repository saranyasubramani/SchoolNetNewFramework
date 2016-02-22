using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Pages.Components
{
    /// <summary>
    /// enumberable extensions
    /// </summary>
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> RandomSubset<T>(this IEnumerable<T> source, int count)
        {
            if (count <= 0) throw new ArgumentNullException("count");
            if (source == null) throw new ArgumentNullException("source");

            var sourceCount = source.Count();
            if (count >= sourceCount)
            {
                return source;
            }
            return RandomSubsetIterator<T>(source, sourceCount, count);
        }

        private static Random random = new Random();

        static IEnumerable<T> RandomSubsetIterator<T>(IEnumerable<T> source, int sourceCount, int count)
        {
            var buffer = source;
            var bufferCount = sourceCount;

            int randomMax = bufferCount / count;
            if (randomMax < 1)
            {
                randomMax = 1;
                count = bufferCount;
            }
            int numberReturned = 0;
            while (numberReturned < count)
            {
                numberReturned++;
                var toSkip = random.Next(1, randomMax);
                buffer = buffer.Skip(toSkip);
                yield return buffer.FirstOrDefault();
            }
        }
    }
}
