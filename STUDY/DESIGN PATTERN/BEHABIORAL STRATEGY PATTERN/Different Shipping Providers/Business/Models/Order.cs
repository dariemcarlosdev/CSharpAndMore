﻿using System;
using System.Collections.Generic;
using System.Text;
using Different_Shipping_Providers.Business.Strategies.Shipping;

namespace Different_Shipping_Providers.Business.Models
{
  //Context
  public class Order
  {
    private static int Tax {get; set;} 
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
    private readonly IShippingProviderStrategy _shippingprovider;

       /*private readonly IShippingProviderStrategy _IShippingStrategy;

    public Order(IShippingProviderStrategy IShippingStrategy)
    {
      _IShippingStrategy = IShippingStrategy;
    }*/

    public int GetTotalCost(){
        int TotalCost = 0;
            foreach (var item in lineItems)
            {
             TotalCost += item.ItemCost;
            }

            return TotalCost;

    }

    public int GetTax()
    {
      //int Tax = 0;
      
     var destination = ShippingDetails.DestinationCountry.ToLowerInvariant();

     if (destination == "Sweeden")
     {
         var origin = ShippingDetails.OriginCountry.ToLowerInvariant();
         if (destination == origin)
         {
          Tax = GetTotalCost() * 2;
         } 
        
        //return Tax;
     }

     if (destination == "Us")
     {
         var origin = ShippingDetails.OriginCountry.ToLowerInvariant();
         if (destination == origin)
         {           
           Tax = GetTotalCost() * 5;  
         } 
         
        //return Tax;    
     }
     return Tax;
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
