using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvcNew.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>(); // Cria o objeto com a instanciação, um departamento tem vários sellers

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller) 
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        { 
            return Sellers.Sum(Seller => Seller.TotalSales(initial, final)); // Linq  com expressao lambda
        }
    }
}
