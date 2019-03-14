Feature: DispatchManager
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Background: 
Given opened ADCENTRA url in browser
When entered Username as 'administrator' and Password  as'toolkit' and I clicked login button
Then should be navigated to home page
When selected dispatch manager option under Configure drop down

@mytag
Scenario: Dispatch Manager - General Settings
	When Configure the options on the Dispatch Manager General Settings screen 'Test Site'
	And Apply is used
	Then the settings should be saved

Scenario: Dispatch Manager - Configure SMTP Paging
    When navigated to SMTP tab under Page Settings tab
    And login user 'administrator' created new SMTP page From as 'abc@atlascopco.com' destination with SMTP IP of '160.100.160.43', port number as '25' and To address as 'xyz@atlascopco.com'  
	When Clicked Test button
	Then A message 'A test message has been placed on the queue.' should be displayed. 
	
Scenario: Dispatch Manager - Configure Other Paging
   When navigated to SMTP tab under Page Settings tab
   And login user 'administrator' created new SMTP page From as 'abc@atlascopco.com' destination with SMTP IP of '160.100.160.43', port number as '25' and To address as 'xyz@atlascopco.com'
   And navigated to General Settings page
   Then General settings page should display
   When Clicked on manual page
   Then 'Send a Page Message' pop-up will appear
   When Typed in Message 'Test Mail' and clicked Send button
   Then 'Page has been submitted' message should be displayed

 #Need to check status in autopager
 Scenario: Dispatch Manager - Pause and Resume
 Then General settings page should display
 When Press the Service status button	
 Then The service status should display accordingly action taken
 #When Check the AAP console utility in the Taskbar and observe the text "Autopager processing has been paused."
 When Press the Service status button	
 Then The service status should display accordingly action taken
#Check the AAP console application and ensure there's the text "Autopager processing has been continued."

