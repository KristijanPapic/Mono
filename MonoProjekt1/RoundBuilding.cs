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
    }
}
