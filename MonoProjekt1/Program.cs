using System;

namespace MonoProjekt1
{
    class Program
    {
        static void Main(string[] args)
        {
            SquareBuilding squareBuilding1 = new SquareBuilding("brick",5,25);

            RoundBuilding roundBuilding1 = new RoundBuilding("wood",6,28);

            squareBuilding1.MoveInAppartment("marko", 6);
            squareBuilding1.MoveInAppartment("ante", 6);


            squareBuilding1.Appartments[0].RingBell("long");

            Console.WriteLine(squareBuilding1.Appartments[0].GetSetOwnerName);

            squareBuilding1.MoveOutAppartment("marko");

            Console.WriteLine(squareBuilding1.Appartments[0].GetSetOwnerName);

            roundBuilding1.MoveInAppartment("ivan", 5);
            roundBuilding1.MoveInAppartment("ana", 2);

            Console.WriteLine("\n\n");

            roundBuilding1.Detail();

            Console.WriteLine("\n\n");

            squareBuilding1.Detail();




        }
    }
}
