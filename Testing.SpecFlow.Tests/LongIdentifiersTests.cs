using System;
using Affecto.Testing.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing.SpecFlow.Tests
{
    [TestClass]
    public class LongIdentifiersTests
    {
        private LongIdentifiers sut;

        [TestInitialize]
        public void Setup()
        {
            sut = new LongIdentifiers();
        }

        [TestMethod]
        public void GeneratingAndGettingGeneratedIdentifier()
        {
            const string text = "text";
            sut.GenerateIdentifier(text);

            long result = sut.GetIdentifier(text);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GeneratingAndGettingTwoGeneratedIdentifiers()
        {
            const string text1 = "text1";
            const string text2 = "text2";

            sut.GenerateIdentifier(text1);
            sut.GenerateIdentifier(text2);

            long result1 = sut.GetIdentifier(text1);
            long result2 = sut.GetIdentifier(text2);

            Assert.AreEqual(1, result1);
            Assert.AreEqual(2, result2);
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