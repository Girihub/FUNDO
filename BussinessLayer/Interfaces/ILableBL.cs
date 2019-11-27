//----------------------------------------------------
// <copyright file="ILableBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace BussinessLayer.Interfaces
{
    using CommonLayer.Model;

    public interface ILableBL
    {
        string AddLable(LabelModel lableModel);

        string DeleteLable(int id);

        string UpdateLable(int id, LabelModel labelModel);

        string GetLables();

        string GetLable(int id);
    }
}
