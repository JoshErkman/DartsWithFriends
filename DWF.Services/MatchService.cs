using DWF.Data;
using DWF.Models;
using DWF.Models.Match;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Services
{
    public class MatchService
    {
        // POST
        public bool CreateMatch(MatchCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //MatchSetup matchSetup = ctx.MatchSetups.Single(e => e.MatchSetupId == model.MatchSetupId);

                var entity =
                    new Match()
                    {
                        MatchId = model.MatchId,
                        MatchSetupId = model.MatchSetupId,
                        PlayerOneNeededScore = model.PlayerOneNeededScore,
                        PlayerTwoNeededScore = model.PlayerTwoNeededScore,
                        SetScore = model.SetScore,
                        LegScore = model.LegScore,
                        PlayerOneAvgRoundScore = model.PlayerOneAvgRoundScore,
                        PlayerTwoAvgRoundScore = model.PlayerTwoAvgRoundScore
                    };

                ctx.Matches.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        
        // GET (all)
        public IEnumerable<MatchListItem> GetMatches()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Matches
                        .Select(
                            e =>
                                new MatchListItem
                                {
                                    MatchId = e.MatchId,
                                    MatchSetupId = e.MatchSetupId,
                                    PlayerOneNeededScore = e.PlayerOneNeededScore,
                                    PlayerTwoNeededScore = e.PlayerTwoNeededScore,
                                    SetScore = e.SetScore,
                                    LegScore = e.LegScore,
                                    PlayerOneAvgRoundScore = e.PlayerOneAvgRoundScore,
                                    PlayerTwoAvgRoundScore = e.PlayerTwoAvgRoundScore
                                }
                        );

                return query.ToArray();
            }
        }

        // GET (by id)
        public MatchDetail GetMatchById(int matchId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Matches
                        .Single(e => e.MatchId == matchId);

                return
                    new MatchDetail
                    {
                        MatchId = entity.MatchId,
                        MatchSetupId = entity.MatchSetupId,
                        PlayerOneNeededScore = entity.PlayerOneNeededScore,
                        PlayerTwoNeededScore = entity.PlayerTwoNeededScore,
                        SetScore = entity.SetScore,
                        LegScore = entity.LegScore,
                        PlayerOneAvgRoundScore = entity.PlayerOneAvgRoundScore,
                        PlayerTwoAvgRoundScore = entity.PlayerTwoAvgRoundScore
                    };
            }
        }

        // PUT
        public bool UpdateMatch(MatchEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Matches
                        .Single(e => e.MatchId == model.MatchId);

                entity.MatchId = model.MatchId;
                entity.PlayerOneNeededScore = model.PlayerOneNeededScore;
                entity.PlayerTwoNeededScore = model.PlayerTwoNeededScore;
                entity.SetScore = model.SetScore;
                entity.LegScore = model.LegScore;
                entity.PlayerOneAvgRoundScore = model.PlayerOneAvgRoundScore;
                entity.PlayerTwoAvgRoundScore = model.PlayerTwoAvgRoundScore;

                return ctx.SaveChanges() == 1;
            }
        }

        // DELETE
        public bool DeleteMatch(int matchId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Matches
                        .Single(e => e.MatchId == matchId);

                ctx.Matches.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
