using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csroguetut
{
    class Program
    {
        static void Main(string[] args)
        {
            //ints
            int Char_Health_Current = 100;
            int Char_Health_Full = 100;
            int score = 0;
            int Gameover = 0;

            //Random
            Random Rand = new Random();

            //strings
            string Draw_Char = "X";
            string[,] Draw_Game_Map = new string[119,29];

            //Program
            do {
                Console.Clear();
                int Spawn_Point_Height = Rand.Next(5,8);
                int Spawn_Point_Width = Rand.Next(7,10);
                int Spawn_Point_Generator_X =  Rand.Next (0, 119 - Spawn_Point_Width-1);
                int Spawn_Point_Generator_Y =  Rand.Next (0, 29 - Spawn_Point_Height-1);
               

                for(int y = 0; y <= Spawn_Point_Height; y++){
                    for(int x = 0; x <= Spawn_Point_Width; x++){
                        if(Spawn_Point_Generator_X + Spawn_Point_Width >= 119){
                            int X_Difference = Spawn_Point_Generator_X + Spawn_Point_Width - 120;
                            Spawn_Point_Generator_X = Spawn_Point_Generator_X - X_Difference;
                        } 
                        if(Spawn_Point_Generator_Y + Spawn_Point_Height >= 28 ){
                            int Y_Difference = Spawn_Point_Generator_Y + Spawn_Point_Height - 29;
                            Spawn_Point_Generator_Y = Spawn_Point_Generator_Y - Y_Difference;
                        }
                        if(y == 0 || y == Spawn_Point_Height){
                            Draw_Game_Map[Spawn_Point_Generator_X+x, Spawn_Point_Generator_Y+y] = "_";
                        }else{
                            if(x == 0 || x == Spawn_Point_Width){
                                Draw_Game_Map[Spawn_Point_Generator_X+x, Spawn_Point_Generator_Y+y] = "|";
                            }
                        }
                        
                    }
                }
                for(int y_Draw = 0; y_Draw <= 28; y_Draw++){
                    for(int x_Draw = 0; x_Draw <= 118; x_Draw++){
                        Console.SetCursorPosition(x_Draw,y_Draw);
                        Console.Write(Draw_Game_Map[x_Draw, y_Draw]);
                    }
                }
                Console.SetCursorPosition(0,29);
                Console.Write("HEALTH: {0}/{1}", Char_Health_Current, Char_Health_Full);
                Console.ReadLine();
            }while(Gameover == 0);
        }
    }
}
