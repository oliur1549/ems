﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;

namespace EMS.Web.Areas.Admin.Models
{
    public abstract class AdminBaseModel
    {
        public MenuModel MenuModel { get; set; }
        public ResponseModel Response
        {
            get
            {
               // if (_httpContextAccessor.HttpContext.Session.IsAvailable
                  //  && _httpContextAccessor.HttpContext.Session.Keys.Contains(nameof(Response)))
                {
                   // var response = _httpContextAccessor.HttpContext.Session.Get<ResponseModel>(nameof(Response));
                    //_httpContextAccessor.HttpContext.Session.Remove(nameof(Response));
                    
                    //return response;
                }
               // else
                    return null;
            }
            set
            {
              //  _httpContextAccessor.HttpContext.Session.Set(nameof(Response),
                //    value);
            }
        }

        protected IHttpContextAccessor _httpContextAccessor;
        public AdminBaseModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            //SetupMenu();
        }

        public AdminBaseModel()
        {
           
        }

   
    }
}
