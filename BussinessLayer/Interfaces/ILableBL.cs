//----------------------------------------------------
// <copyright file="ILableBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace BussinessLayer.Interfaces
{
    using CommonLayer.Model;
    using CommonLayer.Request;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILableBL
    {
        Task<string> AddLable(LabelRequest labelRequest, int UserId);

        Task<string> DeleteLable(int id, int UserId);

        Task<string> UpdateLable(int id, LabelRequest labelRequest, int UserId);

        Task<IList<LabelModel>> GetLables(int UserId);

        Task<IList<LabelModel>> GetLable(int id);
    }
}
