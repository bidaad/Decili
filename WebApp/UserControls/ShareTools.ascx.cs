using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decili.UserControls
{
    public partial class ShareTools : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CurUrl = Request.Url.AbsoluteUri;

            hplBlogger.NavigateUrl = "http://www.blogger.com/blog_this.pyra?t&u=" + CurUrl;
            hplGoogleBookmark.NavigateUrl = "https://www.google.com/bookmarks/mark?op=edit&bkmk=" + CurUrl;
            hplGoolgePlus.NavigateUrl = "https://plus.google.com/share?url=" + CurUrl;
            hplLinkedIn.NavigateUrl = "http://www.linkedin.com/shareArticle?mini=true&url=" + CurUrl;
            hplFriendFeed.NavigateUrl = "http://friendfeed.com/share?url=" + CurUrl;
            hplInstaPaper.NavigateUrl = "http://www.instapaper.com/hello2?url=" + CurUrl;
            hpldelicious.NavigateUrl = "https://delicious.com/login?lo_action=save&next=" + CurUrl;
            hplTwitter.NavigateUrl = "http://twitter.com/intent/tweet?url=" + CurUrl + "&source=sharethiscom&related=sharethis&via=sharethis";
            hplFaceBook.NavigateUrl = "http://www.facebook.com/sharer.php?u=" + CurUrl;
        }
    }
}