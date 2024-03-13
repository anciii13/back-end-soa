﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public.Administration;

public interface IProblemService
{
    Result<PagedResult<ProblemDto>> GetPaged(int page, int pageSize);
    Result<ProblemDto> Create(ProblemDto problem);
    Result<ProblemDto> Update(ProblemDto problem);
    Result Delete(int id);
    Result<PagedResult<ProblemDto>> GetByTouristId(int userId, int page, int pageSize);
    Result<PagedResult<ProblemDto>> GetByGuideId(int tourId, int page, int pageSize);
    int IsThereUnreadMessages(int userId, int page, int pageSize);
    Result<PagedResult<ProblemDto>> GetUnsolvedProblems(int page, int pageSize);
    Result<ProblemDto> getGuideProblemWithClosestDeadline(int id, int page, int pageSize);
}