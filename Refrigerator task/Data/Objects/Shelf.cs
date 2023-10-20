﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator_task.Data.Objects
{
    internal class Shelf
    {
        const int ShelfConstSize = 10; // TODO
        public Guid ShelfId { get; set; }
        public int ShelfFloore { get; set; }
        public int ShelfSize { get; set; }
        public List<Item> MyItems { get; set; }
        public Shelf(int ShelfFloore )
        {
            this.ShelfId = Guid.NewGuid();
            this.ShelfSize = ShelfConstSize;
            this.MyItems = new List<Item>();    
            this.ShelfFloore = ShelfFloore;
            this.MyItems= new List<Item>();


        }

        public override string ToString()
        {
            string details = $"Shelf Details: ID: {ShelfId}, Floor: {ShelfFloore}, Size: {ShelfSize}\n";
            details += "Items on the Shelf:\n";
            foreach (var item in MyItems)
            {
               details += item.ToString();
            }
            return details;
        }
    }




    }

