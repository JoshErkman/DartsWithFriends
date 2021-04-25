using DWF.Data;
using DWF.Models;
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

        public MatchSetupService(Guid userId)
        {
            _userId = userId;
        }

        // POST
        public bool CreateMatchSetup(MatchSetupCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
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

                catch(InvalidOperationException e)
                {
                    return false;
                }
            }
        }

        // public IEnumerable<UserInfo> GetUsers()
        // {
        //     using (var ctx = new ApplicationDbContext())
        //     {
        //         var query =
        //             ctx
        //                 .Users
        //                 .Where(e => e.Id == e.Id)
        //                 .Select(
        //                     e =>
        //                     new UserInfo
        //                     {
        //                         Email = e.Email
        //                     }
        //                 );
        //
        //         return query.ToList();
        //     }
        // }

        public bool ValidateEmail(MatchSetupCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    ApplicationUser opponent = ctx.Users.Single(e => e.UserName == model.OpponentEmail);
                    return true;
                }

                catch (InvalidOperationException)
                {
                    return false;
                }
            }
        }

        public IEnumerable<UserInfo> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Users
                        .Where(e => e.Id == e.Id)
                        .Select(
                            e =>
                            new UserInfo
                            {
                                Id = e.Id,
                                Email = e.Email
                            }
                        );

                return query.ToList();
            }
        }

        // GET (all)
        public IEnumerable<MatchSetupListItem> GetMatchSetups()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .MatchSetups
                        .Where(e => e.PlayerOneId == _userId.ToString())
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

        // GET (by Id)
        public MatchSetupDetail GetMatchSetupById(int matchSetupId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MatchSetups
                        .Single(e => e.MatchSetupId == matchSetupId);
                return
                    new MatchSetupDetail
                    {
                        MatchSetupId = entity.MatchSetupId,
                        PlayerOneId = entity.PlayerOneId,
                        PlayerTwoId = entity.PlayerTwoId,
                        NumberOfSets = entity.NumberOfSets,
                        NumberOfLegs = entity.NumberOfLegs
                    };
            }
        }

        //PUT
        public bool UpdateMatchSetup(MatchSetupEdit model)
        {
            using (var ctx = new ApplicationDbContext())
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
