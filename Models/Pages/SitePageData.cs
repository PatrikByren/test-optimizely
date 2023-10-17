﻿using static Nackademin23.Globals;
using System.ComponentModel.DataAnnotations;
using Nackademin23.Business.Extensions;

namespace Nackademin23.Models.Pages
{
    public abstract class SitePageData : PageData
    {
        [Display(GroupName = GroupNames.MetaData, Order = 100)]
        [CultureSpecific]
        public virtual string MetaTitle
        {
            get
            {
                var metaTitle = this.GetPropertyValue(p => p.MetaTitle);

                return metaTitle.IsNotNullOrWhiteSpace() ? metaTitle : PageName;
            }

            set => this.SetPropertyValue(p => p.MetaTitle, value);
        }
    }
}
