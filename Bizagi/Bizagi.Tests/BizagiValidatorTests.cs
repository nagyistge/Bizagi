using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bizagi.Services;
using System.Xml.Linq;
using System.Linq;

namespace Bizagi.Tests
{
    [TestClass]
    public class BizagiValidatorTests
    {
        [TestMethod]
        public void Sample1ShouldReturnErrorValidationResponses()
        {
            //arrange
            var xml = XElement.Load("Sample 1.xpdl");
            var validator = new BizagiValidator();
            
            //act
            var responses = validator.Validate(xml);

            //assert
            Assert.IsTrue(responses.Count == 2);
            Assert.IsTrue(responses.Select(r => r.ElementId)
                .Contains(Guid.Parse("6082a312-32d1-44bd-90a0-a055fd22f1b1")));
            Assert.IsTrue(responses.Select(r => r.ElementId)
                .Contains(Guid.Parse("c18b9d3a-e828-43d7-bda9-794c8fc79e7a")));
        }

        [TestMethod]
        public void Sample3ShouldReturnErrorValidationResponses()
        {
            //arrange
            var xml = XElement.Load("Sample 3.xpdl");
            var validator = new BizagiValidator();

            //act
            var responses = validator.Validate(xml);

            //assert
            Assert.IsTrue(responses.Count == 2);
            Assert.IsTrue(responses.Select(r => r.ElementId)
                .Contains(Guid.Parse("87d624f2-bd9b-412e-baed-c829a5740d25")));
            Assert.IsTrue(responses.Select(r => r.ElementId)
                .Contains(Guid.Parse("e60e9639-7fa2-46dd-9a77-aaae3b3de4ff")));
        }
    }
}
