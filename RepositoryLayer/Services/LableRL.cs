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
    using CommonLayer.Request;
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
        public async Task<string> AddLable(LabelRequest labelRequest, int UserId)
        {
            try
            {
                var label = new LabelModel()
                {
                    Lable = labelRequest.Lable,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    UserId = UserId
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
        public async Task<string> DeleteLable(int id, int UserId)
        {
            try
            {
                var lable = this.appDbContext.Lables.Where(g => g.Id == id && g.UserId == UserId).FirstOrDefault();
                if (lable != null)
                {
                    ////****** code to remove entries from NoteLabel tabel
                    var noteLabel = this.appDbContext.NoteLabel.Where(g => g.LabelId == id && g.UserId == UserId).FirstOrDefault();
                    while(noteLabel != null)
                    {
                        this.appDbContext.NoteLabel.Remove(noteLabel);
                        await this.appDbContext.SaveChangesAsync();
                        noteLabel = this.appDbContext.NoteLabel.Where(g => g.LabelId == id && g.UserId == UserId).FirstOrDefault();
                    }
                    ////*******                 
                    
                    this.appDbContext.Lables.Remove(lable);                    
                    await this.appDbContext.SaveChangesAsync();
                    return "Label removed";
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
        public async Task<IList<LabelModel>> GetLables(int UserId)
        {
            List<LabelModel> labelModels = new List<LabelModel>(); 

            foreach(var lable in this.appDbContext.Lables)
            {
                if(lable.UserId == UserId)
                {
                    labelModels.Add(lable);
                }
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
        public async Task<string> UpdateLable(int id, LabelRequest labelRequest, int UserId)
        {
            try
            {
                var lable = this.appDbContext.Lables.Where(g => g.Id == id && g.UserId == UserId).FirstOrDefault();
                if(lable == null)
                {
                    return "Enter valid Id";
                }
                lable.Lable = labelRequest.Lable;
                lable.ModifiedDate = DateTime.Now;
                lable.UserId = UserId;
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
