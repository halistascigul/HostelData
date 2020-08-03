using HostelData.Core.Data.Ado.Net;
using HostelData.DataAccess.HostelDataAdaptation;
using HostelData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HostelData.Business.HostelDataBO
{
    public class CustomerBO : IMainBO<Customer>
    {
        HostelDataHelper helper = new HostelDataHelper();
        public bool Delete(int id)
        {
            var result = false;
            try
            {
                string cmdText = "update Customers set IsDeleted='1', IsActive='0' where Id=@Id";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Id",id),
                    new SqlParameter("@IsDeleted",true),
                    new SqlParameter("@IsActive",false)
                };
                result = helper.SetData(cmdText, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public Customer GetById(int id)
        {
            Customer customer = new Customer();
            try
            {
                string cmdText = "select * from Customers where Id=@Id";
                var reader = helper.GetData(cmdText, CommandType.Text, new SqlParameter("@Id", id));
                while (reader.Read())
                {
                    customer.Id = Convert.ToInt32(reader["Id"]);
                    customer.Name = reader["Name"].ToString();
                    customer.Surname = reader["Surname"].ToString();
                    customer.IdentityNumber = Convert.ToInt64(reader["IdentityNumber"]);
                    customer.Gender = reader["Gender"].ToString();
                    customer.EntryDate = Convert.ToDateTime(reader["EntryDate"]);
                    customer.ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
                    //customer.RoomNumber = Convert.ToInt32(reader["RoomNumber"]);
                    customer.Phone = reader["Phone"].ToString();
                    customer.Email = reader["Email"].ToString();
                    customer.Pay = Convert.ToDecimal(reader["Pay"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customer;
        }
        public List<Customer> GetList()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                string cmdText = "select * from Customers where IsActive='1'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.Id = Convert.ToInt32(reader["Id"]);
                    customer.Name = reader["Name"].ToString();
                    customer.Surname = reader["Surname"].ToString();
                    customer.IdentityNumber = Convert.ToInt64(reader["IdentityNumber"]);
                    customer.Gender = reader["Gender"].ToString();
                    customer.EntryDate = Convert.ToDateTime(reader["EntryDate"]);
                    customer.ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
                    customer.RoomNumber = Convert.ToInt32(reader["RoomNumber"]);
                    customer.Phone = reader["Phone"].ToString();
                    customer.Email = reader["Email"].ToString();
                    customer.Pay = Convert.ToDecimal(reader["Pay"]);
                    customer.SoldChips = Convert.ToByte(reader["SoldChips"]);
                    customer.SoldCola = Convert.ToByte(reader["SoldCola"]);
                    customer.SoldFanta = Convert.ToByte(reader["SoldFanta"]);
                    customer.SoldHamburger = Convert.ToByte(reader["SoldHamburger"]);
                    customer.SoldSoda = Convert.ToByte(reader["SoldSoda"]);
                    customer.SoldToast = Convert.ToByte(reader["SoldToast"]);
                    customer.TotalAmount = Convert.ToDecimal(reader["TotalAmount"]);
                    customer.Created = Convert.ToDateTime(reader["Created"]);
                    customer.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    customer.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    customers.Add(customer);
                }
                reader.Close();
                return customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Customer> GetListInHostel()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                string cmdText = "select * from Customers where ReleaseDate>SYSDATETIME() and IsActive='1'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.Id = Convert.ToInt32(reader["Id"]);
                    customer.Name = reader["Name"].ToString();
                    customer.Surname = reader["Surname"].ToString();
                    customer.ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
                    customer.RoomNumber = Convert.ToInt32(reader["RoomNumber"]);
                    customers.Add(customer);
                }
                reader.Close();
                return customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert(Customer model)
        {
            try
            {
                string cmdText = "insert into Customers (Name,Surname,Gender,Phone,Email,IdentityNumber,RoomNumber,Pay,EntryDate,ReleaseDate,IsDeleted,IsActive,Created,Updated,SoldToast,SoldHamburger,SoldChips,SoldCola,SoldFanta,SoldSoda,TotalAmount) values (@Name,@Surname,@Gender,@Phone,@Email,@IdentityNumber,@RoomNumber,@Pay,@EntryDate,@ReleaseDate,@IsDeleted,@IsActive,@Created,@Updated,@SoldToast,@SoldHamburger,@SoldChips,@SoldCola,@SoldFanta,@SoldSoda,@TotalAmount)";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Name",model.Name),
                    new SqlParameter("@Surname",model.Surname),
                    new SqlParameter("@Gender",model.Gender),
                    new SqlParameter("@Phone",model.Phone),
                    new SqlParameter("@Email",model.Email),
                    new SqlParameter("@IdentityNumber",model.IdentityNumber),
                    new SqlParameter("@RoomNumber",model.RoomNumber),
                    new SqlParameter("@Pay",model.Pay),
                    new SqlParameter("@EntryDate",model.EntryDate),
                    new SqlParameter("@ReleaseDate",model.ReleaseDate),
                    new SqlParameter("@IsDeleted",model.IsDeleted),
                    new SqlParameter("@IsActive",model.IsActive),
                    new SqlParameter("@Created",model.Created),
                    new SqlParameter("@Updated",model.Updated),
                    new SqlParameter("@SoldToast",model.SoldToast),
                    new SqlParameter("@SoldHamburger",model.SoldHamburger),
                    new SqlParameter("@SoldChips",model.SoldChips),
                    new SqlParameter("@SoldCola",model.SoldCola),
                    new SqlParameter("@SoldFanta",model.SoldFanta),
                    new SqlParameter("@SoldSoda",model.SoldSoda),
                    new SqlParameter("@TotalAmount",model.TotalAmount)
                };
                return helper.SetData(cmdText, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(Customer model)
        {
            try
            {
                string cmdText = "Update Customers set Name=@Name, Surname=@Surname, Gender=@Gender, Phone=@Phone, Email=@Email, IdentityNumber=@IdentityNumber, RoomNumber=@RoomNumber, Pay=@Pay, EntryDate=@EntryDate, ReleaseDate=@ReleaseDate, Updated=@Updated,IsActive=@IsActive,IsDeleted=@IsDeleted where Id=@Id";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Name",model.Name),
                    new SqlParameter("@Surname",model.Surname),
                    new SqlParameter("@Gender",model.Gender),
                    new SqlParameter("@Phone",model.Phone),
                    new SqlParameter("@Email",model.Email),
                    new SqlParameter("@IdentityNumber",model.IdentityNumber),
                    new SqlParameter("@RoomNumber",model.RoomNumber),
                    new SqlParameter("@Pay",model.Pay),
                    new SqlParameter("@EntryDate",model.EntryDate),
                    new SqlParameter("@ReleaseDate",model.ReleaseDate),
                    new SqlParameter("@Updated",DateTime.Now),
                    new SqlParameter("@IsActive",model.IsActive),
                    new SqlParameter("@IsDeleted",model.IsDeleted),
                    new SqlParameter("@Id",model.Id)
                };
                return helper.SetData(cmdText, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Customer> GetCustomersArchive()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                string cmdText = "select * from Customers where IsActive='0'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    Customer customer = new Customer
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Surname = reader["Surname"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        IdentityNumber = Convert.ToInt64(reader["IdentityNumber"]),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Email"].ToString(),
                        RoomNumber = Convert.ToInt32(reader["RoomNumber"]),
                        EntryDate = Convert.ToDateTime(reader["EntryDate"]),
                        ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]),
                    };
                    customers.Add(customer);
                }
                return customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal TotalPay()
        {
            try
            {
                Customer customer = new Customer();
                string cmdText = "select sum(Pay) as 'TotalPay' from Customers";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    customer.TotalPay = Convert.ToDecimal(reader["TotalPay"]);
                }
                reader.Close();
                return customer.TotalPay;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Customer GetByRoomNumber(int roomNumber)
        {
            Customer customer = new Customer();
            try
            {
                string cmdText = "select * from Customers where RoomNumber=@RoomNumber and IsActive='1'";
                var reader = helper.GetData(cmdText, CommandType.Text, new SqlParameter("@RoomNumber", roomNumber));
                while (reader.Read())
                {
                    customer.Id = Convert.ToInt32(reader["Id"]);
                    customer.RoomNumber = Convert.ToInt32(reader["RoomNumber"]);
                    //customer.Name = reader["Name"].ToString();
                    //customer.Surname = reader["Surname"].ToString();
                    //customer.IdentityNumber = Convert.ToInt64(reader["IdentityNumber"]);
                    //customer.Gender = reader["Gender"].ToString();
                    //customer.EntryDate = Convert.ToDateTime(reader["EntryDate"]);
                    //customer.ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
                    ////customer.RoomNumber = Convert.ToInt32(reader["RoomNumber"]);
                    //customer.Phone = reader["Phone"].ToString();
                    //customer.Email = reader["Email"].ToString();
                    //customer.Pay = Convert.ToDecimal(reader["Pay"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customer;
        }
        public bool AddProduct(Customer model)
        {
            try
            {
                string cmdText = "update Customers set SoldToast=@Toast,SoldHamburger=@Hamburger,SoldChips=@Chips,SoldCola=@Cola,SoldFanta=@Fanta,SoldSoda=@Soda,TotalAmount=@Amount where RoomNumber=@RoomNumber and IsActive='1'";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@RoomNumber",model.RoomNumber),
                    new SqlParameter("@Toast",model.SoldToast),
                    new SqlParameter("@Hamburger",model.SoldHamburger),
                    new SqlParameter("@Chips",model.SoldChips),
                    new SqlParameter("@Cola",model.SoldCola),
                    new SqlParameter ("@Fanta",model.SoldFanta),
                    new SqlParameter("@Soda",model.SoldSoda),
                    new SqlParameter("@Amount",(model.SoldChips*6)+(model.SoldCola*5)+(model.SoldFanta*5)+(model.SoldHamburger*7.5)+(model.SoldSoda*4)+(model.SoldToast*5))
                };
                return helper.SetData(cmdText, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal TotalAmount()
        {
            try
            {
                Customer customer = new Customer();
                string cmdText = "select sum(TotalAmount) as 'TotalAmount' from Customers";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    customer.TotalPay = Convert.ToDecimal(reader["TotalAmount"]);
                }
                reader.Close();
                return customer.TotalPay;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer GetProductsOfCustomer(int roomNumber)
        {
            try
            {
                Customer customer = new Customer();
                string cmdText = "select Id,SoldToast, SoldHamburger,SoldChips,SoldCola,SoldFanta,SoldSoda,RoomNumber from Customers where RoomNumber=@RoomNumber and IsActive='1'";
                var reader = helper.GetData(cmdText, CommandType.Text, new SqlParameter("@RoomNumber", roomNumber));
                while (reader.Read())
                {
                    customer.Id = Convert.ToInt32(reader["Id"]);
                    //customer.Name = reader["Name"].ToString();
                    //customer.Surname = reader["Surname"].ToString();
                    //customer.IdentityNumber = Convert.ToInt64(reader["IdentityNumber"]);
                    //customer.Gender = reader["Gender"].ToString();
                    //customer.EntryDate = Convert.ToDateTime(reader["EntryDate"]);
                    //customer.ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
                    customer.RoomNumber = Convert.ToInt32(reader["RoomNumber"]);
                    //customer.Phone = reader["Phone"].ToString();
                    //customer.Email = reader["Email"].ToString();
                    //customer.Pay = Convert.ToDecimal(reader["Pay"]);
                    customer.SoldChips = Convert.ToByte(reader["SoldChips"]);
                    customer.SoldCola = Convert.ToByte(reader["SoldCola"]);
                    customer.SoldFanta = Convert.ToByte(reader["SoldFanta"]);
                    customer.SoldHamburger = Convert.ToByte(reader["SoldHamburger"]);
                    customer.SoldSoda = Convert.ToByte(reader["SoldSoda"]);
                    customer.SoldToast = Convert.ToByte(reader["SoldToast"]);
                    //customer.TotalAmount = Convert.ToDecimal(reader["TotalAmount"]);
                    //customer.Created = Convert.ToDateTime(reader["Created"]);
                    //customer.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    //customer.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                }
                reader.Close();
                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
