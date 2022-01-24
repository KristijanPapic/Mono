using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProjekt1
{
    class Appartment : Bell
    {
        private string OwnerName;
        private int ResidentsNumber;

        public Appartment(string ownerName, int residentsNumber)
        {
            OwnerName = ownerName;
            ResidentsNumber = residentsNumber;
        }

        public string GetSetOwnerName { get => OwnerName; set => OwnerName = value; }
        public int GetSetResidentsNumber { get => ResidentsNumber; set => ResidentsNumber = value; }

        public void RingBell(string typeOfBell)
        {
            if (typeOfBell == "long") Console.WriteLine("diiiiing doooong");
            else if (typeOfBell == "short") Console.WriteLine("ding dong");
            else Console.WriteLine("This type of bell does not exist");
        }
    }
}
