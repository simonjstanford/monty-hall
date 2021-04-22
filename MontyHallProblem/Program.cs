using System;
using System.Collections.Generic;

namespace ConsoleApp9
{
   class Program
   {
      private static Random rand = new Random();
      private static int gameNumber = 0;
      private static int guessedCorrectly = 0;

      static void Main(string[] args)
      {
         for (int g = 0; g < 10000000; g++)
         {
            gameNumber++;

            var doors = new short[3];
            var prizeDoor = GetRandomDoor();
            doors[prizeDoor] = 1;

            var chosenDoor = GetRandomDoor();
            var doorsThatCanBeRemoved = new List<int>();

            for (int i = 0; i < doors.Length; i++)
            {
               if (i != chosenDoor && i != prizeDoor)
               {
                  doorsThatCanBeRemoved.Add(i);
               }
            }

            var doorToRemoveIndex = rand.Next(0, doorsThatCanBeRemoved.Count);
            var doorToRemove = doorsThatCanBeRemoved[doorToRemoveIndex];
            doors[doorToRemove] = -1;

            for (int i = 0; i < doors.Length; i++)
            {
               var value = doors[i];

               if (i != chosenDoor && value != -1)
               {
                  chosenDoor = i;
                  break;
               }
            }

            if (chosenDoor == prizeDoor)
            {
               guessedCorrectly++;
            }
         }

         Console.WriteLine("Games: " + gameNumber);
         Console.WriteLine("Guessed correctly: " + guessedCorrectly);
         Console.ReadLine();
      }

      private static int GetRandomDoor()
      {
         return rand.Next(0, 3);
      }
   }
}
