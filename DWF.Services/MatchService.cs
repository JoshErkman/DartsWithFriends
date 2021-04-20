using DWF.Data;
using DWF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Services
{
    public class MatchService
    {
        public bool CreateMatch(MatchCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                MatchSetup matchSetup = ctx.MatchSetups.Single(e => e.MatchSetupId == model.MatchSetupId);

                var entity =
                    new Match()
                    {
                        MatchSetupId = matchSetup.MatchSetupId,
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
    }
}
