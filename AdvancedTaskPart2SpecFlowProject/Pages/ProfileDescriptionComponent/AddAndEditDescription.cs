using AdvancedTaskPart2SpecFlowProject.Pages.ManageListingComponent;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.Pages.ProfileDescriptionComponent
{
    public class AddAndEditDescription
    {
        DescriptionRenderComponents renderComponents;
        public AddAndEditDescription()
        {
            renderComponents = new DescriptionRenderComponents();
        }

        public void AddDescription(string description)
        {
            renderComponents.AddAndSaveRenderComponents();
            renderComponents.ClearTextBox();
            if (!string.IsNullOrEmpty(description))
                renderComponents.DescriptionTextBoxLocator()?.SendKeys(description);
            renderComponents.SaveButtonLocator()?.Click();

        }
    }
}
