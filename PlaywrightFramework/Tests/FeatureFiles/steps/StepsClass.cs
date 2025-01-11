using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace PlaywrightFramework.Tests.FeatureFiles.steps
{
    [Binding]
    public class StepsClass
    {
        [Given(@"Our Step (.*)")]
        public void GivenOurStep(int p0)
        {
            throw new PendingStepException();
        }
        [When(@"Our step (.*)")]
        public void WhenOurStep(int p0)
        {
            throw new PendingStepException();
        }

    }
}
