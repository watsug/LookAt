using System.Collections.Generic;

namespace LookAt
{
    class Catalog
    {
        private List<Item> _items = new List<Item>();
        public Item[] Items => _items.ToArray();

        public void Add(Item item)
        {
            _items.Add(item);
        }
    }
}
