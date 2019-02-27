using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using PetVetNew.Data;

namespace PetVET.Extentions
{
    public static class ContextFactoryExtentioncs
    {

            public static bool AllMigrationsApplied(this DbContext context)
            {
                var applied = context.GetService<IHistoryRepository>()
                    .GetAppliedMigrations()
                    .Select(m => m.MigrationId);

                var total = context.GetService<IMigrationsAssembly>()
                    .Migrations
                    .Select(m => m.Key);
                return !total.Except(applied).Any();            }


            public static void EnsureSeeded(this ApplicationDbContext context)
            {
                //if (!context.Salon.Any())
                //{
                //    //var types = JsonConvert.DeserializeObject<List<Salon>>("coś tam z pliku");
                //   // context.AddRange(types);
                //  //  context.SaveChanges();
                //}
            }
        }
    }


