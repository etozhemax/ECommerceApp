namespace ECommerce.DataAccess.Repository.OrderInfo
{
	public interface IOrderInfoRepository : IRepository<Models.OrderInfo>
	{
		public void Update(ECommerce.Models.OrderInfo orderInfo);
	}
}
