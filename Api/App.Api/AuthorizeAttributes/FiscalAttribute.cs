using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace App.Api.AuthorizeAttributes
{
    public class FiscalAttribute:AuthorizeAttribute
    {

        public FiscalAttribute()
        {

        }
        //
        // Summary:
        //     Calls when an action is being authorized.
        //
        // Parameters:
        //   actionContext:
        //     The context.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     The context parameter is null.
        public override void OnAuthorization(HttpActionContext actionContext) {

            string deb = "asd";



        }
        //
        // Summary:
        //     Processes requests that fail authorization.
        //
        // Parameters:
        //   actionContext:
        //     The context.
        protected virtual void HandleUnauthorizedRequest(HttpActionContext actionContext) {


            string teste = "teste";
        }
        //
        // Summary:
        //     Indicates whether the specified control is authorized.
        //
        // Parameters:
        //   actionContext:
        //     The context.
        //
        // Returns:
        //     true if the control is authorized; otherwise, false.
        protected virtual bool IsAuthorized(HttpActionContext actionContext) {

            return false;
            return true;
        }
    }

}
