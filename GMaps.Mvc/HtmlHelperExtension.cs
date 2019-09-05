// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace GMaps.Mvc
{
    using System;
    using System.Web;
    using System.Web.Mvc;

    public static class HtmlHelperExtension
    {
        public static MapBuilder GoogleMap(this HtmlHelper helper)
        {
            if (helper == null)
            {
                throw new ArgumentNullException(nameof(helper));
            }

            return new MapBuilder(helper.ViewContext);
        }

        public static MvcHtmlString LoadGMapsScripts(this HtmlHelper helper)
        {
            // Instantiate a UrlHelper
            var urlHelper = new System.Web.Mvc.UrlHelper(helper.ViewContext.RequestContext);
            var url = urlHelper.Action("EmbeddedScripts", "GMapsMvcApi");
            // Create tag builder
            var builder = new TagBuilder("script");
            builder.MergeAttribute("src", url);
            builder.MergeAttribute("type", "text/javascript");
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }
    }
}