using BusinessLayer.Interface;
using CommonLayer.Model;
using CommonLayer.Request;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class CandidateBL : ICandidateBL
    {
        private readonly ICandidateRL repositoryCandidate;

        public CandidateBL(ICandidateRL repositoryCandidate)
        {
            this.repositoryCandidate = repositoryCandidate;
        }

        public async Task<Candidate> AddCandidate(CandidateRequest candidateRequest)
        {
            try
            {
                return await this.repositoryCandidate.AddCandidate(candidateRequest);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteCandidate(int candidateId)
        {
            try
            {
                return await this.repositoryCandidate.DeleteCandidate(candidateId);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<Candidate> GetCandidates()
        {
            try
            {
                return this.repositoryCandidate.GetCandidates();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Candidate> UpdateCandidate(int candidateId, CandidateRequest candidateRequest)
        {
            try
            {
                return await this.repositoryCandidate.UpdateCandidate(candidateId, candidateRequest);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
