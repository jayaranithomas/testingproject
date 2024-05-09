using AdvancedTaskPart2SpecFlowProject.AssertHelpers;
using AdvancedTaskPart2SpecFlowProject.Pages.ProfileDescriptionComponent;
using AdvancedTaskPart2SpecFlowProject.Utilities;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskPart2SpecFlowProject.StepDefinitions
{
    [Binding]
    public class DescriptionStepDefinitions : CommonDriver
    {
        AddAndEditDescription editDescription;
        DescriptionRenderComponents descriptionRenderComponents;
        DescriptionAssertHelper descriptionAssertHelper;
        string actualMessage = string.Empty;
        string expectedMessage = string.Empty;
        DescriptionStepDefinitions()
        {
            editDescription = new AddAndEditDescription();
            descriptionRenderComponents = new DescriptionRenderComponents();
            descriptionAssertHelper = new DescriptionAssertHelper();
        }

        [Given(@"user clicks on the edit description icon")]
        public void GivenUserClicksOnTheEditDescriptionIcon()
        {
            descriptionRenderComponents.SelectEditDescriptionRenderComponents();
        }

        [When(@"user enters a valid description")]
        public void WhenUserEntersAValidDescription()
        {
            editDescription.AddDescription("I am a skilled software tester. I am good at automation and manual testing. I can perform API and performance testing as well.");
            actualMessage = descriptionRenderComponents.CapturePopupMessage();
            expectedMessage = "Description has been saved successfully";

        }

        [Then(@"Mars portal should save the entered description and display it on the profile page")]
        public void ThenMarsPortalShouldSaveTheEnteredDescriptionAndDisplayItOnTheProfilePage()
        {
            descriptionAssertHelper.AssertAddDescription(actualMessage, expectedMessage);
        }

        [When(@"user enters NULL value in description")]
        public void WhenUserEntersNULLValueInDescription()
        {
            editDescription.AddDescription("");
            actualMessage = descriptionRenderComponents.CapturePopupMessage();
            expectedMessage = "Please, a description is required";

        }
        [Then(@"Mars portal should alert the user and should not save the description")]
        public void ThenMarsPortalShouldAlertTheUserAndShouldNotSaveTheDescription()
        {
            descriptionAssertHelper.AssertDescriptionNotChanged(actualMessage, expectedMessage);
        }

        [When(@"user enters a description starting with special character")]
        public void WhenUserEntersADescriptionStartingWithSpecialCharacter()
        {
            editDescription.AddDescription("%^%$$hgsdhsdgg345683465634568");
            actualMessage = descriptionRenderComponents.CapturePopupMessage();
            expectedMessage = "First character can only be digit or letters";
        }

        [When(@"user enters a description with spaces only")]
        public void WhenUserEntersADescriptionWithSpacesOnly()
        {
            editDescription.AddDescription("                           ");
            actualMessage = descriptionRenderComponents.CapturePopupMessage();
            expectedMessage = "First character can only be digit or letters";
        }

        [When(@"user enters a profile description with more than six hundred characters")]
        public void WhenUserEntersAProfileDescriptionWithMoreThanSixHundredCharacters()
        {
            editDescription.AddDescription("bhsgdfkgfjkhbsjdhf jhgfwefjhILEFHLHFELHLFHLIgfh gfywgefygbyuegfywegfuygeuyfg uygefygwfeygwEYGFYEHFOygfUIYW YGEFYEFUYGOEygyegfdy efWEFHIEUFIWUHEFIHWU WEFIHWFIUWIEYFUIHWEIFUHWE WEwehfiwuehfiuwhefuhefui whefiuhwefuihweihufuiwhef wuhiuhweiufwuehfuihfuib iuhefiwyefuihwehufwieub wyeiuhwufewuehf weyfuihiofuWEUHIWEHFPIUifijodijfaij wauefapewufwaijeifawiue, 34236236hihjhgjhajhfgljkfd kjfhgljdhfgljkhdrguhljkdfhzgljfd 34534hhfidhfizuhdfjh89808jzhfdlkjhzlkjfdh jhghhgljhjhgljhlkjhljkh jgoyIuhiuyfshflIUH;VOIUHZDIHUFG ZUIHGIUHDFGIHFDUIHZ ZUHIUHDGIUHDFGUIHXHUFD:GUI KHDGIUZHFDIH!DXU? FHGIJXHFDGJHXFUIGHHKgfgsdjhgsdgfhjsgdfhasdfgjshdgfdgsfsgdfhJDFKJU");
            actualMessage = descriptionRenderComponents.CapturePopupMessage();
            expectedMessage = "Description has been saved successfully";
        }

        [Then(@"Mars portal should save the first six hundred characters in the description and display it on the profile page")]
        public void ThenMarsPortalShouldSaveTheFirstSixHundredCharactersInTheDescriptionAndDisplayItOnTheProfilePage()
        {
            Console.WriteLine("The length of the Description is: " + descriptionRenderComponents.GetDescriptionLengthRenderComponents());
            descriptionAssertHelper.AssertAddDescription(actualMessage, expectedMessage);
        }

    }
}
