using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MerkaDo_BACKEND.Models;

namespace MerkaDo_BACKEND.Controllers
{
    public class AddToCartController : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: AddToCart
        public async Task<ActionResult> Add( int productoId)
        {
            PRODUCTO__ PRODUCTO__ = await db.PRODUCTO__.FindAsync(productoId);

            if (Session["cart"]==null)
            {
                List<PRODUCTO__> li = new List<PRODUCTO__>();
                li.Add(PRODUCTO__);
                Session["cart"] = li;
                Session["count"] = 1;
            } 
            else
            {
                List<PRODUCTO__> li = (List<PRODUCTO__>)Session["cart"];
                li.Add(PRODUCTO__);
                Session["cart"] = li;
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
            }
            return RedirectToAction("Index", "PRODUCTO__");
        }
        //SEE CART
        public ActionResult Myorder()
        {
            List<PRODUCTO__> msn;
            if (Session["cart"] == null)
            {
                msn = new List<PRODUCTO__>();
            } else
            {
                msn = (List<PRODUCTO__>)Session["cart"];
            }
            return View(msn);
            //
        }
        //REMOVE PRODUCT CART
        public ActionResult Remove(PRODUCTO__ GetIDProduct)
        {
            List<PRODUCTO__> li = (List<PRODUCTO__>)Session["cart"];
            li.RemoveAll(x => x.productoId == GetIDProduct.productoId);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("Myorder", "AddToCart");
        }
    }
}