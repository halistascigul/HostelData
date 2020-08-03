using HostelData.Core.Data.Ado.Net;
using HostelData.DataAccess.HostelDataAdaptation;
using HostelData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HostelData.Business.HostelDataBO
{
    public class NoticeBO : IMainBO<Notice>
    {
        HostelDataHelper helper = new HostelDataHelper();
        public bool Delete(int id)
        {
            try
            {
                string cmdText = "update Notices set IsActive='0', IsDeleted='1' where Id=@Id ";
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
        public Notice GetById(int id)
        {
            try
            {
                Notice notice = new Notice();
                string cmdText = "select * from Notices where Id=@Id";
                var reader = helper.GetData(cmdText, CommandType.Text, new SqlParameter("@Id", id));
                while (reader.Read())
                {
                    notice.NoticeText = reader["NoticeText"].ToString();
                    notice.UserName = reader["UserName"].ToString();
                }
                reader.Close();
                return notice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Notice> GetList()
        {
            List<Notice> notices = new List<Notice>();
            try
            {
                string cmdText = "select * from Notices where IsActive='1'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    Notice notice = new Notice();
                    notice.NoticeText = reader["NoticeText"].ToString();
                    notice.UserName = reader["UserName"].ToString();
                    notice.Id = Convert.ToInt32(reader["Id"]);
                    notice.Created = Convert.ToDateTime(reader["Created"]);
                    notice.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    notice.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    notices.Add(notice);
                }
                reader.Close();
                return notices;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert(Notice model)
        {
            try
            {
                string cmdText = "insert into Notices (NoticeText, UserName, Created, IsActive, IsDeleted) values (@NoticeText, @UserName,@Created,@IsActive,@IsDeleted)";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@NoticeText",model.NoticeText),
                    new SqlParameter("@UserName",model.UserName),
                    new SqlParameter("@Created",model.Created),
                    new SqlParameter("@IsActive",model.IsActive),
                    new SqlParameter("@IsDeleted",model.IsDeleted)
                };
                return helper.SetData(cmdText, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(Notice model)
        {
            try
            {
                string cmdText = "update Notices set NoticeText=@NoticeText, UserName=@UserName, Updated=@Updated where Id=@Id";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Id",model.Id),
                    new SqlParameter("@NoticeText",model.NoticeText),
                    new SqlParameter("@UserName",model.UserName),
                    new SqlParameter("@Updated",DateTime.Now)
                };
                return helper.SetData(cmdText, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetLastNotice()
        {
            try
            {
                Notice notice = new Notice();
                string cmdText = "select top 1 * from Notices where IsActive='1' order by Created Desc";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    notice.NoticeText = reader["NoticeText"].ToString();
                }
                reader.Close();
                return notice.NoticeText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
