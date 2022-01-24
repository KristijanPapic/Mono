using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProjekt1
{
     abstract class Building
    {
        public string BuildingMaterial;
        public int AppartmentsCapacity;
        private int OccupiedAppartments = 0;
        public List<Appartment> Appartments = new List<Appartment>();

        public bool HasRoom()
        {
            if (OccupiedAppartments < AppartmentsCapacity) return true;
            else return false;
;        } 

        public int GetNumberOfOccupiedAppartments()
        {
            return OccupiedAppartments;
        }

        public void MoveInAppartment(string ownerName, int residentsNumber)
        {
            if (OccupiedAppartments < AppartmentsCapacity)
            {
                Appartments.Add(new Appartment(ownerName, residentsNumber));
                OccupiedAppartments++;
                Console.WriteLine(ownerName + " has moved in");
            }
            else Console.WriteLine("The building is full");
           
        }
        public void MoveOutAppartment(string ownerName)
        {
            Appartments.RemoveAll(appartment => appartment.GetSetOwnerName.Equals(ownerName));
            OccupiedAppartments--;
            Console.WriteLine(ownerName + " has moved out");
        }

        public abstract double CalculateSurface();
    }
}
