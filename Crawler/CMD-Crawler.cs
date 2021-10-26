using System;
using System.IO;

namespace Crawler
{
    /**
     * The main class of the Dungeon Crawler Application
     * 
     * You may add to your project other classes which are referenced.
     * Complete the templated methods and fill in your code where it says "Your code here".
     * Do not rename methods or variables which already exist or change the method parameters.
     * You can do some checks if your project still aligns with the spec by running the tests in UnitTest1
     * 
     * For Questions do contact us!
     */
    public class CMDCrawler
    {
        /**
         * use the following to store and control the next movement of the yser
         */
        public enum PlayerActions { NOTHING, NORTH, EAST, SOUTH, WEST, PICKUP, ATTACK, QUIT };
        private PlayerActions action = PlayerActions.NOTHING;
        private char[][] map = new char[0][];
        private char[][] oMap = new char[0][];
        //These private maps are used to store the maps in jagged arrays

        private bool running = false;
        private int gold = 0;
        private int monsterHealth = 5;
        /**
         * tracks if the game is running
         */
        private bool active = true;
        private bool mapLoaded = false;

        /**
         * Reads user input from the Console
         * 
         * Please use and implement this method to read the user input.
         * 
         * Return the input as string to be further processed
         * 
         */
        private string ReadUserInput()
        {
            string inputRead = string.Empty;

            if (running == true) 
            // If the map has been loaded, then take user input as a key press instead of having to press enter
            {
                Console.WriteLine();
                ConsoleKeyInfo inp = Console.ReadKey();
                inputRead = inp.KeyChar.ToString();

            }
            else
            {
                inputRead = Console.ReadLine();
            }
            // Your code here

            return inputRead;
        }
       
     
        ///<summary>
        ///Resets map tile to original value after walking over it 
        ///</summary>
        private void resetMap(int y, int x) {
            map[y][x] = oMap[y][x];
            if (map[y][x] == 'S') {
                map[y][x] = '.';
                //Removes S from the map after player leaves start tille
            }

        }
        ///<summary>
        ///Asks if the user wishes to replay the game 
        ///</summary>
        private void replay(){
            Console.WriteLine("Do you wish to play the game again?: y/n");
            string inp = Console.ReadLine().ToLower();
                
            if(inp == "y"){
                action = PlayerActions.NOTHING;
              map = new char[0][];
                oMap = new char[0][];
                gold = 0;
                monsterHealth = 5;
                mapLoaded = false;
            //If player wishes to replay then set all the object variavles back to initial values
            }else {
                action = PlayerActions.QUIT;
            }
        }
        /**
         * Processed the user input string
         * 
         * takes apart the user input and does control the information flow
         *  * initializes the map ( you must call InitializeMap)
         *  * starts the game when user types in Play
         *  * sets the correct playeraction which you will use in the GameLoop
         */
        public void ProcessUserInput(string input)
        {

            // Your Code here
            string[] inp = input.Split(' ');
            //Splits the input so that only the map name gets passed in when InitializeMap is called
            if (input == "load Simple.map")
            {
                InitializeMap(inp[1]);
                Console.WriteLine("Map has been loaded");
            }
            else if (input == "load Advanced.map")
            {
                InitializeMap(inp[1]);

            }
            else if (input == "play")
            {
                if (mapLoaded)
                {
                    action = PlayerActions.NOTHING;
                    running = true;

                }
               
                else
                {
                    Console.WriteLine("Game cannot be played yet please load a map");
                    
                }
            }
            if (running) 
            // This if statements will only be looked at if the map has been loaded and the game is running
            {
                //Takes in input and set it to the relevant player action
                input = input.ToLower();
                if (input == "w")
                {
                    action = PlayerActions.NORTH;
                }
                else if (input == "a")
                {
                    action = PlayerActions.WEST;
                }
                else if (input == "s")
                {
                    action = PlayerActions.SOUTH;
                }
                else if (input == "d")
                {
                    action = PlayerActions.EAST;
                }
                else if (input == "e")
                {
                    action = PlayerActions.PICKUP;
                }
                else if (input == " ")
                {
                    action = PlayerActions.ATTACK;
                }
            }
            

            


        }

        /**
         * The Main Game Loop. 
         * It updates the game state.
         * 
         * This is the method where you implement your game logic and alter the state of the map/game
         * use playeraction to determine how the character should move/act
         * the input should tell the loop if the game is active and the state should advance
         */
        public void GameLoop(bool active)
        {
            if (running) {
                try{
                Console.Clear();
                }catch(IOException){

                }
                }
            //Console.Clear();
            char[][] oMap = GetOriginalMap();
            int[] pos = GetPlayerPosition();
            int curAction = GetPlayerAction();
            //Gets the original map, current player position and current player action for use in the game loop
            int posY = pos[1];
            int posX = pos[0];





           //Moves the player or does other actions depending on current action

            if (curAction == 1)
            {
                if (map[posY - 1][posX] == '#' || map[posY - 1][posX] == 'M') { } 
                //Checks that the player is not trying to walk through a wall or monster
                else
                {

                    map[posY - 1][posX] = '@';
                    resetMap(posY,posX);
                    //Moves the player and sets the previous tile back to what it originally was
                    
                }
                action = PlayerActions.NOTHING;
            }
            else if (curAction == 2)
            {
                if (map[posY][posX + 1] == '#' || map[posY][posX + 1] == 'M') { }
                else
                {
                    map[posY][posX + 1] = '@';
                    resetMap(posY,posX);
                }
                action = PlayerActions.NOTHING;
            }
            else if (curAction == 3)
            {
                if (map[posY + 1][posX] == '#' || map[posY + 1][posX] == 'M') { }
                else
                {
                    map[posY + 1][posX] = '@';
                    resetMap(posY,posX);

                }
                action = PlayerActions.NOTHING;
            }

            else if (curAction == 4)
            {
                if (map[posY][posX - 1] == '#' || map[posY][posX - 1] == 'M') { }
                else
                {
                    map[posY][posX - 1] = '@';
                    resetMap(posY,posX);
                }
                action = PlayerActions.NOTHING;
            }
            else if (curAction == 5)
            {
                if (oMap[posY][posX] == 'G')
                {
                    
                    oMap[posY][posX] = '.';
                    //map[posY][posX] = '.';
                    gold++;
                    //Pickups gold and set it back to a . on the orignal map so you cant pickup the same gold
                }
            }
            else if (curAction == 6)
            {
                //Checks if any of the tiles all around the player are a monster, if they are then attack
                //If monster health is zero remove monster from map
                if (map[posY + 1][posX] == 'M')
                {
                    if (monsterHealth > 0) monsterHealth--;
                    else {
                    map[posY + 1][posX] = '.';
                    oMap[posY + 1][posX] = '.';
                    }

                }
                else if (map[posY - 1][posX] == 'M')
                {
                    if (monsterHealth > 0) monsterHealth--;
                    else {
                        map[posY - 1][posX] = '.';
                        oMap[posY-1][posX] = '.';
                    }
                }
                else if (map[posY][posX + 1] == 'M')
                {
                    if (monsterHealth >  0) monsterHealth--;
                    else {
                        map[posY][posX + 1] = '.';
                        oMap[posY][posX + 1] = '.';
                    }
                }
                else if (map[posY][posX - 1] == 'M')
                {
                    if (monsterHealth > 0) monsterHealth--;
                    else {
                        map[posY][posX - 1] = '.';
                        oMap[posY][posX - 1] = '.';
                    }

                }



            }
            
            pos = GetPlayerPosition();
            posY = pos[1];
            posX = pos[0];
            //To check if the player has reached the end, you need to get the updated player position
            if (posY != 0 && posX != 0) { 
                if (oMap[posY][posX] == 'E') //Checks if the user has reached the end
                {
                    
                    
                    running = false;
                    action  = PlayerActions.QUIT;
                    //replay();
                    ///Asks if the user wants to replay game 
                }
        }


                GetCurrentMapState(); //Prints the map after the game logic is complete and player has moved
                
           
            }
           
        

        /**
        * Map and GameState get initialized
        * mapName references a file name 
        * 
        * Create a private object variable for storing the map in Crawler and using it in the game.
        */
        public bool InitializeMap(String mapName)
        {
            //bool initSuccess = false;
            string path = @"./maps/";
            
            // Your code here
            try
            {
                mapName = path + mapName;
                string[] startMap = File.ReadAllLines(mapName); //Reads the map file into an array
                map = new char[startMap.Length][]; 
                oMap = new char[startMap.Length][];
                //2d jagged array created to store each map tile 
                for (int i = 0; i < startMap.Length; i++)
                {
                    map[i] = startMap[i].ToCharArray();
                    oMap[i] = startMap[i].ToCharArray();
                    //Iterates through each line of the map and put it into the jagged array
                }
                for (int y = 0; y < map.Length; y++)
                {
                    for (int x = 0; x < map[y].Length; x++)
                    {
                        if (map[y][x] == 'S')
                        {
                            map[y][x] = '@';
                        }
                    }
                    //Itterates through the map that will be updated and adds the player
                }

                //initSuccess = true;
                mapLoaded = true;
                //   running = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return mapLoaded;
        }

        /**
         * Returns a representation of the currently loaded map
         * before any move was made.
         */
        public char[][] GetOriginalMap()
        {

            //Returns the original map
            char[][] map = oMap;

            // Your code here


            return map;
        }

        /*
         * Returns the current map state 
         * without altering it 
         */
        public char[][] GetCurrentMapState()
        {
            int[] pos = GetPlayerPosition();
            // the map should be map[y][x]
            if (!running) return oMap; 
            //If play has not been entered then @ must not be on the map yet

            else if (pos[0] == 0 && pos[1] == 0) Console.WriteLine("Map has not been loaded!");
            //Doubles checks if the map hasnt been loaded (only way not to cause an error if play is entered first)
            else
            {
                char[][] map = this.map;
                foreach (char[] c in map)
                {
                    Console.WriteLine(c);
                    //Loops through the map and prints each line 
                }
                Console.Write("Gold Collected: " + gold);
                Console.Write("  ");
                Console.WriteLine("Monster Health: " + monsterHealth);
                //Shows the gold collected and monster health
           
            }
            return map;
        }

        /**
         * Returns the current position of the player on the map
         * 
         * The first value is the x corrdinate and the second is the y coordinate on the map
         */
        public int[] GetPlayerPosition()
        {
            int[] position = { 0, 0 };

            //Loops through the map to find the player
            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[y].Length; x++)
                {
                    if (map[y][x] == '@')
                    {
                        position[0] = x;
                        position[1] = y;
                    }
                }
             
            }


            return position;
        }

        /**
        * Returns the next player action
        * 
        * This method does not alter any internal state
        */
        public int GetPlayerAction()
        {
            int action = (int)this.action;
            //casts the enum player action to an int
            // Your code here

            return action;
        }


        public bool GameIsRunning()
        {
           

           
            return running;
            //Returns whether game is running 
        }

        /**
         * Main method and Entry point to the program
         * ####
         * Do not change! 
        */
        static void Main(string[] args)
        {
            CMDCrawler crawler = new CMDCrawler();
            string input = string.Empty;
            Console.WriteLine("Welcome to the Commandline Dungeon!" + Environment.NewLine +
                "May your Quest be filled with riches!" + Environment.NewLine);

            // Loops through the input and determines when the game should quit
            while (crawler.active && crawler.action != PlayerActions.QUIT)
            {
                Console.WriteLine("Your Command: ");
                input = crawler.ReadUserInput();
                Console.WriteLine(Environment.NewLine);

                crawler.ProcessUserInput(input);

                crawler.GameLoop(crawler.active);
            }

            Console.WriteLine("See you again" + Environment.NewLine +
                "In the CMD Dungeon! ");


        }


    }
}
