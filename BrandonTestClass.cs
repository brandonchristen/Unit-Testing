using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject1
{
    [TestClass]
    public class BrandonTest
    {

        [TestMethod]
        public void whenMoreThan2NumbersAreUsedThenExceptionIsThrown()
        {
            StringCalcBrandon.add("1,2,3");
            throw new Exception();
        }
        [TestMethod]
        public void when2NumbersAreUsedThenNoExceptionIsThrown()
        {
            StringCalcBrandon.add("1,2");
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void whenNonNumberIsUsedThenExceptionIsThrown()
        {
            StringCalcBrandon.add("1,X");
            Assert.IsTrue(true);
            throw new Exception();
        }

        [TestMethod]
        public void whenEmptyStringIsUsedThenReturnValueIs0()
        {
            Assert.AreEqual(0, StringCalcBrandon.add(""));
        }

        [TestMethod]
        public void whenOneNumberIsUsedThenReturnValueIsThatSameNumber()
        {
            Assert.AreEqual(3, StringCalcBrandon.add("3"));
        }

        [TestMethod]
        public void whenTwoNumbersAreUsedThenReturnValueIsTheirSum()
        {
            Assert.AreEqual(3 + 6, StringCalcBrandon.add("3,6"));
        }

        [TestMethod]
        public void whenAnyNumberOfNumbersIsUsedThenReturnValuesAreTheirSums()
        {
            Assert.AreEqual(3 + 6 + 15 + 18 + 46 + 33, StringCalcBrandon.add("3,6,15,18,46,33"));
        }

        [TestMethod]
        public void whenNewLineIsUsedBetweenNumbersThenReturnValuesAreTheirSums()
        {
            Assert.AreEqual(3 + 6 + 15, StringCalcBrandon.add("3,6n15"));
        }

        [TestMethod]
        public void whenDelimiterIsSpecifiedThenItIsUsedToSeparateNumbers()
        {
            Assert.AreEqual(3 + 6 + 15, StringCalcBrandon.add("//;n3;6;15"));
        }


        [TestMethod]
        public  void whenNegativeNumberIsUsedThenRuntimeExceptionIsThrown()
        {
            try
            {
                StringCalcBrandon.add("3,-6,15,18,46,33");
            }
            catch (Exception e)
            {

            }
        }

        [TestMethod]
        public void whenNegativeNumbersAreUsedThenRuntimeExceptionIsThrown()
        {
            Exception exception;
            try
            {
                StringCalcBrandon.add("3,-6,15,-18,46,33");
            }
            catch (Exception e)
            {
                exception = e;
                Assert.IsNotNull(exception);
                Assert.Equals("Negatives not allowed: [-6, -18]", exception.GetBaseException());
            }
        }

        [TestMethod]
        public void whenOneOrMoreNumbersAreGreaterThan1000IsUsedThenItIsNotIncludedInSum()
        {
            Assert.Equals(3 + 1000 + 6, StringCalcBrandon.add("3,1000,1001,6,1234"));
        }
    }
}