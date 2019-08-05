using System;
using System.Collections.Generic;
using System.GateBoysWebApplication.Models;
using System.Linq;
using System.Web;

namespace GateBoysWebApplication.Logic
{
    public class Item_Business
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<Inventory> all()
        {
            return db.Items.Include(i => i.Category).ToList();
        }
        public bool add(Item model)
        {
            try
            {
                var item = db.Items.Where(x => x.Category_ID == model.Category_ID && x.Description == model.Description && x.Name == model.Name).FirstOrDefault();
                if (item != null)
                {
                    item.QuantityInStock += model.QuantityInStock;
                    item.Picture = model.Picture;
                    item.Price = model.Price;
                    item.MarkUpPercentage = model.MarkUpPercentage;
                    item.CostPrice = model.CostPrice;
                    item.ExpectedProfit = model.ExpectedProfit;
                    //db.SaveChanges();
                }
                else
                {
                    db.Items.Add(model);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool edit(Item model)
        {
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool delete(Item model)
        {
            try
            {
                db.Items.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public Item find_by_id(int? id)
        {
            return db.Items.Find(id);
        }
        //public List<StockCart_Item> get_cart_items(int id)
        //{
        //    //return db.StockCart_Items.
        //}


        public void updateStock_Received(int item_id, int quantity)
        {
            var item = db.Items.Find(item_id);
            item.QuantityInStock += quantity;
            db.SaveChanges();
        }
        public void updateOrder(int id, double price)
        {
            var item = db.Order_Items.Find(id);
            item.price = price;
            item.replied = true;
            item.date_replied = DateTime.Now;
            item.status = "Supplier Replied with Pricing Details";
            db.SaveChanges();
        }

    }
}
    }
}