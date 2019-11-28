//----------------------------------------------------
// <copyright file="LableBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace BussinessLayer.Services
{
    using BussinessLayer.Interfaces;
    using CommonLayer.Model;
    using RepositoryLayer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class LableBL : ILableBL
    {
        private readonly ILableRL repository;

        public LableBL(ILableRL repository)
        {
            this.repository = repository;
        }

        public async Task<string> AddLable(LabelModel lableModel)
        {
            return await this.repository.AddLable(lableModel);
        }

        public async Task<string> DeleteLable(int id)
        {
            return await this.repository.DeleteLable(id);
        }

        public async Task<IList<LabelModel>> GetLable(int id)
        {
            return await this.repository.GetLable(id);
        }

        public async Task<IList<LabelModel>> GetLables()
        {            
            return await this.repository.GetLables();
        }

        public async Task<string> UpdateLable(int id, LabelModel labelModel)
        {
            return await this.repository.UpdateLable(id, labelModel);
        }
    }
}
