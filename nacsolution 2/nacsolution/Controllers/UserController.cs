using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using System.Web.Security;
using nacsolution.Models;

using System.Data.SqlClient;
using System.Data;
using System.Configuration.Provider;


namespace nacsolution.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Registration()

        {

            return View();

        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Registration([Bind(Exclude = "sys_IsEmailVerified,sys_VerificationCode")] NBA_SYS_Users user)

        {

            bool Status = false;

            string message = "";

            //

            // Model Validation 

            if (ModelState.IsValid)

            {



                #region //Email is already Exist 

                var isExist = IsEmailExist(user.email);

                if (isExist)

                {

                    ModelState.AddModelError("EmailExist", "Email already exist");

                    return View(user);

                }

                #endregion



                #region Generate Activation Code 

                user.sys_VerificationCode = Guid.NewGuid();

                #endregion



                #region  Password Hashing 

                user.password = Crypto.Hash(user.password);

                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword); //

                #endregion

                user.sys_IsEmailVerified = false;



                #region Save to Database

                using (nlbdataEntities dc = new nlbdataEntities())

                {



                    dc.NBA_SYS_Users.Add(user);

                    dc.SaveChanges();



                    //Send Email to User

                    SendVerificationLinkEmail(user.email, user.sys_VerificationCode.ToString());

                    message = "Registration successfully done. Account activation link " +

                        " has been sent to your email id:" + user.email;

                    Status = true;

                }

                #endregion

            }

            else

            {

                message = "Invalid Request";

            }



            ViewBag.Message = message;

            ViewBag.Status = Status;

            return View(user);

        }

        //Verify Account  



        [HttpGet]

        public ActionResult VerifyAccount(string id)

        {

            bool Status = false;

            using (nlbdataEntities dc = new nlbdataEntities())

            {

                dc.Configuration.ValidateOnSaveEnabled = false;



                var v = dc.NBA_SYS_Users.Where(a => a.sys_VerificationCode == new Guid(id)).FirstOrDefault();

                if (v != null)

                {

                    v.sys_IsEmailVerified = true;

                    dc.SaveChanges();

                    Status = true;

                }

                else

                {

                    ViewBag.Message = "Invalid Request";

                }

            }

            ViewBag.Status = Status;

            return View();

        }



        //Login 

        [HttpGet]

        public ActionResult Login()

        {

            return View();

        }


        public  string GetRolesForUser(string username)
        {
            using (nlbdataEntities _Context = new nlbdataEntities())
            {
                //var userRoles = (from user in _Context.NBA_SYS_Users
                //                 join roleMapping in _Context.NBA_Role
                //                 on user.NBA_Role  equals roleMapping.ROLE_ID
                //                 join role in _Context.NBA_Role
                //                 on roleMapping.RoleId equals role.ROLE_ID
                //                 where user.Username == username
                //                 select role.RoleName).ToArray();


                //var userRoles = (from user in _Context.NBA_SYS_Users
                //                 where user.email == username
                //                 select user.surname
                //                 );

                ////var userRoles = _Context.NBA_SYS_Users.Where(x => x.email == username).Select(n => n.ROLE_ID );
                var userRoles = _Context.NBA_SYS_Users.Where(x => x.email == username).Select(n => n.ROLE_ID).Take(1).SingleOrDefault();
                ;

                return userRoles.ToString();
            }
        }
        public string GetuserID(string username)
        {
            using (nlbdataEntities _Context = new nlbdataEntities())
            {
                //var userRoles = (from user in _Context.NBA_SYS_Users
                //                 join roleMapping in _Context.NBA_Role
                //                 on user.NBA_Role  equals roleMapping.ROLE_ID
                //                 join role in _Context.NBA_Role
                //                 on roleMapping.RoleId equals role.ROLE_ID
                //                 where user.Username == username
                //                 select role.RoleName).ToArray();


                //var userRoles = (from user in _Context.NBA_SYS_Users
                //                 where user.email == username
                //                 select user.surname
                //                 );

                ////var userRoles = _Context.NBA_SYS_Users.Where(x => x.email == username).Select(n => n.ROLE_ID );
                var userRoles = _Context.NBA_SYS_Users.Where(x => x.email == username).Select(n => n.SYS_USER_ID).Take(1).SingleOrDefault();
                ;

                return userRoles.ToString();
            }
        }
        //Login POST

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Login(UserLogin login, string ReturnUrl = "")

        {
           


           
           

            if (Session["uname"] != null)
            {

                return RedirectToAction("index", "home", new { email = Session["uname"].ToString()});
            }

           

            string message = "";

            using (nlbdataEntities dc = new nlbdataEntities())

            {

                var v = dc.NBA_SYS_Users.Where(a => a.email == login.email).FirstOrDefault();

                if (v != null)

                {

                    if (!v.sys_IsEmailVerified)

                    {

                        ViewBag.Message = "Please verify your email first";

                        return View();

                    }



                     

                    if (string.Compare(Crypto.Hash(login.password), v.password) == 0)

                    {
                        Session["UseriD"]=GetuserID(login.email);



                        int timeout = login.RememberMe ? 525600 : 20; // 525600 min = 1 year

                        var ticket = new FormsAuthenticationTicket(login.email, login.RememberMe, timeout);

                        string encrypted = FormsAuthentication.Encrypt(ticket);

                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);

                        cookie.Expires = DateTime.Now.AddMinutes(timeout);

                        cookie.HttpOnly = true;

                        Response.Cookies.Add(cookie);





                        if (Url.IsLocalUrl(ReturnUrl))

                        {

                            return Redirect(ReturnUrl);


                        }

                        // if (dc.NBA_Role.ToString()=="PGT")
                        string role=GetRolesForUser(login.email);
                            if (role == "4")
                            {
                            Session["uname"] = login.email;


                            return RedirectToAction("Index", "NBA_ManageBeneficiaries");
                           // return ("ManageGirls");
                        }


                       else
                        {

                          
                                return RedirectToAction("Index", "Home");

                            }
                        

                    }

                    else

                    {

                        ViewBag.message = "Invalid credential provided";

                    }

                }

                else

                {

                    ViewBag.message = "Invalid credential provided";

                }

            }

            ViewBag.Message = message;

            return View();

        }

        //[HttpGet]
        //public ActionResult Save(int id)
        //{
        //    using (nlbdataEntities dc = new nlbdataEntities())
        //    {
        //        var v = dc.NBA_Area.Where(a => a.PRID == id).FirstOrDefault();
        //        return View(v);
        //    }
        //}






        //Logout

        [Authorize]

        [HttpPost]

        public ActionResult Logout()

        {

            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "User");

        }





        [NonAction]

        public bool IsEmailExist(string emailID)

        {

            using (nlbdataEntities dc = new nlbdataEntities())

            {

                var v = dc.NBA_SYS_Users.Where(a => a.email == emailID).FirstOrDefault();

                return v != null;

            }

        }



        [NonAction]

        public void SendVerificationLinkEmail(string emailID, string activationCode)

        {

            var verifyUrl = "/User/VerifyAccount/" + activationCode;

            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);



            var fromEmail = new MailAddress("mphophokontsi@gmail.com", "Nacosa");

            var toEmail = new MailAddress(emailID);

            var fromEmailPassword = "H@ppysam"; // Replace with actual password

            string subject = "Your account is successfully created!";



            string body = "<br/><br/>We are excited to tell you that your account is" +

                " successfully created. Please click on the below link to verify your account" +

                " <br/><br/><a href='" + link + "'>" + link + "</a> ";





            var smtp = new SmtpClient

            {

                Host = "smtp.gmail.com",

                Port = 587,

                EnableSsl = true,

                DeliveryMethod = SmtpDeliveryMethod.Network,

                UseDefaultCredentials = false,

                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)







            };





            using (var message = new MailMessage(fromEmail, toEmail)

            {

                Subject = subject,

                Body = body,

                IsBodyHtml = true

            })

                smtp.Send(message);

        }
    }
}