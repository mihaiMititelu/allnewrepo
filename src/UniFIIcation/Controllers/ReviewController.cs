using Microsoft.AspNetCore.Mvc;
using System;
using UniFIIcation.Models;

namespace UniFIIcation.Controllers
{
    public class ReviewController : Controller
    {
        public ActionResult Review(UserReview model)
        {
            var name = model.Name;
            var email = model.Email;
            var comment = model.Comment;

            ReviewModels table = new ReviewModels();
            table.Name = name;
            table.Email = email;
            table.Comment = comment;
            table.DateTime = DateTime.Now;

            return View();
        }
    }
}
