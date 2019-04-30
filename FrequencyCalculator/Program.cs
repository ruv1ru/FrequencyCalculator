using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace FrequencyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<CheckCommonOcccurences>();
        }

    }

    public class CheckCommonOcccurences
    {
        int[] _testArray; 

            /*
                Function that takes an array of integers, and returns an array of integers. 
                The return value contains those integers which are most common in the input array.

                Input => {5, 4, 3, 2, 4, 5, 1, 6, 1, 2, 5, 4}
                Output => {5, 4} or {4, 5}

                Input => {1, 2, 3, 4, 5, 1, 6, 7}
                Output => {1}

                Input => {1, 2, 3, 4, 5, 1, 6, 7}
                Output => {1, 2, 3, 4, 5, 1, 6, 7}
             */
        

        public CheckCommonOcccurences()
        {
            _testArray = GetRandomArray();
        }


        [Benchmark]
        public void BmGetMostCommonViaLinq()
        {
            GetMostCommonViaLinq(_testArray);
        }
        
        [Benchmark]
        public void BmGetMostCommonViaDic()
        {
            GetMostCommonViaDic(_testArray);
        }
        
        [Benchmark]
        public void BmGetMostCommonViaDoubleLoop()
        {
            GetMostCommonViaDoubleLoop(_testArray);
        }


        [Benchmark]
        public void BmGetMostCommonViaSubLoopDic()
        {
            GetMostCommonViaSubLoopDic(_testArray);
        }

        
        private int[] GetRandomArray()
        {
            int[] test = new int[50000]; 

            Random randNum = new Random();
            for (int i = 0; i < test.Length; i++)
            {
                test[i] = randNum.Next(1, 5000);
            }
            return test;
        }

        public static int[] GetMostCommonViaLinq(int[] sourceArray)
        {
            var numbersWithFreq = (from numbers in sourceArray
                    group numbers by numbers into grouped 
                    select new { Number = grouped.Key, Frequency = grouped.Count() }).OrderByDescending(n => n.Frequency);
            
            var maxFreq = numbersWithFreq.Max(n => n.Frequency);

            return numbersWithFreq.Where(n => n.Frequency == maxFreq).Select(n => n.Number).ToArray();


        }


        public static int[] GetMostCommonViaDic(int[] sourceArray)
        {
            
            var freqNumbers = new Dictionary<int, List<int>>() { {1, new List<int> {}} };

            for(int i = 0; i < sourceArray.Length; i++)
            {
                var currentItem = sourceArray[i];
                var dicItem = freqNumbers.FirstOrDefault(kv => kv.Value.Any(v => v == currentItem));

                if(dicItem.Key > 0)
                {

                    var nextKey = dicItem.Key + 1;

                    dicItem.Value.Remove(currentItem);

                    if(freqNumbers.ContainsKey(nextKey))
                    {
                        freqNumbers[nextKey].Add(currentItem);
                    }
                    else
                    {
                        freqNumbers.Add(nextKey, new List<int>{ currentItem });
                    }
                }
                else
                {
                    freqNumbers[1].Add(currentItem);
                }
            }


            return freqNumbers[freqNumbers.Keys.Max()].ToArray();

        }
    
        public static int[] GetMostCommonViaDoubleLoop(int[] sourceArray)
        {
            var maxFreqNumbers = new List<int>();
            var maxFreq = 1;

            for(int i = 0; i < sourceArray.Length; i++)
            {
                var currentItem = sourceArray[i];

                var freq = 0;

                for(int j = 0; j < sourceArray.Length; j++)
                {
                    if(sourceArray[j] == currentItem) 
                    {
                        freq++;
                    }

                }

                if(freq > maxFreq)
                {
                    maxFreqNumbers = new List<int>{currentItem};
                    maxFreq = freq;
                }
                else if (freq == maxFreq && !maxFreqNumbers.Any(n => n == currentItem))
                {
                    maxFreqNumbers.Add(currentItem);
                }
            }

            return maxFreqNumbers.ToArray();


        }

        public static int[] GetMostCommonViaSubLoopDic(int[] sourceArray)
        {
            var numberFreq = new Dictionary<int, int>();

            for(int i = 0; i < sourceArray.Length; i++)
            {
                var currentItem = sourceArray[i];

                if(numberFreq.ContainsKey(currentItem)) continue;
                
                var freq = 1;

                if(i == sourceArray.Length - 1) 
                {
                    numberFreq.Add(currentItem, freq);
                    break;
                }

                for(int j = i + 1; j < sourceArray.Length; j++)
                {
                    if(sourceArray[j] == currentItem) 
                    {
                        freq++;
                    }

                }

                numberFreq.Add(currentItem, freq);


            }

            var maxFreq = numberFreq.Values.Max();
            return numberFreq.Where(n => n.Value == maxFreq).Select(k => k.Key).ToArray();



        }
    }
}
