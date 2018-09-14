﻿using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class User_dao
    {
        public List<User_Model> GetList()
        {
            string sql = "select * from users";
            DataTable da = DbHelperSql.GetTable(sql, CommandType.Text);
            List<User_Model> list = new List<User_Model>();
            if (da.Rows.Count>0)
            {
                list = new List<User_Model>();
                User_Model usermodel = null;
                foreach (DataRow row in da.Rows)
                {
                    usermodel = new User_Model();
                    LoadEntity(row, usermodel);
                    list.Add(usermodel);
                }
            }
            return list;
        }

        private void LoadEntity(DataRow row, User_Model userModel)
        {
            userModel.Id = Convert.ToInt32(row["Id"]);
            userModel.LoginPwd = row["LoginPwd"] != DBNull.Value ? row["LoginPwd"].ToString() : string.Empty;
            userModel.NickName = row["NickName"] != DBNull.Value ? row["NickName"].ToString() : string.Empty;
            userModel.Sex = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : string.Empty;
            userModel.Age = Convert.ToInt32(row["Age"]);
            userModel.FaceId = Convert.ToInt32(row["FaceId"]);
            userModel.Friend = Convert.ToInt32(row["FriendShipPolicyId"]);
            userModel.Name = row["Name"] != DBNull.Value ? row["Name"].ToString() : string.Empty;
            userModel.StarId = Convert.ToInt32(row["StarId"]);
            userModel.BloodId = Convert.ToInt32(row["BloodTypeId"]);
        }

        public int AddUser(User_Model usermodel)
        {
            string sql = "insert into users values(@pwd,@nick,@sex,@age,@face,@friend,@name,@star,@blood)";
            SqlParameter[] pars={
                                    new SqlParameter("@pwd",SqlDbType.VarChar,20),
            new SqlParameter("@nick",SqlDbType.VarChar,20),
            new SqlParameter("@sex",SqlDbType.Char,2),
            new SqlParameter("@age",SqlDbType.Int),
            new SqlParameter("@face",SqlDbType.Int),
            new SqlParameter("@friend",SqlDbType.Int),
            new SqlParameter("@name",SqlDbType.VarChar,20),
            new SqlParameter("@star",SqlDbType.Int),
            new SqlParameter("@blood",SqlDbType.Int)
                                };
            pars[0].Value = usermodel.LoginPwd;
            pars[1].Value = usermodel.NickName;
            pars[2].Value = usermodel.Sex;
            pars[3].Value = usermodel.Age;
            pars[4].Value = usermodel.FaceId;
            pars[5].Value = usermodel.Friend;
            pars[6].Value = usermodel.Name;
            pars[7].Value = usermodel.StarId;
            pars[8].Value = usermodel.BloodId;
            return DbHelperSql.ExecuteNonQuery(sql, CommandType.Text, pars);
        }

        public User_Model GetUser(int id)
        {
            string sql = "select * from users where id=@id";
            User_Model usermodel = new User_Model();
            DataTable da = DbHelperSql.GetTable(sql, CommandType.Text,new SqlParameter("@id",id));
            if (da.Rows.Count>0)
            {
                usermodel = new User_Model();
                LoadEntity(da.Rows[0], usermodel);
            }
            return usermodel;
        }

        public int Update(User_Model usermodel)
        {
            string sql = "update users set loginpwd=@pwd,NickName=@nick,sex=@sex,age=@age,faceid=@face,FriendShipPolicyId=@friend,Name=@name,StarId=@star,BloodTypeId=@blood where id=@id";
            SqlParameter[] pars ={
                                    new SqlParameter("@pwd",SqlDbType.VarChar,20),
            new SqlParameter("@nick",SqlDbType.VarChar,20),
            new SqlParameter("@sex",SqlDbType.Char,2),
            new SqlParameter("@age",SqlDbType.Int),
            new SqlParameter("@face",SqlDbType.Int),
            new SqlParameter("@friend",SqlDbType.Int),
            new SqlParameter("@name",SqlDbType.VarChar,20),
            new SqlParameter("@star",SqlDbType.Int),
            new SqlParameter("@blood",SqlDbType.Int),
            new SqlParameter("@id",SqlDbType.Int)
                              };
            pars[0].Value = usermodel.LoginPwd;
            pars[1].Value = usermodel.NickName;
            pars[2].Value = usermodel.Sex;
            pars[3].Value = usermodel.Age;
            pars[4].Value = usermodel.FaceId;
            pars[5].Value = usermodel.Friend;
            pars[6].Value = usermodel.Name;
            pars[7].Value = usermodel.StarId;
            pars[8].Value = usermodel.BloodId;
            pars[9].Value = usermodel.Id;
            return DbHelperSql.ExecuteNonQuery(sql,CommandType.Text);
        }

        public int DeleteUser(int id)
        {
            string sql = "delete from users where id=@id";
            return DbHelperSql.ExecuteNonQuery(sql, CommandType.Text, new SqlParameter("@id", id));
        }
    }
}
