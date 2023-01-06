using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCarDealer.Models
{
    public class Dealer
    {
        private int _dealerId;
        private string _dealerName;
        private string _dealerLocation;

        public Dealer()
        {
            _dealerId = 0;
            _dealerName = "Not defined";
            _dealerLocation = "Not defined";
        }

        public Dealer(int dealerId, string dealerName, string dealerLocation)
        {
            _dealerId = dealerId;
            _dealerName = dealerName;
            _dealerLocation = dealerLocation;
        }

        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public string DealerLocation { get; set; }
    }
}
