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
    public class InvoiceBO : IMainBO<Invoice>
    {
        HostelDataHelper helper = new HostelDataHelper();
        public bool Delete(int id)
        {
            try
            {
                string cmdText = "update Invoices set IsActive='0', IsDeleted='1' where Id=@Id ";
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

        public Invoice GetById(int id)
        {
            try
            {
                Invoice invoice = new Invoice();
                string cmdText = "select * from Invoices where Id=@Id";
                var reader = helper.GetData(cmdText, CommandType.Text, new SqlParameter("@Id", id));
                while (reader.Read())
                {
                    invoice.Id = Convert.ToInt32(reader["Id"]);
                    invoice.Electrical = Convert.ToDecimal(reader["Electrical"]);
                    invoice.Internet = Convert.ToDecimal(reader["Internet"]);
                    invoice.Warm = Convert.ToDecimal(reader["Warm"]);
                    invoice.Water = Convert.ToDecimal(reader["Water"]);
                }
                reader.Close();
                return invoice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Invoice> GetList()
        {
            List<Invoice> invoices = new List<Invoice>();
            try
            {
                string cmdText = "select * from Invoices where IsActive='1'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    Invoice invoice = new Invoice();
                    invoice.Electrical = Convert.ToDecimal(reader["Electrical"]);
                    invoice.Internet = Convert.ToDecimal(reader["Internet"]);
                    invoice.Warm = Convert.ToDecimal(reader["Warm"]);
                    invoice.Water = Convert.ToDecimal(reader["Water"]);
                    invoice.Id = Convert.ToInt32(reader["Id"]);
                    invoices.Add(invoice);
                }
                reader.Close();
                return invoices;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert(Invoice model)
        {
            try
            {
                string cmdText = "insert into Invoices (Electrical, Internet, Warm, Water, IsDeleted,IsActive,Created) values (@Electrical, @Internet, @Warm, @Water, @IsDeleted,@IsActive,@Created)";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Electrical",model.Electrical),
                    new SqlParameter("@Internet",model.Internet),
                    new SqlParameter("@Warm",model.Warm),
                    new SqlParameter("@Water",model.Water),
                    new SqlParameter("@IsDeleted",model.IsDeleted),
                    new SqlParameter("@IsActive",model.IsActive),
                    new SqlParameter("@Created",model.Created)
                };
                return helper.SetData(cmdText, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(Invoice model)
        {
            try
            {
                string cmdText = "update Invoices set Electrical=@Electrical, Internet=@Internet, Warm=@Warm, Water=@Water, Updated=@Updated where Id=@Id";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Id",model.Id),
                    new SqlParameter("@Electrical",model.Electrical),
                    new SqlParameter("@Internet",model.Internet),
                    new SqlParameter("@Warm",model.Warm),
                    new SqlParameter("@Water",model.Water),
                    new SqlParameter("@Updated",DateTime.Now)
                };
                return helper.SetData(cmdText, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal TotalElectrical()
        {
            try
            {
                Invoice invoice = new Invoice();
                string cmdText = "select sum(Electrical) as 'TotalElectrical' from Invoices where IsActive='1'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    invoice.TotalElectrical = Convert.ToDecimal(reader["TotalElectrical"]);
                }
                reader.Close();
                return invoice.TotalElectrical;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal TotalPaidElectrical()
        {
            try
            {
                Invoice invoice = new Invoice();
                string cmdText = "select sum(Electrical) as 'TotalElectrical' from Invoices where IsActive='0'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    invoice.TotalElectrical = Convert.ToDecimal(reader["TotalElectrical"]);
                }
                reader.Close();
                return invoice.TotalElectrical;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal TotalWater()
        {
            try
            {
                Invoice invoice = new Invoice();
                string cmdText = "select sum(Water) as 'TotalWater' from Invoices where IsActive='1'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    invoice.TotalWater = Convert.ToDecimal(reader["TotalWater"]);
                }
                reader.Close();
                return invoice.TotalWater;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal TotalPaidWater()
        {
            try
            {
                Invoice invoice = new Invoice();
                string cmdText = "select sum(Water) as 'TotalWater' from Invoices where IsActive='0'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    invoice.TotalWater = Convert.ToDecimal(reader["TotalWater"]);
                }
                reader.Close();
                return invoice.TotalWater;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal TotalWarm()
        {
            try
            {
                Invoice invoice = new Invoice();
                string cmdText = "select sum(Warm) as 'TotalWarm' from Invoices where IsActive='1'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    invoice.TotalWarm = Convert.ToDecimal(reader["TotalWarm"]);
                }
                reader.Close();
                return invoice.TotalWarm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal TotalPaidWarm()
        {
            try
            {
                Invoice invoice = new Invoice();
                string cmdText = "select sum(Warm) as 'TotalWarm' from Invoices where IsActive='0'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    invoice.TotalWarm = Convert.ToDecimal(reader["TotalWarm"]);
                }
                reader.Close();
                return invoice.TotalWarm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal TotalInternet()
        {
            try
            {
                Invoice invoice = new Invoice();
                string cmdText = "select sum(Internet) as 'TotalInternet' from Invoices where IsActive='1'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    invoice.TotalInternet = Convert.ToDecimal(reader["TotalInternet"]);
                }
                reader.Close();
                return invoice.TotalInternet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal TotalPaidInternet()
        {
            try
            {
                Invoice invoice = new Invoice();
                string cmdText = "select sum(Internet) as 'TotalInternet' from Invoices where IsActive='0'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    invoice.TotalInternet = Convert.ToDecimal(reader["TotalInternet"]);
                }
                reader.Close();
                return invoice.TotalInternet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
