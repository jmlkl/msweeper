# msweeper

## Short description about project
Minesweeper clone written in C# using dot .NET core 2.2

This is personal practice project to get familiar with C#

## Current state

* Generates random minefield with optional arguments
    * Possibility to set height, width and random seed 
    * Uses 2d array for mines

* Has adjacency system
    * Uses own 2d array for adjacency

* Has few methods for visualization
    * Right now outputs bool mine array, int adjacency array and mix of those two

## Documented changes
* Added simple command line parameter parser
* Removed much commented wrong working or old code from ```gamearea```
* Structural changes to some methods
* Splitting code to several files and classes
    * FieldGeneration.cs - game data
    * Game.cs - actual combined class
    * debugConsole.cs - output game data
    * UserInput - input / string parser user input related actions
* (Working on) User command parser
    * Working version
        * uses switch/case and calls parent methods
* Changed adjacency system logic to work so that
    * bomb is 11 (0xB)
    * hidden cell is 9
    * open cell is 0
    * flag cell is 15 (0xF)
* Has simple game loop and rough reveal system for minefield
    * Fixed and improved reveal system
* Flag operation
* New game view with number coordinates
* Added area sweep on numbered cell when adjacent flag count is matching with cell number

## TODO
* Improve start safe click to quaranteed 0 adjacency so, that start isn't number
* Possibly recursive or bitwise based adjacency check (for actual game use)
    * Or just own array etc for open area
* Timer
* User input
    
    - length, check spaces
    - check command from array etc..
    
        - new game (restart minefield)
        - quit
        - settings
        - hiscore
    
        WHEN GAME IS READY OR TIME IS RUNNING
        - click y,x (Works also as timer initiator, actual start game command)
            -open
        - area y,x 
        - flag y,x

    * Possibly numpad playing
        * for example ```5,5``` open action on 5,5, ```*5,5``` to toggle flag on 5,5 or ```++``` for new game.
     
    * parse parameters
    * call method

* Game logic
* Base64 or own share link system
* History
* Achievements / milestones

* Better drawing method
    * Right now uses clear screen and output everything again
    * Ideal: draw only locations where has been changes

## Issues

Minor problem with showing clicks data when game has initiated. 

~~After starting game and if starting field by revealing 0,0 adjacency continous checks won't happen, maybe something to do how array is initialized~~