using System;
using Affecto.Testing.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing.SpecFlow.Tests
{
    [TestClass]
    public class GuidIdentifiersTests
    {
        private GuidIdentifiers sut;

        [TestInitialize]
        public void Setup()
        {
            sut = new GuidIdentifiers();
        }

        [TestMethod]
        public void GeneratingAndGettingGeneratedIdentifier()
        {
            const string text = "text";
            sut.GenerateIdentifier(text);

            Guid result = sut.GetIdentifier(text);

            Assert.AreNotEqual(Guid.Empty, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GettingAnIdentifierWhenNoIdentifiersAreGenerated()
        {
            sut.GetIdentifier("text");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GettingAnIdentifierThatIsNotGenerated()
        {
            sut.GenerateIdentifier("text");

            sut.GetIdentifier("another text");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GeneratingAnIdentifierTwiceForTheSameText()
        {
            const string text = "text";
            sut.GenerateIdentifier(text);

            sut.GenerateIdentifier(text);
        }
    }
}