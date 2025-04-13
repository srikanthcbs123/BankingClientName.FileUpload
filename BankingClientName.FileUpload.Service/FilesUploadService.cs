using BankingClientName.FileUpload.BusinessEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BankingClientName.FileUpload.Repository;
using BankingClientName.FileUpload.BusinessEntities.DTOS;
using BankingClientName.FileUpload.BusinessEntities;
using BankingClientName.FileUpload.BusinessEntities.Models;
namespace BankingClientName.FileUpload.Service
{
    public class FilesUploadService:IFilesUploadService
    {
        public readonly IFilesUploadRepository _filesUploadRepository;
        private readonly IMapper _mapper;//if you want to work with automapper we need this IMapper interface;

        public FilesUploadService(IFilesUploadRepository filesUploadRepository, IMapper mapper)
        {
            this._filesUploadRepository = filesUploadRepository;
            this._mapper = mapper;
        }
        public async Task<List<FileUploadDTO>> GetFileUploadList()
        {
            var fileUploadList = await _filesUploadRepository.GetFileUploadList();
          //Synatx:Converting source model object to destination model object
          //destination model class Reference variable = Mapper.Map < destinationmodelclassname > (source modelclasspbject)
            return _mapper.Map<List<FileUploadDTO>>(fileUploadList);
        }
        public async Task<FileUploadResponse> AddFileUpload(FileUploadDTO fileUploadDTO)//sourcemodelclass object
        {
            // 1)Auto mapper is used to create a mapping between  to source model object to destination model object
            FileUploadData obj = new FileUploadData();//destinationmodelclass object
            #region Automapperbeforecode

            //This Code was replaced by above Automapper concept.
            //obj.FileName = fileUploadDTO.FileName;
            //obj.FilePath = fileUploadDTO.FilePath;
            //obj.CreatedDatetTime = fileUploadDTO.CreatedDatetTime;
            //obj.Createdby = fileUploadDTO.Createdby;
            //obj.ModifiedFilename = fileUploadDTO.ModifiedFilename;
            //obj.Id = fileUploadDTO.Id;

            #endregion

            //Converting source modelobject to destination modelobject
            //Syntax:   _mapper.Map(SourceModelObject,DestinationModelObject)
            //once mapping is created, source model object can be converted to destination model object with less code and easy way.
            _mapper.Map(fileUploadDTO, obj);



            var result = await _filesUploadRepository.AddFileUpload(obj);
            return result;

        }

        public async Task<FileUploadDTO> GetFileUploadDetailsById(int Id)
        {
            var result = await _filesUploadRepository.GetFileUploadDetailsById(Id);
            FileUploadDTO fileUploadDTO = new FileUploadDTO();
            fileUploadDTO.ModifiedFilename = result.ModifiedFilename;
            return fileUploadDTO;
        }
    }
}
