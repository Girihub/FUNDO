using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Response
{
    public class CandidateResponse
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PartyId { get; set; }

        public string PartyName { get; set; }

        public int ConstituencyId { get; set; }

        public string ConstituencyName { get; set; }

        public int Votes { get; set; }
    }
}
