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

## Endpoints
* http://localhost/battleship/api/setup - Setup board and battleship
```
{
	Ships:
	[
	  "shipName x,y Length H",
	  "shipname x,y Length V"
	]
}
x,y - It is the x,y coordinates of the ship. replace it with actual coordinates
3 - Length of the ship. It could be any number that fits with in the board without overlapping.
H - Direction of the ship (it is either H(Horizontal) or V(Vertical))

example:
{
	Ships:
	[
	  "ship-p1-one 1,1 2 H",
	  "ship-p1-two 2,9 2 V"
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
## Assumptions
* Only single player is supported at the moment.
* Player needs to setup the board and battleship first in order to start playing the game. Please have a look at above setup endpoint example data to setup the board.
* Player can only start attacking once the board is setup. player can attack on a position by providing x and y coordinates. Please have a look at above hit endpoint example data.


## End to end test
* Go to Battleship.E2E.Tests then open GameControllerTests.cs file and run all tests
* It setup the the board and battleship and starting attacking on specified locations.

## Testing tool
* Postman
	
