namespace ECommerce.DataAccess.Repository.OrderDetails
{
	public interface IOrderDetailsRepository : IRepository<Models.OrderDetails>
	{
		public void Update(Models.OrderDetails orderDetails);
	}
}
