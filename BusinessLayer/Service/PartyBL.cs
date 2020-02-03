using BusinessLayer.Interface;
using CommonLayer.Model;
using CommonLayer.Request;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class PartyBL : IPartyBL
    {
        private readonly IPartyRL repositoryParty;

        public PartyBL(IPartyRL repositoryParty)
        {
            this.repositoryParty = repositoryParty;
        }

        public async Task<Party> AddParty(PartyRequest partyRequest)
        {
            try
            {
                return await this.repositoryParty.AddParty(partyRequest);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteParty(int partyId)
        {
            try
            {
                return await this.repositoryParty.DeleteParty(partyId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Party> UpdateParty(int partyId, PartyRequest partyRequest)
        {
            try
            {
                return await this.repositoryParty.UpdateParty(partyId, partyRequest);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<Party> GetParties()
        {
            try
            {
                return this.repositoryParty.GetParties();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
