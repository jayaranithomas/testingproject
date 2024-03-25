﻿using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileAboutMeComponent
{

    public class AboutMeRenderingComponent : CommonDriver
    {
        IWebElement? availabilityEdit;
        IWebElement? hourEdit;
        IWebElement? targetEdit;

        IWebElement? chooseDD;

        IWebElement? removeIcon;
        public void RenderAvailabilityComponents()
        {
            try
            {
                availabilityEdit = driver.FindElement(By.XPath("//div[2][@class='item']//i[@class='right floated outline small write icon']"));
                availabilityEdit?.Click();
                Thread.Sleep(1000);

                chooseDD = driver.FindElement(By.Name("availabiltyType"));

                removeIcon = driver.FindElement(By.XPath("//div[2][@class='item']//i[@class='remove icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void RenderHourComponents()
        {
            try
            {
                hourEdit = driver.FindElement(By.XPath("//div[3][@class='item']//i[@class='right floated outline small write icon']"));
                hourEdit?.Click();
                Thread.Sleep(1000);

                chooseDD = driver.FindElement(By.Name("availabiltyHour"));

                removeIcon = driver.FindElement(By.XPath("//div[3][@class='item']//i[@class='remove icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void RenderTargetComponents()
        {
            try
            {
                targetEdit = driver.FindElement(By.XPath("//div[4][@class='item']//i[@class='right floated outline small write icon']"));
                targetEdit?.Click();
                Thread.Sleep(1000);

                chooseDD = driver.FindElement(By.Name("availabiltyTarget"));

                removeIcon = driver.FindElement(By.XPath("//div[4][@class='item']//i[@class='remove icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public IWebElement OptionLocator()
        {

            return chooseDD!;
        }
        public IWebElement RemoveIconLocator()
        {

            return removeIcon!;
        }
       
    }
}
