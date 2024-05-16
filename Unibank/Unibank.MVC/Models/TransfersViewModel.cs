using Unibank.DAL.Entities;

namespace Unibank.MVC.Models
{
    public class TransfersViewModel
    {
        public List<TransferBanner> TransferBanners = new List<TransferBanner>();
        public List<Method> Methods = new List<Method>();
        public List<Transfer> Transfers = new List<Transfer>();
    }
}
