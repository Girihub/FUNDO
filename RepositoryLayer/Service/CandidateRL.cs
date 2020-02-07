using CommonLayer.Model;
using CommonLayer.Request;
using CommonLayer.Response;
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
    public class CandidateRL : ICandidateRL
    {
        private readonly AuthenticationContext authenticationContext;

        public CandidateRL(AuthenticationContext authenticationContext)
        {
            this.authenticationContext = authenticationContext;
        }

        public async Task<Candidate> AddCandidate(CandidateRequest candidateRequest)
        {
            try
            {
                var candidate = this.authenticationContext.Candidates.Where(c => (c.FirstName.ToLower().Equals(candidateRequest.FirstName.ToLower()) && c.LastName.ToLower().Equals(candidateRequest.LastName.ToLower())) || (c.PartyId == candidateRequest.PartyId && c.ConstituencyId == candidateRequest.ConstituencyId)).FirstOrDefault();

                var party = this.authenticationContext.Parties.Where(c => c.Id == candidateRequest.PartyId).FirstOrDefault();

                var constituency = this.authenticationContext.Constituencies.Where(c => c.Id == candidateRequest.ConstituencyId).FirstOrDefault();

                Candidate newCandidate = new Candidate();

                if(candidate == null && party!= null && constituency != null)
                {
                    newCandidate.FirstName = candidateRequest.FirstName;
                    newCandidate.LastName = candidateRequest.LastName;
                    newCandidate.PartyId = candidateRequest.PartyId;
                    newCandidate.ConstituencyId = candidateRequest.ConstituencyId;
                    newCandidate.CreatedDate = DateTime.Now;
                    newCandidate.ModifiedDate = DateTime.Now;
                    newCandidate.Votes = 0;

                    this.authenticationContext.Candidates.Add(newCandidate);
                    await this.authenticationContext.SaveChangesAsync();
                    return newCandidate;
                }

                return newCandidate;
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
                var candidate = this.authenticationContext.Candidates.Where(c => c.Id == candidateId).FirstOrDefault();

                if (candidate == null)
                {
                    return false;
                }
                else
                {
                    this.authenticationContext.Candidates.Remove(candidate);
                    await this.authenticationContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<CandidateResponse> GetCandidates()
        {
            try
            {
                var allCandidates = this.authenticationContext.Candidates;

                List<CandidateResponse> candidates = new List<CandidateResponse>();

                var newTable = (from c in this.authenticationContext.Candidates
                                join p in this.authenticationContext.Parties
                                on c.PartyId equals p.Id
                                join con in this.authenticationContext.Constituencies
                                on c.ConstituencyId equals con.Id

                                select new CandidateResponse()
                                {
                                    Id = c.Id,
                                    FirstName = c.FirstName,
                                    LastName = c.LastName,
                                    PartyId = c.PartyId,
                                    PartyName = p.PartyName,
                                    ConstituencyId = con.Id,
                                    ConstituencyName = con.Name,
                                    Votes = c.Votes
                                }
                              ).ToList();

                foreach (var candidate in newTable)
                {
                    candidates.Add(candidate);
                }

                return candidates;
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
                var candidate = this.authenticationContext.Candidates.Where(c => c.Id == candidateId).FirstOrDefault();

                var party = this.authenticationContext.Parties.Where(c => c.Id == candidateRequest.PartyId).FirstOrDefault();

                var constituency = this.authenticationContext.Constituencies.Where(c => c.Id == candidateRequest.ConstituencyId).FirstOrDefault();

                if (candidate == null || party == null || constituency == null)
                {
                    Candidate newCandidate = new Candidate();
                    return newCandidate;
                }
                else
                {
                    candidate.FirstName = candidateRequest.FirstName;
                    candidate.LastName = candidateRequest.LastName;
                    candidate.PartyId = candidateRequest.PartyId;
                    candidate.ConstituencyId = candidateRequest.ConstituencyId;
                    candidate.ModifiedDate = DateTime.Now;

                    this.authenticationContext.Entry(candidate).State = EntityState.Modified;
                    await this.authenticationContext.SaveChangesAsync();
                    return candidate;

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
