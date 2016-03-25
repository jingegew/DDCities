using System;
using System.Data.Entity;

namespace DDCities.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly DbContext _context = new DDCitiesEntities();
        private GenericRepository<Line> _lineRepository;
        private GenericRepository<RideRequest> _rideRequestRepository;
        private GenericRepository<DriverSchedule> _driverScheduleRepository;
        private GenericRepository<Car> _carRepository;
        private GenericRepository<User> _userRepository;
        private GenericRepository<Address> _addressRepository;

        private bool disposed;

        public GenericRepository<Line> LineRepository
        {
            get { return _lineRepository ?? (_lineRepository = new GenericRepository<Line>(_context)); }
        }

        public GenericRepository<Address> AddressRepository
        {
            get { return _addressRepository ?? (_addressRepository = new GenericRepository<Address>(_context)); }
        }

        public GenericRepository<User> UserRepository
        {
            get { return _userRepository ?? (_userRepository = new GenericRepository<User>(_context)); }
        }

        public GenericRepository<RideRequest> RideRequestRepository
        {
            get
            {
                return _rideRequestRepository ?? (_rideRequestRepository = new GenericRepository<RideRequest>(_context));
            }
        }

        public GenericRepository<DriverSchedule> DriverScheduleRepository
        {
            get
            {
                return _driverScheduleRepository ?? (_driverScheduleRepository = new GenericRepository<DriverSchedule>(_context));
            }
        }

        public GenericRepository<Car> CarRepository
        {
            get { return _carRepository ?? (_carRepository = new GenericRepository<Car>(_context)); }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
    }
}