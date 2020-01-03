using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web_NoiThat.Models;

namespace Web_NoiThat.Controllers
{
    public class HomeController : Controller
    {
        Data db = new Data();
        Products Products = new Products();

        //Home controller
        public async Task<ActionResult> Index()
        {
            //Get data from database
            var item = from itemed in Products.Product
                       select itemed;
            return View(item.ToList());
        }
        
        [NonAction]
        public async Task<Guid> ActivationCode()
        {
            return Guid.NewGuid();
        }

        // POST: Đăng ký user
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registation([Bind(Exclude = "IsEmailVerified,ActivationCode")] User user)
        {
            if (ModelState.IsValid)
            {
                #region //Check Email Exist
                var isExist = await IsEmailExist(user.EmailID.Trim());
                #endregion
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");   //Thêm thông báo validate
                    return PartialView("Index");
                }
                else
                {
                    #region Create ActivationCode
                    user.ActivationCode = await ActivationCode();
                    #endregion

                    #region Hash Password
                    user.Password = Crypto.Hash(user.Password);
                    #endregion
                    var x = user.Password;
                    user.IsEmailVerified = false;

                    #region Save to database
                    try
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException dbEx)
                    {
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                            }
                        }
                    }



                    #region Send Email To User
                    SenVerificationMail(user.EmailID, user.ActivationCode.ToString());
                    ViewBag.message = "Registation successfully. Account activation link" +
                        "has been sent to your email id:" + user.EmailID;
                    ViewBag.status = true;
                    #endregion


                    #endregion
                }
            }
            return View("ConfirmEmail");
        }


        [NonAction]
        public async Task<bool> IsEmailExist(string Emailid)
        {
            var k = db.Users.Where(a => a.EmailID == Emailid).FirstOrDefault<User>();
            return k != null;
        }

        [NonAction]
        public async Task SenVerificationMail(string emailID, string activationCode)
        {
            var verifyUrl = "/User/VerifyAccount/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("phamhoaihung2408@student.tdmu.edu.vn", "HungPham");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "hoaihung99";

            string subject = "Your account is successfully created!!!";
            string body = "Goood luck when you createed. Please click on the below link to verify your" +
                "account" + "<br><a href='" + link + "'> Click here !!!</a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            MailMessage message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            smtp.Send(message);

        }
        //Post login

        [Authorize(Roles ="Admin")]
        [AllowAnonymous]
        [HttpPost,ActionName("Login")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                var pass = Crypto.Hash(user.Password);
                var checkValue = db.Users.SingleOrDefault(a => a.Password.Equals(pass) && a.EmailID.Equals(user.Email));
                //return Json(checkValue, JsonRequestBehavior.AllowGet);
                if (checkValue != null)
                {
                    ViewBag.User = user.Email;
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    Session["idUser"] = checkValue.UserID;

                    //Set cookies
                    Session["modal"] = "true";

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("PasswordError", "Password is wrong");   //Thêm thông báo validate

                }
            }
            return View("Index");
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("modal");
            Response.Cookies["modalShown"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Index","Home");
        }


        
    }

}