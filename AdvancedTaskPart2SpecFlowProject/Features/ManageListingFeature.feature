Feature: This test suite contains scenarios to test the various features under Manage Listings tab on the Mars Portal

Background: 
Given user reads share skill listing test data from 'TestData\ShareSkillData.json'

Scenario: A. Add new share skill listing by entering valid data in all the mandatory fields
	Given user logs into the Mars Portal
	And user navigates to the service listing page
	When user  enters valid data in all the fields
	Then user should be navigated to the listing management page with the new share skill listed there

Scenario: B. Add new share skill listing without entering title
	Given user logs into the Mars Portal
	And user navigates to the service listing page
	When user keeps the title text box empty and enters valid data in all other mandatory fields
	Then Mars Portal should alert the user and should not save the new share skill listing

Scenario: C. Add new share skill listing without entering description
	Given user logs into the Mars Portal
	And user navigates to the service listing page
	When user keeps the description text box empty and enters valid data in all other mandatory fields
	Then Mars Portal should alert the user and should not save the new share skill listing

Scenario: D. Add new share skill listing without selecting category
	Given user logs into the Mars Portal
	And user navigates to the service listing page
	When user does not select any category but enters valid data in all other mandatory fields
	Then Mars Portal should alert the user and should not save the new share skill listing

Scenario: E. Add new share skill listing without selecting subcategory
	Given user logs into the Mars Portal
	And user navigates to the service listing page
	When user does not select any subcategory but enters valid data in all other mandatory fields
	Then Mars Portal should alert the user and should not save the new share skill listing



Scenario: H. Update an existing share skill listing without making any changes
	Given user logs into the Mars Portal
	And user navigates to the listing management page
	And user  clicks on the pen icon to the right end of the first share skill listing
	When user updates the selected share skill listing without making any changes in it
	Then Mars Portal should save the share skill listing and navigate back to the listing management page

Scenario: I. Update an existing share skill listing by changing all the mandatory fields
	Given user logs into the Mars Portal
	And user navigates to the listing management page
	And user  clicks on the pen icon to the right end of the first share skill listing
	When user updates the selected share skill listing by  changing all the mandatory fields
	Then Mars Portal should save the share skill listing and navigate back to the listing management page

Scenario: J. Update an existing share skill listing without entering title
	Given user logs into the Mars Portal
	And user navigates to the listing management page
	And user  clicks on the pen icon to the right end of the first share skill listing
	When user updates the selected share skill listing without entering title
	Then Mars Portal should alert the user and should not save updated the share skill listing

Scenario: K. Update an existing share skill listing by entering special characters in the title field
	Given user logs into the Mars Portal
	And user navigates to the listing management page
	And user  clicks on the pen icon to the right end of the first share skill listing
	When user updates the selected share skill listing by entering special characters in the title field
	Then Mars Portal should alert the user and should not save updated the share skill listing

Scenario: L. Update an existing share skill listing by entering a title with more than 100 characters
	Given user logs into the Mars Portal
	And user navigates to the listing management page
	And user  clicks on the pen icon to the right end of the first share skill listing
	When user updates the selected share skill listing by entering a title with more than hundred characters
	Then Mars Portal should alert the user and save updated share skill listing with the first hundred characters only

Scenario: M. Update an existing share skill listing without entering description
	Given user logs into the Mars Portal
	And user navigates to the listing management page
	And user  clicks on the pen icon to the right end of the first share skill listing
	When user updates the selected share skill listing without entering description
	Then Mars Portal should alert the user and should not save updated the share skill listing

Scenario: N. Update an existing share skill listing by entering special characters in the description field
	Given user logs into the Mars Portal
	And user navigates to the listing management page
	And user  clicks on the pen icon to the right end of the first share skill listing
	When user updates the selected share skill listing by entering special characters in the description field
	Then Mars Portal should alert the user and should not save updated the share skill listing

Scenario: O. Update an existing share skill listing by entering a description with more than 600 characters
	Given user logs into the Mars Portal
	And user navigates to the listing management page
	And user  clicks on the pen icon to the right end of the first share skill listing
	When user updates the selected share skill listing by entering a description with more than six hundred characters
	Then Mars Portal should alert the user and save the updated share skill listing with the first six hundred characters only in description

Scenario: P. Update an existing share skill listing by changing category and subcategory
	Given user logs into the Mars Portal
	And user navigates to the listing management page
	And user  clicks on the pen icon to the right end of the first share skill listing
	When user updates the selected share skill listing by changing category and subcategory
	Then Mars Portal should save the updated share skill listing and navigate back to the listing management page

Scenario: Q. Update an existing share skill listing by deleting all the tags
	Given user logs into the Mars Portal
	And user navigates to the listing management page
	And user  clicks on the pen icon to the right end of the first share skill listing
	When user updates the selected share skill listing by deleting all the tags
	Then Mars Portal should alert the user and should not save updated the share skill listing

Scenario: R. Update an existing share skill listing by changing the service type Option
	Given user logs into the Mars Portal
	And user navigates to the listing management page
	And user  clicks on the pen icon to the right end of the first share skill listing
	When user updates the selected share skill listing by changing the service type Option
	Then Mars Portal should save the service type updated share skill listing and navigate back to the listing management page

Scenario: S. Update an existing share skill listing by changing the skill trade Option
	Given user logs into the Mars Portal
	And user navigates to the listing management page
	And user  clicks on the pen icon to the right end of the first share skill listing
	When user updates the selected share skill listing by changing the skill trade Option
	Then Mars Portal should save the skill trade updated share skill listing and navigate back to the listing management page


Scenario: T. View an existing share skill listing
	Given user logs into the Mars Portal
	And user navigates to the listing management page
	When user  clicks on the eye icon to the right end of the first share skill listing
	Then Mars Portal should navigate to the service details page



Scenario: U. Toggle the status of a selected Service Listing
	Given user logs into the Mars Portal
	And user navigates to the listing management page
	When user  clicks on the active button of the first share skill listing
	Then Mars Portal should enable the status if it is already disabled or viceversa



Scenario: V. Delete a selected Service Listing
	Given user logs into the Mars Portal
	And user navigates to the listing management page
	When user  clicks on the delete icon to the right end of the first share skill listing and accepts confirmation
	Then Mars Portal should alert the user and delete the selected share skill listing

Scenario: W. Deny the deletion of a selected Service Listing
	Given user logs into the Mars Portal
	And user navigates to the listing management page
	When user  clicks on the delete icon to the right end of the first share skill listing and does not accept the confirmation
	Then Mars Portal should not delete the selected share skill listing

