using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiSample;

namespace ShelbyUnitTest
{
    [TestFixture]
    public class Form1TestFixture
    {
        [Test]
        [TestCase("1234", ExpectedResult = true)]
        [TestCase("123456", ExpectedResult = true)]
        [TestCase("63100", ExpectedResult = true)]
        [TestCase("500", ExpectedResult = false)]
        [TestCase("1234567", ExpectedResult = false)]
        [TestCase("Abcd1234", ExpectedResult = false)]
        [TestCase("a4", ExpectedResult = false)]
        [TestCase("1234567", ExpectedResult = false)]
        [TestCase("abcdef", ExpectedResult = false)]
        [TestCase("500,00", ExpectedResult = false)]
        [TestCase("-4000", ExpectedResult = false)]
        [TestCase("500.0", ExpectedResult = false)]
        public bool TestSellPriceValidation(string input)
        {
            var form1 = new Form1();
            bool result = form1.ValidateSellPrice(input);
            return result;
        }

    }
}
