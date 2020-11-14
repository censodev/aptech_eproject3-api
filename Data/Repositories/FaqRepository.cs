using Data.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class FaqRepository : Repository<Faq>, IFaqRepository
    {
        public FaqRepository(DataContext context, ILogger<FaqRepository> logger) : base(context, logger)
        {
        }
    }
}
