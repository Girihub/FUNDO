using CommonLayer.Model;
using CommonLayer.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IPartyBL
    {
        Task<Party> AddParty(PartyRequest partyRequest);

        Task<bool> DeleteParty(int partyId);

        Task<Party> UpdateParty(int partyId, PartyRequest partyRequest);

        IList<Party> GetParties();
    }
}
