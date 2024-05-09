using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.MarsSearchSkill_Component;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents.RenderingComponents;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using MarsAdvancedTaskPart1NUnitAutomation.AssertHelpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Steps
{

    public class SearchSkillSteps
    {
        IList<IWebElement>? searchResult;
        IWebElement? userName;
        SearchOperationComponent searchOperationComponentObj;
        SearchSkillsRenderingComponent searchSkillsRenderingComponent;
        SearchSkillAssertHelper searchSkillAssertHelper;

        public SearchSkillSteps()
        {
            searchOperationComponentObj = new SearchOperationComponent();
            searchSkillsRenderingComponent = new SearchSkillsRenderingComponent();
            searchSkillAssertHelper = new SearchSkillAssertHelper();
        }


        public void SearchSkillWithSkillName(SearchSkillsDM searchSkillsDM)
        {
            searchOperationComponentObj.SearchSkills(searchSkillsDM);
            searchResult = searchSkillsRenderingComponent.GetSearchRecord();
            if (searchResult is not null)
            {
                searchSkillAssertHelper.AssertSearchSkillWithSkillName(searchResult[0].Text);
            }
        }
        public void SearchSkillWithCategory(SearchSkillsDM searchSkillsDM)
        {
            searchOperationComponentObj.SearchSkills(searchSkillsDM);
            searchResult = searchSkillsRenderingComponent.GetSearchRecord();
            if (searchResult is not null)
            {
                searchSkillAssertHelper.AssertSearchSkillWithCategory(searchResult[1].Text);
            }
        }
        public void SearchSkillWithCategoryAndSubcategory(SearchSkillsDM searchSkillsDM)
        {
            searchOperationComponentObj.SearchSkills(searchSkillsDM);
            searchResult = searchSkillsRenderingComponent.GetSearchRecord();
            if (searchResult is not null)
            {
                searchSkillAssertHelper.AssertSearchSkillWithCategoryAndSubcategory(searchResult[1].Text, searchResult[2].Text);
            }
        }
        public void SearchSkillWithCategoryAndSubcategoryAndSkillName(SearchSkillsDM searchSkillsDM)
        {
            searchOperationComponentObj.SearchSkills(searchSkillsDM);
            searchResult = searchSkillsRenderingComponent.GetSearchRecord();
            if (searchResult is not null)
            {
                searchSkillAssertHelper.AssertSearchSkillWithCategorySubcategoryAndSkillName(searchResult[0].Text, searchResult[1].Text, searchResult[2].Text);
            }
        }
        public void SearchSkillWithCategoryAndSubcategoryAndSkillAndUserName(SearchSkillsDM searchSkillsDM)
        {
            searchOperationComponentObj.SearchSkills(searchSkillsDM);
            searchResult = searchSkillsRenderingComponent.GetSearchRecord();
            userName = searchSkillsRenderingComponent.GetSearchedUserName();

            if (searchResult is not null)
            {
                searchSkillAssertHelper.AssertSearchSkillWithCategorySubcategorySkillAndUserName(searchResult[0].Text, searchResult[1].Text, searchResult[2].Text, userName.Text);
            }
        }
        public void SearchSkillWithCategorySubcategoryUserNameFilterOptionOnline(SearchSkillsDM searchSkillsDM)
        {
            searchOperationComponentObj.SearchSkills(searchSkillsDM);
            searchResult = searchSkillsRenderingComponent.GetSearchRecord();
            userName = searchSkillsRenderingComponent.GetSearchedUserName();
            if (searchResult is not null)
            {
                searchSkillAssertHelper.AssertSearchSkillWithCategorySubcategoryUserNameFilterOptionOnline(searchResult[1].Text, searchResult[2].Text, userName.Text, searchResult[6].Text);
            }
        }
        public void SearchSkillWithCategorySubcategoryUserNameFilterOptionOnsite(SearchSkillsDM searchSkillsDM)
        {
            searchOperationComponentObj.SearchSkills(searchSkillsDM);
            searchResult = searchSkillsRenderingComponent.GetSearchRecord();
            userName = searchSkillsRenderingComponent.GetSearchedUserName();
            if (searchResult is not null)
            {
                searchSkillAssertHelper.AssertSearchSkillWithCategorySubcategoryUserNameFilterOptionOnsite(searchResult[1].Text, searchResult[2].Text, userName.Text, searchResult[6].Text);
            }
        }
    }
}
