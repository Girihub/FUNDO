using CommonLayer.Model;
using CommonLayer.Request;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class ConstituentRL : IConstituentRL
    {
        private readonly AuthenticationContext authenticationContext;

        public ConstituentRL(AuthenticationContext authenticationContext)
        {
            this.authenticationContext = authenticationContext;
        }

        public async Task<Constituency> AddConstituent(ConstituentRequest constituentRequest)
        {
            try
            {
                var constituent = this.authenticationContext.Constituencies.Where(c => c.Name.ToLower().Equals(constituentRequest.Name.ToLower()) && c.State.ToLower().Equals(constituentRequest.State.ToLower())).FirstOrDefault();

                Constituency constituency = new Constituency();
                if (constituent == null)
                {
                    constituency.Name = constituentRequest.Name;
                    constituency.State = constituentRequest.State;
                    constituency.CreatedDate = DateTime.Now;
                    constituency.ModifiedDate = DateTime.Now;
                    this.authenticationContext.Constituencies.Add(constituency);
                    await this.authenticationContext.SaveChangesAsync();
                    return constituency;
                }

                return constituency;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteConstituent(int constituentId)
        {
            try
            {
                var constituent = this.authenticationContext.Constituencies.Where(c => c.Id == constituentId).FirstOrDefault();

                if (constituent == null)
                {
                    return false;
                }
                else
                {
                    this.authenticationContext.Constituencies.Remove(constituent);
                    await this.authenticationContext.SaveChangesAsync();
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Constituency> UpdateConstituent(int constituentId, ConstituentRequest constituentRequest)
        {
            try
            {
                var constituent = this.authenticationContext.Constituencies.Where(c => c.Id == constituentId).FirstOrDefault();

                if (constituent == null)
                {
                    return constituent;
                }
                else
                {
                    constituent.Name = constituentRequest.Name;
                    constituent.State = constituentRequest.State;
                    constituent.ModifiedDate = DateTime.Now;
                    this.authenticationContext.Entry(constituent).State = EntityState.Modified;
                    await this.authenticationContext.SaveChangesAsync();
                    return constituent;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<Constituency> GetConstituencies()
        {
            try
            {
                var allConstituencies = this.authenticationContext.Constituencies;

                List<Constituency> constituencies = new List<Constituency>();

                foreach(var constituency in allConstituencies)
                {
                    constituencies.Add(constituency);
                }

                return constituencies;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
