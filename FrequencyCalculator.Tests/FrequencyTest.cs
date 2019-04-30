using NUnit.Framework;
using FrequencyCalculator;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {

        private int[] _multipleSource;
        private int[] _singleSource;
        private int[] _allSource;

        [SetUp]
        public void Setup()
        {
            _multipleSource = new int[]{5, 4, 3, 2, 4, 5, 1, 6, 1, 2, 5, 4};
            _singleSource = new int[]{1, 2, 3, 4, 5, 1, 6, 7};
            _allSource = new int[]{1, 2, 3, 4, 5, 6, 7};
        }

         [Test]
         public void CheckSingleCommonOcccurences_ShouldReturnOneValue()
         {

              var testInput = GetSingleCommonOccurenceArray();

              var result =  CheckCommonOcccurences.GetMostCommonViaDic(testInput);

              AssertSingle(result);

              result = CheckCommonOcccurences.GetMostCommonViaLinq(testInput);

              AssertSingle(result);

              result = CheckCommonOcccurences.GetMostCommonViaSubLoopDic(testInput);

              AssertSingle(result);

              result = CheckCommonOcccurences.GetMostCommonViaDoubleLoop(testInput);

              AssertSingle(result);

         }

         [Test]
         public void CheckMultipleCommonOcccurences_ShouldReturnMultipleValues()
         {

              var testInput = GetMultipleCommonOccurenceArray();

              var result =  CheckCommonOcccurences.GetMostCommonViaDic(testInput);

                AssertMultiple(result);


               result = CheckCommonOcccurences.GetMostCommonViaLinq(testInput);


                AssertMultiple(result);



               result = CheckCommonOcccurences.GetMostCommonViaSubLoopDic(testInput);


                AssertMultiple(result);

            
               result = CheckCommonOcccurences.GetMostCommonViaDoubleLoop(testInput);

                AssertMultiple(result);



         }



         [Test]
         public void CheckAllCommonOcccurences_ShouldReturnAllValues()
         {
              var testInput = GetAllCommonOccurenceArray();

              var result =  CheckCommonOcccurences.GetMostCommonViaDic(testInput);

              AssertAll(result);

              result = CheckCommonOcccurences.GetMostCommonViaLinq(testInput);

              AssertAll(result);

              result = CheckCommonOcccurences.GetMostCommonViaSubLoopDic(testInput);

              AssertAll(result);

              result = CheckCommonOcccurences.GetMostCommonViaDoubleLoop(testInput);

              AssertAll(result);
         }
         
         
         void AssertMultiple(int[] result)
         {

            Assert.AreEqual(result.Length, 2);
            Assert.True(result[0] == 4 || result[0] == 5);
            Assert.True(result[1] == 4 || result[1] == 5);
            Assert.False(result[0] == 4 && result[1] == 4);
            Assert.False(result[0] == 5 && result[1] == 5);
         }
         void AssertSingle(int[] result)
         {
               Assert.AreEqual(result.Length, 1);
               Assert.True(result[0] == 1);
         }
         void AssertAll(int[] result)
         {
            Assert.AreEqual(result.Length, 7);
         }

         int[] GetSingleCommonOccurenceArray()
         {
            return _singleSource;
         }
         int[] GetMultipleCommonOccurenceArray()
         {
            return _multipleSource;
         }
         int[] GetAllCommonOccurenceArray()
         {
            return _allSource;
         }
    }
}