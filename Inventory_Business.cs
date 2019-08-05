using GateBoysWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GateBoysWebApplications.Logic
{
    public class Inventory_Business
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public List<Inventory> all()
        {
            return db.Inventories.ToList();
        }
        public bool add(Inventory model)
        {
            try
            {
                var item = db.Inventories.Where(x => x.CategoryId == model.CategoryId && x.Description == model.Description && x.Name == model.Name).FirstOrDefault();
                if (item != null)
                {
                    item.Quantity += model.Quantity;
                    item.Image = model.Image;
                    item.Price = model.Price;
                    //db.SaveChanges();
                }
                else
                {
                    db.Inventories.Add(model);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool edit(Inventory model)
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
        public bool delete(Inventory model)
        {
            try
            {
                db.Inventories.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public Inventory find_by_id(int? id)
        {
            return db.Inventories.Find(id);
        }
        //public List<StockCart_Item> get_cart_items(int id)
        //{
        //    //return db.StockCart_Items.
        //}


        public void updateStock_Received(int item_id, int quantity)
        {
            var item = db.Inventories.Find(item_id);
            item.Quantity += quantity;
            db.SaveChanges();
        }
        public void updateOrder(int id, double price)
        {
            var item = db.Order_Items.Find(id);
            item.UnitPrice = price;
            //item.replied = true;
            //item.date_replied = DateTime.Now;
            //item.status = "Supplier Replied with Pricing Details";
            db.SaveChanges();
        }

    }
}
    
