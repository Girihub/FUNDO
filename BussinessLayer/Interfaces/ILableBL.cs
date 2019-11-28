//----------------------------------------------------
// <copyright file="ILableBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace BussinessLayer.Interfaces
{
    using CommonLayer.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILableBL
    {
        Task<string> AddLable(LabelModel lableModel);

        Task<string> DeleteLable(int id);

        Task<string> UpdateLable(int id, LabelModel labelModel);

        Task<IList<LabelModel>> GetLables();

        Task<IList<LabelModel>> GetLable(int id);
    }
}
