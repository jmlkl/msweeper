using System;

namespace demo_minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            gamecore game = new gamecore();
            game.Report();

            gamearea gameA = new gamearea(16,100);
            Console.WriteLine(gameA.Report());
            gameA.RandomizeField();
            //gameA.VisualizeFieldFull();
            
            gameA.CheckAdjacency();
            //gameA.VisualizeAdjacencyFull();
            gameA.VisualizeFAndA();



            
            Console.WriteLine("ANOTHER GEN");

            gameA.InitField();
            gameA.RandomizeField();
            //gameA.VisualizeFieldFull();

            gameA.CheckAdjacency();
            //gameA.VisualizeAdjacencyFull();
            gameA.VisualizeFAndA();

        }
    }
}
