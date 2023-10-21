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
        public int numOfshelves { get; set; }

        public List<Shelf> Myshelves { get; set; }

        public Refrigerator(string RefrigeratorColor, string RefrigeratorType, int numOfshelves=6)
        {   this.RefrigeratorId = Guid.NewGuid();
            this.RefrigeratorColor = RefrigeratorColor;
            this.RefrigeratorType = RefrigeratorType;
            this.numOfshelves = numOfshelves;
            this.Myshelves = new List<Shelf>();
            for (int i = 0; i < numOfshelves; i++)
            {
                AddShelf(i);
            }

        }


        public void AddShelf(int shelfFloor)
        {
            Shelf newSelf=new Shelf(shelfFloor);
            Myshelves.Add(newSelf);
        }
       
        public override string ToString()
        {
            string details= $"Refrigerator ID: {RefrigeratorId}\n Color: {RefrigeratorColor}\n Type: {RefrigeratorType}\n Number of Shelves: {numOfshelves}\n";

            details += "The shelves:\n";
            foreach (var shelf in Myshelves)
            {
                details += shelf.ToString();
            }
            return details;
        }
    }


}
