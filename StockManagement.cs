﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WarehouseApplication
{
    internal class StockManagement
    {
        private Warehouse warehouse;
        private List<Source> sources;
        private List<Product> products;

        public StockManagement()
        {
            sources = new List<Source>
            {
                new Source(1, "In house"),
                new Source(2, "3rd party")
            };
            products = new List<Product>
            {
                new Product(1, "RICE", sources[0], 100),
                new Product(2, "BEANS", sources[0], 100),
                new Product(3, "TOMATOES", sources[1], 100),
                new Product(4, "APPLES", sources[1], 100)
            };
            warehouse = new Warehouse();
            warehouse.Products = products;
        }

        public void ListProducts()
        {
            if (warehouse.Products.Count == 0)
            {
                Console.WriteLine("Warehouse is empty");
            }
            else
            {
                foreach (var product in warehouse.Products)
                {
                    Console.WriteLine($"\nID: {product.Id}\nNAME: {product.Name}\nSOURCE: {product.Source.Name}\nSTOCK: {product.Stock}");
                }
            }
        }

        public void SearchProduct(string name)
        {
            string upperName = name.ToUpper();
            Product product = warehouse.Products.Find(p => p.Name.Contains(upperName));
            if (product != null)
            {
                Console.WriteLine($"\nID: {product.Id}\nNAME: {product.Name}\nSOURCE: {product.Source.Name}\nSTOCK: {product.Stock}");
            }
            else
            {
                Console.WriteLine($"Product {upperName} not found.");
            }
        }

        public void AddProduct(int id, string name, int sourceId, int stock)
        {
            Source source = sources.Find(s => s.Id == sourceId);
            if (source != null)
            {
                Product product = new Product(warehouse.Products.Count+1, name.ToUpper().Trim(), source, stock);
                warehouse.Products.Add(product);
            } else
            {
                Console.WriteLine($"Source with Id {sourceId} not found.");
            }
        }

        public void RemoveProduct(int id)
        {
            Product product = warehouse.Products.Find(p => p.Id == id);
            if (product != null)
            {
                warehouse.Products.Remove(product);
                Console.WriteLine($"Congratulations! Product with Id {id} removed successfully.");
            } else
            {
                Console.WriteLine($"Product with Id {id} not found.");
            }
        }

        public void EditProduct(int id, string name, int sourceId, int stock)
        {
            Product product = warehouse.Products.Find(p => p.Id == id);
            if (product != null)
            {
                Source source = sources.Find(s => s.Id == sourceId);
                if (source != null)
                {
                    product.Name = name.ToUpper().Trim();
                    product.Source = source;
                    Console.WriteLine($"Congratulations! Product with Id {id} updated successfully.");
                }
                else
                {
                    Console.WriteLine($"Source with Id {sourceId} not found.");
                }
            }
            else
            {
                Console.WriteLine($"Product with Id {id} not found.");
            }
        }

        public void UpdateStock(int id, int stock)
        {
            Product product = warehouse.Products.Find(p => p.Id == id);
            if (product != null)
            {
                product.Stock = stock;
                Console.WriteLine($"Congratulations! Product's stock with Id {id} updated successfully.");
            }
            else
            {
                Console.WriteLine($"Product with Id {id} not found.");
            }
        }

    }
}
