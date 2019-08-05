using GateBoysWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GateBoysWebApplication.Services
{
    public class ProductsService
    {

        #region Singleton
        public static ProductsService Instance
        {
            get
            {
                if (instance == null) instance = new ProductsService();

                return instance;
            }
        }
        private static ProductsService instance { get; set; }

        private ProductsService()
        {
        }

        #endregion
        public List<Inventory> SearchProducts(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int pageNo, int pageSize)
        {
            using (ApplicationDbContext context= new ApplicationDbContext())
            {
                var products = context.Inventories.ToList();

                if (categoryID.HasValue)
                {
                    products = products.Where(x => x.Categories.CategoryId == categoryID.Value).ToList();
                }

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    products = products.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
                }

                if (minimumPrice.HasValue)
                {
                    products = products.Where(x => x.Price >= minimumPrice.Value).ToList();
                }

                if (maximumPrice.HasValue)
                {
                    products = products.Where(x => x.Price <= maximumPrice.Value).ToList();
                }

                if (sortBy.HasValue)
                {
                    switch (sortBy.Value)
                    {
                        case 2:
                            products = products.OrderByDescending(x => x.StockNo).ToList();
                            break;
                        case 3:
                            products = products.OrderBy(x => x.Price).ToList();
                            break;
                        default:
                            products = products.OrderByDescending(x => x.Price).ToList();
                            break;
                    }
                }

                return products.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
            }
        }



    }
}
