using Project0.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.DummyData
{
    public class DummyProduce
    {
        public static List<Product> DProduce = new List<Product>()
        {
            new Book(){
                Author = "Jane Austen",
                Title = "Pride and Prejudice",
                Genre = "Romance",
                Desc = "Fictional Book",
                Price = 5,
                Name = "Pride and Prejudice"
            },
            new Book(){
                Author = "Jane Austen",
                Title = "Emma",
                Genre = "Romance",
                Desc = "Fictional Book",
                Price = 5,
                Name = "Emma"
            },
            new Book(){
                Author = "Jane Austen",
                Title = "Persuasion",
                Genre = "Romance",
                Desc = "Fictional Book",
                Price = 5,
                Name = "Persuasion"
            },
            new Book(){
                Author = "Jane Austen",
                Title = "Sense and Sensibility",
                Genre = "Romance",
                Desc = "Fictional Book",
                Price = 5,
                Name = "Sense and Sensibility"
            }
        };

        public static List<int> DStock = new List<int>() { 10, 20, 30, 40 };
    }
}
