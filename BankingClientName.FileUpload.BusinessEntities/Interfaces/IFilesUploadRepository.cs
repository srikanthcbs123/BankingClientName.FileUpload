using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingClientName.FileUpload.BusinessEntities.Models;
namespace BankingClientName.FileUpload.BusinessEntities.Interfaces
{
    public interface IFilesUploadRepository
    {
        Task<FileUploadResponse> AddFileUpload(FileUploadData fileUpload);
        Task<List<FileUploadData>> GetFileUploadList();
        Task<FileUploadData> GetFileUploadDetailsById(int Id);
    }
}
