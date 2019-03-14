@setup_feature
Feature: DeviceExplorerTests

Background: 
    Given I opened ADCENTRA app url 
	When I entered 'administrator' and 'toolkit' and clicked login button
@mytag
Scenario: Device Explorer - Add Folder 
	Then I should be navigated to Home page
	When I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder

Scenario: Device Explorer - Rename Folder
	Then I should be navigated to Home page
	When I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder
	When I click on added folder and rename
	Then I should be able to see Folder Renamed Successfully message and after clicking on Ok button, renamed folder should be displayed

Scenario: Device Explorer - Find, Add and Remove Systems
	Then I should be navigated to Home page
	When I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder
	When I clicked Find Equipment
	When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When I selected Remove from Folder and clicked on OK button
	Then I should be able to see Equipment Removed Successfully message and Equipment should be removed from device

Scenario: Device Explorer - Delete folder
	Then I should be navigated to Home page
	When I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder
	When I clicked header of added folder and clicked Delete option
	Then Delete Folder window should appear to confirm your action
	When I clicked cancel button
	Then Delete Folder window closes and no action is taken
	When I clicked the header of the folder again and choose Delete
	Then Delete Folder window should appear to confirm your action
	When I clicked OK button in Delete window pop -up
	Then Folder Deleted Successfully is displayed and deleted Folder should no longer be visible
	
Scenario: Device Explorer - Share Folder with groups & users
	When I Added user in group with details 'testuser' 'Test@123' 'Test@123' 'Client Name' 'Edward' 'test' 'user' and 'testuser@atlascopco.com' and group details 'testgroup' and 'testgroupdescription'
	And  I clicked on Home Icon in top navigation menubar
	Then I should be navigated to Home page
	When I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder
	When  I clicked the header of the folder and this choose Share Folder
	Then Share Folder Foldername pop-up should be displayed with available and granted list.
	And I selected previously created Group ('testgroup') from available list and transfered it to granted list and pressed Apply.
	Then Changes should be saved.
	When I clicked OK button
	Then message pop- up should be closed
	When I clicked on Home Icon in top navigation menubar
	Then I should be navigated to Home page
	When I clicked on user and selected logout option 
	Then I should be navigated to login page
    When I entered 'testuser' and 'Test@123' and clicked login button
    Then I should be navigated to Home page
	When I clicked Device Explorer link
    Then I should be able to see added folder in previous steps 
	When I add new User with details 'testuser2' 'Test2@123' 'Test2@123' 'Client Name?' 'Atlas' 'test2' 'user2' and 'testuser2@atlascopco.com'
	When I clicked on Home Icon in top navigation menubar on UserPage
	Then I should be navigated to Home page
	When I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When  I clicked the header of the folder and this choose Share Folder
	Then Share Folder Foldername pop-up should be displayed with available and granted list.
	And I selected previously created Group 'test2' 'user2' and 'testuser2' from available list and transfered it to granted list and pressed Apply.
	Then Changes should be saved.
	When I clicked OK button
	Then message pop- up should be closed
	When I clicked on Home Icon in top navigation menubar
	Then I should be navigated to Home page
	When I clicked on user and selected logout option 
	Then I should be navigated to login page
    When I entered 'testuser2' and 'Test2@123' and clicked login button
    Then I should be navigated to Home page
	When I clicked Device Explorer link
    Then I should be able to see added folder in previous steps 

#Prerequisites
#Have a piece of equipment that is communicating and sending parameter data through the system added to a folder (see previous tests)
Scenario: Device Explorer - Device Explorer - SEV Pages
	Then I should be navigated to Home page
	When I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder
    When I clicked Find Equipment
	When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When I clicked on added equipment
	Then I should be navigated to SEV page
	And Status should be running and alarm should be enabled
	When I selected one of the options 'AIM Software' from the serial number drop-down
	Then The textbox next to the serial number drop-down should briefly say Retrieving then come back with the result. 
	When I clicked Parameters tab
	Then Parameters page should show with all of the parameters for the piece of equipment
	When I clicked the Guage tab
	Then Gauges page should show with all of the gauged parameters for the piece of equipment
	When I clicked the Graph tab
	Then should see a drop-down box with a list of parameters that you can add to the graph
	And I selected MB Temp (ºC) clicked the Add button
	Then I should be able to see Reset button
	When I clicked Reset button
	Then The graph should be removed and you will be left with the "Select Parameter" drop-down and graph plaeholder image.

#Prerequisite -1) Turbo agent up and running.
#2) One Turbo device created but yet not commissioned.
#3) Device Explorer folder created.
Scenario: Create then Commission/Decommission Equipment
	Then I should be navigated to Home page
	When I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder
    When I clicked Find Equipment
	And deleted all equipments
	When I clicked on Add button, selected create/commission and provided all required parameters 'Turbo Pump', '127.0.0.1', "4001" and clicked on Add button
	Then device should be commissioned and appropriate message should be displayed
	When I clicked the header of the folder selected decommission 
	Then device should be decommissioned and appropriate message should be displayed
	
Scenario Outline:User Permissions on Device Explorer having "View" and "Maintenance" permission
	Then I should be navigated to Home page
	When I set up user who has Device Explorer permission with details <Username>, <Password>, <Confirm Password>, <Memorable Question>, <Memorable Answer>, <First Name>, <Last Name>, <Email>, <Feature>, <column1>, <column2>
	When I clicked on Home Icon in top navigation menubar on UserPage
	Then I should be navigated to Home page
	When I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder
	When I clicked Find Equipment
	When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When I clicked on Top Level link
	Then I should be navigated to Device Explorer page
	When I clicked the header of the folder and this choose Share Folder
	Then Share Folder Foldername pop-up should be displayed with available and granted list.
	And I selected previously created user <First Name>, <Last Name> and <Username> from available list and transfered it to granted list and pressed Apply.
	Then Changes should be saved.
	When I clicked OK button
	Then message pop- up should be closed
	When I clicked on Home Icon in top navigation menubar
	Then I should be navigated to Home page
	When I clicked on user and selected logout option 
	Then I should be navigated to login page
    When entered <Username> and <Password> and clicked login button
    Then I should be navigated to Home page
	When I clicked Device Explorer link
    Then I should be able to see added folder in previous steps 
	When I clicked Find Equipment
	Then A context menu opened with the option to Set Maintenance to ON
	When Selected this option to turn Maintenance Mode on
	Then A message saying that maintenance is set to on is displayed and the item updates to show the maintenance icon
	When I clicked again Equipment header 
	Then A context menu opened with the option to Set Maintenance to OFF
	When I selected this option to turn Maintenance Mode off
	Then A message saying that maintenance is set to off is displayed and the item updates to remove the maintenance icon.
	
 Examples: 
	| Username  | Password  | Confirm Password | Memorable Question |  Memorable Answer    | First Name | Last Name | Email | Feature | column1 | column2 |
	| Testuser1 | Test1@123 | Test1@123        | Client Name?       |   Edward             | test1      | user1     | testuser1@atlascopco.com | Device Explorer | View    | Maintenance|

	Scenario Outline:User Permissions on Device Explorer having "View" and "Commission" permission
	Then I should be navigated to Home page
	When I set up user who has Device Explorer permission with details <Username>, <Password>, <Confirm Password>, <Memorable Question>, <Memorable Answer>, <First Name>, <Last Name>, <Email>, <Feature>, <column1>, <column2>
	When I clicked on Home Icon in top navigation menubar on UserPage
	Then I should be navigated to Home page
	When I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder
	When I clicked Find Equipment
	When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When I clicked on Top Level link
	Then I should be navigated to Device Explorer page
	When I clicked the header of the folder and this choose Share Folder
	Then Share Folder Foldername pop-up should be displayed with available and granted list.
	And I selected previously created user <First Name>, <Last Name> and <Username> from available list and transfered it to granted list and pressed Apply.
	Then Changes should be saved.
	When I clicked OK button
	Then message pop- up should be closed
	When I clicked on Home Icon in top navigation menubar
	Then I should be navigated to Home page
	When I clicked on user and selected logout option 
	Then I should be navigated to login page
    When entered <Username> and <Password> and clicked login button
    Then I should be navigated to Home page
	When I clicked Device Explorer link
    Then I should be able to see added folder in previous steps 
	When I clicked Find Equipment
	Then I should get a context menu with Commission or Decommission options depending on the state of the system
	
 Examples: 
	| Username  | Password  | Confirm Password |Memorable Question |Memorable Answer | First Name | Last Name | Email | Feature | column1 | column2 |
	| Testuser2 | Test2@123 | Test2@123        | Client Name       |Edward           | test2      | user2     | testuser2@atlascopco.com | Device Explorer | View    | Commission |

	
	Scenario Outline:User Permissions on Device Explorer having "View" and "Delete" permission
	Then I should be navigated to Home page
	When I set up user who has Device Explorer permission with details <Username>, <Password>, <Confirm Password>, <Memorable Question>, <Memorable Answer>, <First Name>, <Last Name>, <Email>, <Feature>, <column1>, <column2>
	When I clicked on Home Icon in top navigation menubar on UserPage
	Then I should be navigated to Home page
	When I clicked Device Explorer link
	Then I should be navigated to Device Explorer page
	When I clicked on add folder/ system icon
	And  I Entered folder name and Clicked on Add button
	Then I should be able to see Folder Added Successfully message
	When I clicked OK button 
	Then I should be able to see newly added folder
	When I clicked Find Equipment
	When I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button
	Then I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed
	When I clicked on Top Level link
	Then I should be navigated to Device Explorer page
	When I clicked the header of the folder and this choose Share Folder
	Then Share Folder Foldername pop-up should be displayed with available and granted list.
	And I selected previously created user <First Name>, <Last Name> and <Username> from available list and transfered it to granted list and pressed Apply.
	Then Changes should be saved.
	When I clicked OK button
	Then message pop- up should be closed
	When I clicked on Home Icon in top navigation menubar
	Then I should be navigated to Home page
	When I clicked on user and selected logout option 
	Then I should be navigated to login page
    When entered <Username> and <Password> and clicked login button
    Then I should be navigated to Home page
	When I clicked Device Explorer link
    Then I should be able to see added folder in previous steps 
	When I clicked Find Equipment
	Then A context menu opened with the option to Delete
	
 Examples: 
	| Username  | Password  | Confirm Password  | Memorable Question | Memorable Answer | First Name | Last Name | Email | Feature | column1 | column2 |
	| Testuser3 | Test3@123 | Test3@123         | Client Name       | Edward           | test3      | user3     | testuser3@atlascopco.com | Device Explorer | View    | Delete     |