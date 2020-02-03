using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Model;
using CommonLayer.Request;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service
{
    public class ConstituentBL : IConstituentBL
    {
        private readonly IConstituentRL repositoryConstituent;

        public ConstituentBL(IConstituentRL repositoryConstituent)
        {
            this.repositoryConstituent = repositoryConstituent;
        }

        public async Task<Constituency> AddConstituent(ConstituentRequest constituentRequest)
        {
            try
            {
                return await this.repositoryConstituent.AddConstituent(constituentRequest);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteConstituent(int constituentId)
        {
            try
            {
                return await this.repositoryConstituent.DeleteConstituent(constituentId);
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
                return await this.repositoryConstituent.UpdateConstituent(constituentId, constituentRequest);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<Constituency> GetConstituencies()
        {
            try
            {
                return this.repositoryConstituent.GetConstituencies();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
