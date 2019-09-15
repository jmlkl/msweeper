using System;

class gamecore{

    public void Report(){

        
    }
}

class gamearea {
    int width;
    int height;
    int itemCount;
    int itemRatio;

    bool[,] grid;
    int[,] adjacency;

    int gridSeed;

    public string Report(){
        return $"Area:{height}x{width} Item count:{itemCount} ({itemRatio}%) Seed: {gridSeed}";
    }
    public void InitField() {   //TODO return bool success???
        grid = new bool[height, width];
        adjacency = new int[height, width];

        for( int _y = 0; _y < height; _y++ ){
            for( int _x = 0; _x < width; _x++ ){
                grid[ _y, _x] = false;
                adjacency[ _y, _x ] = 0;
            }
        }
    }
    public void RandomizeField( int setSeed = 0 ) { //TODO?: add bool that 0 seed can be used?

        //procedure seems little bit funny
        if( setSeed == 0 ){
            Random rnd2 = new Random(); 
            gridSeed = rnd2.Next();
        } else gridSeed = setSeed;

        Random rnd = new Random( gridSeed );


        int count = 0;
        int attempts = 0;   //Not needed outside of debug, but lets keep it there for now. Could be part of class??
        while( count < itemCount ) {
            int y = rnd.Next(0, height);
            int x = rnd.Next(0, width);
            if( !grid[ y, x ] ) {
                grid[ y, x ] = true;
                count++;
            }
            attempts++;
        }
    }

    public void VisualizeFieldFull(){   //used for debug
        string row;
        for( int y = 0; y < height; y++ ){
            row = VisualizeFieldRow( y );
            Console.WriteLine(row);
        }
    }
    public string VisualizeFieldRow( int y ) {
        string row = "";
        for( int x = 0; x < width; x++ ){
            if( grid[ y, x] ){
                row +="*";
            } else row += ".";
        }

        return row;
    }
    
    public int CheckAdjacencyCell( int y, int x ) {
        int adjCount = 0;

        for( int cy = -1; cy < 2; cy++) {
            for( int cx = -1; cx < 2; cx++) {
                if(grid[y, x]) {
                    adjCount = 9;   //ignore self when having item
                } else if( y+cy >=0 && y+cy < height) { //toimiva mutta, ehkä vähän vaikea lukuinen
                    if( x+cx >=0 && x+cx < width ) {
                        if( grid[ y+cy, x+cx] ) adjCount++;
                    }
                } 
            }
        }
        return adjCount;
    }
    public void AdjacencyCell( int y, int x ) {
        adjacency[y, x] = CheckAdjacencyCell( y, x);
    }

    public void AdjacencyFull() {        
        for( int y = 0; y < height; y++ ){
            for( int x = 0; x < width; x++){
                // int adjCount = 0;

                // for( int cy = -1; cy < 2; cy++) {
                //     for( int cx = -1; cx < 2; cx++) {
                //         if(grid[y, x]) {
                //             adjCount = 9;   //ignore self when having item
                //         } else if( y+cy >=0 && y+cy < height) { //toimiva mutta, ehkä vähän vaikea lukuinen
                //             if( x+cx >=0 && x+cx < width ) {
                //                 if( grid[ y+cy, x+cx] ) adjCount++;
                //             }
                //         } 
                //     }
                // }
                adjacency[y, x] = CheckAdjacencyCell( y, x);
            }
        }
    }

    
    public void VisualizeAdjacencyFull() { //could this and below be used by passing array, if so then I could combine VisualizeField... and rename it to more general purpose use!!!!!!
        for( int y = 0; y < height; y++ ){
            Console.WriteLine( VisualizeAdjacencyRow( y ) );
        }
    }
    public string VisualizeAdjacencyRow( int y ) {
        string _strRow = "";
        for( int x = 0; x < width; x++ ){
            _strRow += adjacency[y ,x].ToString();
        }
        return _strRow;
    }

    public string VisualizeBothRow( int y ) {
        string _strRow = "";
        char[] characterList = {'.', '1', '2', '3', '4', '5', '6', '7', '8', '*'};
        for( int x = 0; x < width; x++ ){
            _strRow += characterList[ adjacency[y ,x]].ToString();
        }
        return _strRow;
    }

    public void VisualizeAll() {
        for( int y = 0; y < height; y++ ){
            Console.Write( $"{VisualizeFieldRow( y )} {VisualizeAdjacencyRow( y )} {VisualizeBothRow( y )} \n" );
        }
        Console.WriteLine( Report() );
    }

    public gamearea( int height=8, int width=8, int itemRatio = 16, int itemCount = 0) {   //byte or ushort would be enough, but it is easier to do operations with int :/
        this.height = height;
        this.width = width;

        this.itemRatio = itemRatio;
        if( itemCount <= 0 ) this.itemCount = height*width*itemRatio/100;
        InitField();
    }    
}

