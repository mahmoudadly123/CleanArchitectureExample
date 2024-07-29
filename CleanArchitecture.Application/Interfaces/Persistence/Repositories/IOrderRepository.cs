using System.Linq.Expressions;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Domain.Aggregates;

namespace CleanArchitecture.Application.Interfaces.Persistence.Repositories;

public interface IOrderRepository: IGenericRepository<Order, int>
{
    Task<Order?> Get_Order_By_Number(string orderNumber);
    Task<Order?> Get_Order_With_Items_By_Id(int orderId);
    Task<Order?> Get_Order_With_Items_By_Number(string orderNumber);

    Task<List<Order>> Get_All_Orders_With_Items();
    Task<List<Order>> Get_Orders_With_Items(Expression<Func<Order,bool>> predicate);

}