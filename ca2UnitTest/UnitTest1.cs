using Microsoft.VisualStudio.TestTools.UnitTesting;
using BMICalculator;
using System;
using BMICalculator.Pages;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.TestHost;
using System.Net;

namespace ca2UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        const double UnderWeightUpperLimit = 18.4;             
        const double NormalWeightUpperLimit = 24.9;
        const double OverWeightUpperLimit = 29.9;
        const double stonesToPounds = 14;
        const double feetToInches = 12;
        const double PoundsToKgs = 0.453592;
        const double InchestoMetres = 0.0254;
      

        [TestMethod]
        public void TestBMICategory()
        {
            var bmi = new BMI();
            var bmivalue = bmi.BMIValue;
            BMICategory result;
            BMICategory actual;
            

            if (bmivalue <= UnderWeightUpperLimit)
            {
                result = bmi.BMICategory;
                actual = BMICategory.Underweight;
                Assert.AreEqual(result, actual);
            }
            else if (bmivalue <= NormalWeightUpperLimit)
            {
                result = bmi.BMICategory;
                actual = BMICategory.Normal;
                Assert.AreEqual(result, actual);
            }
            else if (bmivalue <= OverWeightUpperLimit)
            {
                result = bmi.BMICategory;
                actual = BMICategory.Overweight;
                Assert.AreEqual(result, actual);
            }
            else
            {
                result = bmi.BMICategory;
                actual = BMICategory.Obese;
            }
            Assert.AreEqual(result, actual);
        }

     
        [TestMethod]

        public void TestWeightInPoundsNotNull()
        {
            var bmi = new BMI();
            Random rd = new Random();
            var stones = rd.Next(5, 50);
            var pounds = rd.Next(0, 13);
            double weightInPounds = (stones + stonesToPounds) + pounds;
            Assert.IsNotNull(weightInPounds);
        }
        [TestMethod]
        public void ProperWeightStoneStoreCorrectly()
        {
            var bmi = new BMI();
            bmi.WeightStones = 20;
            Assert.AreEqual(bmi.WeightStones,20);
        }

        [TestMethod]
        public void ProperPoundStoreCorrectly()
        {
            var bmi = new BMI();
            bmi.WeightPounds = 7;
            Assert.AreEqual(bmi.WeightPounds, 7);
        }

        [TestMethod]
        public void ProperInchStoreCorrectly()
        {
            var bmi = new BMI();
            bmi.HeightInches = 7;
            Assert.AreEqual(bmi.HeightInches, 7);
        }

        [TestMethod]
        public void ProperFeetStoreCorrectly()
        {
            var bmi = new BMI();
            bmi.HeightFeet = 6;
            Assert.AreEqual(bmi.HeightFeet, 6);
        }

        [TestMethod]
        public void NormalCategory()
        {
            var bmi = new BMI();
            bmi.WeightStones = 15;
            bmi.HeightFeet = 6;
            bmi.WeightPounds = 7;
            bmi.HeightInches = 7;
            if(bmi.BMIValue <= NormalWeightUpperLimit)
            {
                var result = bmi.BMICategory;
            }

            Assert.AreEqual(bmi.BMICategory, BMICategory.Normal);
        }

        [TestMethod]
        public void TestUnderweightBMICAtegoryIsValid()
        {
            var bmi = new BMI();
            bmi.WeightStones = 5;
            bmi.HeightFeet = 6;
            bmi.WeightPounds = 2;
            bmi.HeightInches = 7;
            if (bmi.BMIValue <= NormalWeightUpperLimit)
            {
                var result = bmi.BMICategory;
            }

            Assert.AreEqual(bmi.BMICategory, BMICategory.Underweight);
        }

        [TestMethod]
        public void TestOverweightBMICAtegoryIsValid()
        {
            var bmi = new BMI();
            bmi.WeightStones = 18;
            bmi.HeightFeet = 6;
            bmi.WeightPounds = 2;
            bmi.HeightInches = 7;
            if (bmi.BMIValue <= NormalWeightUpperLimit)
            {
                var result = bmi.BMICategory;
            }

            Assert.AreEqual(bmi.BMICategory, BMICategory.Overweight);
        }

        [TestMethod]
        public void AboutPageMessage()
        {
             //var bmi = new BMI();
            //  Assert.AreEqual(BMICalculator.Pages.AboutModel);
            // BMICalculator.Pages.AboutModel
           //var test = new BMICalculator.Pages._Pages_About();
            var test = new BMICalculator.Pages.AboutModel();
            test.Message = "hi";
            Assert.AreEqual(test.Message, "hi");
        }

        [TestMethod]
        public void SetMessagesInAboutPagesIsValid()
        {
            var about = new AboutModel();
            about.Message = "This is New!";
            Assert.IsNotNull(about.Message);
            Assert.AreEqual(about.Message, "This is New!");
        }

        [TestMethod]
        public void setBMIInBmiModelIsValid()
        {
            var bmi = new BmiModel();
            bmi.BMI = new BMI();
            Assert.IsNotNull(bmi.BMI);
        }

        [TestMethod]
        public void SetMessagesInContactPagesIsValid()
        {
            var contact = new ContactModel();
            contact.Message = "This is how";
            Assert.IsNotNull(contact.Message);
            Assert.AreEqual(contact.Message, "This is how");
        }

        [TestMethod]
        public void TestSetRequestIdIsNotNull()
        {
            var errorHandler = new ErrorModel();
            errorHandler.RequestId = "id123";
            Assert.IsNotNull(errorHandler.RequestId);
        }

        [TestMethod]
        public void TestGetShowRequestIdIsNotNull()
        {
            var errorHandler = new ErrorModel();
            errorHandler.RequestId = "id123";
            Assert.IsTrue(errorHandler.ShowRequestId);
        }

        [TestMethod]
        public void AboutPageOnGet()
        {
            // var bmi = new BMI();
            //  Assert.AreEqual(BMICalculator.Pages.AboutModel);
            // BMICalculator.Pages.AboutModel
           //var test = new BMICalculator.Pages._Pages_About();
            var test = new BMICalculator.Pages.AboutModel();
            
            test.Message = "hi";
            string imessage = "hi";
           // string messgae2 = test.OnGet();
            var about = new AboutModel();

            //var reader = about.;
            // Assert.AreEqual(test.OnGet());
            
            test.OnGet(imessage);
          //  Assert.IsNotNull(test.OnGet(imessage),null);
            
        }
        [TestMethod]
        public void ContactPageOnGet()
        {
            // var bmi = new BMI();
            //  Assert.AreEqual(BMICalculator.Pages.AboutModel);
            // BMICalculator.Pages.AboutModel
            //var test = new BMICalculator.Pages._Pages_About();
            var test = new BMICalculator.Pages.ContactModel();

            test.Message = "hi";
        
          
            test.OnGet();
            //  Assert.IsNotNull(test.OnGet());

        }

        [TestMethod]
        public void PrivacyPageOnGet()
        {
            // var bmi = new BMI();
            //  Assert.AreEqual(BMICalculator.Pages.AboutModel);
            // BMICalculator.Pages.AboutModel
            //var test = new BMICalculator.Pages._Pages_About();
            var test = new BMICalculator.Pages.PrivacyModel();

            //test.Message = "hi";
           // string imessage = "hi";

            test.OnGet();
            //  Assert.IsNotNull(test.OnGet());

        }

        
    }

   

}
