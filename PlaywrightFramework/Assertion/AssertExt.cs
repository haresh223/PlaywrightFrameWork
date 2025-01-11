using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWright.Assertion
{
    internal class AssertExt
    {
        public static void IsTrue(bool condition, string message)
        {
            if (condition)
            {
                Setup.test.Pass(message);
            }
            else
            {
                Setup.test.Fail(message);
            }
            Assert.IsTrue(condition);
        }

        public static void IsFalse(bool condition, string message)
        {
            if (!condition)
            {
                Setup.test.Pass(message);
            }
            else
            {
                Setup.test.Fail(message);
            }
            Assert.IsFalse(condition);
        }

        public static void AreEqual(string value1, string value2, string message)
        {
            if (value1 == value2)
            {
                Setup.test.Pass(message);
            }
            else
            {
                Setup.test.Fail($"{value1} is not equals to {value2}");
            }
            Assert.AreEqual(value1, value2, message);
        }

        public static void AreNotEqual(string value1, string value2, string message)
        {
            if (value1 != value2)
            {
                Setup.test.Pass(message);
            }
            else
            {
                Setup.test.Fail($"{value1} is equals to {value2}");
            }
            Assert.AreNotEqual(value1, value2, message);
        }
    }
}
