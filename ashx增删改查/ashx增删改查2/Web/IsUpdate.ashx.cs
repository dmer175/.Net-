﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    /// <summary>
    /// IsUpdate 的摘要说明
    /// </summary>
    public class IsUpdate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            BLL.users_service userservice = new BLL.users_service();
            int id = Convert.ToInt32(context.Request.Form["hiddenId"]);
            Model.Users_model usermodel = new Model.Users_model();
            if (usermodel!=null)
            {
                 usermodel.LoginPwd = context.Request.Form["txtpwd"];
                usermodel.NickName = context.Request.Form["txtnick"];
                usermodel.Sex = context.Request.Form["txtsex"];
                usermodel.Age = Convert.ToInt32(context.Request.Form["txtage"]);
                usermodel.FaceId = Convert.ToInt32(context.Request.Form["txtface"]);
                usermodel.Friend = Convert.ToInt32(context.Request.Form["txtfriend"]);
                usermodel.Name = context.Request.Form["txtname"];
                usermodel.StarId = Convert.ToInt32(context.Request.Form["txtstar"]);
                usermodel.BloodId = Convert.ToInt32(context.Request.Form["txtblood"]);
                usermodel.Id = id;
            }
            if (userservice.UpdateUser(usermodel))
            {
                context.Response.Redirect("Index.ashx");
            }
            else
            {
                context.Response.Redirect("Error.html");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}