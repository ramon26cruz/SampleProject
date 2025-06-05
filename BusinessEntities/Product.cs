using System;
using System.Text;
using System.Xml.Linq;

namespace BusinessEntities
{
   
    public class Product : IdObject
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public decimal Price { get; protected set; }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name was not provided.");
            }
            Name = name;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("Description was not provided.");
            }
            Description = description;
        }

        public void SetPrice(decimal price)
        {
            Price = price;
        }
    }
}
