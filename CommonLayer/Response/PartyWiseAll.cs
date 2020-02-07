using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Response
{
    public class PartyWiseAll
    {
        public string PartyName { get; set; }

        public string CandidateName { get; set; }

        public int CandidateId { get; set; }

        public int Votes { get; set; }

        public string ConstituencyName { get; set; }

        public string State { get; set; }
    }
}
