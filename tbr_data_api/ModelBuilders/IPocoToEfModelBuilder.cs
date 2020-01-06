using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tbr_data_api.ModelBuilders
{
    internal interface IPocoToEfModelBuilder
    {
        internal void BuildModel(ModelBuilder modelBuilder);
    }

    internal static class PocoToEfModelBuilderExtensions {
        internal static void BuildModels(this IEnumerable<IPocoToEfModelBuilder> t, ModelBuilder modelBuilder)
        {
            t.ToList<IPocoToEfModelBuilder>().ForEach(p=>p.BuildModel(modelBuilder));
        }
    }

    
}
