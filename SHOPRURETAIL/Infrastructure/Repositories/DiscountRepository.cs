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
//    public class DiscountRepository : Ge<DiscountType>, IDiscountRepository
//    {
//        public DiscountRepository(ApplicationContext context) :base(context) { }
//        public void CreateDiscountType(DiscountType discount) => Create(discount);

//        public string DiscountPercentage(DiscountType discount)
//        {
//            if (discount.IsRatePercentage) return $"{discount.Rate}%";
//            return null;
//        }

//        public async Task<IEnumerable<DiscountType>> GetAllDiscounts(bool trackChanges) =>
//            await FindAll(trackChanges).OrderBy(d => d.Name).ToListAsync();

//        public async Task<DiscountType> GetDiscountPercentageByType(string type, bool trackChanges) =>
//            await FindByCondition(d => d.Type.Trim().ToLower()
//                .Equals(type.Trim().ToLower()), trackChanges).SingleOrDefaultAsync();
//    }
//}
