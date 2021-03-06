using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Different_Shipping_Providers.Business.Strategies.SalesTax;
using Different_Shipping_Providers.Business.Strategies.Shipping;
using Different_Shipping_Providers.Business.Strategies.Invoice;
using System.Linq;

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
    public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.WaitingForPayment;
    public IInvoiceStrategy InvoiceStrategy { get; set; }

    //private readonly IShippingProviderStrategy _shippingprovider;

    public IShippingStrategy ShippingStrategy { get; set; }
    public ISaleTaxStrategy SaleTaxStrategy { get; set; }
    public List<Payment> SelectedPayments { get; set; }
    public int AmountDue {

            get 
            {
                return this.GetTax() + this.GetTotalCost();
            
            }
                
                }



        //Using the Strategy
        //If we don't pass the Strategy to our method, we´re going to use the one that's been set on our Context.
        //optional parameter to our GetTax method.

        //Whenever a method take an interface to allow alternative outcome of computation we are leveraging the strategy pattern.
        public int GetTax( [Optional] ISaleTaxStrategy saleTaxStrategy)
        {
            //The null-coalescing operator ?? returns the value of its left-hand operand if it isn't null; otherwise, it evaluates the right-hand operand and returns its result
            var strategy = saleTaxStrategy ?? SaleTaxStrategy;

            if (strategy == null)
            {
                return 0;
            }

            return strategy.GetTaxFor(this);

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

     
            
    public void FinalizeOrder(){

      if (SelectedPayments.Any( x => x.PaymentProvider == PaymentProvider.Invoice) &&
                AmountDue > 0 &&
                ShippingStatus == ShippingStatus.WaitingForPayment
                )
      {
        InvoiceStrategy.Generate(this);
        ShippingStatus = ShippingStatus.ReadyForShippment;
      }

            else if (AmountDue > 0)
            {
                throw new Exception("Unable to process Order");
            }
            ShippingStrategy.Ship(this);
    }

  }
}
