using AdvancedTaskPart2SpecFlowProject.DataModel;
using AdvancedTaskPart2SpecFlowProject.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.Pages
{
    public class LoginWindow : CommonDriver
    {
        List<LoginDM> loginData;
        IWebElement? emailIdTextBox;
        IWebElement? passWordTextBox;
        IWebElement? loginButton;
        public LoginWindow()
        {
            loginData = new List<LoginDM>();
        }

        public void RenderComponents()
        {
            try
            {
                Wait.WaitToBeClickable("XPath", "//*[@placeholder='Email address']", 2);
                emailIdTextBox = driver.FindElement(By.XPath("//*[@placeholder='Email address']"));
                passWordTextBox = driver.FindElement(By.XPath("//*[@placeholder='Password']"));
                loginButton = driver.FindElement(By.XPath("//*[text()='Login']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void GetLoginData()
        {
            jsonReaderObj?.SetDataPath(@"TestData\LoginData.json");
            loginData = jsonReaderObj!.ReadLoginJsonData();
        }
        public void LoginActions(int index)
        {

            RenderComponents();
            GetLoginData();

            emailIdTextBox?.Click();
            emailIdTextBox?.Clear();
            emailIdTextBox?.SendKeys(loginData[index].email);

            passWordTextBox?.Click();
            passWordTextBox?.Clear();
            passWordTextBox?.SendKeys(loginData[index].password);


            loginButton?.Click();

        }
    }
}
