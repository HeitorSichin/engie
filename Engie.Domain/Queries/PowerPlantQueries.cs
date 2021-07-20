using System;
using System.Linq.Expressions;
using Engie.Domain.Entities;
using Engie.Domain.Enums;

namespace Engie.Domain.Queries
{
    public static class PowerPlantQueries
    {
        public static Expression<Func<PowerPlant, bool>> GetAllActivate()
        {
            return x => x.Active == EActive.Active;
        }

        public static Expression<Func<PowerPlant, bool>> GetAllInactivate()
        {
            return x => x.Active == EActive.Inactive;
        }

    }
}