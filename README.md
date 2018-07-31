# Battleship

## Pre-requisites
* Windows
* .Net 4.6.1 Framework
* Visual Studio Professional 2017 **OR** Visual Studio Community 2017 with Extensions (from Tools > Extensions and Updates:
* NuGet Package Manager (3.4)
* IIS Express (8.0) - install via the "Web Platform"

## Setup And Start instructions:
* Goto project directory, There is a Battleship.sln file in project directory. double click it to open in visual studio.
* Right click on Solution folder in visual studio select Rebuild Solution or (Clean and then Build Solution).
* Right click on Battleship.Core.Tests and Battleship.E2E.Tests project in visual studio select Run Unit Tests.
* Right click on Battleship project And Select Set as StartUp Project.
* Start the application.

## Endpoints
* api/battleship/setup - Setup board and battleship
```
{
    PlayerName: "playerName",
    Ships:[
    	"shipName x,y Length R",
		"shipname x,y Length B"
        ]
}
x,y - It is the x,y coordinates of the ship. replace it with actual coordinates
3 - Length of the ship. 
R - Direction of the ship (it is either R or B)

example data:
{
	 PlayerName: "p1",
	 Ships:[
			 "ship-p1-one 1,1 2 R",
             "ship-p1-two 2,9 2 B"
        ]
}
```
	
* /api/battleship/hit - To attack on a given position
```
{
	PlayerName: "p2",
	X: 1, 
	Y: 2
}
	X,Y are the coordinates of the attacking position.
```
	
## Testing tool
* Postman
	
