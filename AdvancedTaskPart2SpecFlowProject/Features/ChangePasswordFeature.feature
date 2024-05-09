Feature: This test suite contains scenarios for Change Password feature on the Mars Portal

Background: 
	Given User logs into the Mars Portal Profile Page
	And User selects the Change Password Option
	And User reads test data from 'TestData\ChangePasswordData.json'

Scenario: A. Change Password with valid data in all fields
	When User enters valid credentials in all the three fields
	Then Mars portal should alert the user and save the new password for the account

Scenario: B. Change Password without entering data in any fields
	When User does not enter data in any of the three fields
	Then Mars portal should alert the user and should not change the account password

Scenario: C. Change Password with incorrect data in current password fields
	When User enters incorrect data in current password field
	Then Mars portal should alert the user and should not change the account password

Scenario: D. Change Password with different data in new and confirm password fields
	When User enters different data in new and confirm password fields
	Then Mars portal should alert the user and should not change the account password

Scenario: E. Change Password without entering confirm password
	When User does not enter data in confirm password field
	Then Mars portal should alert the user and should not change the account password
