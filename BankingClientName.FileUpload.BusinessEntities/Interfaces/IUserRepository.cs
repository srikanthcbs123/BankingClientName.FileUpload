﻿using BankingClientName.FileUpload.BusinessEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingClientName.FileUpload.BusinessEntities.Interfaces
{
   public   interface IUserRepository
    {
        Task<string> InvokeUsersList();
        Task<string> InvokeUsersById(int id);

        Task<string> InsertUserData(User userDetail);

        Task<string> UpdateUserData(User userDetail, int id);
        Task<string> DeleteUserData(int id);
    }
}
