using JustGiving.QA.Framework;
//using NUnit.Framework;
using TechTalk.SpecFlow;

namespace JustGiving.QA.Web.Tests
{
    public  class BaseTest
    {
        [BeforeScenario()]
        public  void InitDriver()
        {
            Browser.Initialize();
        }

        [AfterScenario()]
        public  void Teardown()
        {
            Browser.Close();
        }

    }
}