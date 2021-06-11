namespace Different_Shipping_Providers.Business.Models
{
    public class Item
    {
        public string ItemName { get; set; }
        public int ItemCost { get; set; }

        public float ItemWeight { get; set; }

       

        public Item(string ItemName, int ItemCost, float Weight)
        {
            this.ItemName = ItemName;
            this.ItemCost = ItemCost;
            this.ItemWeight = Weight;
        }
    }
}