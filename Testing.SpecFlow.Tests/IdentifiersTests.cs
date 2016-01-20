using System;
using Affecto.Testing.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing.SpecFlow.Tests
{
    [TestClass]
    public class IdentifiersTests
    {
        private Identifiers sut;

        [TestInitialize]
        public void Setup()
        {
            sut = new Identifiers();
        }

        [TestMethod]
        public void GeneratingAndGettingGeneratedIdentifier()
        {
            const string text = "text";
            sut.Generate(text);

            Guid result = sut.Get(text);

            Assert.AreNotEqual(Guid.Empty, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GettingAnIdentifierWhenNoIdentifiersAreGenerated()
        {
            sut.Get("text");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GettingAnIdentifierThatIsNotGenerated()
        {
            sut.Generate("text");

            sut.Get("another text");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GeneratingAnIdentifierTwiceForTheSameText()
        {
            const string text = "text";
            sut.Generate(text);

            sut.Generate(text);
        }
    }
}
