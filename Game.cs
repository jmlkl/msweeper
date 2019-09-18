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
        System.Console.WriteLine("Done with checks!");
        System.Console.ReadLine();

        return success;
    }

    public void checkCell( int cy, int cx ){
        
        int _check = gArea.AdjacencyCellGet( cy, cx);   //needs getter
        int _clickRes = gArea.AdjacencyCell( cy, cx );  //because this is getter does additional operation

        //System.Console.WriteLine($"ch{_check} cl{_clickRes}");
        //System.Console.ReadKey();
        if( _clickRes == 11) reporter.setMessage("POMMI!"); //FIXME point to hard number
        else if( _clickRes == 0 && _check == 9 ) { //FIXME point to hard number (revealed object was before unknown)
            int system = 2;
            if( system == 1 ) {
                //TODO IF pasta, USE MORE ELEGANT WAY TO SOLVE THIS!            
                int _tmp = 0;
                if( CheckLimitsY( cy -1) != -1 ){
                    if( gArea.AdjacencyCellGet( cy-1, cx) > 8 ) {
                        checkCell( cy-1, cx );      //N
                        _tmp++;
                    }
                }
                if( CheckLimitsX( cx+1) != -1 ) {
                    if( gArea.AdjacencyCellGet( cy, cx+1) > 8 ) {
                        checkCell( cy, cx+1 );      //E
                        _tmp++;
                    }
                }
                if( CheckLimitsY( cy+1) != -1 ) {
                    if( gArea.AdjacencyCellGet( cy+1, cx) > 8 ) {
                        checkCell( cy+1, cx );      //S
                        _tmp++;
                    }
                }
                if( CheckLimitsX( cx-1) != -1 ) {
                    if( gArea.AdjacencyCellGet( cy, cx-1) > 8 ) {                
                        checkCell( cy, cx-1 );    //W
                        _tmp++;
                    }
                }
                
                //System.Console.WriteLine($"{cy}.{cx}: {calc} done {_tmp} things here!");
                //System.Console.ReadLine();
            } 
            else if( system == 2 ) {
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
    public gameAssembled( int _h, int _w ) {
        gArea = new gamearea( _h, _w ); //TODO rename all these 3!
        reporter = new reportMethods( gArea );
        reader = new userInput( this );

        clicks = 0;
    }
}