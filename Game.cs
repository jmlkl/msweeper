class gameAssembled{
    private gamearea gArea;
    public reportMethods reporter;
    public userInput reader;


    public int gameInput( string command ) {
        return reader.HandleUserInput( command );
    }
    public void showData() {
        reporter.DebugOutput();
    }

    public void ResizeGameField( int height, int width ) {
        gArea.height = height;
        gArea.width = width;
        gArea.InitField(); 
    }
    public void InitGamestart( int seed, int click_y = -1, int click_x = -1 ) {
        gArea.RandomizeField( seed, click_y, click_x );
        gArea.AdjacencyFull();
    }

    public gameAssembled( int _h, int _w ) {
        gArea = new gamearea( _h, _w ); //TODO rename all these 3!
        reporter = new reportMethods( gArea );
        reader = new userInput();
    }
}