using ECommerce.Data;

namespace ECommerce.DataAccess.Repository.OrderInfo
{
	public class OrderInfoRepository : Repository<Models.OrderInfo>, IOrderInfoRepository
	{
		private readonly ECommerceDbContext _dbContext;

		public OrderInfoRepository(ECommerceDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public void Update(Models.OrderInfo orderInfo)
		{
			_dbContext.Update(orderInfo);
		}
	}
}
