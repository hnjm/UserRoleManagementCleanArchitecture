using Application.Abstracts.Repositories;
using Application.Features.Users.Dtos;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries.GetList
{
    public class GetListUserQueryHandler : IRequestHandler<GetListQueryRequest, GetListQueryResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetListUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetListQueryResponse> Handle(GetListQueryRequest request, CancellationToken cancellationToken)
        {
           IList<User> user  = await _userRepository.GetListAsync(
                include: user => user.Include(user => user.UserRoles).ThenInclude(userRole => userRole.Role)
                );

            GetListQueryResponse response = _mapper.Map<GetListQueryResponse>(user);
            return response;
        }
    }
}
