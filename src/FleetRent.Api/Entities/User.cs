using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetRent.Api.Exceptions;

namespace FleetRent.Api.Entities
{
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

        public void ChangeFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public void ChangeLastName(string lastName)
        {
            LastName = lastName;
        }

        public void ChangeEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new EmptyEmailException();
            }
            Email = email;
        }

        public void ChangePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new EmptyPhoneException();
            }
            Phone = phone;
        }

        public void ChangeActivity(bool isActive)
        {
            IsActive = isActive;
        }
    }
}