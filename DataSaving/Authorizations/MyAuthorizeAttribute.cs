using Microsoft.AspNetCore.Authorization;

namespace DataSaving.Authorizations;


//to avoid implementing Authentication
//tried to implement costum AuthoriseAtttribute
//to use in HTTP actions 
//not fully understand it 
public class MyAuthorizeAttribute : AuthorizeAttribute
{
    //protected virtual bool AuthorizeCore(System.Web.HttpContextBase httpContext);


    //protected override bool AuthorizeCore(HttpContextBase httpContext)
    //{
    //    var authorized = base.AuthorizeCore(httpContext);
    //    if (!authorized)
    //    {
    //        return false;
    //    }

    //    var rd = httpContext.Request.RequestContext.RouteData;

    //    var id = rd.Values["id"];
    //    var userName = httpContext.User.Identity.Name;

    //    Submission submission = unit.SubmissionRepository.GetByID(id);
    //    User user = unit.UserRepository.GetByUsername(userName);

    //    return submission.UserID == user.UserID;
    //}
}