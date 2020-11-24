using Data.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class SurveyResultRepository : Repository<SurveyResult>, ISurveyResultRepository
    {
        public SurveyResultRepository(DataContext context, ILogger<SurveyResultRepository> logger) : base(context, logger)
        {
        }
    }
}
