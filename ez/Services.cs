using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ez
{
    public static class Services
    {

        private async static Task<int> Pow(int x, int y)
        {
            int result = 1;
            for (int i = 0; i < y; i++)
            {
                result *= x;
            }

            return result;
        }
        public static async Task<IList<int>> StreamPow(this List<int> _array, int pow, int mergeCount = 1)
        {

            var result = await _array
                  .ToObservable()
                  .Select(x => Observable.FromAsync(async () =>
                  {
                      return await Services.Pow(x, 2);
                  }))
                  .Merge(mergeCount)
                  .ToList();

            return result;


        }
        public static async Task<List<int>> ForPow(this List<int> _array, int pow)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < _array.Count; i++)
            {
                result.Add(await Pow(_array[i], 2));
            }

            return result;

        }
        public static async Task<List<int>> ForeachPow(this List<int> _array, int pow)
        {
            var result = new List<int>();
            foreach (int i in _array)
            {
                result.Add(await Pow(i, 2));
            }

            return result;
        }


    }
}
