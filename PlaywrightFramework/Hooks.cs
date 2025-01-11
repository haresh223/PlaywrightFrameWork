using AventStack.ExtentReports;
using AventStack.ExtentReports.Configuration;
using AventStack.ExtentReports.Gherkin.Model;
using PlaywrightFramework.SetUpClasses;
using Portal.Automation.Framework.Report;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace PlaywrightFramework
{
    [Binding]
    public sealed class Hooks
    {

        public static BrowserAsync BrowserAsync { get; set; }
        public static ExtentTest feature;
        public static ExtentTest scenario;
        public static EnvironmentConfig EnvironmentConfig {  get; set; }
        string projectPath;
        string reportPath;

        [BeforeTestRun]
        public static async Task SetupAsync()
        {
            BrowserAsync = new BrowserAsync();
            await BrowserAsync.InitilizeAsync();
            ConfigManager.GetConfig();
            //string configFilePath = "config.json";
            //string jsonString = File.ReadAllText(configFilePath);
            //EnvironmentConfig = JsonSerializer.Deserialize<EnvironmentConfig>(jsonString);
            Report.Instance.Initialize(EnvironmentConfig.baseUrl);
        }

        [AfterScenario]
        public async Task TearDown()
        {
            await BrowserAsync.DisposeAsync();
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioInfo)
        {
            string testResult = "TestResults";
            scenario = feature.CreateNode<Feature>(scenarioInfo.ScenarioInfo.Title);
            Report.test = scenario;
            //Browser.Instance.InitDriver(_environmentFixture.Environment.Browser);
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            projectPath = new Uri(actualPath).LocalPath;
            reportPath = projectPath.Substring(0, projectPath.Length - 1);
            if (!Directory.Exists(Path.Combine(reportPath, testResult)))
            {
                Directory.CreateDirectory(Path.Combine(reportPath, testResult));
            }

        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureInfo)
        {
            feature = Report.Instance.CreateTest(featureInfo.FeatureInfo.Title);
        }

        [BeforeTestRun]
        public static void RunBeforeAllTests()
        {

            //Logger.InitLogging(_environmentFixture.Environment.LogFile);
            //Report.Instance.Initialize(_environmentFixture.Environment.SACSUrl);
        }


        [AfterScenario]
        public static void AfterScenario(ScenarioContext scenarioInfo)
        {
            string status = null;
            if (scenarioInfo.TestError != null)
            {
                if (scenarioInfo.TestError.Message.Equals("These tests are for Local machine") || scenarioInfo.TestError.Message.Contains("Bug"))
                {
                    status = "Skipped";
                }
                else
                {
                    status = scenarioInfo.TestError == null ? "Passed" : "Failed";
                }
            }
            Report.Instance.LogTestResult(status);
            //Browser.Instance.CloseDriver();
        }

        [AfterFeature]
        public static void AfterFeature(FeatureContext feature)
        {


        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Report.Instance.Close();

        }
    }
}