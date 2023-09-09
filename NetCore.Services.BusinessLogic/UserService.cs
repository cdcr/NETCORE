using NetCore.Domain.Abstractions.Repository;
using NetCore.Domain.Abstractions.Service;
using NetCore.Domain.Entities;
using NetCore.Domain.Entities.DTO;

namespace NetCore.Services.BusinessLogic
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddUser(UserDTO userDTO)
        {
            var newUser = new User(userDTO);
            newUser.Password= Encrypt(userDTO.Password);
            _unitOfWork.UserRepository.AddUser(newUser);
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            return (await _unitOfWork.UserRepository.GetAllUsers())
                .Select(x => new UserDTO()
                { 
                    Id = x.Id,
                    UserName = x.UserName,
                    Password = x.Password
                }); ;
        }

        public async Task RemoveUser(int Id)
        {
            await _unitOfWork.UserRepository.RemoveUser(Id);
        }

        public async Task UpdateUser(UserDTO userDTO)
        {
            var newUser = new User(userDTO);
            await _unitOfWork.UserRepository.UpdateUser(newUser);
        }

        public async Task<bool> ValidateSession(string UserName, string password)
        {
            var passwordEncrypted = await _unitOfWork.UserRepository.GetPasswordByUserName(UserName);
            if (passwordEncrypted == null)
                return false;
            else
            {
                return (Decrypt(password).Equals(Decrypt(passwordEncrypted)));
            }
        }

        public static string Decrypt( string toDecrypt)
        {
            string result = string.Empty;
            byte[] decrypted = Convert.FromBase64String(toDecrypt);
            result = System.Text.Encoding.Unicode.GetString(decrypted);
            return result;
        }

        public static string Encrypt(string toEncrypt)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(toEncrypt);
            result = Convert.ToBase64String(encryted);
            return result;
        }
    }
}
