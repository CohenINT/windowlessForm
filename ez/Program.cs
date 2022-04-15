

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ez
{
    public static class Helpers
    {
        public static bool TryAddValue(this Dictionary<int, int> _dict, int key, int value)
        {
            if (_dict == null)
                return false;

            if (_dict.ContainsKey(key))
                return false;

            _dict.Add(key, value);
            return true;

        }

    }
    public class Result
    {
        public static void staircase(int n)
        {
            int timesPerLine = 1;

            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n - timesPerLine; j++)
                {
                    Console.Write(' ');
                }
                for (int k = 0; k < timesPerLine; k++)
                {
                    Console.Write('#');
                }


                if (i != (n - 1))
                    Console.WriteLine(" ");
                timesPerLine++;
            }

        }
        public static List<int> Sort(List<int> arr)
        {
            int temp = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < arr.Count - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }

            }

            return arr;
        }
        public static void miniMaxSum(List<int> arr)
        { // arr = [1,2,3,4,5]  max - 14  , min - 10  . result => 10 14
            arr = Sort(arr);
            Int64 min = 0;
            Int64 max = 0;
            for (int i = 0; i < arr.Count - (arr.Count - 4); i++)
            {// Summing the minimum
                min += arr[i];
            }
            for (int i = arr.Count - 1; i >= 0 + (arr.Count - 4); i--)
            {// Summing the maximum
                max += arr[i];
            }

            Console.WriteLine($"{min} {max}");



        }
        public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
        {
            ////Test
            //ranked = new List<int>() { 100, 90, 90, 80, 75, 60 };
            //player = new List<int>() { 50, 65, 77, 90, 102 };

            var rankDict = new Dictionary<int, int>();
            var playerRes = new List<int>();
            int _res = 0;

            for (int i = 0, j = 1; i < ranked.Count; i++)
            {

                if (rankDict.TryAddValue(ranked[i], j))
                {
                    j++;
                }

            }


            for (int i = 0; i < player.Count; i++)
            {
                if (rankDict.TryGetValue(player[i], out int val))
                {
                    playerRes.Add(val);
                    continue;
                }
                // Else, didn't find the right key, get the overrun element.
                var firstElm = rankDict.Where(x => player[i] > x.Key).FirstOrDefault();
                if (firstElm.Value == 0)
                { // our player rank is the lowest, get last rank
                    firstElm = rankDict.LastOrDefault();
                    _res = firstElm.Value + 1;
                }
                else
                {// our player rank passed something, get that element rank
                    _res = firstElm.Value;

                }
                playerRes.Add(_res);
                continue;


            }

            return playerRes;



        }

    }

    public static class Program
    {
        public static Stopwatch watch = new Stopwatch();
        public static int GetStuffDone(int[] arr)
        {
            HashSet<int> buffer = new HashSet<int>();
            int biggest = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                buffer.Add(arr[i]);
                if (buffer.Contains(arr[i] * -1) && biggest < Math.Abs(arr[i]))
                {
                    biggest = Math.Abs(arr[i]);
                }
            }
            return biggest;
        }
        public static int GetBiggestWithNegative(int[] arr)
        {
            //HashSet<int> buffer = new HashSet<int>();
            arr = Sort(arr);

            for (int i = arr.Length - 1; i > 0; i--)
            {
                for (int j = arr.Length - 1; j > 0; j--)
                {
                    if (arr[j] == (arr[i] * (-1)))
                    {
                        return arr[i];
                    }
                }
            }

            return -1;// error not found
        }
        public static int[] Sort(int[] arr)
        {
            int temp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }

            }

            return arr;
        }

        public static int birthdayCakeCandles(List<int> candles)
        {// 4 4 13 5 15 1 

            IDictionary<int, int> dict = new Dictionary<int, int>();
            int max = 0;

            for (int i = 0; i < candles.Count; i++)
            {

                try
                {
                    if (candles[i] > max)
                        max = candles[i];

                    dict.Add(candles[i], 1);
                }
                catch (Exception ex)
                {
                    dict[candles[i]]++;

                }  // If failed, there might be already identical key, so just add another one to value.

            }

            // up to this point we have dictionary of all numbers with their instances amount (if there are any).
            return dict[max];
        }

        public static bool TryGetValue(this int[] nums, int currentIndex, int targetValue, out int searchIndex)
        {
            var ret = Array.FindIndex<int>(nums, (n) => n == (targetValue - nums[currentIndex]));
            if (ret != -1 && ret != currentIndex)
            {
                searchIndex = ret;
                return true;
            }
            searchIndex = -1;
            return false;
        }
        public static int[] TwoSum(int[] nums, int target)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums.TryGetValue(i, target, out int searchIndex))
                {
                    return new int[] { i, searchIndex };
                }
            }


            return null;
        }


        public static int PureRecrusion(JObject d)
        {
            int sum = 0;

            if (d.Count == 0|| !d.HasValues  )
                return sum;
            
            
            //d.Properties().FirstOrDefault().type
            //sum = sum + PureRecrusion(); 
            return -1;

        }



        public class StudentModel
        {
            public int Grade { set; get; }
            public string Name { set; get; }
            public int Age { set; get; }
        }
        public class TempModel
        {
            public int Age { set; get; }
            public StudentModel Student { set; get; }

        }
        static async Task Main(string[] args)
        {

            var data = new TempModel() { Age = 21, Student = new StudentModel() { Age = 55, Grade = 100, Name = "Mikasa" } };
            var data_OBJ = JObject.FromObject(data);
            int result = PureRecrusion(data_OBJ);


        }



    }
}
