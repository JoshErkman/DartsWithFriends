using DWF.Data;
using DWF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Services
{
    class RoundService
    {
        public bool CreateRound(RoundCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Match match = ctx.Matches.Single(e => e.MatchId == model.MatchId);
                var entity =
                    new Round()
                    {
                        TotalPoints = model.TotalPoints,
                        MatchId = match.MatchId
                    };

                ctx.Rounds.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        
    }
}
