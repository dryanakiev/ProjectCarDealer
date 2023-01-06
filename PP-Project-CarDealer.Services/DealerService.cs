using ProjectCarDealer.Models;
using ProjectCarDealer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCarDealer.Services
{
    public class DealerService
    {
        private static DealerService _instance;
        private DealerRepository _dealerRepository;

        public DealerService()
        {
            _dealerRepository = DealerRepository.getInstance();
        }

        public static DealerService getInstance()
        {
            if (_instance == null)
            {
                _instance = new DealerService();
            }

            return _instance;
        }

        public List<Dealer> GetDealers()
        {
            List<Dealer> dealers = _dealerRepository.GetAllDealers();

            return dealers;
        }

        public void AddDealer(string dealerName, string dealerLocation)
        {
            _dealerRepository.AddDealer(dealerName, dealerLocation);
        }

        public void DeleteDealer(int dealerId)
        {
            _dealerRepository.DeleteDealerById(dealerId);
        }
    }
}
