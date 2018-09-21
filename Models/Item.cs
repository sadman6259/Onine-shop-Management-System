using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommersShop.Models
{
    public class Item{
    private TopProduct Pr = new TopProduct();
    private LatestProduct Lr = new LatestProduct();
    private Category Cr = new Category();
        public TopProduct Pr1
        {
            get { return Pr; }
            set { Pr = value; }
        }
        public LatestProduct Lr1
        {
            get { return Lr; }
            set { Lr = value; }
        }
        public Category Cr1
        {
            get { return Cr; }
            set { Cr = value; }
        }

      
        private int Quantity;

        public int Quantity1
        {
            get { return Quantity; }
            set { Quantity = value; }
        }

        public Item()
        {

        }
        public Item(TopProduct product,int Quantity)
        {
            this.Pr1 = product;
            this.Quantity1 = Quantity;

        }
        public Item(LatestProduct product10, int Quantity)
        {

            this.Lr1 = product10;
            this.Quantity1 = Quantity;

        }
        public Item(Category product1, int Quantity)
        {
            this.Cr1 = product1;
            this.Quantity1 = Quantity;

        }
    }
}