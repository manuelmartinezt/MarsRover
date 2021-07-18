using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers
{
    class Rover
    {
        /*we need to declare the atributes of the class Rover*/ 
        public int x;
        public int y;
        public char facing;

        /*we need to initialize the variables with a constructor*/
        public Rover(string positionOnGrid) //we recive the param positionOnGrid for example: 1 0 N
        {
            /*we need to split the array position and asing to the variables declared before*/
            x = Convert.ToInt32(positionOnGrid.Split(' ')[0]);
            y = Convert.ToInt32(positionOnGrid.Split(' ')[1]);
            facing = Convert.ToChar(positionOnGrid.Split(' ')[2]);
        }

        /* now we have to declare the behaviors (methods) of the Rover on the grid*/
        public void RotateLeft()
        {
            /*we know that if rover is facing to the north and turn to the left, it will be facing to the West*/
            switch (facing)
            {
                case 'N':
                    facing = 'W';
                    break;
                case 'S':
                    facing = 'E';
                    break;
                case 'W':
                    facing = 'S';
                    break;
                case 'E':
                    facing = 'N';
                    break;
                default:
                    throw new Exception("Invalid Command");
            }
        }
        public void RotateRight()
        {
            /*we know that if rover is facing to the north and turn to the right, it will be facing to the East*/
            switch (facing)
            {
                case 'N':
                    facing = 'E';
                    break;
                case 'S':
                    facing = 'W';
                    break;
                case 'W':
                    facing = 'N';
                    break;
                case 'E':
                    facing = 'S';
                    break;
                default:
                    throw new Exception("Invalid Command"); 
            }
        }
        public void MoveForward()
        {            
            /*to do this, we need the direction of Rover is facing to... and we must increment or decrement the value
             on the grid (x or y) depending on that*/
            switch (facing)
            {
                case 'N':
                    if (CanMoveNorth(x, y)) /*we have to validate the Rover can move and dont go out of the plateau*/
                        y += 1;
                    else
                        throw new Exception("Rover Out of Plateau");
                    break;                      
                case 'S':
                    if (CanMoveSuth(x, y))                    
                        y -= 1;
                    else
                        throw new Exception("Rover Out of Plateau");
                    break;
                case 'W':
                    if (CanMoveWest(x, y))
                        x -= 1;
                    else
                        throw new Exception("Rover Out of Plateau");
                    break;
                case 'E':
                    if (CanMoveEast(x, y))
                        x += 1;
                    else
                        throw new Exception("Rover Out of Plateau");
                    break;
                default:
                    throw new Exception("Invalid Command");
            }
        }
        /*we have methods to know is the next move is valid*/
        public static bool CanMoveNorth(int currentX, int currentY)
        {
            return currentY + 1 <= Plateau._y;
        }
        public static bool CanMoveEast(int currentX, int currentY)
        {
            return currentX + 1 <= Plateau._x;
        }
        public static bool CanMoveSuth(int currentX, int currentY)
        {
            return currentY - 1 >= 0;
        }
        public static bool CanMoveWest(int currentX, int currentY)
        {
            return currentX - 1 >= 0;
        }

        //public void printCurrentPosition()
        //{
        //    Console.WriteLine(x + " " + y + " " + facing);
        //}
    }
}
