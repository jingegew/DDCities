using System.Linq;
using DDCities.Data;

namespace DDCities.Business
{
    public class TripService
    {
        private readonly UnitOfWork _work;

        public TripService(UnitOfWork work)
        {
            _work = work;
        }

        public long SaveOrigrinAddress(TripModel model)
        {
            var address =
                _work.AddressRepository.Get(
                    a => a.Address1 == model.FromAddress && a.City == model.FromCity && a.State == model.FromState)
                    .FirstOrDefault();
            //Save line if not there
            if (address == null)
            {
                address = new Address
                {
                    Address1 = model.FromAddress,
                    City = model.FromCity,
                    State = model.FromState
                };
                _work.AddressRepository.Insert(address);
                _work.Save();
            }
            return address.AddressId;
        }

        public long SaveDestinationAddress(TripModel model)
        {
            var address =
                _work.AddressRepository.Get(
                    a => a.Address1 == model.ToAddress && a.City == model.ToCity && a.State == model.ToState)
                    .FirstOrDefault();
            //Save line if not there
            if (address == null)
            {
                address = new Address
                {
                    Address1 = model.ToAddress,
                    City = model.ToCity,
                    State = model.ToState
                };
                _work.AddressRepository.Insert(address);
                _work.Save();
            }
            return address.AddressId;
        }
    }
}