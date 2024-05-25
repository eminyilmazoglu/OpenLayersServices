using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OpenLayersServices.DTOs;
using OpenLayersServices.Model;
using OpenLayersServices.MyDbContext;

namespace OpenLayersServices.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto> AddUserWithCoordinates(User user, Coordinate coordinate)
        {
            try
            {
                user.Id = Guid.NewGuid();
                _context.Users.Add(user);
                coordinate.UserId = user.Id;
                coordinate.Id = Guid.NewGuid();
                _context.Coordinates.Add(coordinate);
                foreach (var point in coordinate.Points)
                {
                    point.CoordinateId = coordinate.Id;
                    _context.Points.Add(point);
                }
                await _context.SaveChangesAsync();
                return new ResponseDto() { isSuccess = true, Message = "Kayıt İşlemi başarılı!" };
            }
            catch (Exception ex)
            {
                return new ResponseDto() { isSuccess = false, Message = "Kayıt İşleminde Hata Oluştu! " + ex.Message };
            }
        }

        public async Task<ResponseDto> GetAllUserCoordinates()
        {
            try
            {
                var userData = await _context.Users.Include(x => x.Coordinates).ThenInclude(c => c.Points).ToListAsync();

                return new ResponseDto() { result = userData, isSuccess = true };
            }
            catch (Exception ex)
            {
                return new ResponseDto() { isSuccess= false, Message = "User ve kordinatverileri çekilemedi! " + ex.Message };                
            }
        }
    }
}
