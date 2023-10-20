using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator_task.Data.Objects
{
    class Refrigerator
    {
        public Guid RefrigeratorId { get; set; }
        public string RefrigeratorColor { get; set; }
        public string RefrigeratorType { get; set; }
        public int numOfShelfs { get; set; }

        public List<Shelf> MyShelfs { get; set; }

        public Refrigerator(string RefrigeratorColor, string RefrigeratorType, int numOfShelfs=6)
        {   this.RefrigeratorId = Guid.NewGuid();
            this.RefrigeratorColor = RefrigeratorColor;
            this.RefrigeratorType = RefrigeratorType;
            this.numOfShelfs = numOfShelfs;
            this.MyShelfs = new List<Shelf>();
            for (int i = 0; i < numOfShelfs; i++)
            {
                AddShelf(i);
            }

        }


        public void AddShelf(int shelfFloor)//TODO להוציא ליוטיל
        {
            Shelf newSelf=new Shelf(shelfFloor);
            MyShelfs.Add(newSelf);
        }
       
        public override string ToString()
        {
            string details= $"Refrigerator ID: {RefrigeratorId}, Color: {RefrigeratorColor}, Type: {RefrigeratorType}, Number of Shelves: {numOfShelfs}";

            details += "The Shelfs:\n";
            foreach (var shelf in MyShelfs)
            {
                details += shelf.ToString();
            }
            return details;
        }
    }


}
