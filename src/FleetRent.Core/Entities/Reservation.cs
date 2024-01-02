using FleetRent.Core.Exceptions;
using FleetRent.Core.ValueObjects;

namespace FleetRent.Core.Entities
{
    /// <summary>
    /// Represents a reservation made by a user.
    /// </summary>
    public class Reservation
    {
        public ReservationId Id { get; }
        public ReservationDate StartDate { get; private set;}
        public ReservationDate EndDate { get; private set;}
        public User User { get; private set;}
        public IsActive IsActive { get; private set; }

        /// <summary>
        /// Represents a reservation made by a user.
        /// </summary>
        /// <param name="id">The unique identifier of the reservation.</param>
        /// <param name="startDate">The start date of the reservation.</param>
        /// <param name="endDate">The end date of the reservation.</param>
        /// <param name="user">The user who made the reservation.</param>
        public Reservation(Guid id, DateTime startDate, DateTime endDate, User user)
        {
            Id = id;
            ChangeStartDate(startDate);
            ChangeEndDate(endDate);
            ChangeUser(user);
            IsActive = true;
        }

        public Reservation(Guid id, DateTime startDate, User user)
        {
            Id = id;
            ChangeStartDate(startDate);
            ChangeUser(user);
            IsActive = true;
        }

        /// <summary>
        /// Changes the start date of the reservation.
        /// </summary>
        /// <param name="startDate">The new start date.</param>
        public void ChangeStartDate(DateTime startDate)
        {
            if (EndDate is not null)
            {
                ValidateDates(startDate, EndDate);
            }
            
            StartDate = startDate;
        }

        /// <summary>
        /// Changes the end date of the reservation.
        /// </summary>
        /// <param name="endDate">The new end date.</param>
        public void ChangeEndDate(DateTime endDate)
        {
            if (StartDate is not null)
            {
                ValidateDates(StartDate, endDate);
            }
            
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

        /// <summary>
        /// Validates the dates of a reservation.
        /// </summary>
        /// <param name="startDate">The start date of the reservation.</param>
        /// <param name="endDate">The end date of the reservation.</param>
        /// <exception cref="InvalidDatesException">Thrown when the start date is greater than the end date.</exception>
        /// <exception cref="WekendDayException">Thrown when any of the dates falls on a weekend day (Saturday or Sunday).</exception>
        private void ValidateDates(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new InvalidDatesException();
            }
            
            if (startDate > DateTime.MinValue && endDate > DateTime.MinValue)
            {
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
}