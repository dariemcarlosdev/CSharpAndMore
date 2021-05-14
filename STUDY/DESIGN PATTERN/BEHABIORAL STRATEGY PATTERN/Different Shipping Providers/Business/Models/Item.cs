namespace Different_Shipping_Providers.Business.Models
{
    public class Item
    {
        public string ItemName { get; set; }
        public int ItemCost { get; set; }

        public Item(string ItemName, int ItemCost)
        {
            this.ItemName = ItemName;
            this.ItemCost = ItemCost;
        }
    }
}