using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Forum
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            routes.MapPageRoute("ForumTitle",
               "Forum/Threads/{id}",
               "~/Forum/Thread.aspx");

            routes.MapPageRoute("ForumThreadEdit",
               "Forum/Edit/Threads/{id}",
               "~/Forum/Edit/ThreadEdit.aspx");

            routes.MapPageRoute("ForumAnswerEdit",
               "Forum/Edit/Answers/{id}",
               "~/Forum/Edit/AnswerEdit.aspx", true);

            routes.MapPageRoute("ForumCommentEdit",
            "Forum/Edit/Comments/{id}",
            "~/Forum/Edit/CommentEdit.aspx");
        }

           

    }
}
