using AutoMapper;

namespace MongoSample.Domains.EmployeeDomain.Models
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
