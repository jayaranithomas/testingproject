using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedTaskPart2SpecFlowProject.Pages;
using AdvancedTaskPart2SpecFlowProject.TestSetUpClass;
using TechTalk.SpecFlow;


namespace AdvancedTaskPart2SpecFlowProject.Utilities
{
    public class CommonDriver
    {

        public static IWebDriver driver;

        public static HomePage? homePageObj = new HomePage();
        public static LoginWindow? loginWindowObj = new LoginWindow();
        public static JSONReader? jsonReaderObj = new JSONReader();

        public static void InitialSetUp(int index)
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            homePageObj?.SignInAction();
            loginWindowObj?.LoginActions(index);
            Thread.Sleep(1000);
            TestHooksClass.generateReport?.CreateTest();

        }

        public static void UpdateAndQuit()
        {
            TestHooksClass.generateReport?.UpdateTest();
            driver?.Quit();

        }


    }
}
