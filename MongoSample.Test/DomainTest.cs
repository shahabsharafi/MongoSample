using AutoMapper;
using MongoSample.Domain;
using MongoSample.Domain.Infrasructure.Contracts;
using MongoSample.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using AutoMapper.QueryableExtensions;
using System.Linq.Expressions;

namespace MongoSample.Test
{
    public class DomainTest
    {
        private readonly Mock<IPersonRepository> _mockPersonRepository = new();
        private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();
        private readonly Mock<IMapper> _mockMapper;
        private PersonHandller? _handler;

        public DomainTest()
        {
            _mockMapper = Utility.GetMapperMock<Person>();
        }

        [Fact]
        public async void DomainTest_GetAllPeopelQuery()
        {
            //Arange           
            List<Person> people = new();

            _mockPersonRepository.Setup(x => x.GetAll()).Returns(() => Task.FromResult(people.AsQueryable()));

            _mockUnitOfWork.Setup(x => x.PersonRepository).Returns(() => _mockPersonRepository.Object);            

            _handler = new(_mockUnitOfWork.Object, _mockMapper.Object);

            GetAllPeopelQuery request = new();
            
            //Act
            IQueryable<PersonDto> list = await _handler.Handle(request, new System.Threading.CancellationToken());

            //Asert
            _mockPersonRepository.Verify(x => x.GetAll());
        }
    }
}