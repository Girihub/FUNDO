using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Context
{
    public class AuthenticationContext : DbContext
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options): base(options)
        {

        }

        public DbSet<Admin> Admin { get; set; }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<Constituency> Constituencies { get; set; }

        public DbSet<Party> Parties { get; set; }

        public DbSet<UserVoting> UserVotings { get; set; }
    }
}
