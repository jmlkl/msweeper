using System;
public class reportMethods {
    gamearea gameData;
    public string Report(){
        return $"Area:{gameData.height}x{gameData.width} Item count:{gameData.itemCount} ({gameData.itemRatio}%) Seed: {gameData.gridSeed}";
    }

    public void VisualizeFieldFull(){   //used for debug
        string row;
        for( int y = 0; y < gameData.height; y++ ){
            row = VisualizeFieldRow( y );
            Console.WriteLine(row);
        }
    }
    public string VisualizeFieldRow( int y ) {
        string row = "";
        for( int x = 0; x < gameData.width; x++ ){
            if( gameData.grid[ y, x] ){
                row +="*";
            } else row += ".";
        }

        return row;
    }
    public void VisualizeAdjacencyFull() { //could this and below be used by passing array, if so then I could combine VisualizeField... and rename it to more general purpose use!!!!!!
        for( int y = 0; y < gameData.height; y++ ){
            Console.WriteLine( VisualizeAdjacencyRow( y ) );
        }
    }
    public string VisualizeAdjacencyRow( int y ) {
        string _strRow = "";
        for( int x = 0; x < gameData.width; x++ ){
            _strRow += gameData.adjacency[y ,x].ToString();
        }
        return _strRow;
    }

    public string VisualizeBothRow( int y ) {
        string _strRow = "";
        char[] characterList = {'.', '1', '2', '3', '4', '5', '6', '7', '8', '*'};
        for( int x = 0; x < gameData.width; x++ ){
            _strRow += characterList[ gameData.adjacency[y ,x]].ToString();
        }
        return _strRow;
    }
    public void VisualizeAll() {
    for( int y = 0; y < gameData.height; y++ ){
        Console.Write( $"{VisualizeFieldRow( y )} {VisualizeAdjacencyRow( y )} {VisualizeBothRow( y )} \n" );
        }
    }
    public void DebugOutput() {
        VisualizeAll();
        Console.WriteLine( Report() );
    }

    public reportMethods( gamearea gameDataArea ) {    //I hope I am doing this right
        gameData = gameDataArea;
        }

}