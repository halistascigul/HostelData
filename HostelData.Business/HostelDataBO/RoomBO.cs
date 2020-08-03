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
    public class RoomBO : IMainBO<Room>
    {
        HostelDataHelper helper = new HostelDataHelper();
        public bool Delete(int id)
        {
            try
            {
                string cmdText = "update Rooms set IsActive='0', IsDeleted='1' where Id=@Id ";
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
        public Room GetById(int id)
        {
            try
            {
                Room room = new Room();
                string cmdText = "select * from Rooms where Id=@Id";
                var reader = helper.GetData(cmdText, CommandType.Text, new SqlParameter("@Id", id));
                while (reader.Read())
                {
                    room.RoomNumber = Convert.ToInt32(reader["RoomNumber"]);
                }
                reader.Close();
                return room;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Room> GetList()
        {
            List<Room> rooms = new List<Room>();
            try
            {
                string cmdText = "select * from Rooms where IsActive='1'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    Room room = new Room
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        RoomNumber = Convert.ToInt32(reader["RoomNumber"]),
                    };
                    rooms.Add(room);
                }
                reader.Close();
                return rooms;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert(Room model)
        {
            try
            {
                string cmdText = "insert into Rooms (RoomNumber, Created, IsActive, IsDeleted) values (@RoomNumber,@Created,@IsActive,@IsDeleted)";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@RoomNumber",model.RoomNumber),
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
        public bool Update(Room model)
        {
            try
            {
                string cmdText = "update Rooms set RoomNumber=@RoomNumber, Updated=@Updated where Id=@Id";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@RoomNumber",model.RoomNumber),
                    new SqlParameter("@Updated",DateTime.Now),
                    new SqlParameter("@Id",model.Id)
                };
                return helper.SetData(cmdText, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
