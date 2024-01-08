using System.Web.Mvc;
using akinsoft_mvc.Models;
using akinsoft_mvc.BPL;
using System.Threading.Tasks;
using System.Web.Security;

namespace akinsoft_mvc.Controllers
{
    public class HomeController : Controller

    {
        loginBPL loginBPL = new loginBPL();
        public static int user_id;

        // User Login Pages
        [HttpGet]
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            var user = new login_page();
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Index(login_page lgn, string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            int sonuc = await loginBPL.user_validate(lgn);
            if (sonuc>0)
            {

              //Authorize
              FormsAuthentication.SetAuthCookie(lgn.username, false);

               user_id = sonuc;

                if (!string.IsNullOrEmpty(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Admin");
                }
                  
            }
            else
            {
                ViewBag.Error = "<span class ='text-danger'>Username Or Password Error !</span>";
                return View(lgn);
            }
           
        }




        //User Register Pages
        [HttpGet]
        public ActionResult Signup()
        {
          var loginpage_ = new register_user();
          return View(loginpage_);
        }
        [HttpPost]
        public async Task<ActionResult> Signup(register_user mdl)
        {

          
            if (!ModelState.IsValid)
            {
                return View(mdl);
            }
            bool durum = await loginBPL.save_user(mdl);

            if (durum)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(mdl);
            }
           
        }

    }
}