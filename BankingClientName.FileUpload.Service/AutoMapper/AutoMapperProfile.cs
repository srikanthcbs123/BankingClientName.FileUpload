using AutoMapper;
using BankingClientName.FileUpload.BusinessEntities.DTOS;
using BankingClientName.FileUpload.BusinessEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingClientName.FileUpload.Service.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {//you must register your source class,destination class here.otherise if you are not registered it will throw automapper error.
         //      1) creating mapping
         //syntax: mapper.createmap < sourcemodelclass ,destination model class >();
            CreateMap<FileUploadDTO, FileUploadData>();//dml performs[inser,update,delete]//from dto to table loki inserting
            CreateMap<FileUploadData, FileUploadDTO>();//get methods // from table to picking data
        }
    }
}
//(*) This required two steps:

//        1) creating mapping

//       syntax: CreateMap < sourcemodel Class, destination modelclass >();

//Here<> Means We called as a Placeholder .

//        2) Converting source modelobject to destination modelobject

//        destination modelclass Reference variable= Mapper.Map<destination modelclassname>(source modelclasspbject)