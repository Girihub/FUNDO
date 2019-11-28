using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface ILableRL
    {
        Task<string> AddLable(LabelModel lableModel);

        Task<string> DeleteLable(int id);

        Task<string> UpdateLable(int id, LabelModel labelModel);

        Task<IList<LabelModel>> GetLables();

        Task<IList<LabelModel>> GetLable(int id);
    }
}
