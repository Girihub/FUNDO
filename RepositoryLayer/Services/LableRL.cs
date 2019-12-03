//----------------------------------------------------
// <copyright file="LableRL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace RepositoryLayer.Services
{
    using CommonLayer.Model;
    using Microsoft.EntityFrameworkCore;
    using RepositoryLayer.Context;
    using RepositoryLayer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class LableRL : ILableRL
    {
        private readonly AuthenticationContext appDbContext;

        public LableRL(AuthenticationContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<string> AddLable(LabelModel lableModel)
        {
            try
            {
                this.appDbContext.Lables.Add(lableModel);
                await this.appDbContext.SaveChangesAsync();
                return "Lable Added";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> DeleteLable(int id)
        {
            try
            {
                var lable = this.appDbContext.Lables.Where(g => g.Id == id).FirstOrDefault();
                if(lable != null)
                {
                    this.appDbContext.Remove(lable);
                    await this.appDbContext.SaveChangesAsync();
                    return "Lable removed";
                }

                return "Enter valid id";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IList<LabelModel>> GetLable(int id)
        {
            try
            {
                List<LabelModel> labelModels = new List<LabelModel>();
                var lable = this.appDbContext.Lables.Where(g => g.Id == id).FirstOrDefault();
                if(lable == null)
                {
                    throw new Exception();
                }

                labelModels.Add(lable);
                await this.appDbContext.SaveChangesAsync();
                return labelModels;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IList<LabelModel>> GetLables()
        {
            List<LabelModel> labelModels = new List<LabelModel>(); 

            foreach(var lable in this.appDbContext.Lables)
            {
                labelModels.Add(lable);
            }
            await this.appDbContext.SaveChangesAsync();
            return labelModels;
            
        }

        public async Task<string> UpdateLable(int id, LabelModel labelModel)
        {
            try
            {
                var lable = this.appDbContext.Lables.Where(g => g.Id == id).FirstOrDefault();
                if(lable == null)
                {
                    return "Enter valid Id";
                }
                lable.Lable = labelModel.Lable;
                lable.CreatedDate = labelModel.CreatedDate;
                lable.ModifiedDate = labelModel.ModifiedDate;
                lable.UserId = labelModel.UserId;
                appDbContext.Entry(lable).State = EntityState.Modified;
                await this.appDbContext.SaveChangesAsync();
                return "Updated...";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
