using CommonLayer.Model;
using CommonLayer.Request;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IVotingRL
    {
        Task<UserVoting> Vote(VotingRequest votingRequest);

        Task<bool> ReElection();

        IList<ConstituencyWiseResponse> ConstituencyWiseResult(int constituencyId);

        IList<PartyWiseResponse> PartWiseResultState(string state);

        IList<PartyWiseAll> PartyWiseAll();

        IList<AllVoters> AllVoters();
    }
}
