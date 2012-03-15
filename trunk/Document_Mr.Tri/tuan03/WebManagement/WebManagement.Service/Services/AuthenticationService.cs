
namespace WebManagement.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel.DomainServices.Server;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server.ApplicationServices;
    using System.Web;
    using System.Web.Security;
    using AuthenticationLib;

    [EnableClientAccess]
    public class AuthenticationService : LinqToEntitiesDomainService<Portal_VanLangEntities>, IAuthentication<LoginUser>
    {
        private AuthController _controllerAuth;
        public AuthController ControllerAuth
        {
            get
            {
                if (_controllerAuth == null)
                    _controllerAuth = new AuthController();
                return _controllerAuth;
            }
        }

        private static readonly LoginUser DefaultLoginUser = new LoginUser
        {
            Name = String.Empty,
            Roles = new List<string>()
        };

        [Query(IsComposable = false)]
        public LoginUser GetUser()
        {
            if ((ServiceContext != null) &&
                (ServiceContext.User != null) &&
                ServiceContext.User.Identity.IsAuthenticated)
            {
                return GetUserByName(ServiceContext.User.Identity.Name);
            }
            return DefaultLoginUser;
        }

        private LoginUser GetUserByName(string userName)
        {
            AuthenticationLib.AuthService.Login log = ControllerAuth.GetUser(userName);
            return new LoginUser
            {
                UserID = log.UserID,
                Name = log.UserName,
                LastName = log.LastName,
                FirstName = log.FirstName,
                Email = log.Email,
                UserType = log.UserType,
                Roles = log.ListOjectKey
            };
        }

        public LoginUser Login(string userName, string password, bool isPersistent, string customData)
        {
            try
            {
                AuthenticationLib.AuthService.Login log = ControllerAuth.UserLogin(userName, password);
                if (log.UserID != -1)
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        /* version */ 1,
                        userName,
                        DateTime.Now, DateTime.Now.AddDays(1),
                        isPersistent,
                        string.Empty,
                        FormsAuthentication.FormsCookiePath);

                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                    if (ticket.IsPersistent)
                    {
                        authCookie.Expires = ticket.Expiration;
                    }

                    HttpContextBase httpContext = (HttpContextBase)ServiceContext.GetService(typeof(HttpContextBase));
                    httpContext.Response.Cookies.Add(authCookie);

                    return new LoginUser
                    {
                        UserID = log.UserID,
                        Name = log.UserName,
                        LastName = log.LastName,
                        FirstName = log.FirstName,
                        Email = log.Email,
                        UserType = log.UserType,
                        Roles = log.ListOjectKey
                    };
                }
                return DefaultLoginUser;
            }
            catch (Exception ex)
            {
                Exception actualException = ex;
                while (actualException.InnerException != null)
                {
                    actualException = actualException.InnerException;
                }
                throw actualException;
            }
        }

        public LoginUser Logout()
        {
            FormsAuthentication.SignOut();
            return DefaultLoginUser;
        }

        [Update]
        public void UpdateUser(LoginUser user)
        {

        }
    }
}


