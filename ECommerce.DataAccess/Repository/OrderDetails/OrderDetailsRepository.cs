using ECommerce.Data;

namespace ECommerce.DataAccess.Repository.OrderDetails
{
	public class OrderDetailsRepository : Repository<Models.OrderDetails>, IOrderDetailsRepository
	{
		private readonly ECommerceDbContext _dbContext;

		public OrderDetailsRepository(ECommerceDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public void Update(Models.OrderDetails orderDetails)
		{
			_dbContext.Update(orderDetails);
		}
	}
}
