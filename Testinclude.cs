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
        return $"Area:{height}x{width} Item count:{itemCount} ({itemRatio}%)";
    }
    public void InitField() {   //return bool success???
        grid = new bool[height, width];
        for( int _y = 0; _y < height; _y++ ){
            for( int _x = 0; _x < width; _x++ ){
                grid[ _y, _x] = false;
            }
        }
    }
    public void RandomizeField( int setSeed = 0 ) {

        //procedure seems little bit funny
        if( setSeed == 0 ){
            Random rnd2 = new Random(); 
            gridSeed = rnd2.Next();
        } else gridSeed = setSeed;

        Random rnd = new Random( gridSeed );


        int count = 0;
        int attempts = 0;
        while( count < itemCount ) {
            int y = rnd.Next(0, height);
            int x = rnd.Next(0, width);
            //Console.WriteLine( $"{count}: y:{y} x:{x}");
            if( !grid[ y, x ] ) {
                grid[ y, x ] = true;
                count++;
            }
            attempts++;
        }
        //Console.WriteLine($"Seed: {gridSeed} items:{count} attempts: {attempts}");
    }

    public void VisualizeFieldFull(){   //used for debug
        string row;
        for( int y = 0; y < height; y++ ){
            
            // for( int x = 0; x < width; x++ ){
            //     if( grid[ y, x] ){
            //         row +="*";
            //     } else row += ".";
            // }
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
    public void CheckAdjacency() {
        adjacency = new int[height, width];

        for( int y = 0; y < height; y++ ){
            for( int x = 0; x < width; x++){
                int adjCount = 0;

                for( int cy = -1; cy < 2; cy++) {
                    for( int cx = -1; cx < 2; cx++) {
                        // if( y+cy >= 0 && x+cx >= 0 && y+cy < height && x+cx < width ) {
                        //     if( grid[ y+cy, x+cx] ) adjCount++;
                        // }
                        if(grid[y, x]) {
                            adjCount = 0;   //ignore self when having item
                        } else if( y+cy >=0 && y+cy < height) { //toimiva mutta, ehkä vähän vaikea lukuinen
                            if( x+cx >=0 && x+cx < width ) {
                                if( grid[ y+cy, x+cx] ) adjCount++;
                            }
                        } 
                        // else if( y==height && cy != 1){
                        //     if( x+cx>=0 && x+cx < width ) {
                        //         if( grid[ y+cy, x+cx] ) adjCount++;
                        //     }
                        // }
                    }
                }

                // for( int cy = y-1; cy < y+1 && cy < height; cy++ ) {    //Tätä voisi OIKEASTI parantaa ja selkeyttää
                //     if( cy >= 0 ) {
                //         for( int cx = x-1; cx < x+1 && cx < width; cx++ ) {
                //             if( cx >= 0 ) {
                //                 if( cy != y && cx != x ) {  //ignore own cell..
                //                     if( grid[ cy, cx ] ) adjCount++;
                //                 }
                //             }                            
                //         }
                //     }
                // }
                adjacency[y, x] = adjCount;
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

    public void VisualizeFAndA() {
        for( int y = 0; y < height; y++ ){
            Console.Write( $"{VisualizeFieldRow( y )} {VisualizeAdjacencyRow( y )} \n" );
        }
    }

    public gamearea( int height=8, int width=8, int itemRatio = 16, int itemCount = 0) {   //byte or ushort would be enough, but it is easier to do operations with int :/
        this.height = height;
        this.width = width;

        this.itemRatio = itemRatio;
        if( itemCount <= 0 ) this.itemCount = height*width*itemRatio/100;
        InitField();
    }    
}

