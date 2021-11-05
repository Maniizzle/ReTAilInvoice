using AutoMapper;
using MediatR;
using Moq;
using SHOPRURETAIL.Application.Exceptions;
using SHOPRURETAIL.Application.Features.Customers.Commands;
using SHOPRURETAIL.Application.Interfaces;
using SHOPRURETAIL.Application.Interfaces.Repositories;
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
        Mock<ICustomerRepositoryAsync> customerrepo;
        Mock<IMapper> mapper;
        Mock<IMediator> mediator;
        public CreateCustomerCommandTest()
        {
             mediator = new Mock<IMediator>();
             mapper = new Mock<IMapper>();
             customerrepo = new Mock<ICustomerRepositoryAsync>();

        }

        [Fact]
        public async Task CreateCustomerCommandShouldThrowExceptionIfEmailIsDuplicate()
        {
           
            CreateCustomerCommand command = new CreateCustomerCommand() { Email="bola@gmail.com"};

            customerrepo.Setup(c =>c.GetCustomerByEmail(It.IsAny<string>())).Returns(Task.FromResult(new Customer()));
            mapper.Setup(c => c.Map<Customer>(It.IsAny<CreateCustomerCommand>()));
            CreateCustomerCommandHandler handler = new CreateCustomerCommandHandler(customerrepo.Object,mapper.Object);

            //Act
            await Assert.ThrowsAsync<ApiException>(async () => await handler.Handle(command, new System.Threading.CancellationToken()));
            
        }
    }
}
