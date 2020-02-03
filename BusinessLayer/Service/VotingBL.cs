using BusinessLayer.Interface;
using CommonLayer.Model;
using CommonLayer.Request;
using CommonLayer.Response;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class VotingBL : IVotingBL
    {
        private readonly IVotingRL repositoryVoting;

        public VotingBL(IVotingRL repositoryVoting)
        {
            this.repositoryVoting = repositoryVoting;
        }

        public async Task<UserVoting> Vote(VotingRequest votingRequest)
        {
            try
            {
                return await this.repositoryVoting.Vote(votingRequest);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> ReElection()
        {
            try
            {
                return await this.repositoryVoting.ReElection();
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
                return this.repositoryVoting.ConstituencyWiseResult(constituencyId);
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
                return this.repositoryVoting.PartWiseResultState(state);
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
                return this.repositoryVoting.PartyWiseAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
