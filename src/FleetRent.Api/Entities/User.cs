using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetRent.Api.Exceptions;

namespace FleetRent.Api.Entities
{
    /// <summary>
    /// Represents a user entity.
    /// </summary>
    public class User
    {
        public Guid Id { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public bool IsActive { get; private set; }

        public User(Guid id, string firstName, string lastName, string email, string phone)
        {
            Id = id;
            ChangeFirstName(firstName);
            ChangeLastName(lastName);
            ChangeEmail(email);
            ChangePhone(phone);
            IsActive = true;
        }

        /// <summary>
        /// Changes the first name of the user.
        /// </summary>
        /// <param name="firstName">The new first name.</param>
        public void ChangeFirstName(string firstName)
        {
            FirstName = firstName;
        }

        /// <summary>
        /// Changes the last name of the user.
        /// </summary>
        /// <param name="lastName">The new last name.</param>
        public void ChangeLastName(string lastName)
        {
            LastName = lastName;
        }

        /// <summary>
        /// Changes the email address of the user.
        /// </summary>
        /// <param name="email">The new email address.</param>
        /// <exception cref="EmptyEmailException">Thrown when the email is null, empty, or consists only of whitespace characters.</exception>
        /// <exception cref="InvalidEmailException">Thrown when the email is not in a valid format.</exception>
        public void ChangeEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new EmptyEmailException();
            }

            var emailRegex = new System.Text.RegularExpressions.Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
            if (!emailRegex.IsMatch(email))
            {
                throw new InvalidEmailException();
            }

            Email = email;
        }

        /// <summary>
        /// Changes the phone number of the user.
        /// </summary>
        /// <param name="phone">The new phone number.</param>
        public void ChangePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new EmptyPhoneException();
            }
            Phone = phone;
        }

        /// <summary>
        /// Changes the activity status of the user.
        /// </summary>
        /// <param name="isActive">The new activity status.</param>
        public void ChangeActivity(bool isActive)
        {
            IsActive = isActive;
        }
    }
}