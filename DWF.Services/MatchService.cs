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
                        PlayerOneAvgRoundScore = model.PlayerOneAvgRoundScore,
                        PlayerTwoAvgRoundScore = model.PlayerTwoAvgRoundScore
                    };

                ctx.Matches.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool CreateMatch1(int matchsetupid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //MatchSetup matchSetup = ctx.MatchSetups.Single(e => e.MatchSetupId == model.MatchSetupId);

                var entity =
                    new Match()
                    {

                        MatchSetupId = matchsetupid,
                        PlayerOneNeededScore = 501,
                        PlayerTwoNeededScore = 501,
                        PlayerOneAvgRoundScore = 0,
                        PlayerTwoAvgRoundScore = 0
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

                entity.Rounds++;
                entity.PlayerOneNeededScore = entity.PlayerOneNeededScore - model.PlayerOneRoundScore;
                entity.PlayerTwoNeededScore = entity.PlayerTwoNeededScore - model.PlayerTwoRoundScore;
                entity.PlayerOneAvgRoundScore = (entity.PlayerOneAvgRoundScore + model.PlayerOneRoundScore) / entity.Rounds;//change this
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
