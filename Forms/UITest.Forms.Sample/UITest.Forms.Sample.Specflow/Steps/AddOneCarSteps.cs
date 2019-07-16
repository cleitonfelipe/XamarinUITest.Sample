using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace UITest.Forms.Sample.Specflow.Steps
{
    [Binding]
    public class AddOneCarSteps
    {
        protected IApp app;
        protected Platform platform;
        public AddOneCarSteps()
        {
            this.platform = Platform.Android;
        }

        [BeforeScenario()]
        public void Initialize()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Given(@"the app is started in my device")]
        public void GivenTheAppIsStartedInMyDevice()
        {
            app.Screenshot("App Initialized");
        }
        
        [Given(@"I tap in Add")]
        public void GivenITapInAdd()
        {
            app.Tap(x => x.Marked("Add"));
        }
        
        [Given(@"I enter with ""(.*)"" and ""(.*)""")]
        public void GivenIEnterWithAnd(string mark, string model)
        {
            app.EnterText(x => x.Class("UITextField").Index(0), mark);
            app.EnterText(x => x.Class("UITextView").Index(0), model);
        }

        [When(@"I tap to back")]
        public void WhenITapToBack()
        {
            app.Back();
        }

        [Then(@"the result should be (.*) item on the screen with description ""(.*)""")]
        public void ThenTheResultShouldBeItemOnTheScreenWithDescription(int count, string model)
        {
            var result = app.Query(x => x.Text(model));

            Assert.AreEqual(count, result.Length);
        }
    }
}
