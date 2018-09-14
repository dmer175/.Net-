﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Model;
using System.Text;
using System.IO;

namespace Web
{
    /// <summary>
    /// Index 的摘要说明
    /// </summary>
    public class Index : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            users_service userService = new users_service();
            List<Users_model> list = userService.GetList();
            StringBuilder sbu = new StringBuilder();
            foreach (var users in list)
            {
                sbu.AppendFormat("<tr><th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th><th>{6}</th><th>{7}</th><th>{8}</th><th>{9}</th><th><a href='DeleteUser.ashx?id={0}' class='del'>删除</a></th><th><a href='Update.ashx?id={0}'>编辑</a></th></tr>",
                    users.Id, users.LoginPwd, users.NickName, users.Sex, users.Age, users.FaceId, users.FaceId, users.Friend, users.Name, users.StarId, users.BloodId);
            }
            string filePath = context.Request.MapPath("Index.html");
            string fileContent = File.ReadAllText(filePath);
            fileContent = fileContent.Replace("$tbody", sbu.ToString());
            context.Response.Write(fileContent);
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