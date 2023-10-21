using Refrigerator_task.Data.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator_task.Logic
{
     class Utils
    {
        public static double Free_space_in_Refrigerator( Refrigerator refrigerator )
        {   double free_space_Sum = 0;
            foreach (var shelf in refrigerator.Myshelves)
            {
                free_space_Sum += Free_space_in_Shelf(shelf);
            }
            return  free_space_Sum;
        }
        public static double Free_space_in_Shelf( Shelf shelf )
        {
            double sum = 0;
            foreach(var item in shelf.MyItems)
            {
                sum += item.itemSize;
            }
            return shelf.shelvesize-sum;
        }
        // ליצור פונקצית עז רשאומרת איפה יש מקום לפריט הזה והיא מחזירה את המדף שיש בו מקום אפשר גם ליעל למדף עם המקום הכי נכון
        public static void Enter_Item_To_Refrigerator(Refrigerator refrigerator, Item item)
        {
            if (Free_space_in_Refrigerator(refrigerator)>0)
            {
                foreach (var shelf in refrigerator.Myshelves)// TODO לפי המקו ם של המדפים
                {
                    if(Free_space_in_Shelf(shelf) >= item.itemSize)
                    {
                        shelf.MyItems.Add(item);
                        item.MyShelf= shelf;
                        Console.WriteLine("item added");
                        return;
                    }


                }
                throw new Exception(" The item is to big , not enough space on the shelves ");
            }
            else
            {
                throw new Exception("Not enough space in the fridge");

            }
        }
        public static Item Take_out_item_from_Refrigerator(Refrigerator refrigerator ,Guid itemId )
        {
            int item_index;
            foreach (var shelf in refrigerator.Myshelves)
            {
                item_index= find_Position_Item_On_Shelf(shelf, itemId);

                if (item_index!=-1)
                {
                    Item item = shelf.MyItems[item_index];
                    shelf.MyItems.RemoveAt(item_index);
                    Console.WriteLine("item out");
                    return item;
                }
            
            }

            throw new NotImplementedException( "item not exsist");//לראות שזו זריקה טובה TODO
            
        }
        public static int find_Position_Item_On_Shelf(Shelf shelf, Guid itemId)
        {
            

            for (int i = 0; i < shelf.MyItems.Count; i++)
            {
                if (shelf.MyItems[i].IitemId == itemId)
                {
                    return i;
                }
            }
            return -1;

        }
        public static List<Item> Throw_Expired_Item_From_Shelf( Shelf shelf)// לשנות לאייטם?
        {
            List<Item> expiredItem = new List<Item>();
            foreach ( var item in  shelf.MyItems)
            {
                if(item.itemExpiryDate <= DateTime.Today)
                {
                    expiredItem.Add(item);
                   
                }
            }
            shelf.MyItems.RemoveAll(item => expiredItem.Contains(item));

            return expiredItem;
        }
        public static List<Item> Throw_Expired_Item_From_Rrefrigerator(Refrigerator refrigerator)
        {
            List<Item> expiredItem = new List<Item>();

            foreach (var shelf in refrigerator.Myshelves)
            {
                expiredItem.AddRange(Throw_Expired_Item_From_Shelf(shelf));
            }
            return expiredItem;


        }

        public static List<Item> Find_Items_that_are( string itemKashrut, string ItemType, Refrigerator refrigerator)
        {
            List<Item> suitableItems = new List<Item>();
            foreach (var shelf in refrigerator.Myshelves)
            {
                foreach(var item in shelf.MyItems)
                {
                    if (item.itemExpiryDate > DateTime.Today && item.ItemKosher.Equals(itemKashrut) && item.ItemType.Equals(ItemType))
                    { 
                        suitableItems.Add(item); 
                    }
                }
            }
            return suitableItems;
        }
       
        public static void Go_shopping (Refrigerator refrigerator)
        {
            Get_Space_In_Refrigerator(refrigerator, 20);
        }
        
        public  static void Get_Space_In_Refrigerator(Refrigerator refrigerator, double space)
        {

            if (Free_space_in_Refrigerator(refrigerator) < space)
            {
                Throw_Expired_Item_From_Rrefrigerator(refrigerator);


                if (Free_space_in_Refrigerator(refrigerator) < space)
                {
                    List<Item> ToThrowItems = new List<Item>();
                    foreach (var shelf in refrigerator.Myshelves)
                    {
                        ToThrowItems.AddRange(Item_on_shelf_about_to_expire(shelf, "Dairy", 3));
                    }
                    if ((Free_space_in_Refrigerator(refrigerator) + Sum_Size_Items(ToThrowItems)) < 20)
                    {
                        foreach (var shelf in refrigerator.Myshelves)
                        {
                            ToThrowItems.AddRange(Item_on_shelf_about_to_expire(shelf, "Meat", 7));
                        }
                    }
                    if ((Free_space_in_Refrigerator(refrigerator) + Sum_Size_Items(ToThrowItems)) < 20)
                    {
                        foreach (var shelf in refrigerator.Myshelves)
                        {
                            ToThrowItems.AddRange(Item_on_shelf_about_to_expire(shelf, "parve", 2));
                            // ככה כותבים פרווה?
                        }
                    }
                    if ((Free_space_in_Refrigerator(refrigerator) + Sum_Size_Items(ToThrowItems)) < 20)
                    {
                        Console.WriteLine("this is not the time to shop");
                        return;
                    }
                    foreach (var item in ToThrowItems)
                    {
                        Throw_Item_From_Rrefrigerator(item, refrigerator);

                    }
                }


            }
            Console.WriteLine("YOU  are redy");
        }
        public static void Throw_Item_From_Rrefrigerator( Item item,Refrigerator refrigerator)
        {//להוסיף בדיקה אם הוא נמצא או לא
            foreach (var shelf in refrigerator.Myshelves)
            {
                Throw_Item_From_Shelf( item, shelf);
            }

          
        }
         public static void Throw_Item_From_Shelf(Item itemToRemove, Shelf shelf)
        {
          // if (item == null) { }
          foreach(var item in shelf.MyItems)
            {
                if (item.IitemId == itemToRemove.IitemId)
                {
                    shelf.MyItems.Remove(itemToRemove);
                    Console.WriteLine($"item remove:{itemToRemove.IitemId}");//fכדאי לקרוא כאן לTOSRING
                    break;
                } 
            }
        }






        public static List<Item> Item_on_shelf_about_to_expire(Shelf shelf, string itemkashrut,int numOfDays )///לשנות את השם למשהו שהוא לא זריקה כי הוא לא זורק
        {
          
            List<Item> ToThrowItems = new List<Item>();
            DateTime now = DateTime.Now;
            DateTime DayToCome = now.AddDays(numOfDays );
            foreach (var item in shelf.MyItems)
            {
                if (item.ItemKosher.Equals(itemkashrut) && item.itemExpiryDate <= DayToCome)
                {
                    ToThrowItems.Add(item);
                }
            }
            return ToThrowItems;
        }

       public static double Sum_Size_Items(List<Item> items)
        {
            double sum = 0;
            foreach (var item in items)
            {
                sum += item.itemSize;
            }
            return sum;

        }
    }
}
