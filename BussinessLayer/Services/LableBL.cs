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
    using CommonLayer.Request;
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

        public async Task<string> AddLable(LabelRequest labelRequest, int UserId)
        {
            try
            {
                if(labelRequest != null)
                {
                    return await this.repository.AddLable(labelRequest, UserId);
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

        public async Task<string> DeleteLable(int id, int UserId)
        {
            try
            {
                if(id.Equals(null))
                {
                    return ErrorMessages.invalidId;
                }
                else
                {
                    return await this.repository.DeleteLable(id, UserId);
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

        public async Task<IList<LabelModel>> GetLables(int UserId)
        {
            try
            {
                return await this.repository.GetLables(UserId);
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }            
        }

        public async Task<string> UpdateLable(int id, LabelRequest labelRequest, int UserId)
        {
            try
            {
                if (labelRequest != null)
                {
                    return await this.repository.UpdateLable(id, labelRequest, UserId);
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
