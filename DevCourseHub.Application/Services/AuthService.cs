using AutoMapper;
using DevCourseHub.Application.DTOs.Auth;
using DevCourseHub.Application.Interfaces;
using DevCourseHub.Domain.Entities;
using DevCourseHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;

        public AuthService(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
        }

        public async Task<CurrentUserDto?> GetCurrentUserAsync(Guid userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null) return null;
            return _mapper.Map<CurrentUserDto>(user);
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {
            var email = request.Email.Trim().ToLower();
            var user = await _unitOfWork.Users.GetByEmailAsync(email);
            if (user is null || !_passwordHasher.Verify(request.Password, user.PasswordHash))
            {
                throw new Exception("Email veya şifre hatalı.");
            }
            var (token,expiration) = _jwtTokenGenerator.GenerateToken(user);

            return new AuthResponseDto
            {
                Token = token,
                Expiration = expiration
            };

        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request)
        {
            var existingUser = await _unitOfWork.Users.GetByEmailAsync(request.Email);
            if (existingUser is not null)
            {
                throw new Exception("Bu email adersi zaten kayıtlı");
            }
            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email.Trim().ToLower(),
                PasswordHash = _passwordHasher.Hash(request.Password),
                Role = UserRole.Student
            };
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            var (token, expiration) = _jwtTokenGenerator.GenerateToken(user);
            return new AuthResponseDto
            {
                Token = token,
                Expiration = expiration
            };
        }
    }
}
