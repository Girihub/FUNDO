using CommonLayer.Model;
using CommonLayer.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface ILableRL
    {
        Task<string> AddLable(LabelRequest labelRequest, int UserId);

        Task<string> DeleteLable(int id, int UserId);

        Task<string> UpdateLable(int id, LabelRequest labelRequest, int UserId);

        Task<IList<LabelModel>> GetLables(int UserId);

        Task<IList<LabelModel>> GetLable(int id);
    }
}
