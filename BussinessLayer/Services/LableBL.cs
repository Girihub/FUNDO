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
    using ServiceStack.Redis;
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

        public async Task<LabelModel> AddLable(LabelRequest labelRequest, int UserId)
        {
            try
            {
                return await this.repository.AddLable(labelRequest, UserId);
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }            
        }

        public async Task<bool> DeleteLable(int id, int UserId)
        {
            try
            {
                return await this.repository.DeleteLable(id, UserId);
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }            
        }

        public async Task<IList<LabelModel>> GetLable(int id, int UserId)
        {
            try
            {
                return await this.repository.GetLable(id, UserId);
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

        public async Task<LabelModel> UpdateLable(int id, LabelRequest labelRequest, int UserId)
        {
            try
            {
                return await this.repository.UpdateLable(id, labelRequest, UserId);
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }            
        }
    }
}
