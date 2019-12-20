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
        Task<LabelModel> AddLable(LabelRequest labelRequest, int UserId);

        Task<bool> DeleteLable(int id, int UserId);

        Task<LabelModel> UpdateLable(int id, LabelRequest labelRequest, int UserId);

        Task<IList<LabelModel>> GetLables(int UserId);

        Task<IList<LabelModel>> GetLable(int id, int UserId);
    }
}
