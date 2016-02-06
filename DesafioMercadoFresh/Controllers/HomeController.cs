using DesafioMercadoFresh.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DesafioMercadoFresh.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() // First method called when user access website. It's responsible to retrieve all products waiting for picking
        {
            try
            {
                using (Model context = new Model())
                {
                    List<IndexViewModel> pOrderList = getItemsWithStatus(Status.Waiting_For_Picking); // Get all products with status 'Waiting_For_Picking'

                    return View(pOrderList);
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult SetOnDislike(int id, string obs) // Method responsible for change the status to 'Standby_Not_Found'
        {
            using (Model context = new Model())
            {
                List<ProductOrder> productOrder = context.ProductOrder.Where(x => x.ProductId == id && x.Observations == obs).ToList(); // Try to find the product with the id and observation given

                foreach (var item in productOrder)
                {
                    item.Status = Status.Standby_Not_Found; // Set status to 'Standby_Not_Found' and save changes
                }

                context.SaveChanges();
            }

            return Json(true);
        }
        public ActionResult SetOnLike(int id, string obs) // Method responsible for change the status to 'Standby_Picked'
        {
            using (Model context = new Model())
            {
                List<ProductOrder> productOrder = context.ProductOrder.Where(x => x.ProductId == id && x.Observations == obs).ToList(); // Try to find the product with the id and observation given

                foreach (var item in productOrder)
                {
                    item.Status = Status.Standby_Picked; // Set status to 'Standby_Picked' and save changes
                }

                context.SaveChanges();
            }

            return Json(true);
        }

        public ActionResult ResetWaitingPickup() // Support method to reset the status to Waiting_For_Picking
        {
            using (Model context = new Model())
            {
                var allProductOrder = context.ProductOrder.ToList();

                foreach (var item in allProductOrder)
                {
                    item.Status = Status.Waiting_For_Picking; // Set status to 'Waiting_For_Picking' and save changes
                }

                context.SaveChanges();
            }

            return Json(true);
        }

        public ActionResult ConfirmItems(string id) // Method responsible to list products in the confirmation page
        {
            try
            {
                using (Model context = new Model())
                {
                    List<IndexViewModel> pOrderList = getItemsWithStatus(id == "Picked" ? Status.Standby_Picked : Status.Standby_Not_Found); // retrieve products with status 'Standby_Picked' or 'Standby_Not_Found'

                    TempData["Status"] = id;

                    return View(pOrderList);
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        private List<IndexViewModel> getItemsWithStatus(Status status) // Method responsible to retrieve products grouped by Observations and ProductName
        {
            List<IndexViewModel> pOrderList = null;

            using (Model context = new Model())
            {
                string sql = "select a.ProductId, ProductName, ProductImage, Observations, Sum(Quantity) as TotalQuantity, QntyUnity from products a, categories b, productorder c where a.Category_CategoryId = b.CategoryId and c.productid = a.ProductId";
                sql += " and c.Status = " + (int)status;
                sql += " group by a.ProductId, ProductName, ProductImage, Observations, CategoryPriority, QntyUnity";
                sql += " order by CategoryPriority desc, ProductName desc";

                pOrderList = context.Database.SqlQuery<IndexViewModel>(sql).ToList();
            }

            return pOrderList;
        }

        public ActionResult ConfirmStatus(List<ProductOrder> products) // Method responsible to confirm the status of the product after final evaluation
        {
            if (products != null)
            {
                using (Model context = new Model())
                {
                    foreach (var listItem in products)
                    {
                        var productOrder = context.ProductOrder
                            .Where(x => x.ProductId == listItem.ProductId
                                && x.Observations == (listItem.Observations == null ? "" : listItem.Observations)) // Find product with id and observation given
                            .ToList();

                        foreach (var singleItem in productOrder)
                        {
                            singleItem.Status = listItem.Status; // Save it with new status
                        }
                    }

                    context.SaveChanges();
                }
            }

            return Json(true);
        }
    }
}
