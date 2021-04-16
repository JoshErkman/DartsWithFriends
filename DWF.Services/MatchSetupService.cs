using DWF.Data;
using DWF.Models.MatchSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWF.Services
{
    public class MatchSetupService
    {
        public bool CreateMatchSetup(MatchSetupCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ApplicationUser opponent = ctx.Users.Single(e => e.UserName == model.OpponentEmail);

                var entity =
                    new MatchSetup()
                    {
                        PlayerOneId = model.PlayerOneId,
                        PlayerTwoId = opponent.Id,
                        NumberOfSets = model.NumberOfSets,
                        NumberOfLegs = model.NumberOfLegs
                    };

                ctx.MatchSetups.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
