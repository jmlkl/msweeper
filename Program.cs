using System;

namespace demo_minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {   
            int fieldHeight = 8;
            int fieldWidth = 8;
            int fieldSeed = 0;
            //int s

            int argsL = args.Length;
            int[] argsP = new int[argsL];
            
            //SIMPLE ARGUMENT PARSER v0.1
            // if( argsL > 0 ) fieldHeight=Convert.ToInt32(args[0]);
            // if( argsL > 1 ) fieldWidth=Convert.ToInt32(args[1]);
            // if( argsL > 2 ) fieldSeed=Convert.ToInt32(args[2]);

            //SIMPLE ARGUMENT PARSER v0.2
            #region Simple Parser 0.2
            if( true ){
                bool conDebug = false;
                for( int i = 0; i < argsL; i ++ ){
                    if( conDebug) Console.Write( args[i] );
                    Int32.TryParse(args[i], out argsP[i]);
                    if( conDebug) Console.Write($" {argsP[i]}\n");
                }

                if( argsL > 0 && argsP[0] > 0) fieldHeight = argsP[0];
                if( argsL > 1 && argsP[1] > 0) fieldWidth = argsP[1];
                if( argsL > 2 && argsP[2] > 0) fieldSeed = argsP[2];
            }
            #endregion
            //Console.WriteLine($"CONDEBUG OUTSIDE SCOPE?:{conDebug}");

            /* 
            gamecore game = new gamecore();
            game.Report();

            gamearea gameA = new gamearea(fieldHeight, fieldWidth);
            //Console.WriteLine(gameA.Report());
            gameA.RandomizeField(fieldSeed);
            //gameA.VisualizeFieldFull();
            
            gameA.AdjacencyFull();
            //gameA.AdjacencyCell(0,1);
            //gameA.VisualizeAdjacencyFull();
            gameA.VisualizeAll();

            Console.Write("\n====================================\n");

            gameA.InitField();
            gameA.RandomizeField(fieldSeed,0,6);
            
            gameA.AdjacencyFull();
            gameA.VisualizeAll();

            gameA.HandleUserInput("  click (1,1)");
            
            gameA.HandleUserInput("flag (3,4)");
            */

            gameAssembled peli = new gameAssembled( fieldHeight, fieldWidth );
            Console.Clear();
            peli.InitGamestart(fieldSeed);
            peli.showData();
            int uAction = -1;
            int cL = Console.CursorLeft;
            int cT = Console.CursorTop;
            while( uAction != 0 ) {
                Console.SetCursorPosition( cL, cT );
                string _uStr = Console.ReadLine();
                uAction = peli.gameInput( _uStr );
                
            }
        }
    }
}
