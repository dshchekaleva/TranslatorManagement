using AutoMapper;
using TranslationManagement.Api.DTOs.Models;
using TranslationManagement.Api.DTOs.Requests;
using TranslationManagement.Application.Jobs.UseCases;
using TranslationManagement.Domain.Entities;

namespace TranslationManagement.Api.Mappers
{
    public class TranslationJobControllerMapper : Profile
    {
        public TranslationJobControllerMapper()
        {
            CreateMap<TranslationJob, JobModel>();
            CreateMap<CreateJobRequest, CreateJob>();
            CreateMap<CreateJob, TranslationJob>();
        }
    }
}
