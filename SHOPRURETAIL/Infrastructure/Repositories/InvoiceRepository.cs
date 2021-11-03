//using Microsoft.EntityFrameworkCore;
//using ShopsRUs.Contracts;
//using ShopsRUs.Data;
//using ShopsRUs.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ShopsRUs.Repositories
//{
//    public class InvoiceRepository : RepositoryBase<Invoice>, IInvoiceRepository
//    {
//        public InvoiceRepository(ApplicationContext context) :base(context) { }

//        public void GenerateInvoiceForCustomer(int userId, Invoice invoice)
//        {
//            invoice.UserId = userId;
//            Create(invoice);
//        }

//        public async Task<Invoice> GetTotalInvoiceAmount(string billNumber, bool trackChanges) =>
//             await FindByCondition(i => i.InvoiceNumber.Equals(billNumber),
//                trackChanges).SingleOrDefaultAsync();
//    }
//}
