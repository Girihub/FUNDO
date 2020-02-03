using CommonLayer.Model;
using CommonLayer.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface ICandidateRL
    {
        Task<Candidate> AddCandidate(CandidateRequest candidateRequest);

        Task<bool> DeleteCandidate(int candidateId);

        Task<Candidate> UpdateCandidate(int candidateId, CandidateRequest candidateRequest);

        IList<Candidate> GetCandidates();
    }
}
