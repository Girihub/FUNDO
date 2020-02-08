using BussinessLayer.Interfaces;
using BussinessLayer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooTestCases
{
    public class AccountUnitTest
    {
        private readonly IAccountBL accountBL;
        private readonly IAccountRL accountRL;
        private readonly IConfiguration configuration;

        public static DbContextOptions<AuthenticationContext> DbContext { get; }
        public static string sqlConnection = "server=localhost;Database=FundoAPI;Trusted_Connection=true; MultipleActiveResultSets = true;";

        static AccountUnitTest()
        {
            DbContext = new DbContextOptionsBuilder<AuthenticationContext>().UseSqlServer(sqlConnection).Options;
        }
        public AccountUnitTest()
        {
            var context = new AuthenticationContext(DbContext);
            this.accountBL = new AccountBL(this.accountRL);
            this.accountRL = new AccountRL(context,configuration);
        }
    }
}
