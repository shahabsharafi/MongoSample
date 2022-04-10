using AutoMapper;

namespace MongoSample.Domain.Models
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<AddPersonCommand, Person>();
            CreateMap<UpdatePersonCommand, Person>();
            CreateMap<Person, PersonDto>();
        }
    }
}
