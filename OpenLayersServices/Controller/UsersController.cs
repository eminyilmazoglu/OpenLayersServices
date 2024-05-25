using Microsoft.AspNetCore.Mvc;
using OpenLayersServices.DTOs;
using OpenLayersServices.Model;
using OpenLayersServices.Services;

namespace OpenLayersServices.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CreateUserCoordinates")]
        public async Task<IActionResult> CreateUserCoordinates(UserDto request)
        {
            // Map islemleri icin bu uygun degil - AutoMapper kullanmali baslangic icin bu sekilde yapildi...
            var user = new User
            {
                UserName = request.userName,
                DataNumber = request.dataNumber
            };

            var coordinate = new Coordinate
            {
                Type = request.coordinates.type,
                Points = request.coordinates.coordinates[0].Select(coord => new Point
                {
                    Latitude = coord[1],
                    Longitude = coord[0]
                }).ToList()
            };

            var result = await _userService.AddUserWithCoordinates(user, coordinate);

            return Ok(result);
        }

        [HttpGet("GetUserCoordinates")]
        public async Task<IActionResult> GetUserCoordinates()
        {
            var result = await _userService.GetAllUserCoordinates();

            return Ok(result);
        }
    }
}

