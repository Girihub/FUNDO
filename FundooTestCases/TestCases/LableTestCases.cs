//----------------------------------------------------
// <copyright file="LableTestCases.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace FundooTestCases.TestCases
{
    using System;
    using BussinessLayer.Services;
    using CommonLayer.Model;
    using Moq;
    using RepositoryLayer.Interfaces;    
    using Xunit;

    /// <summary>
    /// test cases for labels
    /// </summary>
    public class LableTestCases
    {
        /// <summary>
        /// test case for add label
        /// </summary>
        [Fact]
        public void AddLable()
        {
            ////creating a fake instance of registration interfcae.
            var repository = new Mock<ILableRL>();
            var business = new LableBL(repository.Object);
            var model = new LabelModel()
            {
                Lable = "label",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                UserId = 1
            };

            //// act          
            var data = business.AddLable(model);

            ////assert
            Assert.NotNull(data);
        }

        /// <summary>
        /// test case for delete label
        /// </summary>
        [Fact]
        public void DeleteLable()
        {
            ////creating a fake instance of registration interfcae.
            var repository = new Mock<ILableRL>();
            var business = new LableBL(repository.Object);
            var model = new LabelModel()
            {
                Id = 1
            };

            //// act          
            var data = business.DeleteLable(model.Id);

            ////assert
            Assert.NotNull(data);
        }

        /// <summary>
        /// test case for update label
        /// </summary>
        [Fact]
        public void UpdateLable()
        {
            ////creating a fake instance of registration interfcae.
            var repository = new Mock<ILableRL>();
            var business = new LableBL(repository.Object);
            var model = new LabelModel()
            {
                Id = 1,
                Lable = "label",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                UserId = 1
            };

            //// act          
            var data = business.UpdateLable(model.Id, model);

            ////assert
            Assert.NotNull(data);
        }
    }
}
