using BMICalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UnitTestBMICalcInputs
{
    [TestClass]
    public class BMICalculationTest
    {
        public object RegularExpression { get; private set; }

        [TestMethod]
        public void TestInputs_WeightStones()
        {
            // Arrange
            BMI bmiCalTest = new BMI();

            // Act
            bmiCalTest.WeightStones = 50;
            //bmiCalTest.WeightPounds = 3;
            //bmiCalTest.HeightFeet = 5;
            //bmiCalTest.HeightInches = 11;

            // Assert
            Assert.IsTrue(bmiCalTest.WeightStones >= 5 && bmiCalTest.WeightStones <= 50);

        }

        [TestMethod]
        public void TestInputs_Pounds()
        {
            // Arrange
            BMI bmiCalTest = new BMI();

            // Act
            //bmiCalTest.WeightStones = 120;
            bmiCalTest.WeightPounds = 13;
            //bmiCalTest.HeightFeet = 5;
            //bmiCalTest.HeightInches = 11;

            // Assert
            Assert.IsTrue(bmiCalTest.WeightPounds >= 0 && bmiCalTest.WeightPounds <= 13);

        }

        [TestMethod]
        public void TestInputs_HeightFeet()
        {
            // Arrange
            BMI bmiCalTest = new BMI();

            // Act
            //bmiCalTest.WeightStones = 120;
            //bmiCalTest.WeightPounds = 3;
            bmiCalTest.HeightFeet = 8;
            //bmiCalTest.HeightInches = 11;

            // Assert
            Assert.IsTrue(bmiCalTest.HeightFeet >= 3 && bmiCalTest.HeightFeet <= 8);

        }

        [TestMethod]
        public void TestInputs_Inches()
        {
            // Arrange
            BMI bmiCalTest = new BMI();

            // Act
            //bmiCalTest.WeightStones = 120;
            //bmiCalTest.WeightPounds = 3;
            //bmiCalTest.HeightFeet = 5;
            bmiCalTest.HeightInches = 11;

            // Assert
            Assert.IsTrue(bmiCalTest.HeightInches >= 0 && bmiCalTest.HeightInches <= 12);

        }

        [TestMethod]
        public void Test_UnderWeightUpperLimit()
        {
            //Arrange
            BMI bmiCalTest = new BMI();
            bmiCalTest.WeightStones = 5; 
            bmiCalTest.WeightPounds = 3;
            bmiCalTest.HeightFeet = 5;
            bmiCalTest.HeightInches = 11;

            //Act
            double actualResult = bmiCalTest.BMIValue;  //Person is under weight

            // Assert
            Assert.IsTrue(actualResult <= 18.4);

        }

        [TestMethod]
        public void Test_NormalWeightUpperLimit()
        {
            //Arrange
            BMI bmiCalTest = new BMI();
            bmiCalTest.WeightStones = 10;
            bmiCalTest.WeightPounds = 3;
            bmiCalTest.HeightFeet = 5;
            bmiCalTest.HeightInches = 11;

            //Act
            double actualResult = bmiCalTest.BMIValue;  //Person is normal weight

            // Assert
            Assert.IsTrue(actualResult > 18.4 && actualResult <= 24.9);

        }

        [TestMethod]
        public void Test_OverWeightUpperLimit()
        {
            //Arrange
            BMI bmiCalTest = new BMI();
            bmiCalTest.WeightStones = 13;
            bmiCalTest.WeightPounds = 3;
            bmiCalTest.HeightFeet = 5;
            bmiCalTest.HeightInches = 11;

            //Act
            double actualResult = bmiCalTest.BMIValue;  //Person is Overweight

            // Assert
            Assert.IsTrue(actualResult > 24.9 && actualResult <= 29.9);

        }


        [TestMethod]
        public void Test_Obese()
        {
            //Arrange
            BMI bmiCalTest = new BMI();
            bmiCalTest.WeightStones = 18;
            bmiCalTest.WeightPounds = 3;
            bmiCalTest.HeightFeet = 5;
            bmiCalTest.HeightInches = 11;

            //Act
            double actualResult = bmiCalTest.BMIValue;  //Person is Obese

            // Assert
            Assert.IsTrue(actualResult > 24.9);

        }

        [TestMethod]
        public void TestBMICalculation_Calculates_ReturnBMIValue()
        {
            //Arrange
            BMI bmiCalTest = new BMI();
            bmiCalTest.WeightStones = 12;
            bmiCalTest.WeightPounds = 3;
            bmiCalTest.HeightFeet = 5;
            bmiCalTest.HeightInches = 11;


            double totalWeightInPounds = (12 * 14) + 3;
            double totalHeightInInches = (5 * 12) + 11;

            // do conversions to metric
            double totalWeightInKgs = totalWeightInPounds * 0.453592;
            double totalHeightInMetres = totalHeightInInches * 0.0254;

            Decimal expectedResult = (Decimal)(totalWeightInKgs / (System.Math.Pow(totalHeightInMetres, 2)));


            //Act
            Decimal actualResult = (Decimal)(bmiCalTest.BMIValue);

            //Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void Test_Valid_Fullname()
        {
            //Arrange
            BMI bmiCalTest = new BMI();

            //Act
            bmiCalTest.Fullname = "David Ginty";


            // Assert
            Assert.IsTrue(Regex.IsMatch(bmiCalTest.Fullname, "^[a-zA-Z\\s]+$"));

        }

       


    }
}

/*
    [TestClass]
    public class BMIInputWeightStones_Range_Test
    {
         [TestMethod]
        public void TestBMICalculation_WeightStonesInputRange_ReturnBMIValue()
        {
            //Arrange
            BMI bmiCalTest = new BMI();
            bmiCalTest.WeightStones = 50;   //Changed input for test to value outside validate Range (between 5 and 50)
            bmiCalTest.WeightPounds = 3;
            bmiCalTest.HeightFeet = 5;
            bmiCalTest.HeightInches = 11;

            double totalWeightInPounds = -1;
            // WeightStones range expected inputs
            if ((bmiCalTest.WeightStones >= 5) && (bmiCalTest.WeightStones <= 50))
            {
                //Valid input do nothing.
                totalWeightInPounds = (bmiCalTest.WeightStones * 14) + bmiCalTest.WeightPounds;
            }
            else
            {
                //Forced failed input.
                totalWeightInPounds = (-1 * 14) + bmiCalTest.WeightPounds;
            }

            double totalHeightInInches = (bmiCalTest.HeightFeet * 12) + bmiCalTest.HeightInches;

            // do conversions to metric
            double totalWeightInKgs = totalWeightInPounds * 0.453592;
            double totalHeightInMetres = totalHeightInInches * 0.0254;

            Decimal expectedResult = (Decimal)(totalWeightInKgs / (System.Math.Pow(totalHeightInMetres, 2)));


            //Act
            Decimal actualResult = (Decimal)(bmiCalTest.BMIValue);

            //Assert
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}

    */