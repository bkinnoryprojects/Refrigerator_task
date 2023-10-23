// See https://aka.ms/new-console-template for more information






//
using Refrigerator_task.Data.Objects;
using Refrigerator_task.Logic;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)

    {// כדאי להפוך לאי נם או להכניס לפונקציה
        List<string> validItemTypes = new List<string> { "Food", "Drink" };
        List<string> validItemKosher = new List<string> { "Dairy", "Meat", "Purve" };

        Refrigerator refrigerator = new Refrigerator("red","samsung",10 );
        Refrigerator refrigerator2 = new Refrigerator("black", "LG", 9);

        Item item1 = new Item("apple", "Food", "Purve", DateTime.Today.AddDays(-5) ,5);
        Item item2 = new Item("banna", "Food", "Purve", DateTime.Today.AddDays(5), 5);
        Item item3 = new Item("orenge", "Food", "Purve", DateTime.Today.AddDays(-5), 5);

        Item item4 = new Item("lemon", "Food", "Purve", DateTime.Today.AddDays(5), 5);
        Utils.Enter_Item_To_Refrigerator( refrigerator,item1);
        Utils.Enter_Item_To_Refrigerator(refrigerator, item2);
        Utils.Enter_Item_To_Refrigerator(refrigerator, item3);
        Utils.Enter_Item_To_Refrigerator(refrigerator, item4);
        
        List<Refrigerator> refrigeratorList= new List<Refrigerator>();
        refrigeratorList.Add( refrigerator);
        refrigeratorList.Add(refrigerator2);

        int choice=0;
       
        do
        {
            try
            {


                ShowMenu();
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine(refrigerator.ToString());
                            // מה אם המדפים ריקים או 
                            break;
                        case 2:
                            Console.WriteLine(Utils.Free_space_in_Refrigerator(refrigerator));
                            break;
                        case 3:
                            Console.Write("Enter Item Name: ");
                            string itemName = Console.ReadLine();


                            Console.Write("Enter Item Type (Food/Drink): ");

                            string itemType = Console.ReadLine();
                            while (!validItemTypes.Contains(itemType))
                            {
                                Console.Write("Enter valid Item Type (Food/Drink): ");
                                itemType = Console.ReadLine();
                            }


                            Console.Write("Enter Item Kashrut (Dairy/Meat/Purve): ");
                            string itemKosher = Console.ReadLine();
                            while (!validItemKosher.Contains(itemKosher))
                            {
                                Console.Write("Enter valid item Kashrut (Dairy/Meat/Purve): ");
                                itemKosher = Console.ReadLine();
                            }
                            Console.Write("Enter Expiry Date (YYYY-MM-DD): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime expiryDate))
                            {
                                Console.Write("Enter Item Size: ");

                                if (double.TryParse(Console.ReadLine(), out double itemSize))
                                {
                                    Item newItem = new Item(itemName, itemType, itemKosher, expiryDate, itemSize);
                                    Utils.Enter_Item_To_Refrigerator(refrigerator, newItem);


                                }
                                else
                                {
                                    Console.WriteLine("Invalid item size. Please enter a valid number.");

                                }

                            }
                            else
                            {
                                Console.WriteLine("Invalid expiry date. Please enter a valid date in YYYY-MM-DD format.");

                            }


                            break;
                        case 4:
                            Console.Write("Enter Item id: ");
                            if (Guid.TryParse(Console.ReadLine(), out Guid itemid))
                            { // שואלת מה הפריט
                                try
                                {
                                    Item itemout = Utils.Take_out_item_from_Refrigerator(refrigerator, itemid);
                                    itemout.ToString();
                                }
                                catch (Exception ex)
                                {

                                    Console.WriteLine(ex.Message);

                                }

                            }
                            break;
                        case 5:
                            List<Item> expiredItem = Utils.Throw_Expired_Item_From_Rrefrigerator(refrigerator);
                            foreach (var item5 in expiredItem)
                            {
                                Console.WriteLine("the item:" + item5.IitemName);
                            }

                            break;
                        case 6:

                            Console.Write("Enter Item Type (Food/Drink): ");

                            string itemType6 = Console.ReadLine();
                            while (!validItemTypes.Contains(itemType6))
                            {
                                Console.Write("Enter valid Item Type (Food/Drink): ");
                                itemType = Console.ReadLine();
                            }


                            //לבדוק את זה
                            Console.Write("Enter Item Kashrut (Dairy/Meat/Purve): ");
                            string itemKosher6 = Console.ReadLine();
                            //לבדוק שזה סטרינג
                            while (!validItemKosher.Contains(itemKosher6))
                            {
                                Console.Write("Enter valid item Kashrut (Dairy/Meat/Purve): ");
                                itemKosher = Console.ReadLine();
                            }

                            List<Item> itemsfound = Utils.Find_Items_that_are(itemKosher6, itemType6, refrigerator);
                            foreach (var item6 in itemsfound)
                            {
                                Console.WriteLine("the item:" + item6.ToString());

                            }
                            break;
                        case 7:




                            List<Item> SortItems = Sort.Sort_Item_By_Expiration_Date(refrigerator);
                            foreach (var item in SortItems)
                            {
                                Console.WriteLine(item.ToString());
                            }


                            break;
                        case 8:
                            List<Shelf> SortShelf = Sort.Sort_Shelves_By_Free_Space(refrigerator);
                            foreach (var shelf in SortShelf)
                            {
                                Console.WriteLine(shelf.ToString());
                            }
                            break;
                        case 9:
                            List<Refrigerator> sortRefrigerator = Sort.Sort_Refrigerators_By_Free_Space(refrigeratorList);
                            foreach (var refrigerator9 in sortRefrigerator)
                            {
                                Console.WriteLine(refrigerator9.ToString());
                            }


                            break;
                        case 10:
                            Utils.Go_shopping(refrigerator);
                            break;

                        case 100:
                            Console.WriteLine("System shutting down.");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);


            }
            
        } while (choice != 100);
    }

    static void ShowMenu()
    {
        Console.WriteLine("Refrigerator Management System");
        Console.WriteLine("1. Print all items in the refrigerator");
        Console.WriteLine("2. Print remaining space in the fridge");
        Console.WriteLine("3. Add an item to the refrigerator");
        Console.WriteLine("4. Remove an item from the refrigerator");
        Console.WriteLine("5. Clean the refrigerator and list discarded items");
        Console.WriteLine("6. Choose what to eat");
        Console.WriteLine("7. Print all products sorted by expiry date");
        Console.WriteLine("8. Print shelves sorted by free space");
        Console.WriteLine("9. Print refrigerators sorted by free space");
        Console.WriteLine("10. Prepare refrigerator for shopping");
        Console.WriteLine("100. Exit");

    }
}

