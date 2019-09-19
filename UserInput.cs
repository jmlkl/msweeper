using System;

class userInput{

    private gameAssembled parent;
    public static readonly string[] commandArray = {"quit", "exit", "new", "help", "settings", "open", "check", "flag", "debug", "show", "redraw", "error"};
    //qu ex ne he se op ch fl de sh re er
    

    public int HandleUserInput( string userInput ) {
        
        userInput = userInput.Trim();
        string[] split = userInput.Split(" ");
        int coordy = -1;
        int coordx = -1;
        // for( int i = 0; i < split.Length; i++) {
        //     Console.WriteLine($"{i}: {split[i]}");
        // }
        int sentAction = -1;
        if( split[0].Length > 1 ) {
            for( int i = 0; i < commandArray.Length; i++ ) {            
                if( split[0].Substring(0,2) == commandArray[i].Substring(0,2)) sentAction = i;  //TODO Maybe this shouldn't be case sensitive
            }
        }

        if( split.Length >= 3) {
            if( !Int32.TryParse( split[1], out coordy) || !Int32.TryParse( split[2], out coordx)) {
                coordy = -1;
                coordx = -1;
            }

            Console.WriteLine($"y:{coordy} x:{coordx}");
        }

        if( sentAction >= 0) {
            //Console.WriteLine($"Your action is {commandArray[sentAction]}");
            string outMessage ="";
            switch( commandArray[sentAction] ) {
                case "new":
                    parent.NewGame();  //use resize instead of ng?
                    parent.showData( true );
                break;

                case "quit":
                case "exit":    //alias
                    sentAction = 0;
                    break;
                case "settings":
                    Console.WriteLine("This is GENERAL action.");
                    break;
                case "help":
                    //parent.showData( true );
                    outMessage = "These are available actions ";   //TODO move to constructor, MUCH data inside case
                    int _l = commandArray.Length;
                    for( int i = 0; i <_l; i++ ){
                        string _suffix = ", ";
                        if( i == _l -2) {
                            _suffix = " and ";
                        } else if( i >= _l -1){
                            _suffix = ".";
                        }
                        outMessage += commandArray[i] + _suffix;
                    }
                    parent.addMessage( outMessage );
                    //Console.WriteLine($"{_str}"); //TODO send this string to elsewhere, structure this class to work without WriteLine???
                    parent.showData( true );                    
                    break;
                case "open":
                    parent.clickCell( coordy, coordx);
                    parent.showData( true );
                    break;
                case "check":
                    parent.addMessage("This is ACTIVE GAME related action.");
                    parent.showData( true );
                    break;
                case "flag":
                    parent.toggleFlagCell( coordy, coordx );
                    parent.showData( true );
                    break;
                case "redraw":
                    parent.showData( true );
                    break;
                case "debug":
                    //parent.DebugShowFullAdj();
                    parent.showDebug( true );
                    break;
                case "show":
                    parent.DebugShowFullAdj();
                    break;
                case "error":
                    parent.addMessage("This is DEBUG related action.");
                    break;
                default:
                    parent.addMessage("This shouldn't happen.");
                    break;
            }
        } else {
            parent.addMessage("Not valid command!");
            parent.showData( true );
        }
        return sentAction;
    }
    public userInput( gameAssembled _parent ){
        parent = _parent;
        //commandArray = new string[]{"quit", "new", "open", "check", "flag", "debug", "redraw", "error"};  //using open command for revealing cell, click might be better but now all commands start with different letter
    }
}