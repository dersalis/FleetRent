using FleetRent.Api.Exceptions;
using FleetRent.Api.ValueObjects;

namespace FleetRent.Api.Entities
{
    /// <summary>
    /// Represents a hire of a vehicle by a user.
    /// </summary>
    public class Hire
    {
        public Guid Id { get; }
        public HireDate StartDate { get; private set;}
        public HireDate EndDate { get; private set;}
        public User User { get; private set;}
        public int StartMileage { get; private set; }
        public int EndMileage { get; private set; }
        public HireDate ReleaseDate { get; private set; }
        public HireDate ReturnDate { get; private set; }
        public IsActive IsActive { get; private set; }

        public Hire(Guid id, DateTime startDate, DateTime endDate, User user, int startMileage, int endMileage, DateTime releaseDate, DateTime returnDate)
        {
            Id = id;
            ChangeStartDate(startDate);
            ChangeEndDate(endDate);
            ChangeUser(user);
            //ChangeStartMileage(startMileage);
            StartMileage = startMileage;
            ChangeEndMileage(endMileage);
            ChangeReleaseDate(releaseDate);
            ChangeReturnDate(returnDate);
            IsActive = true;
        }

        public Hire(Guid id, User user, DateTime startDate, DateTime endDate, int startMileage)
        {
            Id = id;
            ChangeStartDate(startDate);
            ChangeEndDate(endDate);
            ChangeUser(user);
            ChangeStartMileage(startMileage);
            IsActive = true;
        }

        /// <summary>
        /// Changes the start date of the hire.
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
        /// Changes the end date of the hire.
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
        /// Changes the user associated with the hire.
        /// </summary>
        /// <param name="user">The new user to be associated with the hire.</param>
        public void ChangeUser(User user)
        {
            if (user is null)
            {
                throw new NullUserException();
            }
            User = user;
        }

        /// <summary>
        /// Changes the start mileage of the hire.
        /// </summary>
        /// <param name="startMileage">The new start mileage.</param>
        public void ChangeStartMileage(int startMileage)
        {
            ValidateMileage(startMileage, EndMileage);
            StartMileage = startMileage;
        }

        /// <summary>
        /// Changes the end mileage of the hire.
        /// </summary>
        /// <param name="endMileage">The new end mileage.</param>
        public void ChangeEndMileage(int endMileage)
        {
            ValidateMileage(StartMileage, endMileage);
            EndMileage = endMileage;
        }

        /// <summary>
        /// Changes the release date of the hire.
        /// </summary>
        /// <param name="releaseDate">The new release date.</param>
        public void ChangeReleaseDate(DateTime releaseDate)
        {
            if (ReturnDate is not null)
            {
                ValidateDates(releaseDate, ReturnDate);
            }
            
            ReleaseDate = releaseDate;
        }

        /// <summary>
        /// Changes the return date of the hire.
        /// </summary>
        /// <param name="returnDate">The new return date.</param>
        public void ChangeReturnDate(DateTime returnDate)
        {
            if (ReleaseDate is not null)
            {
                ValidateDates(ReleaseDate, returnDate);
            }

            ReturnDate = returnDate;
        }

        /// <summary>
        /// Changes the activity status of the hire.
        /// </summary>
        /// <param name="isActive">The new activity status.</param>
        public void ChangeActivity(bool isActive)
        {
            IsActive = isActive;
        }

        /// <summary>
        /// Validates the dates for a hire.
        /// </summary>
        /// <param name="startDate">The start date of the hire.</param>
        /// <param name="endDate">The end date of the hire.</param>
        private void ValidateDates(HireDate startDate, HireDate endDate)
        {
            if (startDate > endDate)
            {
                throw new InvalidDatesException();
            }
            
            if ((DateTime)startDate > DateTime.MinValue && (DateTime)endDate > DateTime.MinValue)
            {
                for (var date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    var dayOfWeek = ((DateTime)date).DayOfWeek;
                    if (dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday)
                    {
                        throw new WekendDayException();
                    }
                }
            }
        }

        /// <summary>
        /// Validates the mileage values for a hire.
        /// </summary>
        /// <param name="startMileage">The starting mileage.</param>
        /// <param name="endMileage">The ending mileage.</param>
        /// <exception cref="NegativeMileageException">Thrown when either the starting mileage or ending mileage is negative.</exception>
        /// <exception cref="InvalidMileageException">Thrown when the starting mileage is greater than or equal to the ending mileage.</exception>
        private void ValidateMileage(int startMileage, int endMileage)
        {
            if (startMileage < 0 || endMileage < 0)
            {
                throw new NegativeMileageException();
            }

            if (startMileage >= endMileage)
            {
                throw new InvalidMileageException();
            }
        }
    }
}