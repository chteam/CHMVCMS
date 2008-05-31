using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YouXiArticle.Controllers
{
	public class BaseController : DataController
    {
        string _SubDomain = null;

        public string SubDomain
        {
            get
            {
                if (_SubDomain == null)
                {
                    _SubDomain = this.Request.Url.Host.Split('.')[0].ToLower();
                }
                return _SubDomain;
            }
        }
    }
}
