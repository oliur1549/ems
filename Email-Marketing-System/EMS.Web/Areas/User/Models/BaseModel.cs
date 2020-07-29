using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using EMS.Framework;

namespace EMS.Web.Areas.User.Models
{
    public abstract class UserBaseModel
    {
        public MenuModel MenuModel { get; set; }
        public ResponseModel Response
        {
            get
            {
                if (_httpContextAccessor.HttpContext.Session.IsAvailable &&
                    _httpContextAccessor.HttpContext.Session.Keys.Contains(nameof(Response)))
                {
                    var response = _httpContextAccessor.HttpContext.Session.Get<ResponseModel>(nameof(Response));
                    _httpContextAccessor.HttpContext.Session.Remove(nameof(Response));

                    return response;
                }
                else
                    return null;
            }
            set
            {
                _httpContextAccessor.HttpContext.Session.Set(nameof(Response), value);
            }
        }

        protected IHttpContextAccessor _httpContextAccessor;
        public UserBaseModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            SetupMenu();
        }

        public UserBaseModel()
        {
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
            SetupMenu();
        }
        private void SetupMenu()
        {
            MenuModel = new MenuModel
            {
                MenuItems = new List<MenuItem>
                {
                    {
                        new MenuItem
                        {
                            Title = "Member Configurations",
                            Childs = new List<MenuChildItem>
                            {
                                new MenuChildItem{ Title = "View Group", Url = "/User/Group/Index" },
                                new MenuChildItem{ Title = "Create Group", Url ="/User/Group/CreateGroup"},
                                new MenuChildItem{ Title = "View Smtp Configuration", Url = "/User/Smtp/Index" },
                                new MenuChildItem{ Title = "Create Smtp Configuration", Url ="/User/Smtp/CreateSmtp"}
                            }
                        }
                    },
                    {
                        new MenuItem
                        {
                            Title = "Campaign Configurations",
                            Childs = new List<MenuChildItem>
                            {
                                new MenuChildItem{ Title = "View Campaign", Url = "/User/Campaign/Index" },
                                new MenuChildItem{ Title = "Create Campaign", Url ="/User/Campaign/AddCampaign"}
                            }
                        }
                    }
                }
            };
        }


    }
}
