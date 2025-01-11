using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Net.Mail;

namespace Portal.Automation.Framework.Report
{
    public sealed class Report
    {

        public static ExtentReports extent;
        public static ExtentTest test;
        public static ExtentHtmlReporter htmlReporter;
        string projectPath;
        //string reportPath;
        private string reportPath;
        private string reportFolderLocation;

        private DateTime startTime;
        private DateTime endTime;
        private static readonly object padlock = new object();
        public readonly string base64ImageTag = "<img style=\"width:100%;\" src='{0}'>";
        private static Report instance = null;
        public static Report Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Report();
                    }
                    return instance;
                }
            }
        }
        private Report()
        {

        }
        public void Initialize(string url)
       {
           string reportFolder = "Reports";
            string testResultsPath = @"/TestResults";
            //To obtain the current solution path/project path
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));

            projectPath = new Uri(actualPath).LocalPath;
            reportPath = projectPath.Substring(0, projectPath.Length - 1);
            if (!Directory.Exists(reportPath))
            {
                Directory.CreateDirectory(reportPath);
            }
            string aa = Path.Combine(reportPath, reportFolder);
            string bb = reportPath + reportFolder;
            if (!Directory.Exists(Path.Combine(reportPath,reportFolder )))
            {
                Directory.CreateDirectory(Path.Combine(reportPath, reportFolder));
            }
           
            htmlReporter = new ExtentHtmlReporter(Path.Combine(reportPath + testResultsPath, reportFolder));
            htmlReporter.LoadConfig(Path.Combine(Environment.CurrentDirectory ,"Report","Extent-Config.xml"));
            htmlReporter.Config.ReportName = "Playwright Framework";
            htmlReporter.Config.DocumentTitle = "Playwright Automation Report";


            startTime = DateTime.Now;
            //Boolean value for replacing exisisting report
            extent = new ExtentReports();

            //Add QA system info to html report

            extent.AddSystemInfo("Application URL : ", url);

            //Adding config.xml file
            extent.AttachReporter(htmlReporter);

        }

        public ExtentTest CreateTest(string testName)
        {
            try
            {
                test = extent.CreateTest(testName);
                return test;
            }
            catch (Exception ex)
            {
                throw ex;

                //Logger.WriteError(ex.Message, ex);
            }

        }

        public void LogStepInfo(string message)
        {
            test.Log(Status.Info, message);
        }

        public void LogTestResult(string status)
        {
            LogTestValidation(status, "Test ended with " + status);
        }

        public void LogTestValidation(string status, string errorMessage)
        {
            try
            {
                Status logstatus;
                switch (status)
                {
                    case "Failed":
                        logstatus = Status.Fail;
                        //string screenShotPath = TakeScreenshot(DateTime.Now.ToString("MM_dd_yyyy HH-mm-ss"));
                        test.Log(logstatus, errorMessage);
                        //test.Log(logstatus, "Snapshot below:"+test.AddScreenCaptureFromPath(screenShotPath,"Failed"));
                        break;
                    case "Skipped":
                        logstatus = Status.Skip;
                        test.Log(logstatus, errorMessage);
                        break;
                    default:
                        logstatus = Status.Pass;
                        //screenShotPath = TakeScreenshot(DateTime.Now.ToString("MM_dd_yyyy HH-mm-ss"));
                        test.Log(logstatus, errorMessage);
                        //test.Log(logstatus, "Snapshot below: " + test.AddScreenCaptureFromPath(screenShotPath,"Passed"));
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //Logger.WriteError(ex.Message, ex);
            }

        }

        public void Close()
        {
            extent.Flush();
        }
    }

}
