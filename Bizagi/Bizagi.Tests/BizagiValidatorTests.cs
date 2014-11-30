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
            //Assert.IsTrue(responses.Count == 3);
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
            //Assert.IsTrue(responses.Count == 2);
            Assert.IsTrue(responses.Select(r => r.ElementId)
                .Contains(Guid.Parse("87d624f2-bd9b-412e-baed-c829a5740d25")));
            Assert.IsTrue(responses.Select(r => r.ElementId)
                .Contains(Guid.Parse("e60e9639-7fa2-46dd-9a77-aaae3b3de4ff")));
        }

        [TestMethod]
        public void Sample4ShouldReturnErrorValidationResponsesThrow()
        {
            //arrange
            var xml = XElement.Load("Sample 4.xpdl");
            var validator = new BizagiValidator();

            //act
            var responses = validator.Validate(xml);

            //assert
            //Assert.IsTrue(responses.Count == 2);
            Assert.IsTrue(responses.Select(r => r.ElementId)
                .Contains(Guid.Parse("b097b926-3faa-43a2-8af9-0eeea24e1457")));
        }

        [TestMethod]
        public void Sample4ShouldReturnErrorValidationResponsesCatch()
        {
            //arrange
            var xml = XElement.Load("Sample 4.xpdl");
            var validator = new BizagiValidator();

            //act
            var responses = validator.Validate(xml);

            //assert
            //Assert.IsTrue(responses.Count == 2);
            Assert.IsTrue(responses.Select(r => r.ElementId)
                .Contains(Guid.Parse("d2fcd615-aa97-4f74-a8c1-3c55409b1d5a")));
        }

        [TestMethod]
        public void Sample2ShouldReturnErrorValidationResponses()
        {
            //arrange
            var xml = XElement.Load("Sample 2.xpdl");
            var validator = new BizagiValidator();

            //act
            var responses = validator.Validate(xml);

            //assert
            Assert.IsTrue(responses.Select(r => r.ElementId)
                .Contains(Guid.Parse("4344453a-134d-4476-91ec-4793f03a4e69")));
        }
    }
}
