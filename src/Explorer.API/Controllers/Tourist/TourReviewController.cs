﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.UseCases.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    
    [Route("api/tourist/tourReview")]
    public class TourReviewController : BaseApiController
    {
        private readonly ITourReviewService _tourReviewService;
        public TourReviewController(ITourReviewService tourReviewService)
        {
            _tourReviewService = tourReviewService;
        }

        [HttpPost]
        public ActionResult<TourReviewDto> Create([FromBody] TourReviewDto tourReviewDto) { 
        
            var result= _tourReviewService.Create(tourReviewDto);
            return CreateResponse(result);
        }

        [HttpGet]
        public ActionResult<PagedResult<TourReviewDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _tourReviewService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<TourReviewDto> Update([FromBody] TourReviewDto tourReviewDto)
        {
            var result = _tourReviewService.Update(tourReviewDto);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _tourReviewService.Delete(id);
            return CreateResponse(result);
        }

    }
}
