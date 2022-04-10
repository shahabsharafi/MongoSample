using AutoMapper;
using MongoSample.Domain.Models;
using Moq;

namespace MongoSample.Test
{
    public class Utility
    {
        public static Mock<IMapper> GetMapperMock<Profile>()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PersonProfile());
            });
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.ConfigurationProvider).Returns(() => mapperConfiguration);
            return mockMapper;
        }
    }
}
