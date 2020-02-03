namespace RepositoryLayer.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CommonLayer.Model;
    using CommonLayer.Request;
    using Microsoft.EntityFrameworkCore;
    using RepositoryLayer.Context;
    using RepositoryLayer.Interface;

    public class PartyRL : IPartyRL
    {
        private readonly AuthenticationContext authenticationContext;

        public PartyRL(AuthenticationContext authenticationContext)
        {
            this.authenticationContext = authenticationContext;
        }
        public async Task<Party> AddParty(PartyRequest partyRequest)
        {
            try
            {
                var party = this.authenticationContext.Parties.Where(c => c.PartyName.ToLower() == partyRequest.PartyName.ToLower()).FirstOrDefault();

                Party newParty = new Party();
                if(party == null)
                {
                    newParty.PartyName = partyRequest.PartyName;
                    newParty.CreatedDate = DateTime.Now;
                    newParty.ModifiedDate = DateTime.Now;
                    this.authenticationContext.Parties.Add(newParty);
                    await this.authenticationContext.SaveChangesAsync();
                    return newParty;
                }

                return newParty;
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
                var party = this.authenticationContext.Parties.Where(c => c.Id == partyId).FirstOrDefault();

                if (party == null)
                {
                    return false;
                }
                else
                {
                    this.authenticationContext.Parties.Remove(party);
                    await this.authenticationContext.SaveChangesAsync();
                    return true;
                }
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
                var party = this.authenticationContext.Parties.Where(c => c.Id == partyId).FirstOrDefault();

                if (party == null)
                {
                    Party newParty = new Party();
                    return newParty;
                }
                else
                {
                    party.ModifiedDate = DateTime.Now;
                    party.PartyName = partyRequest.PartyName;
                    this.authenticationContext.Entry(party).State = EntityState.Modified;
                    await this.authenticationContext.SaveChangesAsync();
                    return party;
                }
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
                var allParties = this.authenticationContext.Parties;
                List<Party> parties = new List<Party>();
                foreach(var party in allParties)
                {
                    parties.Add(party);
                }
                return parties;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
