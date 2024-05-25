using Microsoft.AspNetCore.Mvc;
using OpenLayersServices.DTOs;
using OpenLayersServices.Model;

namespace OpenLayersServices.Services
{
    public interface IUserService
    {
        Task<ResponseDto> AddUserWithCoordinates(User user, Coordinate coordinate);
        Task<ResponseDto> GetAllUserCoordinates();
    }
}
