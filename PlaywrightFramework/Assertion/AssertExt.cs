using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightFramework.Assertion
{
    internal class AssertExt
    {
        public static void IsTrue(bool condition, string message)
        {
            if (condition)
            {
                Hooks.scenario.Pass(message);
            }
            else
            {
                Hooks.scenario.Fail(message);
            }
            Assert.That(condition, Is.True, message);
            
        }

        public static void IsFalse(bool condition, string message)
        {
            if (!condition)
            {
                Hooks.scenario.Pass(message);
            }
            else
            {
                Hooks.scenario.Fail(message);
            }
            Assert.That(condition,Is.False,message);
        }

        public static void AreEqual(string value1, string value2, string message)
        {
            if (value1 == value2)
            {
                Hooks.scenario.Pass(message);
            }
            else
            {
                Hooks.scenario.Fail($"{value1} is not equals to {value2}");
            }
            Assert.That(value1, Is.EqualTo(value2),message);
            
        }

        public static void AreNotEqual(string value1, string value2, string message)
        {
            if (value1 != value2)
            {
                Hooks.scenario.Pass(message);
            }
            else
            {
                Hooks.scenario.Fail($"{value1} is equals to {value2}");
            }
            Assert.That(value1, Is.Not.EqualTo(value2), message);

        }
    }
}
