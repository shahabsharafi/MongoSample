using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using MongoSample.Domain.Infrasructure.Contracts;
using MongoSample.Domain.Models;

namespace MongoSample.Domain
{    
    public class GetAllPeopelQuery : IRequest<IQueryable<PersonDto>> { }
    public class GetOnePersonQuery : IRequest<PersonDto> 
    {
        public string Id { get; set; } = string.Empty;
    }
    public class AddPersonCommand : PersonModel, IRequest { }
    public class AddPersonCommandValidator : AbstractValidator<AddPersonCommand>
    {
        public AddPersonCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("Name is required.");

            RuleFor(x => x.Family).NotEmpty()
                .WithMessage("Family is required.");
        }
    }
    public class UpdatePersonCommand : PersonModel, IRequest
    {
        public string Id { get; set; } = string.Empty;
    }

    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("Name is required.");

            RuleFor(x => x.Family).NotEmpty()
                .WithMessage("Family is required.");
        }
    }

    public class DeletePersonCommand : IRequest
    {
        public string Id { get; set; } = string.Empty;
    }

    public class PersonHandller :
        IRequestHandler<GetAllPeopelQuery, IQueryable<PersonDto>>,
        IRequestHandler<GetOnePersonQuery, PersonDto>,
        IRequestHandler<AddPersonCommand>,
        IRequestHandler<UpdatePersonCommand>,
        IRequestHandler<DeletePersonCommand>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public PersonHandller(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IQueryable<PersonDto>> Handle(GetAllPeopelQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.PersonRepository.GetAll();
            var result = list.ProjectTo<PersonDto>(_mapper.ConfigurationProvider);
            return result;
        }

        public async Task<PersonDto> Handle(GetOnePersonQuery request, CancellationToken cancellationToken)
        {
            Person obj = await _unitOfWork.PersonRepository.GetById(request.Id);
            PersonDto dto = _mapper.Map<PersonDto>(obj);
            return dto;
        }

        public async Task<Unit> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            Person person = _mapper.Map<Person>(request);
            _unitOfWork.PersonRepository.Add(person);
            await _unitOfWork.Commit();
            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            Person person = _mapper.Map<Person>(request);
            _unitOfWork.PersonRepository.Update(person);
            await _unitOfWork.Commit();
            return Unit.Value;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.PersonRepository.Remove(request.Id);
            await _unitOfWork.Commit();
            return Unit.Value;
        }
    }
}
