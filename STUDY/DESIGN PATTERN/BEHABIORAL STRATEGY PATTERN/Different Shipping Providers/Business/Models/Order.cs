using System;
using System.Collections.Generic;
using System.Text;

namespace Different_Shipping_Providers.Business.Models
{
    public class Order
    {
        private int _nroOrder;
        public int NroOrden {

            get {

                return _nroOrder;
            
            }

            set {

                _nroOrder = value;
            }
        
        }
        public List<Item> lineItems;

        

        public Order(List<Item> LineItems)
        {
            var r = new Random();
            this.lineItems = LineItems;
            _nroOrder = r.Next(0,1000) ;
        }

        public int GetTax() {

            int TotalCost = 0;
            foreach (var item in lineItems)
            {

              TotalCost +=  item.ItemCost;

            }

            return (int)((int)TotalCost * 0.2);
        
        }
       
    }
}
