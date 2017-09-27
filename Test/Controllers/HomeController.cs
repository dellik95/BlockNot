using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //using (UserContext us = new UserContext())
            //{
            //    Users us1 = new Users
            //    {
            //        UserName = "User1",
            //        UserSname = "User1",
            //        UserEmail = "User1"
            //    };
            //    Users us2 = new Users
            //    {
            //        UserName = "User2",
            //        UserSname = "User2",
            //        UserEmail = "User2"
            //    };
            //    us.Users.AddRange(new List<Users> { us1, us2 });
            //    us.SaveChanges();


            //    Phones ph1 = new Phones
            //    {
            //        Phone = 566544654,
            //        User = us1,
            //        User_ID = us1.User_ID
            //    };
            //    Phones ph2 = new Phones
            //    {
            //        Phone = 566544654,
            //        User = us2,
            //        User_ID = us2.User_ID
            //    };
            //    Phones ph3 = new Phones
            //    {
            //        Phone = 566544654,
            //        User = us1,
            //        User_ID = us1.User_ID
            //    };

            //    us.Phones.AddRange(new List<Phones> {ph1,ph2,ph3 });
            //    us.SaveChanges();
            //}

            return View();
        }

        public JsonResult GetUser()
        {
            using (UserContext us = new UserContext())
            {
                var query = us.Users.Include("Phones").ToList();

                return Json(query, JsonRequestBehavior.AllowGet);
            }
        }

        public void DeleteUser(int id)
        {
            using (UserContext us = new UserContext())
            {
                Users user = us.Users.Include("Phones").Where(x => x.User_ID == id).FirstOrDefault();
                us.Users.Remove(user);
                us.SaveChanges();
            }
        }
        [HttpGet]
        public ActionResult CreateUser()
        {
            return PartialView();
        }
        [HttpPost]
        public void CreateUser(Users user, int[] Phones)
        {
            using (UserContext us = new UserContext())
            {
                Users us1 = user;
                us.Users.Add(us1);
                us.SaveChanges();
                foreach (var item in Phones)
                {
                    if (item != 0)
                    {
                        us.Phones.Add(new Phones
                        {
                            Phone = item,
                            User_ID = us1.User_ID
                        });
                    }
                }
                us.SaveChanges();
            }
        }
        [HttpGet]
        public ActionResult EditUser(short id)
        {
            using (UserContext us = new UserContext())
            {
                Users user = us.Users.Include("Phones").Where(x => x.User_ID == id).FirstOrDefault();
                return PartialView(user);
            }
        }
        [HttpPost]
        public void EditUser(Users user)
        {

            using (UserContext us = new UserContext())
            {
                var upUser = us.Users.Include("Phones").Where(x => x.User_ID == user.User_ID).FirstOrDefault();

                upUser.UserName = user.UserName;
                upUser.UserSname = user.UserSname;
                upUser.UserEmail = user.UserEmail;
                us.SaveChanges();
            }
        }
    }
}