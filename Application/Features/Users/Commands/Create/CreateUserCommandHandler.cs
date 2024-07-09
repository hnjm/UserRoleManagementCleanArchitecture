//using Application.Abstracts.Repositories;
//using AutoMapper;
//using Domain.Entities;
//using MediatR;

//namespace Application.Features.Users.Commands.Create
//{
//    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
//    {
//        private readonly IUserRepository _userRepository;
//        private readonly IMapper _mapper;

//        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
//        {
//            _userRepository = userRepository;
//            _mapper = mapper;
//            //BusinessRules
//        }
//        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
//        {
//            User user = _mapper.Map<User>(request);
//            await _userRepository.AddAsync(user);

//            CreateUserCommandResponse response = _mapper.Map<CreateUserCommandResponse>(user);
//            return response;
//        }
//    }
//}
