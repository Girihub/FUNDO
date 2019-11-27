//----------------------------------------------------
// <copyright file="AuthenticationContext.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace RepositoryLayer.Context
{
    using CommonLayer.Model;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// AuthenticationContext as a class
    /// </summary>
    public class AuthenticationContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationContext"/> class.
        /// </summary>
        /// <param name="options">options as a parameter</param>
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options)
        {            
        }

        /// <summary>
        /// Gets or sets for Registration. Creates Database for Registration
        /// </summary>
        public DbSet<RegistrationModel> Registration { get; set; }

        public DbSet<RegistrationModel> Notes { get; set; }

        public DbSet<RegistrationModel> Lables { get; set; }


    }
}
