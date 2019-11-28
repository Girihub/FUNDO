//----------------------------------------------------
// <copyright file="LableBL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace BussinessLayer.Services
{
    using BussinessLayer.Interfaces;
    using CommonLayer.Constants;
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
            try
            {
                if(lableModel != null)
                {
                    return await this.repository.AddLable(lableModel);
                }
                else
                {
                    return ErrorMessages.nullModel;
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }            
        }

        public async Task<string> DeleteLable(int id)
        {
            try
            {
                if(id.Equals(null))
                {
                    return ErrorMessages.invalidId;
                }
                else
                {
                    return await this.repository.DeleteLable(id);
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }            
        }

        public async Task<IList<LabelModel>> GetLable(int id)
        {
            try
            {
                if (!id.Equals(null))
                {
                    return await this.repository.GetLable(id);
                }
                else
                {
                    throw new Exception(ErrorMessages.invalidId);
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }            
        }

        public async Task<IList<LabelModel>> GetLables()
        {
            try
            {
                return await this.repository.GetLables();
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }            
        }

        public async Task<string> UpdateLable(int id, LabelModel labelModel)
        {
            try
            {
                if (labelModel != null)
                {
                    return await this.repository.UpdateLable(id, labelModel);
                }
                else
                {
                    return ErrorMessages.nullModel;
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }            
        }
    }
}
