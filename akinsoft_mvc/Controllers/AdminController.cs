using akinsoft_mvc.BPL;
using akinsoft_mvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace akinsoft_mvc.Controllers
{
   [Authorize]
    public class AdminController : Controller
    {
        private ItemBPL itemBPL = new ItemBPL();
       public ActionResult Index()
        {
            return View(itemBPL.Item_List(HomeController.user_id).Result);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var result_ = itemBPL.Item_List(HomeController.user_id).Result.Where(x => x.registername.Contains(search)).ToList();
                return View(result_);
            }
            else
            {
                return View(itemBPL.Item_List(Convert.ToInt32(HomeController.user_id)).Result);
            }

        }

        [HttpGet]
        public ActionResult Register(string id=null)
        {
            ViewBag.User_id = HomeController.user_id;

            if (!string.IsNullOrEmpty(id))
            {
                Item_Saved tr=itemBPL.Get_Item(id).Result;
                return View(tr);
            }
            var mdl = new Item_Saved();
            return View(mdl);
        }

        [HttpPost]
        public async Task<ActionResult> Register(Item_Saved mdl)
        {
            if (!ModelState.IsValid)
            {
                return View(mdl);
            }

            bool durum = await itemBPL.Item_Saved(mdl);
            if (durum)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(mdl);
            }
           
        }

        public ActionResult Category()
        {
            ViewBag.User_id = HomeController.user_id;
            return View(itemBPL.get_category_list(HomeController.user_id).Result);
            //V2
            //V2 Gelismeler

            //Masterde Gelismeler

            //Master Gelismeler 2
        }

        public ActionResult Category_Saved(catagory mdl)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Category");
            }
            if (itemBPL.Category_Saved(mdl).Result)
            {
                return RedirectToAction("Category");
            }
            else
            return RedirectToAction("Index");
        }
       
        public ActionResult Register_Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                itemBPL.Item_Delete(id);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult Get_Category()
        {
            List<catagory> catagories = new List<catagory>();
            catagories = itemBPL.get_category_list(Convert.ToInt32(HomeController.user_id)).Result;
            return Json(catagories, JsonRequestBehavior.AllowGet);
           
        }
    }
}