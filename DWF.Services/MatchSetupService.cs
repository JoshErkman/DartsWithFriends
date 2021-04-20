﻿using DWF.Data;
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
        private readonly Guid _userId;

        public MatchSetupService (Guid userId)
        {
            _userId = userId;
        }

        // POST
        public bool CreateMatchSetup(MatchSetupCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ApplicationUser opponent = ctx.Users.Single(e => e.UserName == model.OpponentEmail);

                var entity =
                    new MatchSetup()
                    {
                        PlayerOneId = _userId.ToString(),
                        PlayerTwoId = opponent.Id,
                        NumberOfSets = model.NumberOfSets,
                        NumberOfLegs = model.NumberOfLegs
                    };

                ctx.MatchSetups.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // GET
        public IEnumerable<MatchSetupListItem> GetMatchSetupById(int matchSetupId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .MatchSetups
                        .Where(e => e.MatchSetupId == matchSetupId)
                        .Select(
                            e =>
                                new MatchSetupListItem
                                {
                                    MatchSetupId = e.MatchSetupId,
                                    PlayerOneId = e.PlayerOneId,
                                    PlayerTwoId = e.PlayerTwoId,
                                    NumberOfSets = e.NumberOfSets,
                                    NumberOfLegs = e.NumberOfLegs
                                }
                           );
                return query.ToArray();
            }
        }

        //PUT
        public bool UpdateMatchSetup(MatchSetupEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MatchSetups
                        .Single(e => e.MatchSetupId == model.MatchSetupId);

                entity.PlayerOneId = model.PlayerOneId;
                entity.PlayerTwoId = model.PlayerTwoId;
                entity.NumberOfSets = model.NumberOfSets;
                entity.NumberOfLegs = model.NumberOfLegs;

                return ctx.SaveChanges() == 1;
            }
        }

        // DELETE
        public bool DeleteMatchSetup(int matchSetupId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MatchSetups
                        .Single(e => e.MatchSetupId == matchSetupId);

                ctx.MatchSetups.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}