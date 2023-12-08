using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetRent.Api.Exceptions;

namespace FleetRent.Api.Entities
{
    public class Reservation
    {
        public Guid Id { get; }
        public DateTime StartDate { get; private set;}
        public DateTime EndDate { get; private set;}
        public User User { get; private set;}

        public Reservation(Guid id, DateTime startDate, DateTime endDate, User user)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            User = user;
        }

        public void ChangeStartDate(DateTime startDate)
        {
            ValidateDates(startDate, EndDate);
            StartDate = startDate;
        }

        public void ChangeEndDate(DateTime endDate)
        {
            ValidateDates(StartDate, endDate);
            EndDate = endDate;
        }

        public void ChangeUser(User user)
        {
            if (user is null)
            {
                throw new NullUserException();
            }
            User = user;
        }

        private void ValidateDates(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new InvalidDatesException();
            }
            
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    throw new WekendDayException();
                }
            }
        }
    }
}