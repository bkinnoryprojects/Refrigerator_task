using Refrigerator_task.Data.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator_task.Logic
{
    internal class Sort
    {
        public void SortItemsByExpiryDate(Refrigerator refrigerator)
        {

        }
        public static List<Item> Sort_Item_By_Expiration_Date(Refrigerator refrigerator)
        {
            List<Item> items = new List<Item>();
            foreach (var shelf in refrigerator.MyShelfs)
            {
                items.AddRange(shelf.MyItems);

            }
            List<Item> orderItems=  items.OrderBy(item => item.itemExpiryDate).ToList();

            return orderItems;
        }
        public static List<Shelf> Sort_Shelves_By_Free_Space( Refrigerator refrigerator)
        {
            List<Shelf> Shelves = refrigerator.MyShelfs;
            List<Shelf> orderShelves =Shelves.OrderByDescending(shelf => Utils.Free_space_in_Shelf(shelf)).ToList();
            return orderShelves;

        }
        public static List<Refrigerator> Sort_Refrigerators_By_Free_Space(List<Refrigerator> refrigerators)
        {
            return refrigerators.OrderByDescending(Refrigerator => Utils.Free_space_in_Refrigerator(Refrigerator)).ToList();
             

        }
    }
}
