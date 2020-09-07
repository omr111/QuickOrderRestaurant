using QuickOrder.Entities.Entities.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickOrder.WebMVC.App_Classes
{
    public  class card
    {
      
        public void addBasket(basketItem basket)
        {
            if (HttpContext.Current.Session["activeBasket"] != null)
            {
                int a =5;
                int b = a;
                b = 3;

                card card = (card)HttpContext.Current.Session["activeBasket"];

                if (card.BasketItems.Any(x => x.products.id == basket.products.id))
                {
                    card.BasketItems.FirstOrDefault(x => x.products.id == basket.products.id).count++;

                }
                else
                    card.BasketItems.Add(basket);
            }
            else
            {
                card card = new card();
                card.BasketItems.Add(basket);
                HttpContext.Current.Session["activeBasket"] = card;
            }              
 
        }
       
        public decimal cardTotalPrice
        {
            get { return BasketItems.Sum(x => x.totalPrice); }
        }
        private List<basketItem> basketItems =new List<basketItem>();

        public List<basketItem> BasketItems
        {
            get { return basketItems; }
            set { basketItems = value; }
        }
        public static int tax
        {
            get { return 18; }

        }
        public class basketItem
        {
            public Products products { get; set; }
            public int count { get; set; }
            public double discount { get; set; }         

            public decimal totalPrice
            {
                get
                {
                    var price = products.price * count;
                    
                    return (decimal)price +(decimal)((price* tax) / 100);
                }
            }


        }
       

    }
}