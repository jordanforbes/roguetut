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
            int Room_Counter = 1;
            int Rooms_Counted = 0;
            int Char_Move_Left_Right = 0;
            int Char_Move_Up_Down = 0;

            //Random
            Random Rand = new Random();

            //strings
            string Draw_Char = "X";
            string[,] Draw_Game_Map = new string[119,29];

            //Program
            do {
                Console.Clear();
                Console.SetCursorPosition(0,29);
                Console.Write("HEALTH: {0}/{1}", Char_Health_Current, Char_Health_Full);
                Console.SetCursorPosition(20,29);
                Console.Write("Score: {0}", score);
                // Console.ReadLine();
                
               
                
                if(Rooms_Counted != Room_Counter){
                    
                    int Spawn_Point_Height = Rand.Next(5,8);
                    int Spawn_Point_Width = Rand.Next(7,10);
                    int Spawn_Point_Generator_X =  Rand.Next (0, 119 - Spawn_Point_Width-1);
                    int Spawn_Point_Generator_Y =  Rand.Next (0, 29 - Spawn_Point_Height-1);

                    Char_Move_Left_Right = Spawn_Point_Generator_X+1;
                    Char_Move_Up_Down = Spawn_Point_Generator_Y+1;

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
                                    Draw_Game_Map[Spawn_Point_Generator_X + x, Spawn_Point_Generator_Y + y] = "|";
                                }else{
                                    Draw_Game_Map[Spawn_Point_Generator_X + x, Spawn_Point_Generator_Y + y] = ".";
                                }
                            }
                            
                        }
                    }
                    //First Road:
                    if(Spawn_Point_Generator_X <=59){
                        int Spawn_First_Road_Y = Rand.Next(1, Spawn_Point_Height-1);
                        Draw_Game_Map[Spawn_Point_Generator_X + Spawn_Point_Width+ 1, Spawn_Point_Generator_Y+ Spawn_First_Road_Y +1] = "#";

                    }
                    Rooms_Counted++;
                }
                for(int y_Draw = 0; y_Draw <= 28; y_Draw++){
                    for(int x_Draw = 0; x_Draw <= 118; x_Draw++){
                        Console.SetCursorPosition(x_Draw,y_Draw);
                        Console.Write(Draw_Game_Map[x_Draw, y_Draw]);
                    }
                }
                
                //Player Controls:

                ConsoleKeyInfo KeyInfo;
                KeyInfo = Console.ReadKey(true);
                switch(KeyInfo.Key){
                    
                    //RIGHT
                    case ConsoleKey.RightArrow:
                        if(Char_Move_Left_Right <118){

                            if(Draw_Game_Map[Char_Move_Left_Right +1, Char_Move_Up_Down] == "|" || Draw_Game_Map[Char_Move_Left_Right - 1, Char_Move_Up_Down] == null)
                            {}
                            else{
                                Char_Move_Left_Right++;
                                Draw_Game_Map[Char_Move_Left_Right, Char_Move_Up_Down] = "X";
                                Draw_Game_Map[Char_Move_Left_Right -1, Char_Move_Up_Down] = ".";   
                            }          
                        }else{}
                        break;
                    
                    //LEFT
                    case ConsoleKey.LeftArrow:
                        if(Char_Move_Left_Right >1){
                            if(Draw_Game_Map[Char_Move_Left_Right -1, Char_Move_Up_Down] == "|" || Draw_Game_Map[Char_Move_Left_Right + 1, Char_Move_Up_Down] == null)
                            {}
                            else{
                                Char_Move_Left_Right--;
                                Draw_Game_Map[Char_Move_Left_Right, Char_Move_Up_Down] = "X";
                                Draw_Game_Map[Char_Move_Left_Right +1, Char_Move_Up_Down] = ".";
                            }
                        }else{}
                        break;        
    
                    //UP
                    case ConsoleKey.UpArrow:
                        if(Char_Move_Up_Down > 0){
                            if(Draw_Game_Map[Char_Move_Left_Right, Char_Move_Up_Down - 1] == "_" || Draw_Game_Map[Char_Move_Left_Right, Char_Move_Up_Down - 1] == null)
                            {}
                            else{
                                Char_Move_Up_Down--;
                                Draw_Game_Map[Char_Move_Left_Right, Char_Move_Up_Down] = "X";
                                Draw_Game_Map[Char_Move_Left_Right, Char_Move_Up_Down + 1] = ".";
                            }
                        }else{}
                        break;

                    //DOWN
                    case ConsoleKey.DownArrow:
                        if(Char_Move_Up_Down < 27){
                             if(Draw_Game_Map[Char_Move_Left_Right, Char_Move_Up_Down + 1] == "_" || Draw_Game_Map[Char_Move_Left_Right, Char_Move_Up_Down + 1] == null)
                            {}
                            else{
                                Char_Move_Up_Down++;
                                Draw_Game_Map[Char_Move_Left_Right, Char_Move_Up_Down] = "X";
                                Draw_Game_Map[Char_Move_Left_Right, Char_Move_Up_Down - 1] = ".";
                            }
                        }else{}
                        break;
                }

                
            }while(Gameover == 0);
        }
    }
}
