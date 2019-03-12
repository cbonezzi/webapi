using System;
using System.Threading.Tasks;
using WA.Data.Interfaces;
using WA.Service.Interfaces;
using WA.Service.Mappers;
using WA.Service.Models;
using WA.Service.Results;
using WA.Service.Validators;

namespace WA.Service.Services
{
    //usercred service class where interface get defined
    public class UserCredService : IUserCredService
    {
        #region Private Members

        /// <summary>
        /// variable carrying repository context 
        /// </summary>
        private readonly IUserCredRepository _userCredRepository;

        #endregion

        #region Public Repository Interfaces

        /// <summary>
        /// constructor for service class 
        /// </summary>
        /// <param name="userCredRepository"></param>
        public UserCredService(IUserCredRepository userCredRepository)
        {
            _userCredRepository = userCredRepository;
        }

        /// <summary>
        /// creates user data 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<GuidResult> CreateGuid(CredentialModel model)
        {
            var result = new GuidResult { ValidationResults = model.Validate() };

            if (result.ValidationResults.Count == 0)
            {
                var randomGuid = new Guid();

                if (string.IsNullOrEmpty(model.UserId))
                {
                    randomGuid = Guid.NewGuid();
                    model.UserId = randomGuid.ToString();
                    model.Expire = string.IsNullOrEmpty(model.Expire) ? "2629743" : model.Expire;
                }

                var entity = model.MapToEntity();

                await _userCredRepository.Add(entity);

                result.CredentialModel = entity.MapToModel();

                return result;
            }
            return result;
        }

        /// <summary>
        /// delete user data by guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<GuidResult> DeleteGuid(string guid)
        {
            var result = new GuidResult { ValidationResults = guid.ValidateGuid(_userCredRepository) };

            if (result.ValidationResults.Count == 0)
            {
                await _userCredRepository.Delete(x => x.UserId == new Guid(guid));
            }
            return result;
        }

        /// <summary>
        /// gets user data by guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<GuidResult> ReadGuid(string guid)
        {
            var result = new GuidResult { ValidationResults = guid.ValidateGuid(_userCredRepository) };

            if (result.ValidationResults.Count == 0)
            {
                var entity = await _userCredRepository.GetById(new Guid(guid));
                result.CredentialModel = entity.MapToModel();
                return result;
            }

            return result;
        }

        /// <summary>
        /// updates user data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<GuidResult> Update(CredentialModel model)
        {
            var result = new GuidResult { ValidationResults = model.Validate() };

            if (result.ValidationResults.Count == 0)
            {
                var entity = await _userCredRepository.GetById(new Guid(model.UserId));

                result.CredentialModel = entity.MapToModel();

                if (entity != null)
                {
                    entity.Username = string.IsNullOrEmpty(model.Username) ? entity.Username : model.Username;
                    entity.Expire = string.IsNullOrEmpty(model.Expire) ? entity.Expire : model.Expire;
                    entity.UserId = new Guid(model.UserId);
                    await _userCredRepository.AddOrUpdate(entity);
                }

                result.CredentialModel = entity.MapToModel();
                return result;
            }
            return result;
        }

        #endregion
    }
}