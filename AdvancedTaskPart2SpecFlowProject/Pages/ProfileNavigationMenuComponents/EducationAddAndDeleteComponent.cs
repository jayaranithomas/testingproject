using AdvancedTaskPart2SpecFlowProject.DataModel;
using AdvancedTaskPart2SpecFlowProject.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.Pages.ProfileNavigationMenuComponents
{
    public class EducationAddAndDeleteComponent : CommonDriver
    {
        public EducationRenderComponents educationRenderComponents;
        int cancelFlag = 0;

        public EducationAddAndDeleteComponent()
        {
            educationRenderComponents = new EducationRenderComponents();
        }
        public void DeleteAllEducationRecords()
        {

            int rowCount = educationRenderComponents.GetEducationRecordsCount();
            for (int i = 1; i <= rowCount;)
            {
                educationRenderComponents.RenderDeleteComponents();
                rowCount--;
                Thread.Sleep(4000);
            }
        }
        public void SetCancelFlag(int flag)
        {
            cancelFlag = flag;
        }


        public void AddEducation(EducationDM education)
        {
            educationRenderComponents.RenderAddComponents();

            if (!string.IsNullOrEmpty(education.college))
            {
                educationRenderComponents.CollegeTextBoxLocator().SendKeys(education.college);
            }
            if (!string.IsNullOrEmpty(education.country))
            {
                educationRenderComponents.ChooseCountryDDLocator().SendKeys(education.country);
            }
            if (!string.IsNullOrEmpty(education.title))
            {
                educationRenderComponents.ChooseTitleDDLocator().SendKeys(education.title);
            }
            if (!string.IsNullOrEmpty(education.degree))
            {
                educationRenderComponents.DegreeTextBoxLocator().SendKeys(education.degree);
            }
            if (!string.IsNullOrEmpty(education.year))
            {
                educationRenderComponents.ChooseYearDDLocator().SendKeys(education.year);
            }
            Thread.Sleep(2000);

            if (cancelFlag != 1)
            {
                educationRenderComponents.AddButtonLocator().Click();
            }
            else
            { cancelFlag = 0; educationRenderComponents.CancelButtonLocator().Click(); }

            Thread.Sleep(2000);

        }
    }
}
