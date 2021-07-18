using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace MarsRovers
{
    class Program
    {
        static void Main(string[] args)
        {
            /*we need to know the path where is located our input text file
             */
            string filePath = @"C:\RoverCommands.txt";

            string[] lines = File.ReadAllLines(filePath); //this is an array with the lines of the file
            int numLinesFile = File.ReadAllLines(filePath).Length; //we count how many lines has the file

            /*we need to know the size of the plateau, it is in the first line*/
            string plateauSize = lines[0];
            int plateauX = Convert.ToInt32(plateauSize.Split(' ')[0]);
            int plateauY = Convert.ToInt32(plateauSize.Split(' ')[1]);
            Plateau._x = plateauX;
            Plateau._y = plateauY;
            //Console.WriteLine("Plateau X: "+ plateauX);

            /* then, for every Rover we have 2 lines, the first for the position on the grid and the second one
             for the commands to the Rover         */
           
            for (int i = 1; i < numLinesFile; i = i + 2)
            {
                try
                {
                    /*we need instanciate an object Rover*/
                    Rover rover = new Rover(lines[i]);
                    string commandLine = lines[i + 1];                    

                    /*we need to move for every command in the command line and for every command 
                        call the corresponding method of the object*/
                    //Console.WriteLine("Rover");
                    for (int j = 0; j < commandLine.Length; j++)
                    {
                        //rover.printCurrentPosition();
                        switch (commandLine[j])
                        {
                            case 'L':
                                rover.RotateLeft();
                                break;
                            case 'R':
                                rover.RotateRight();
                                break;
                            case 'M':
                                rover.MoveForward();
                                break;
                            default:
                                Console.WriteLine("Invalid command");
                                break;
                        }
                    }                    
                    Console.WriteLine(rover.x + " " + rover.y + " " + rover.facing);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.ReadLine();
        }
    }
}
