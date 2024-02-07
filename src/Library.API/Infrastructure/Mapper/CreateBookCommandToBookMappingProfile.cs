﻿using AutoMapper;
using Library.API.Application.Commands;
using Library.API.Application.Queries;
using Library.Domain.Model;

namespace Library.API.Infrastructure.Mapper
{
    public class CreateBookCommandToBookMappingProfile : Profile
    {
        public CreateBookCommandToBookMappingProfile()
        {
            CreateMap<CreateBookCommand, Book>();
        }
    }
}