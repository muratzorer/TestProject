using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace TestApplication.Integration.Tests
{
    [Binding]
    public class DenemeSteps
    {
        private int sum = 0;
        [Given]
        public void Given_I_have_entered_P0_into_the_calculator(int p0)
        {
            sum = sum + p0;
        }
        
        [When]
        public void When_I_press_add()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then]
        public void Then_the_result_should_be_P0_on_the_screen(int p0)
        {
            Assert.AreEqual(sum, p0);
        }
    }
}
