﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.Models.Objects;

namespace ZennoPosterProjectAccountRegister.Letu
{
    internal static class LetuTabClickDataBuilder
    {
        /// <summary>
        /// Call js function for input phone number
        /// </summary>
        /// <returns></returns>
        public static StandardTabElementsModel ClickStartRegister()
        {
            string xPathCloseActiveSessions = "//div[@class='header-v3__content-item']//a[@data-at-authorization-modal-button]";
            StandardTabElementsModel standardTabElements = new StandardTabElementsModel(xPathCloseActiveSessions);
            return standardTabElements;
        }
    }
}
