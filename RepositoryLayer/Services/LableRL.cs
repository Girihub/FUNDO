//----------------------------------------------------
// <copyright file="LableRL.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace RepositoryLayer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CommonLayer.Model;
    using Microsoft.EntityFrameworkCore;
    using RepositoryLayer.Context;
    using RepositoryLayer.Interfaces;

    /// <summary>
    /// LableRL as a class
    /// </summary>
    public class LableRL : ILableRL
    {
        /// <summary>
        /// private field appDBContext to access database
        /// </summary>
        private readonly AuthenticationContext appDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="LableRL"/> class.
        /// </summary>
        /// <param name="appDbContext">appDBContext as a parameter</param>
        public LableRL(AuthenticationContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        /// <summary>
        /// Method implementation to add label
        /// </summary>
        /// <param name="lableModel">lableModel as a parameter</param>
        /// <returns>returns result in string format</returns>
        public async Task<string> AddLable(LabelModel lableModel)
        {
            try
            {
                var label = new LabelModel()
                {
                    Lable = lableModel.Lable,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    UserId = lableModel.UserId
                };
                
                this.appDbContext.Lables.Add(label);
                await this.appDbContext.SaveChangesAsync();
                return "Lable Added";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method to delete label
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <returns>returns result in string format</returns>
        public async Task<string> DeleteLable(int id)
        {
            try
            {
                var lable = this.appDbContext.Lables.Where(g => g.Id == id).FirstOrDefault();
                if (lable != null)
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

        /// <summary>
        /// Method to dispaly label by id
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <returns>returns result in list format</returns>
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

        /// <summary>
        /// Method to dispaly all labels
        /// </summary>
        /// <returns>returns result in list format</returns>
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

        /// <summary>
        /// Method to update label
        /// </summary>
        /// <param name="id">id as a parameter</param>
        /// <param name="labelModel">labelModel as a parameter</param>
        /// <returns>returns result in string format</returns>
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
                this.appDbContext.Entry(lable).State = EntityState.Modified;
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
