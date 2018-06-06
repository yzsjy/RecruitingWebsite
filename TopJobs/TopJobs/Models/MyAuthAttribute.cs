using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TopJobs.Models;

namespace AuthTest.Models
{
    public class MyAuthAttribute : AuthorizeAttribute
    {
        // 只需重载此方法，模拟自定义的角色授权机制  
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var currentUserId = httpContext.User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(httpContext.User.Identity.GetUserId());
            string currentRole = GetRole(currentUser.VisitRole);
            if (Roles.Contains(currentRole))
                return true;
            return base.AuthorizeCore(httpContext);
        }

        // 返回用户对应的角色， 在实际中， 可以从SQL数据库中读取用户的角色信息  
        private string GetRole(string name)
        {
            switch (name)
            {
                case "Jobseeker": return "Jobseeker";
                case "Employer": return "Employer";
                case "Administrator": return "Administrator";
                default: return "Fool";
            }
        }
    }

}