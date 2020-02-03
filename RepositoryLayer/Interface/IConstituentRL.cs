using CommonLayer.Model;
using CommonLayer.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IConstituentRL
    {
        Task<Constituency> AddConstituent(ConstituentRequest constituentRequest);

        Task<bool> DeleteConstituent(int constituentId);

        Task<Constituency> UpdateConstituent(int constituentId, ConstituentRequest constituentRequest);

        IList<Constituency> GetConstituencies();
    }
}
