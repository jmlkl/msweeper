using System;

class userInput{
    public static readonly string[] commandArray = {"quit", "new", "help", "settings", "open", "check", "flag", "debug", "redraw", "error"};
    

    public int HandleUserInput( string userInput ) {
    // TODO Needed components
    //  length, check spaces
    //  partial command check
    //   check command from array etc..
    //  - new game
    //   - quit
    //   - settings
    //   - hiscore
    //
    //   WHEN GAME IS READY OR TIME IS RUNNING
    //       - click y,x
    //           -open
    //       - check area y,x 
    //       - flag y,x
    //
    //   parse parameters
    //   call method
    //
    //  c# event handler?

        
        userInput = userInput.Trim();
        string[] split = userInput.Split(" ");
        
        for( int i = 0; i < split.Length; i++) {
            Console.WriteLine($"{i}: {split[i]}");
        }
        int sentAction = -1;
        if( split[0].Length > 1 ) {
            for( int i = 0; i < commandArray.Length; i++ ) {            
                if( split[0].Substring(0,2) == commandArray[i].Substring(0,2)) sentAction = i;  //TODO Maybe this shouldn't be case sensitive
            }
        }

        if( sentAction >= 0) {
            Console.WriteLine($"Your action is {commandArray[sentAction]}");

            switch( commandArray[sentAction] ) {
                case "quit":
                case "new":
                case "help":
                case "settings":
                    Console.WriteLine("This is GENERAL action.");
                    break;
                case "open":
                case "check":
                case "flag":
                    Console.WriteLine("This is ACTIVE GAME related action.");
                    break;
                case "redraw":
                case "debug":
                case "error":
                    Console.WriteLine("This is DEBUG related action.");
                    break;
                default:
                    Console.WriteLine("This shouldn't happen.");
                    break;
            }
        } else Console.WriteLine("Not valid command!");

        return sentAction;
    }
    // public userInput(){
    //     //commandArray = new string[]{"quit", "new", "open", "check", "flag", "debug", "redraw", "error"};  //using open command for revealing cell, click might be better but now all commands start with different letter
    // }
}