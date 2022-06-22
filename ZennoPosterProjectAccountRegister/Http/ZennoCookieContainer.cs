﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel;

namespace ZennoPosterProjectAccountRegister.Http
{
    class ZennoCookieContainer : CookieContainer
    {
        public ZennoCookieContainer(ICookieContainer cookieContainer) : base(200)
        {
            CookieCollection cookieCollection = ConvertToCookieCollection(cookieContainer);
            Add(cookieCollection);
        }

        private CookieCollection ConvertToCookieCollection(ICookieContainer cookieContainer)
        {
            CookieCollection cookieCollection = new CookieCollection();
            foreach(string domain in cookieContainer.Domains)
            {
                var domainCookies = cookieContainer.Get(domain);
                CookieCollection domainCookieCollection = GetDomainCollectionCookie(domainCookies);
                cookieCollection.Add(domainCookieCollection);
            }
            return cookieCollection;
        }

        private CookieCollection GetDomainCollectionCookie(IEnumerable<ICookieItem> domainCookies)
        {
            CookieCollection domainCookieCollection = new CookieCollection();
            foreach(var domainCookie in domainCookies)
            {
                Cookie cookie = new Cookie(
                    domainCookie.Name,
                    domainCookie.Value,
                    domainCookie.Path,
                    domainCookie.Host
                    );
                domainCookieCollection.Add(cookie);
            }
            return domainCookieCollection;
        }
    }
}