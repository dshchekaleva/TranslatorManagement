using AutoMapper;
using MediatR;
using System;
using TranslationManagement.Api.DTOs.Models;
using TranslationManagement.Api.DTOs.Requests;
using TranslationManagement.Application.Translators.UseCases;
using TranslationManagement.Domain.Entities;
using TranslationManagement.Domain.Enums;

namespace TranslationManagement.Api.Mappers
{
    public class TranslatorManagementControllerMapper : Profile
    {
        public TranslatorManagementControllerMapper()
        {
            CreateMap<Translator, TranslatorModel>();
            CreateMap<AddTranslatorRequest, AddTranslator>();
            CreateMap<AddTranslator, Translator>()
                .ForMember(x => x.Status, opt => opt.MapFrom(o => MapStatus(o.Status)));
        }

        private object MapStatus(string status)
        {
            Enum.TryParse(status, out TranslatorStatuses destStatus);
            return destStatus;
        }
    }
}
