using BankingClientName.FileUpload.BusinessEntities;
using BankingClientName.FileUpload.BusinessEntities.Interfaces;
using BankingClientName.FileUpload.BusinessEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using BankingClientName.FileUpload.Repository.Utility;
namespace BankingClientName.FileUpload.Repository
{
    public class FilesUploadRepository : IFilesUploadRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public FilesUploadRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<FileUploadResponse> AddFileUpload(FileUploadData fileUpload)
        {//Need to write the logic for database communication 
            //Here we are using ado.net orm to communicating with database.
            FileUploadResponse fileUploadResponse = new FileUploadResponse();
            using (SqlConnection con = _connectionFactory.GetHotelManagementSqlConnection())//here we are getting the conection string
            {
                SqlCommand cmd = new SqlCommand(StoredProcedureNames.AddFileUpload_SP, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FileName", fileUpload.FileName);//storedprocedure paramters binding here
                cmd.Parameters.AddWithValue("@FilePath", fileUpload.FilePath);//storedprocedure paramters binding here
                cmd.Parameters.AddWithValue("@ModifiedFilename", fileUpload.ModifiedFilename);//storedprocedure paramters binding here
                cmd.Parameters.AddWithValue("@Createdby", fileUpload.Createdby);//storedprocedure paramters binding here
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "FileUpload");
                DataTable dt = new DataTable();
                dt = ds.Tables["FileUpload"];
                foreach (DataRow dr in dt.Rows)
                {
                    fileUploadResponse.Error_Code = Convert.ToString(dr["ERROR_CODE"]);
                    fileUploadResponse.Error_Message = Convert.ToString(dr["ERROR_MESSAGE"]);
                }
            }
            return fileUploadResponse;
        }

        public async Task<FileUploadData> GetFileUploadDetailsById(int Id)
        {//Need to write the logic for database communication 
            FileUploadData fileUpload = new FileUploadData();
            using (SqlConnection con = _connectionFactory.GetHotelManagementSqlConnection())//here we are getting the conection string
            {
                SqlCommand cmd = new SqlCommand(StoredProcedureNames.GetFileUploadDetailsById_SP, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "FileUpload");
                DataTable dt = new DataTable();
                dt = ds.Tables["FileUpload"];
                foreach (DataRow dr in dt.Rows)
                {
                    fileUpload.ModifiedFilename = Convert.ToString(dr["ModifiedFilename"]);
                }
            }
            return fileUpload;
        }

        public async Task<List<FileUploadData>> GetFileUploadList()
        {//Need to write the logic for database communication 

            List<FileUploadData> lstfiles = new List<FileUploadData>();
            //don't read the hardcooded connection string .realtime not recommedd way
            // string conectonstring = "Server=DESKTOP-AAO14OC;Database=hotelmanagement;integrated security=yes;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";
            using (SqlConnection con = _connectionFactory.GetHotelManagementSqlConnection())//here we are getting the conection string
            {
                SqlCommand cmd = new SqlCommand(StoredProcedureNames.GetFileUpload_SP, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "FileUpload");
                DataTable dt = new DataTable();
                dt = ds.Tables["FileUpload"];
                foreach (DataRow dr in dt.Rows)
                {
                    FileUploadData fileUpload = new FileUploadData();
                    fileUpload.Id = Convert.ToInt32(dr["Id"]);
                    fileUpload.FileName = Convert.ToString(dr["FileName"]);
                    fileUpload.ModifiedFilename = Convert.ToString(dr["ModifiedFilename"]);
                    fileUpload.FilePath = Convert.ToString(dr["FilePath"]);
                    fileUpload.Createdby = Convert.ToString(dr["Createdby"]);
                    fileUpload.CreatedDatetTime = Convert.ToDateTime(dr["CreatedDateTime"]);
                    lstfiles.Add(fileUpload);
                }
            }
            return lstfiles;
        }
    }
}
