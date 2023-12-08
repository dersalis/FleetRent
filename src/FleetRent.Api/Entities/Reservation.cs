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
        public bool IsActive { get; private set; }

        public Reservation(Guid id, DateTime startDate, DateTime endDate, User user)
        {
            Id = id;
            ChangeStartDate(startDate);
            ChangeEndDate(endDate);
            ChangeUser(user);
            IsActive = true;
        }

        /// <summary>
        /// Changes the start date of the reservation.
        /// </summary>
        /// <param name="startDate">The new start date.</param>
        public void ChangeStartDate(DateTime startDate)
        {
            ValidateDates(startDate, EndDate);
            StartDate = startDate;
        }

        /// <summary>
        /// Changes the end date of the reservation.
        /// </summary>
        /// <param name="endDate">The new end date.</param>
        public void ChangeEndDate(DateTime endDate)
        {
            ValidateDates(StartDate, endDate);
            EndDate = endDate;
        }

        /// <summary>
        /// Changes the user associated with the reservation.
        /// </summary>
        /// <param name="user">The new user to be associated with the reservation.</param>
        public void ChangeUser(User user)
        {
            if (user is null)
            {
                throw new NullUserException();
            }
            User = user;
        }

        /// <summary>
        /// Changes the activity status of the user.
        /// </summary>
        /// <param name="isActive">The new activity status.</param>
        public void ChangeActivity(bool isActive)
        {
            IsActive = isActive;
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