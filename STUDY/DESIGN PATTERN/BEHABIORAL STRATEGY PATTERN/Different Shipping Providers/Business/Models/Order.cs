using System;
using System.Collections.Generic;
using System.Text;
using Different_Shipping_Providers.Business.Strategies.SalesTax;
using Different_Shipping_Providers.Business.Strategies.Shipping;

namespace Different_Shipping_Providers.Business.Models
{
  //Context
  public class Order
  {

    private int _nroOrder;
    public int NroOrden
    {
      get
      {
        return _nroOrder;
      }
      set
      {
        _nroOrder = value;
      }

    }
    public List<Item> lineItems;
    public ShippingDetails ShippingDetails { get; set; }

    //private readonly IShippingProviderStrategy _shippingprovider;


    public ISaleTaxStrategy SaleTaxStrategy { get; set; }
  



        public int GetTax() {

            if (SaleTaxStrategy == null)
            {
                return 0;
            }

            return SaleTaxStrategy.GetTaxFor(this);

        }


        public int GetTotalCost()
        {
            int TotalCost = 0;
            foreach (var item in lineItems)
            {
                TotalCost += item.ItemCost;
            }

            return TotalCost;

        }

        public string TotalWeight()
    {
      float sum = 0;
      foreach (var item in lineItems)
      {
        sum += item.ItemWeight;
      }
      return sum.ToString("0.00");
    }

  }
}
