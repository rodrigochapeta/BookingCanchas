﻿using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CanchasDbContext _context;
        private IGameRepository _game;
        private IBusinessRepository _business;
        private IFieldRepository _field;
        private ICustomerRepository _customer;
        private IBookingRepository _booking;
        public IGameRepository Games
        {
            get
            {
                if (_game == null)
                {
                    _game = new GameRepository(_context);
                }

                return _game;
            }
        }

        public IBusinessRepository Businesses
        {
            get
            {
                if (_business == null)
                {
                    _business = new BusinessRepository(_context);
                }

                return _business;
            }
        }

        public IFieldRepository Fields
        {
            get
            {
                if (_field == null)
                {
                    _field = new FieldRepository(_context);
                }

                return _field;
            }
        }

        public ICustomerRepository Customers
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_context);
                }

                return _customer;
            }
        }

        public IBookingRepository Bookings
        {
            get
            {
                if (_booking == null)
                {
                    _booking = new BookingRepository(_context);
                }

                return _booking;
            }
        }

        public RepositoryWrapper(CanchasDbContext repositoryContext)
        {
            _context = repositoryContext;
        }
    }
}
