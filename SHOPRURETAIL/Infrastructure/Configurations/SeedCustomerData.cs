using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHOPRURETAIL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Infrastructure.Configurations
{
    public class SeedCustomerData : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasIndex(c => c.Email).IsUnique();
            builder.HasData
            (
                new Customer(DateTime.Now.AddYears(-3))
                {
                    CustomerId = 1,
                    FirstName = "Chukwu",
                    MiddleName = "Ngozi",
                    LastName = "Ebube",
                    Email = "Ebube@email.com",
                    PhoneNumber = "123456789",
                    CustomerTypeId = 1
                },
                new Customer(DateTime.Now.AddMonths(-3))
                {
                    CustomerId = 2,
                    FirstName = "David",
                    MiddleName = "James",
                    LastName = "Otee",
                    Email = "Otee@email.com",
                    PhoneNumber = "12345678910",
                    CustomerTypeId = 1
                },
                new Customer(DateTime.Now.AddYears(-1))
                {
                    CustomerId = 3,
                    FirstName = "Puma",
                    MiddleName = "Lanre",
                    LastName = "Nike",
                    Email = "Nike@email.com",
                    PhoneNumber = "123456789",
                    CustomerTypeId = 2
                },
                new Customer(DateTime.Now.AddYears(-5))
                {
                    CustomerId = 4,
                    FirstName = "Bose", 
                    LastName = "Ayo",
                    Email = "boseayo@email.com",
                    PhoneNumber = "123456789",
                    CustomerTypeId = 2
                },
                new Customer(DateTime.Now.AddYears(-3))
                {
                    CustomerId = 5,
                    FirstName = "Bola", 
                    LastName = "Joko",
                    Email = "bolajoko@email.com",
                    PhoneNumber = "123456789",
                    CustomerTypeId = 3
                }
            );
        }
    }
}
