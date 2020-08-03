using HostelData.Core.Data.Ado.Net;
using HostelData.DataAccess.HostelDataAdaptation;
using HostelData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelData.Business.HostelDataBO
{
    public class UserBO : IMainBO<User>
    {
        HostelDataHelper helper = new HostelDataHelper();
        public bool Delete(int id)
        {
            try
            {
                string cmdText = "update Users set IsActive='0', IsDeleted='1' where Id=@Id";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Id",id),
                    new SqlParameter("@IsActive",false),
                    new SqlParameter("@IsDeleted",true)
                };
                return helper.SetData(cmdText, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public User GetById(int id)
        {
            try
            {
                User user = new User();
                string cmdText = "select * from Users where Id=@Id";
                var reader = helper.GetData(cmdText, CommandType.Text, new SqlParameter("@Id", id));
                while (reader.Read())
                {
                    user.Id = Convert.ToInt32(reader["Id"]);
                    user.UserName = reader["UserName"].ToString();
                    user.Password = reader["Password"].ToString();
                    user.Created = Convert.ToDateTime(reader["Created"]);
                    user.Updated = Convert.ToDateTime(reader["Updated"]);
                    user.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    user.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                }
                reader.Close();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<User> GetList()
        {
            List<User> users = new List<User>();
            try
            {
                string cmdText = "select * from Users where IsActive='1'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(reader["Id"]);
                    user.UserName = reader["UserName"].ToString();
                    user.Password = reader["Password"].ToString();
                    users.Add(user);
                }
                reader.Close();
                return users;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert(User model)
        {
            try
            {
                string cmdText = "insert into Users (UserName, Password, Created) values (@UserName, @Password, @Created)";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@UserName",model.UserName),
                    new SqlParameter("@Password",model.Password),
                    new SqlParameter("@Created",model.Created),
                };
                return helper.SetData(cmdText, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(User model)
        {
            try
            {
                string cmdText = "update Users set UserName=@UserName, Password=@Password, Updated=@Updated where Id=@Id";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Id",model.Id),
                    new SqlParameter("@UserName",model.UserName),
                    new SqlParameter("@Password",model.Password),
                    new SqlParameter("@Updated",DateTime.Now)
                };
                return helper.SetData(cmdText, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<User> GetUserName()
        {
            List<User> users = new List<User>();
            try
            {
                string cmdText = "select [UserName] from Users order by UserName asc";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    User user = new User();
                    user.UserName = reader["UserName"].ToString();
                    users.Add(user);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return users;
        }
        public User GetByUserName(string userName)
        {
            User user = new User();
            try
            {
                string cmdText = "select * from Users where UserName=@UserName";
                var reader = helper.GetData(cmdText, CommandType.Text, new SqlParameter("@UserName", userName));
                while (reader.Read())
                {
                    user.Id = Convert.ToInt32(reader["Id"]);
                    user.UserName = reader["UserName"].ToString();
                    user.Password = reader["Password"].ToString();
                }
                reader.Close();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
