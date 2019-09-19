class gameAssembled{
    private gamearea gArea;
    public reportMethods reporter;
    public userInput reader;


    private bool gameRunning;   //Issues with this, remove this and later again?, something wrong with draw when doing opening action
    private int clicks;
    //private int hp ;
    public int gameInput( string command ) {
        return reader.HandleUserInput( command );
    }
    public void showData( bool clearScreen = false) {
        reporter.GameOuput( clearScreen );
        if( gameRunning ) {
            addMessage($"Clicks: {clicks}");
        } else {
            addMessage("GAME IS NOT RUNNING!");
        }
    }

    public void showDebug( bool clearScreen = false) {
        reporter.DebugOutput( clearScreen );
        if( gameRunning ) {
            addMessage($"Clicks: {clicks}");
        } else {
            addMessage("GAME IS NOT RUNNING!");
        }
    }
    public void NewGame() {
        gArea.InitField();
        clicks = 0;
        gameRunning = false;
    }

    public void ResizeGameField( int height =1, int width =1 ) {
        if( height > 2) gArea.height = height;
        if( width  > 2) gArea.width = width;
        gArea.InitField(); 
    }
    public bool InitGamestart( int seed=0, int click_y = -1, int click_x = -1) {
        bool success = false;   //TODO is there use to move this to method parameters?
        click_y = CheckLimitsY( click_y );
        click_x = CheckLimitsX( click_x );

        if( click_y > -1 && click_x > -1 ) {
            clicks++;
            gArea.RandomizeField( seed, click_y, click_x );
            //gArea.AdjacencyCell( click_y, click_x);   //FIX??
            success = true;
        }
        return success;
    }

    public int CheckLimitsY( int y ){
        if( y < 0 ) y = -1;
        if( y >= gArea.height ) y = -1; 
        return y;
    }
    public int SetLimitsY( int y ){
        if( y < 0 ) y = 0;
        if( y >= gArea.height ) y = gArea.height -1; 
        return y;
    }
    public int CheckLimitsX( int x ){
        if( x < 0 ) x = -1;
        if( x >= gArea.width ) x =-1;
        return x; 
    }
    public int SetLimitsX( int x ){
        if( x < 0 ) x = 0;
        if( x >= gArea.width ) x = gArea.width -1;
        return x; 
    }
    public void DebugShowFullAdj() {
        gArea.AdjacencyFull();
    }

    public bool clickCell( int cy=-1, int cx=-1){
        
        bool success = false; //TODO is there use to move this to method parameters?
        cy = CheckLimitsY( cy );
        cx = CheckLimitsX( cx );

        if( cx > -1 && cy > -1 ) {
            if( clicks == 0 ) {
                InitGamestart( click_y: cy, click_x: cx);
                    gameRunning = true;
                    addMessage("STARTING GAME! ");
            
            }
            checkCell( cy, cx);
            clicks++;
            success = true;
        }
        //System.Console.WriteLine("Done with checks!");
        //System.Console.ReadLine();

        return success;
    }

    public void toggleFlagCell( int cy, int cx ){

        int _check;
        cy = CheckLimitsY( cy );
        cx = CheckLimitsX( cx );
        if( cy > -1 && cx > -1 ) {
            _check = gArea.AdjacencyCellGet( cy, cx);   //needs getter
            
            //flagToggle( cy, cx, _check );
            if( _check == 9 ) {
                gArea.AdjacencyCellSet( cy, cx, 0xF);
            } else if( _check == 0xF ){
                gArea.AdjacencyCellSet( cy, cx, 9 );
            }
        }
    }

    public void checkCell( int cy, int cx  ){   //actual unveil operation when user clicks/opens unveiled cell/tile //TODE possibly method renaming needed
        
        int _check = gArea.AdjacencyCellGet( cy, cx);   //needs getter
        int _clickRes = gArea.AdjacencyCell( cy, cx );  //because this is getter does additional operation

        //System.Console.WriteLine($"ch{_check} cl{_clickRes}");
        //System.Console.ReadKey();
        if( _check == 9 ) {
            if( _clickRes == 11) {
                addMessage("POMMI!"); //FIXME point to hard number
                gameRunning = false;
            }else if( _clickRes == 0 ) { //FIXME point to hard number (revealed object was before unknown)
                for( int _dy = -1; _dy < 2; _dy++ ) {   //Here start point of actual 3x3 area revealing loop
                    for( int _dx = -1; _dx < 2; _dx++ ) {
                        if( CheckLimitsY( cy + _dy) != -1 && CheckLimitsX( cx + _dx) != -1 ){
                            if( gArea.AdjacencyCellGet( cy+_dy, cx+_dx) > 8 ) { //FIXME point to hard number
                                checkCell( cy+_dy, cx+_dx );
                            }
                        }
                    }
                }
            }
        }
    }

    public void addMessage( string message ) {
        reporter.setMessage( message );
    }
    public gameAssembled( int _h, int _w ) {
        
        gameRunning = false;
        clicks = 0;

        gArea = new gamearea( _h, _w ); //TODO rename all these 3!
        reporter = new reportMethods( gArea );
        reader = new userInput( this );


    }
}