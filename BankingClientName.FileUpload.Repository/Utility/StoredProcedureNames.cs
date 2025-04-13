using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingClientName.FileUpload.Repository.Utility
{
    public static class StoredProcedureNames
    {
        public static readonly string AddFileUpload_SP = "Usp_AddFileUpload";

        public static readonly string GetFileUpload_SP = "GetFileUpload";

        public static readonly string GetFileUploadDetailsById_SP = "GetFileUploadDetailsById";
    }
}
