using Npgsql;
using DAL;
using DomainModel;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Interfaces.Repository;
using DomainModel.Exceptions;


namespace BLL.Services
{
    public class ReportService : IReportService
    {
        private IDbRepos db;
        public ReportService(IDbRepos repos)
        {
            db = repos;
        }

        public List<OrdersByMonth> ExecuteSP(int month, int year, int ClientId)
        {

            var res = db.Reports.ExecuteSP(month, year, ClientId).Select(i => new OrdersByMonth
            {
                order_id = i.order_id,
                courier_id = i.courier_id,
                Date = i.Date
            }).ToList();
            return res;

        }


        public List<ReportData> ReportPizzas(int? ingredientId)
        {

            var request = db.Reports.PizzaWithIngredients(ingredientId).Select(i =>  
            new ReportData
            {
                 Id=i.Id,
                 Description=i.Description,
                 Name=i.Name,
            })
            .ToList();
            //if (request == null)
            //    throw new PizzaNotFoundException((int) ingredientId);
            return request;
        }
    }
}
