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

        public void AddUser(UserDTO UserDTO)
        {
            var newUser = new User(UserDTO);
            _unitOfWork.UserRepository.AddUser(newUser);
            _unitOfWork.Complete();
        }

        public async Task<IEnumerable<UserDTO>> GeByField(string field, string value)
        {
            return (await _unitOfWork.UserRepository.GetByField(field, value))
                .Select(x => new UserDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Title = x.Title,
                    Status = x.Status
                });
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            return (await _unitOfWork.UserRepository.GetAllUsers())
                .Select(x => new UserDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Title = x.Title,
                    Status = x.Status
                });
        }

        public void RemoveUser(UserDTO UserDTO)
        {
            var newUser = new User(UserDTO);
            _unitOfWork.UserRepository.RemoveUser(newUser.Id);
            _unitOfWork.Complete();
        }

        public void UpdateUser(UserDTO UserDTO)
        {
            var newUser = new User(UserDTO);
            _unitOfWork.UserRepository.UpdateUser(newUser);
            _unitOfWork.Complete();
        }
    }
}
