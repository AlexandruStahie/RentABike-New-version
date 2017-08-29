﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace RentABike
{
    public abstract class AppViewPage<TModel> : WebViewPage<TModel>
    {
        protected UserApp CurrentUser
        {
            get
            {
                return new UserApp(this.User as ClaimsPrincipal);
            }
        }
    }

    public abstract class AppViewPage : AppViewPage<dynamic>
    {
    }
}