using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.AssertHelpers
{
    public class SearchSkillAssertHelper
    {
        public void AssertSearchSkillWithSkillName(String skillName)
        {
            Console.WriteLine("Searched Skill Name is in " + skillName + "");
            Assert.That(skillName.Contains("Testing"), "Search result not Successful");
        }
        public void AssertSearchSkillWithCategory(String category)
        {
            Console.WriteLine("Searched Category is " + category + "");
            Assert.That(category.Contains("Programming"), "Search result not Successful");
        }
        public void AssertSearchSkillWithCategoryAndSubcategory(String category, String subcategory)
        {
            Console.WriteLine("Category is " + category + "");
            Console.WriteLine("Subcategory is " + subcategory + "");
            Assert.That(category.Contains("Programming") && subcategory.Contains("QA"), "Search result not Successful");
        }
        public void AssertSearchSkillWithCategorySubcategoryAndSkillName(String skillName, String category, String subcategory)
        {
            Console.WriteLine("Category is " + category + "");
            Console.WriteLine("Subcategory is " + subcategory + "");
            Console.WriteLine("Searched Skill Name is in " + skillName + "");

            Assert.That(skillName.Contains("Testing") && category.Contains("Programming") && subcategory.Contains("QA"), "Search result not Successful");
        }
        public void AssertSearchSkillWithCategorySubcategorySkillAndUserName(String skillName, String category, String subcategory, String userName)
        {
            Console.WriteLine("Category is " + category + "");
            Console.WriteLine("Subcategory is " + subcategory + "");
            Console.WriteLine("Searched Skill Name is in" + skillName + "");
            Console.WriteLine("Searched User is " + userName + "");
            if (userName is not null)
                Assert.That(userName.Contains("Rachel") && skillName.Contains("Testing") && category.Contains("Programming") && subcategory.Contains("QA"), "Search result not Successful");
        }
        public void AssertSearchSkillWithCategorySubcategoryUserNameFilterOptionOnline(String category, String subcategory, String userName, String filter)
        {
            Console.WriteLine("Category is " + category + "");
            Console.WriteLine("Subcategory is " + subcategory + "");
            Console.WriteLine("Searched User is " + userName + "");
            Console.WriteLine("Location type is based on the filter applied : " + filter + "");
            if (userName is not null)
                Assert.That(userName.Contains("Rachel") && filter.Contains("Online") && category.Contains("Marketing") && subcategory.Contains("Marketing"), "Search result not Successful");
        }
        public void AssertSearchSkillWithCategorySubcategoryUserNameFilterOptionOnsite(String category, String subcategory, String userName, String filter)
        {
            Console.WriteLine("Category is " + category + "");
            Console.WriteLine("Subcategory is " + subcategory + "");
            Console.WriteLine("Searched User is " + userName + "");
            Console.WriteLine("Location type is based on the filter applied : " + filter + "");
            if (userName is not null)
                Assert.That(userName.Contains("Rachel") && filter.Contains("On-Site") && category.Contains("Marketing") && subcategory.Contains("Marketing"), "Search result not Successful");
        }
    }
}
