using System;
using WA.Data;
using WA.Service.Models;

namespace WA.Service.Mappers
{
    internal static class CredentialMapper
    {
        public static UserCred MapToEntity(this CredentialModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new UserCred
            {
                UserId = new Guid(model.UserId),
                Expire = model.Expire,
                Username = model.Username
            };
        }

        public static CredentialModel MapToModel(this UserCred entity)
        {
            if(entity == null)
            {
                return null;
            }

            return new CredentialModel
            {
                UserId = entity.UserId.ToString(),
                Expire = entity.Expire,
                Username = entity.Username
            };
        }
    }
}
