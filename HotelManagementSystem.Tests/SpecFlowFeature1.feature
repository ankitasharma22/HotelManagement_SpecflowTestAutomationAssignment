Feature: Add hotel
	In order to simulate hotel management system
	As api consumer
	I want to be able to add hotel,get hotel details and book hotel

@AddHotel
Scenario Outline: User adds hotel in database by providing valid inputs
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And Use has added required details for hotel
	When User calls AddHotel api
	Then Hotel with name '<name>' should be present in the response
Examples: 
| id | name   |
| 1  | hotel1 |
| 2  | hotel2 |
| 3  | hotel3 |

@GetHotels
Scenario: User get hotels in the database
	Given Use has added required details for hotel
	Given User provided valid Id '5' and 'hotel5' for hotel 
	Given User provided valid Id '6' and 'hotel6' for hotel 
	And Use has added required details for hotel
	And User calls AddHotel api
	When User calls GetHotels api
	Then Hotels in the database should be displayed


@GetHotelById
Scenario Outline: User get hotels by Id from database
	#Given Use has added required details for hotel
	#Given User calls AddHotel api
	When User calls GetHotelById api
	Then Hotels matching the id '<id>' should be displayed
Examples: 
| id |
| 1  |




