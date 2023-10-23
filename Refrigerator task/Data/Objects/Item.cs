using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator_task.Data.Objects
{
    internal class Item
    {
        public  Guid IitemId { get; set; }
        public string IitemName { get; set; }
        public string ItemType { get; set; }//TO DO enum 
        public Shelf MyShelf { get; set; }
        public string ItemKosher { get; set; }

        // public enum ItemKosher { get; set; }
        
        public DateTime itemExpiryDate { get; set; }
        public double itemSize { get; set; }

        public Item (string IitemName, string ItemType, string ItemKosher, DateTime itemExpiryDate, double itemSize)
        {   this.IitemId=Guid.NewGuid();
            this.IitemName = IitemName;
            this.ItemType = ItemType;
            this.ItemKosher= ItemKosher;
            this.itemExpiryDate= itemExpiryDate;
            this.itemSize = itemSize;
            //this.MyShelf=new Shelf()





        }
        public override string ToString()
        {
            return $"Item ID: {IitemId}\n Name: {IitemName}\n Type: {ItemType}\n Kosher: {ItemKosher}\n Expiry Date: {itemExpiryDate}\n Size: {itemSize}\n Shelf: {(MyShelf != null ? MyShelf.ShelfId.ToString() : "N/A")}\n";


        }




    }
}
