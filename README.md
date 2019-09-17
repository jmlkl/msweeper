﻿# msweeper

## Short description about project
Minesweeper clone written in C#.

This is personal practice project to get familiar with C#

## Current state

* Generates random minefield with optional arguments
    * Possibility to set height, width and random seed 
    * Uses 2d array for mines

* Has adjacency system
    * Uses 2d array for adjacency

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

## TODO
* Possibly recursive or bitwise based adjacency check (for actual game use)
    * Or just own array etc for open area
* Timer
* User input
    
    - length, check spaces
    - check command from array etc..
    
        - new game
        - quit
        - settings
        - hiscore
    
        WHEN GAME IS READY OR TIME IS RUNNING
        - click y,x
            -open
        - check area y,x 
        - flag y,x
     
    * parse parameters
    * call method

* Game logic
* Base64 or own share link system


