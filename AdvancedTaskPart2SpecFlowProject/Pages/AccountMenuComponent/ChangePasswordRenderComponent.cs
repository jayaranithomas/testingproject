using AdvancedTaskPart2SpecFlowProject.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.Pages.AccountMenuComponent
{
    public class ChangePasswordRenderComponent : CommonDriver
    {
        IWebElement? userNameMenu;
        IWebElement? changePasswordOption;
        IWebElement? currentPasswordTB;
        IWebElement? newPasswordTB;
        IWebElement? confirmPasswordTB;
        IWebElement? saveButton;
        IWebElement? messageBox;
        string actualMessage = string.Empty;

        public void UserNameMenuRenderComponent()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//span[contains(text(),'Hi ')]", 10);
                userNameMenu = driver.FindElement(By.XPath("//span[contains(text(),'Hi ')]"));
                userNameMenu.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ChangePasswordOptionRenderComponent()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//a[contains(text(),'Change Password')]", 5);
                changePasswordOption = driver.FindElement(By.XPath("//a[contains(text(),'Change Password')]"));
                changePasswordOption.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void PasswordRenderComponent()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//input[@name='oldPassword']", 3);
                currentPasswordTB = driver.FindElement(By.XPath("//input[@name='oldPassword']"));
                newPasswordTB = driver.FindElement(By.XPath("//input[@name='newPassword']"));
                confirmPasswordTB = driver.FindElement(By.XPath("//input[@name='confirmPassword']"));
                saveButton = driver.FindElement(By.XPath("//button[@role='button'][contains(text(),'Save')]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public IWebElement GetCurrentPasswordLocator()
        {
            return currentPasswordTB!;
        }
        public IWebElement GetNewPasswordLocator()
        {
            return newPasswordTB!;
        }
        public IWebElement GetConfirmPasswordLocator()
        {
            return confirmPasswordTB!;
        }
        public IWebElement GetSavePasswordLocator()
        {
            return saveButton!;
        }
        public string CapturePopupMessage()
        {

            Thread.Sleep(1000);
            try
            {
                messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (messageBox != null)
            {
                actualMessage = messageBox.Text;
                Console.WriteLine(actualMessage);
            }

            return actualMessage!;
        }
    }
}
