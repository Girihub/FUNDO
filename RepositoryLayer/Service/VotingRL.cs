using CommonLayer.Model;
using CommonLayer.Request;
using CommonLayer.Response;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class VotingRL : IVotingRL
    {
        private readonly AuthenticationContext authenticationContext;

        public VotingRL(AuthenticationContext authenticationContext)
        {
            this.authenticationContext = authenticationContext;
        }

        public async Task<UserVoting> Vote(VotingRequest votingRequest)
        {
            try
            {
                var vote = this.authenticationContext.UserVotings.Where(c => c.MobileNumber == votingRequest.MobileNumber).FirstOrDefault();

                var candidate = this.authenticationContext.Candidates.Where(c => c.Id == votingRequest.CandidateId).FirstOrDefault();

                UserVoting userVoting = new UserVoting();

                if(vote != null || candidate == null)
                {
                    return userVoting;
                }
                else
                {
                    userVoting.FirstName = votingRequest.FirstName;
                    userVoting.LastName = votingRequest.LastName;
                    userVoting.MobileNumber = votingRequest.MobileNumber;
                    userVoting.CandidateId = votingRequest.CandidateId;
                    userVoting.CreatedDate = DateTime.Now;
                    userVoting.ModifiedDate = DateTime.Now;

                    this.authenticationContext.UserVotings.Add(userVoting);
                    await this.authenticationContext.SaveChangesAsync();
                    candidate.Votes = candidate.Votes + 1;
                    await this.authenticationContext.SaveChangesAsync();
                    return userVoting;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> ReElection()
        {
            try
            {
                var userVoting = this.authenticationContext.UserVotings;

                if (!userVoting.Any())
                {
                    return false;
                }
                else
                {
                    foreach(var candidate in this.authenticationContext.Candidates)
                    {
                        candidate.Votes = 0;
                    }
                    await this.authenticationContext.SaveChangesAsync();

                    foreach(var voters in this.authenticationContext.UserVotings)
                    {
                        this.authenticationContext.UserVotings.Remove(voters);
                    }

                    await this.authenticationContext.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<ConstituencyWiseResponse> ConstituencyWiseResult(int constituencyId)
        {
            try
            {
                List<ConstituencyWiseResponse> result = new List<ConstituencyWiseResponse>();
                var constituency = this.authenticationContext.Constituencies.Where(c => c.Id == constituencyId).FirstOrDefault();

                var candidates = this.authenticationContext.Candidates.Where(c => c.ConstituencyId == constituencyId);

                var parties = this.authenticationContext.Parties;

                if (constituency == null)
                {
                    return result;
                }

                var newTabel = (from c in this.authenticationContext.Candidates
                                join p in this.authenticationContext.Parties
                                on c.PartyId equals p.Id
                                where c.ConstituencyId == constituencyId
                                select new ConstituencyWiseResponse()
                                {
                                    FirstName=c.FirstName,
                                    LastName=c.LastName,
                                    PartyName=p.PartyName,
                                    Votes=c.Votes
                                }
                                ).ToList();

                foreach(var tabel in newTabel)
                {
                    result.Add(tabel);
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<PartyWiseResponse> PartWiseResultState(string state)
        {
            try
            {
                List<PartyWiseResponse> partyWiseResponses = new List<PartyWiseResponse>();

                var constituencies = this.authenticationContext.Constituencies.Where(c => c.State.ToLower().Equals(state.ToLower()));

                if (state.Equals("All"))
                {
                    constituencies = this.authenticationContext.Constituencies;
                } 

                if (constituencies == null)
                {
                    return partyWiseResponses;
                }

                foreach(var constituency in constituencies)
                {
                    var newTabel = (from can in this.authenticationContext.Candidates
                                    join p in this.authenticationContext.Parties
                                    on can.PartyId equals p.Id
                                    where can.ConstituencyId == constituency.Id

                                    select new PartyWiseResponse()
                                    {
                                        PartyName = p.PartyName,
                                        Votes = can.Votes
                                    }
                                    ).ToList();
                    foreach(var tabel in newTabel)
                    {
                        bool flag = false;
                        foreach(var partyWiseResponse in partyWiseResponses)
                        {
                            if (tabel.PartyName == partyWiseResponse.PartyName)
                            {
                                partyWiseResponse.Votes = tabel.Votes+partyWiseResponse.Votes;
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            partyWiseResponses.Add(tabel);
                        }
                    }                    
                }

                return partyWiseResponses;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<PartyWiseAll> PartyWiseAll()
        {
            try
            {
                List<PartyWiseAll> result = new List<PartyWiseAll>();

                var candidates = this.authenticationContext.Candidates;

                if (!candidates.Any())
                {
                    return result;
                }

                var newTabel = (from can in this.authenticationContext.Candidates
                                join p in this.authenticationContext.Parties
                                on can.PartyId equals p.Id
                                join con in this.authenticationContext.Constituencies
                                on can.ConstituencyId equals con.Id

                                select new PartyWiseAll()
                                {
                                    CandidateName = can.FirstName + " " + can.LastName,
                                    Votes = can.Votes,
                                    ConstituencyName = con.Name,
                                    PartyName = p.PartyName,
                                    State=con.State
                                }
                                ).ToList();

                foreach(var tabel in newTabel)
                {
                    result.Add(tabel);
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
