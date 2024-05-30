using ECommerce.Data;

namespace ECommerce.DataAccess.Repository.OrderHeader
{
	public class OrderHeaderRepository : Repository<Models.OrderHeader>, IOrderHeaderRepository
	{
		private readonly ECommerceDbContext _dbContext;

		public OrderHeaderRepository(ECommerceDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public void Update(Models.OrderHeader orderHeader)
		{
			_dbContext.Update(orderHeader);
		}
	}
}
