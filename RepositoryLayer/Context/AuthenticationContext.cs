using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Context
{
    public class AuthenticationContext : DbContext
    {
        public AuthenticationContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<RegistrationModel> Registration { get; set; }        
       
    }
}
