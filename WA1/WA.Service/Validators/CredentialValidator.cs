using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WA.Data.Interfaces;
using WA.Service.Models;

namespace WA.Service.Validators
{
    /// <summary>
    /// extension class to help validate user input. this is to check at data layer level.
    /// </summary>
    internal static class CredentialValidator
    {
        /// <summary>
        /// validation method for user input
        /// </summary>
        /// <param name="model"></param>
        /// <returns>list of validationresults if errors are found</returns>
        internal static IList<ValidationResult> Validate(this CredentialModel model)
        {
            var errors = new List<ValidationResult>();
            errors.Add(model.IsValidUsername());
            errors.Add(model.IsValidExpireTime());

            return errors.Where(x => x != null).ToList();
        }

        /// <summary>
        /// check if guid is valid
        /// </summary>
        /// <param name="Guid"></param>
        /// <param name="userCredRepository"></param>
        /// <returns></returns>
        internal static IList<ValidationResult> ValidateGuid(this string Guid, IUserCredRepository userCredRepository)
        {
            var errors = new List<ValidationResult>();
            errors.Add(IsValidGuid(Guid, userCredRepository));

            return errors.Where(x => x != null).ToList();
        }

        /// <summary>
        /// check if valid user was provided
        /// </summary>
        /// <param name="model"></param>
        /// <returns>if user was not provided return validation error, else return null</returns>
        internal static ValidationResult IsValidUsername(this CredentialModel model)
        {
            if (string.IsNullOrEmpty(model.Username))
            {
                return new ValidationResult("You must provide username");
            }
            return null;
        }

        /// <summary>
        /// check if expire time is valid number of characters
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        internal static ValidationResult IsValidExpireTime(this CredentialModel model)
        {
            // this is a valid chack as we can follow with a default 
            if (string.IsNullOrEmpty(model.Expire))
                return null;
            if(model.Expire.Length > 8)
            {
                return new ValidationResult("Expiration cannot be greater than 8");
            }
            return null;
        }

        /// <summary>
        /// validate if user exists
        /// </summary>
        /// <param name="guid">guid to search</param>
        /// <param name="userCredRepository"></param>
        /// <returns>if user is not found, return user does not exist; else return null</returns>
        internal static ValidationResult IsValidGuid(string guid, IUserCredRepository userCredRepository)
        {
            var result = userCredRepository.GetAllQueryable().Where(x => x.UserId == new Guid(guid)).FirstOrDefault();
            if (result == null)
            {
                return new ValidationResult("User does not exist");
            }
            return null;
        }
    }
}
