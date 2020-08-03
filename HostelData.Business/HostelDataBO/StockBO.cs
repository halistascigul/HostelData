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
    public class StockBO : IMainBO<Stock>
    {
        HostelDataHelper helper = new HostelDataHelper();
        public bool Delete(int id)
        {
            try
            {
                string cmdText = "update Stocks set IsActive='0', IsDeleted='1' where Id=@Id ";
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
        public Stock GetById(int id)
        {
            try
            {
                Stock stock = new Stock();
                string cmdText = "select * from Stocks where Id=@Id";
                var reader = helper.GetData(cmdText, CommandType.Text, new SqlParameter("@Id", id));
                while (reader.Read())
                {
                    stock.Id = Convert.ToInt32(reader["Id"]);
                    stock.Chips = Convert.ToInt32(reader["Chips"]);
                    stock.Cola = Convert.ToInt32(reader["Cola"]);
                    stock.Fanta = Convert.ToInt32(reader["Fanta"]);
                    stock.Hamburger = Convert.ToInt32(reader["Hamburger"]);
                    stock.Soda = Convert.ToInt32(reader["Soda"]);
                    stock.Toast = Convert.ToInt32(reader["Toast"]);
                }
                reader.Close();
                return stock;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Stock> GetList()
        {
            List<Stock> stocks = new List<Stock>();
            try
            {
                string cmdText = "select * from Stocks where IsActive='1'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    Stock stock = new Stock();
                    stock.Chips = Convert.ToInt32(reader["Chips"]);
                    stock.Cola = Convert.ToInt32(reader["Cola"]);
                    stock.Fanta = Convert.ToInt32(reader["Fanta"]);
                    stock.Hamburger = Convert.ToInt32(reader["Hamburger"]);
                    stock.Soda = Convert.ToInt32(reader["Soda"]);
                    stock.Toast = Convert.ToInt32(reader["Toast"]);
                    stock.Id = Convert.ToInt32(reader["Id"]);
                    stocks.Add(stock);
                }
                reader.Close();
                return stocks;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert(Stock model)
        {
            try
            {
                string cmdText = "insert into Stocks (Chips, Cola, Fanta, Hamburger, Soda, Toast, Created, IsActive, IsDeleted) values (@Chips, @Cola, @Fanta, @Hamburger, @Soda, @Toast,@Created,@IsActive,@IsDeleted)";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Chips",model.Chips),
                    new SqlParameter("@Cola",model.Cola),
                    new SqlParameter("@Fanta",model.Fanta),
                    new SqlParameter("@Hamburger",model.Hamburger),
                    new SqlParameter("@Soda",model.Soda),
                    new SqlParameter("@Toast",model.Toast),
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
        public bool Update(Stock model)
        {
            try
            {
                string cmdText = "update Stocks set Chips=@Chips, Cola=@Cola, Fanta=@Fanta, Hamburger=@Hamburger, Soda=@Soda, Toast=@Toast, Updated=@Updated where Id=@Id";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Id",model.Id),
                    new SqlParameter("@Chips",model.Chips),
                    new SqlParameter("@Cola",model.Cola),
                    new SqlParameter("@Fanta",model.Fanta),
                    new SqlParameter("@Hamburger",model.Hamburger),
                    new SqlParameter("@Soda",model.Soda),
                    new SqlParameter("@Toast",model.Toast),
                    new SqlParameter("@Updated",DateTime.Now)
                };
                return helper.SetData(cmdText, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal TotalBeverage()
        {
            try
            {
                Stock stock = new Stock();
                string cmdText = "select sum(Cola) as 'Cola', sum(Fanta) as 'Fanta', sum(Soda) as 'Soda', (sum(Cola)+ sum(Fanta)+ sum(Soda)) as 'TotalBeverage' from Stocks where IsActive='1'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    stock.TotalBeverage = Convert.ToDecimal(reader["TotalBeverage"]);
                }
                reader.Close();
                return stock.TotalBeverage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal TotalPaidBeverage()
        {
            try
            {
                Stock stock = new Stock();
                string cmdText = "select sum(Cola) as 'Cola', sum(Fanta) as 'Fanta', sum(Soda) as 'Soda', (sum(Cola)+ sum(Fanta)+ sum(Soda)) as 'TotalBeverage' from Stocks where IsActive='0'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    stock.TotalBeverage = Convert.ToDecimal(reader["TotalBeverage"]);
                }
                reader.Close();
                return stock.TotalBeverage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal TotalFood()
        {
            try
            {
                Stock stock = new Stock();
                string cmdText = "select sum(Toast) as 'Toast', sum(Hamburger) as 'Hamburger', sum(Chips) as 'Chips', (sum(Toast) + sum(Hamburger) + sum(Soda)) as 'TotalFood' from Stocks where IsActive='1'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    stock.TotalFood = Convert.ToDecimal(reader["TotalFood"]);
                }
                reader.Close();
                return stock.TotalFood;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal TotalPaidFood()
        {
            try
            {
                Stock stock = new Stock();
                string cmdText = "select sum(Toast) as 'Toast', sum(Hamburger) as 'Hamburger', sum(Chips) as 'Chips', (sum(Toast) + sum(Hamburger) + sum(Soda)) as 'TotalFood' from Stocks where IsActive='0'";
                var reader = helper.GetData(cmdText, CommandType.Text);
                while (reader.Read())
                {
                    stock.TotalFood = Convert.ToDecimal(reader["TotalFood"]);
                }
                reader.Close();
                return stock.TotalFood;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
