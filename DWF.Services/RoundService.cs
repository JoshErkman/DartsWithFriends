using DWF.Data;
using DWF.Models;
using DWF.Models.Round;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Services
{
    class RoundService
    {
        // POST
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

        // GET
        public RoundDetail GetRoundById(int roundId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rounds
                        .Single(e => e.RoundId == roundId);

                return
                    new RoundDetail
                    {
                        RoundId = entity.RoundId,
                        TotalPoints = entity.TotalPoints,
                        MatchId = entity.MatchId
                    };
            }
        }

        // PUT
        public bool UpdateRound(RoundEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rounds
                        .Single(e => e.RoundId == model.RoundId);

                entity.TotalPoints = model.TotalPoints;
                entity.MatchId = model.MatchId;

                return ctx.SaveChanges() == 1;
            }
        }

        // DELETE
        public bool DeleteRound(int roundId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rounds
                        .Single(e => e.RoundId == roundId);

                ctx.Rounds.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
