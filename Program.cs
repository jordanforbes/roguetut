using System;

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
            string Draw_Char = "x";
            string[,] Draw_Game_Map = new string[239,77];

            //PRogram
            do {
                int Spawn_Point_Generator_X =  Rand.Next (0, 230);
                int Spawn_Point_Generator_Y =  Rand.Next (0, 77);
                int Spawn_Point_Height = Rand.Next(5,8);
                int Spawn_Point_Width = Rand.Next(7,10);

                for(int x = 0; x <= Spawn_Point_Height-1; x++){
                    for(int y = 0; y <= Spawn_Point_Width; y++){
                        if(y == 0 || y == Spawn_Point_Height){
                            
                        }else{
                            if(x == 0 || x == Spawn_Point_Width){
                                Draw_Game_Map[x,y] = "|";
                            }
                        }
                        
                    }
                }
            }while(Gameover == 0);
        }
    }
}
