using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProjekt1
{
    class SquareBuilding : Building
    {
        public int SideLenght;

        public SquareBuilding(string buildingMaterial, int appartmentCapacity, int lenght)
        {
            BuildingMaterial = buildingMaterial;
            AppartmentsCapacity = appartmentCapacity;
            SideLenght = lenght;
        }

            public override double CalculateSurface()
        {
            return Math.Pow(SideLenght,2);
        }

        public void Detail()
        {
            Console.WriteLine("This square building made out of " + BuildingMaterial
                + " has a floor area of " + CalculateSurface()
                + " square meters " + "and currently has " + GetNumberOfOccupiedAppartments()
                + " occupied appartments: ");
            for (int i = 0; i < GetNumberOfOccupiedAppartments(); i++)
            {
                Console.WriteLine("Appartment number : " + i + ", Owner name : "
                    + Appartments[i].GetSetOwnerName + " , Number or ressidents: " + Appartments[i].GetSetResidentsNumber);
            }
        }
    }
    }


