using AutoMapper;
using MediatR;
using Moq;
using SHOPRURETAIL.Application.Exceptions;
using SHOPRURETAIL.Application.Features.Customers.Commands;
using SHOPRURETAIL.Application.Interfaces;
using SHOPRURETAIL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SHOPRURetail.Tests.CustomerTests
{
   public class CreateCustomerCommandTest
    {
        Mock<IGenericRepositoryAsync<Customer>> customerrepo;
        Mock<IMapper> mapper;
        Mock<IMediator> mediator;
        public CreateCustomerCommandTest()
        {
             mediator = new Mock<IMediator>();
             mapper = new Mock<IMapper>();
             customerrepo = new Mock<IGenericRepositoryAsync<Customer>>();

        }

        [Fact]
        public async Task CreateCustomerCommandShouldThrowExceptionIfEmailIsDuplicate()
        {
           
            CreateCustomerCommand command = new CreateCustomerCommand() { Email=""};

            customerrepo.Setup(c => c.GetByParameter(c => c.Email == It.IsAny<string>())).Returns(new List<Customer>().AsQueryable());
            mapper.Setup(c => c.Map<Customer>(It.IsAny<CreateCustomerCommand>()));
            CreateCustomerCommandHandler handler = new CreateCustomerCommandHandler(customerrepo.Object,mapper.Object);

            //Act
            await Assert.ThrowsAsync<ApiException>(async () => await handler.Handle(command, new System.Threading.CancellationToken()));
            
        }
    }
}
