using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Syncfusion.EJ2.Navigations;

namespace EJ2MVCSampleBrowser.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            var replyTemplate = "<input type='text' tabindex='1' id='replyAllList' />";
            var movetoTemplate = "<input type='text' tabindex='1' id='moveToList' />";
            var categoryTemplate = "<input type='text' tabindex='1' id='categoryList' />";
            var moreTemplate = "<input type='tex' tabindex='1' id='moreList' />";
            var ele = "<div class='search-div1' style= 'width:90%' >" +
                    "<div style='height: 30px'>" +
                    "<input type='text' id='txtSearch1' tabindex='1' style='height: 30px' />" +
                    "</div>" +
                    "</div>";
            var moreToolBarTemplate = "<input type='text' tabindex='1' id='moreList1' />";
            List<ToolbarItem> items = new List<ToolbarItem>();
            items.Add(new ToolbarItem { PrefixIcon = "ej-icon-New tb-icons", Text = "New", TooltipText = "Write a new message", CssClass = "tb-item-new-mail" });
            items.Add(new ToolbarItem { PrefixIcon = "ej-icon-Mark-as-read tb-icons", Text = "Mark all as read", TooltipText = "Mark all as read", CssClass = "tb-item-mark-read" });
            items.Add(new ToolbarItem { PrefixIcon = "ej-icon-Reply-All tb-icons", Template = replyTemplate, TooltipText = "Reply All", CssClass = "tb-item-Selected tb-item-replyAll" });
            items.Add(new ToolbarItem { PrefixIcon = "ej-icon-Delete tb-icons", Text = "Delete", TooltipText = "Delete", CssClass = "tb-item-Selected" });
            items.Add(new ToolbarItem { Text = "Junk", TooltipText = "Mark the sender as unsafe and delete the message", CssClass = "tb-item-Selected" });
            items.Add(new ToolbarItem { Template = movetoTemplate, TooltipText = "Move To", CssClass = "tb-item-Selected" });
            items.Add(new ToolbarItem { Template = categoryTemplate, TooltipText = "Add Categories to message", CssClass = "tb-item-Selected" });
            items.Add(new ToolbarItem { Template = moreTemplate, TooltipText = "More actions", CssClass = "tb-item-more tb-item-Selected" });
            items.Add(new ToolbarItem { PrefixIcon = "ej-icon-Copy tb-icons", TooltipText = "Open in a separate window", CssClass = "tb-item-Selected", Align =  ItemAlign.Right  });
            ViewBag.tbItems = items;

            List<ToolbarItem> tbitems = new List<ToolbarItem>();
            tbitems.Add(new ToolbarItem { PrefixIcon = "ej-icon-Menu tb-icons", CssClass = "tb-item-menu tb-item-front" });
            tbitems.Add(new ToolbarItem { PrefixIcon = "ej-icon-Back", CssClass = "tb-item-back-icon tb-item-back" });
            tbitems.Add(new ToolbarItem { Text = "Inbox", CssClass = "tb-item-inbox tb-item-front" });
            tbitems.Add(new ToolbarItem { Text = "Compose", CssClass = "tb-item-inbox tb-item-back tb-item-newmail-option" });
            tbitems.Add(new ToolbarItem { Template = ele, CssClass = "tb-item-search-option", Align =  ItemAlign.Center });
            tbitems.Add(new ToolbarItem { PrefixIcon = "ej-icon-Close", TooltipText = "Clear", Align =  ItemAlign.Right , CssClass = "tb-item-search-option" });
            tbitems.Add(new ToolbarItem { PrefixIcon = "ej-icon-Search", TooltipText = "Search Mail", Align =  ItemAlign.Right , CssClass = "tb-item-front" });
            tbitems.Add(new ToolbarItem { PrefixIcon = "ej-icon-Create-New", TooltipText = "Write a new message", Align =  ItemAlign.Right , CssClass = "tb-item-front" });
            tbitems.Add(new ToolbarItem { PrefixIcon = "ej-icon-Send", TooltipText = "Send", Align =  ItemAlign.Right , CssClass = "tb-item-back tb-item-newmail-option" });
            tbitems.Add(new ToolbarItem { PrefixIcon = "ej-icon-Attach", TooltipText = "Attach", Align =  ItemAlign.Right , CssClass = "tb-item-back  tb-item-newmail-option" });
            tbitems.Add(new ToolbarItem { PrefixIcon = "ej-icon-Delete", TooltipText = "Delete", Align =  ItemAlign.Right , CssClass = "tb-item-back" });
            tbitems.Add(new ToolbarItem { PrefixIcon = "ej-icon-Reply-All", TooltipText = "Reply All", Align =  ItemAlign.Right , CssClass = "tb-item-back" });
            tbitems.Add(new ToolbarItem { Template = moreToolBarTemplate, TooltipText = "More actions", CssClass = "tb-item-more tb-item-back", Align =  ItemAlign.Right  });
            ViewBag.tbmItems = tbitems;

            return PartialView("home");
        }

        public ActionResult Newmail()
        {
            var moreNewMailTemplate = "<input type='text' tabindex='1' id='moreList2' />";
            List<ToolbarItem> newMailItems = new List<ToolbarItem>();
            newMailItems.Add(new ToolbarItem { PrefixIcon = "ej-icon-Send tb-icons", TooltipText = "Send", Text = "Send" });
            newMailItems.Add(new ToolbarItem { PrefixIcon = "ej-icon-Attach tb-icons", Text = "Attach", TooltipText = "Attach" });
            newMailItems.Add(new ToolbarItem { Text= "Discard"});
            newMailItems.Add(new ToolbarItem { Template = moreNewMailTemplate, TooltipText = "More actions", CssClass = "tb-item-more tb-item-more-mail" });
            newMailItems.Add(new ToolbarItem { PrefixIcon = "ej-icon-Copy tb-icons", TooltipText = "Edit in a separate window", CssClass = "tb-item-window-mail", Align =  ItemAlign.Right  });
            newMailItems.Add(new ToolbarItem { PrefixIcon = "ej-icon-Close tb-icons", TooltipText = "Close", CssClass = "tb-item-back-mail", Align =  ItemAlign.Right  });
            ViewBag.tbNewMailItems = newMailItems;

            List<ToolbarItem> toolbarItem = new List<ToolbarItem>();
            toolbarItem.Add(new ToolbarItem { PrefixIcon = "ej-icon-Font tb-icons", TooltipText = "Font" });
            toolbarItem.Add(new ToolbarItem { PrefixIcon = "ej-icon-Font-Size path2 tb-icons", TooltipText = "Font Size" });
            toolbarItem.Add(new ToolbarItem { PrefixIcon = "ej-icon-Bold tb-icons", TooltipText = "Bold" });
            toolbarItem.Add(new ToolbarItem { PrefixIcon = "ej-icon-Italic tb-icons", TooltipText = "Italic" });
            toolbarItem.Add(new ToolbarItem { PrefixIcon = "ej-icon-Underlined tb-icons", TooltipText = "Underline" });
            toolbarItem.Add(new ToolbarItem { PrefixIcon = "ej-icon-Highlight tb-icons", TooltipText = "Highlight" });
            toolbarItem.Add(new ToolbarItem { PrefixIcon = "ej-icon-Font-Color-Icon tb-icons", TooltipText = "Font color" });
            toolbarItem.Add(new ToolbarItem { PrefixIcon = "ej-icon-Bullets tb-icons", TooltipText = "Bullets" });
            toolbarItem.Add(new ToolbarItem { PrefixIcon = "ej-icon-Numbering tb-icons", TooltipText = "Numbering" });
            toolbarItem.Add(new ToolbarItem { PrefixIcon = "ej-icon-Decr-Indent tb-icons", TooltipText = "Decrease Indent" });
            toolbarItem.Add(new ToolbarItem { PrefixIcon = "ej-icon-Incr-Indent tb-icons", TooltipText = "Increase Indent" });
            toolbarItem.Add(new ToolbarItem { PrefixIcon = "ej-icon-Left-aligned tb-icons", TooltipText = "Decrease Indent" });
            toolbarItem.Add(new ToolbarItem { PrefixIcon = "ej-icon-Centre-aligned tb-icons", TooltipText = "Increase Indent" });
            toolbarItem.Add(new ToolbarItem { PrefixIcon = "ej-icon-Right -aligned tb-icons", TooltipText = "Decrease Indent" });
            toolbarItem.Add(new ToolbarItem { PrefixIcon = "ej-icon-Hyperlink tb-icons", TooltipText = "Hyperlink" });
            ViewBag.toolbarItems = toolbarItem;
            return PartialView("newmail");
        }

        public ActionResult Readingpane()
        {    
          return PartialView("readingpane");
        }
    }
}