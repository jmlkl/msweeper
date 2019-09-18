class gameAssembled{
    private gamearea gArea;
    public reportMethods reporter;
    public userInput reader;

    private int clicks;
    public int gameInput( string command ) {
        return reader.HandleUserInput( command );
    }
    public void showData( bool clearScreen = false) {
        reporter.DebugOutput( clearScreen );
    }

    public void NewGame() {
        gArea.InitField();
        clicks = 0;
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
            gArea.AdjacencyCell( click_y, click_x);
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
            if( clicks < 1 ) {
                InitGamestart( click_y: cy, click_x: cx);
            }
            checkCell( cy, cx);
            clicks++;
            success = true;
        }

        return success;
    }

    public void checkCell( int cy, int cx, int calc = 0 ){
        
        int _check = gArea.AdjacencyCell( cy, cx );
        if( _check == 11) reporter.setMessage("POMMI!"); //FIXME MAGIC NUMBES
        else if( _check == 0 && calc < 8 ) {
            //TODO IF pasta, using calc var temporarily to keep running time on borders
            calc++;
            if( CheckLimitsY( cy -1) != -1 ){
                checkCell( cy-1, cx, calc );      //N
            }
            if( CheckLimitsX( cx+1) != -1 ) {
                checkCell( cy, cx+1, calc );      //E
            }
            if( CheckLimitsY( cy+1) != -1 ) {
                checkCell( cy+1, cx, calc );      //S
            }
            if( CheckLimitsX( cx-1) != -1 ) {
                checkCell( cy, cx-1, calc );    //W
            }
        }
    }
    public gameAssembled( int _h, int _w ) {
        gArea = new gamearea( _h, _w ); //TODO rename all these 3!
        reporter = new reportMethods( gArea );
        reader = new userInput( this );

        clicks = 0;
    }
}