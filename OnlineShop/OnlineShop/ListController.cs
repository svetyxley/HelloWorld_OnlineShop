using OnlineShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Generic List Controller: ListController<T> is a generic class that can handle lists of any type,
//providing methods to add, remove, and retrieve items, as well as a custom ToString method.

namespace OnlineShop
{
    public class ListController<T>
        {
            private List<T> items;

            public ListController()
            {
                items = new List<T>();
            }

            // Add an item to the list
            public void AddItem(T item)
            {
                items.Add(item);
            }

            // Remove an item from the list by index
            public bool RemoveItemAt(int index)
            {
                if (index >= 0 && index < items.Count)
                {
                    items.RemoveAt(index);
                    return true;
                }
                return false;
            }

            // Get all items as a list
            public List<T> GetItems()
            {
                return new List<T>(items);
            }

            // Override the ToString method to display all items
            public override string ToString()
            {
                if (items.Count == 0)
                    return "No items in the list.";

                string result = "Items:\n";
                foreach (var item in items)
                {
                    result += item.ToString() + "\n";
                }
                return result;
            }
        }
    }
