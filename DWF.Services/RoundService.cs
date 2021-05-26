using DWF.Data;
using DWF.Models;
using DWF.Models.Match;
using DWF.Models.Round;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Services
{
    public class RoundService
    {
        // POST
        public bool CreateRound(RoundCreateMatchEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Match match = ctx.Matches.Single(e => e.MatchId == model.MatchId);
                var entity =
                    new Round()
                    {
                        RoundId = model.RoundId, 
                        TotalRoundPoints = model.TotoalRoundPoints,
                        MatchId = model.MatchId
                    };

                ctx.Rounds.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // GET ALL
        public IEnumerable<RoundListItem> GetRounds()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Rounds
                        .Select(
                            e =>
                                new RoundListItem
                                {
                                    RoundId = e.RoundId,
                                    MatchId = e.MatchId,
                                    TotalPoints = e.TotalRoundPoints
                                }
                        );

                return query.ToArray();
            }
        }

        // GET (by Id)
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
                        TotalPoints = entity.TotalRoundPoints,
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

                entity.TotalRoundPoints = model.TotalPoints;
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
