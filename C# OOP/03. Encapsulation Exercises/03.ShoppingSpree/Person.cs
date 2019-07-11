using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }
        public IReadOnlyCollection<Product> Bag
        {
            get
            {
                return this.bag.AsReadOnly();
            }
        }


        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public string BuyProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.money -= product.Cost;
                this.bag.Add(product);

                return $"{this.name} bought {product.Name}";
            }

            return $"{this.name} can't afford {product.Name}";
        }

        public override string ToString()
        {
            var personProducts = this.Bag.Count == 0 ? "Nothing bought" : string.Join(", ", this.Bag.Select(x => x.Name));

            return $"{this.Name} - {personProducts}";
        }
    }
}
