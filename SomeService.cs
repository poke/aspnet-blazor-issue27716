using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleApp
{
    public class SomeService
    {
        List<Item> _items = new List<Item>();

        public event EventHandler ItemsChanged;

        public bool ExceptionEnabled { get; set; }

        public async Task<IList<Item>> LoadItems()
        {
            await Task.Delay(2000);

            if (ExceptionEnabled)
                throw new Exception("Load items failed");

            return _items.AsReadOnly();
        }

        public void AddItem()
        {
            _items.Add(new Item { Title = $"Item {_items.Count}" });

            ItemsChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Item
    {
        public string Title
        { get; set; }
    }
}
