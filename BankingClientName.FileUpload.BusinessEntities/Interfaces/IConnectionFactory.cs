﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace BankingClientName.FileUpload.BusinessEntities.Interfaces
{
    public interface IConnectionFactory
    {
        SqlConnection GetHotelManagementSqlConnection();//Method heading 
    }
}
