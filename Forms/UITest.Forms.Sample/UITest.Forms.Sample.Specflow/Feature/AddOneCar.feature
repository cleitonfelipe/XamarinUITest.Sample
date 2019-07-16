Feature: AddOneCar
	In this test case we are adding an item to the list of car names
	
@mytag
Scenario: Add Item new car
	Given the app is started in my device
	And I tap in Add
	And I enter with "Citroen" and "C4 Cactus"
	When I tap to back
	Then the result should be 1 item on the screen with description "C4 Cactus"
