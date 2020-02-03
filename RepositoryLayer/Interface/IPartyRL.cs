using CommonLayer.Model;
using CommonLayer.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IPartyRL
    {
        Task<Party> AddParty(PartyRequest partyRequest);

        Task<bool> DeleteParty(int partyId);

        Task<Party> UpdateParty(int partyId, PartyRequest partyRequest);

        IList<Party> GetParties();
    }
}
