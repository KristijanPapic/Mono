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
    }
    }


