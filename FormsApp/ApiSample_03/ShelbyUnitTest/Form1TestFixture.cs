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


        [Test]
        [TestCase("1234", ExpectedResult = false)]
        [TestCase("123456", ExpectedResult = false)]
        [TestCase("63100", ExpectedResult = false)]
        [TestCase("1234aabc", ExpectedResult = false)]
        [TestCase("ab63100", ExpectedResult = true)]
        [TestCase("ab&c", ExpectedResult = false)]
        [TestCase("ab-c", ExpectedResult = false)]
        [TestCase(")c", ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        [TestCase("abcd", ExpectedResult = true)]
        [TestCase("AbCd", ExpectedResult = true)]
        [TestCase("Abc8d", ExpectedResult = true)]
        public bool TestNonEmptyValidation(string input)
        {
            var form1 = new Form1();
            bool result = form1.ValidateNonEmpty(input);
            return result;
        }

    }
}
