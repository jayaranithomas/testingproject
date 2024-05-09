Feature: This test suite contains scenarios for Certification feature on the Mars Portal

Background: 
	Given User logs into the Mars Portal Profile Page
	And user selects the certification tab
	And User reads certification test data from 'TestData\CertificationData.json'

Scenario: A. Delete all Certification records
	When user deletes all the certification records one by one
	Then Mars portal should not have any certification records for the logged in account

Scenario: B. Adds new Certification record with valid data in all fields
	When user enters valid data in all the required fields
	Then Mars portal should alert the user and save the new certification record

Scenario: C. Adds new Certification record without entering values in any of the fields
	When user does not enter data in any of the available certification fields
	Then Mars portal should alert the user and should not save the new certification record

Scenario: D. Adds new Certification record without selecting the dropdowns
	When user does not select any options from the year dropdown
	Then Mars portal should alert the user and should not save the new certification record

Scenario: E. Adds new Certification record without entering any data in Text Boxes
	When user does not enter any data in both the certification Text Boxes
	Then Mars portal should alert the user and should not save the new certification record

Scenario: F. Add an already existing Certification record
	When user adds an already existing certification record
	Then Mars portal should alert the user and should not save the new certification record

Scenario: G. Adds a Certification record with already existing data in Text Boxes and selecting different year
	When user adds an education record with already existing data in Text Boxes and selecting different year from dropdown
	Then Mars portal should alert the user and should not save the new certification record

Scenario: H. Adds a Certification record with new data in Text Boxes and selecting already existing dropdown
	When user adds an certification record with new data in Text Boxes and selecting already existing year from dropdown
	Then Mars portal should alert the user and save the new certification record

Scenario: I. Adds a Certification record with Special Characters and numbers in Certification name TextBox
	When user adds a certification record with Special Characters and numbers in certification name TextBox
	Then Mars portal should alert the user and save the new certification record

Scenario: J. Adds a Certification record with more than 500 characters in CertifiedFrom TextBox
	When user adds a certification record with very long data in CertifiedFrom TextBox
	Then Mars portal should alert the user and save the new certification record

Scenario: K. Adds a Certification record with only Spaces in TextBoxes
	When user adds a certification record with only Spaces in TextBoxes
	Then Mars portal should alert the user and save the new certification record

Scenario: L. Cancels a Certification record without adding
	When user cancels a certification record without adding
	Then Mars portal should not save the cancelled certification record

