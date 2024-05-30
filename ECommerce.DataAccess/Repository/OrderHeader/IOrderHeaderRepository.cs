namespace ECommerce.DataAccess.Repository.OrderHeader
{
	public interface IOrderHeaderRepository : IRepository<Models.OrderHeader>
	{
		public void Update(ECommerce.Models.OrderHeader orderHeader);
	}
}
