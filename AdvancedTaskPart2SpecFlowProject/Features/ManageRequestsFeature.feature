Feature: This test suite contains scenarios to test the various features under Manage Requests tab

Scenario: A. View all the sent requests pagewise
	Given user logs into the Mars Portal as Abcd
	When user  navigates to the Sent Request page
	Then user should be able to view all the requests sent by Abcd pagewise

Scenario: B. View all the received requests pagewise
	Given user logs into the Mars Portal as Abcd
	When user  navigates to the received Request page
	Then user should be able to view all the requests received by Abcd pagewise

Scenario: C. Sent a new skill trade request to another user and withdraw it
	Given user logs into the Mars Portal as Abcd
	And user  navigates to the interested service details page
	When user sends a skill trade request to the intended user
	And user withdraws the sent request
	Then user should be able to successfully sent the request and withdraw it

Scenario: D. Complete and Review a skill trade sent request that has been accepted rated and completed by the receiver
	Given user logs into the Mars Portal as Abcd
	And user  navigates to the interested service details page
	And user sends a skill trade request to the intended user
	When received user accepts rates and completes the received request
	And sent user completes and reviews the skill trade sent request
	Then sent user should be able to successfully complete the skill trade request

Scenario: E. Decline a received request from the sender
	Given user logs into the Mars Portal as Abcd
	And user  navigates to the interested service details page
	And user sends a skill trade request to the intended user
	When received user declines the new skill trade request
	Then sent user should be able to see the skill trade request in declined status
