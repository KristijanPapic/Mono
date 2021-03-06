using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProjekt1
{
    class RoundBuilding : Building
    {
        public int Radius;

        public RoundBuilding(string buildingMaterial, int appartmentCapacity, int radius)
        {
            BuildingMaterial = buildingMaterial;
            AppartmentsCapacity = appartmentCapacity;
            Radius = radius;
        }

        public override double CalculateSurface()
        {
            return Math.PI * Math.Pow(Radius,2);
        }

        public void Detail()
        {
            Console.WriteLine("This round building made out of " + BuildingMaterial
                + " has a floor area of " + CalculateSurface()
                + " square meters " + "and currently has " + GetNumberOfOccupiedAppartments()
                + " occupied appartments: ");
            for(int i = 0; i < GetNumberOfOccupiedAppartments(); i++)
            {
                Console.WriteLine("Appartment number : " + i + ", Owner name : "
                    + Appartments[i].GetSetOwnerName + " , Number or ressidents: " + Appartments[i].GetSetResidentsNumber);
            }
        }
    }
}
