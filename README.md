# Battleship

## Pre-requisites
* Windows
* .Net 4.6.1 Framework
* Visual Studio Professional 2017 **OR** Visual Studio Community 2017 with Extensions (from Tools > Extensions and Updates:
* NuGet Package Manager (3.4)
* IIS

## Setup And Start instructions:
* Run Visual studio as Administrator(It requires full IIS) and open the Battleship.sln.
* Right click on Solution folder in visual studio select Rebuild Solution or (Clean and then Build Solution).
* Right click on Battleship.Core.Tests project in visual studio select Run Unit Tests.
* Right click on Battleship project And Select Set as StartUp Project.
* Start the application.

## End to end test
* Go to Battleship.E2E.Tests then open GameControllerTests.cs file and run all tests
* It setup the the board and battleship and starting attacking on specified locations.

## Endpoints
* http://localhost/battleship/api/setup - Setup board and battleship
```
{
    Ships:
	[
		"shipName x,y Length R",
		"shipname x,y Length B"
    ]
}
x,y - It is the x,y coordinates of the ship. replace it with actual coordinates
3 - Length of the ship. 
R - Direction of the ship (it is either R or B)

example data:
{
	 Ships:
	 [
		 "ship-p1-one 1,1 2 R",
		 "ship-p1-two 2,9 2 B"
     ]
}
```
	
* http://localhost/battleship/api/hit - To attack on a given position
```
{
	X: 1, 
	Y: 2
}
	X,Y are the coordinates of the attacking position.
```
	
## Testing tool
* Postman
	
