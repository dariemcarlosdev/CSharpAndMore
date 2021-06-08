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
             
        public List<Item> _lineItems;

        public Order(List<Item> LineItems)
        {
            _lineItems = LineItems;
            var r = new Random();
            _nroOrder = r.Next(0,1000) ;
        }

        public int GetTax() {

            int TotalCost = 0;
            foreach (var item in _lineItems)
            {
              TotalCost +=  item.ItemCost;
            }

            return (int)((int)TotalCost * 0.2);
        
        }

        public string TotalWeight(){
         
        float sum = 0;
        foreach (var item in _lineItems)
        {
            sum += item.ItemWeight;
        }
         return sum.ToString("0.00");
        }
       
    }
}
