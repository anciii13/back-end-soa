﻿using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Domain;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.Administration
{
    public class TourObjectService : CrudService<TourObjectDto, TourObject>, ITourObjectService
    {
        public TourObjectService(ICrudRepository<TourObject> repository, IMapper mapper) : base(repository, mapper) { }

        TourObjectDto ITourObjectService.GetTour(int id)
        {
            var result = CrudRepository.Get(id);
            return MapToDto(result);
        }


    }
}
