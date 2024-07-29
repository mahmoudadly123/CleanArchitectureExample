using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Order.Commands
{
    public class DeleteOrderCommandHandler : CommandHandler<DeleteOrderCommand, DeleteOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        

        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _orderRepository = orderRepository;
        }

        public override async Task<Result<DeleteOrderResponse>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Validate 
                if (request.OrderId == 0)
                {
                    return Result.Failure<DeleteOrderResponse>($"{nameof(request.OrderId)} equal zero");
                }


                //check if original data exist or not
                var isExist = await _orderRepository.ExistAsync(request.OrderId);
                if (isExist == false)
                {
                    return Result.Failure<DeleteOrderResponse>($"Order with Id {request.OrderId} Not Found");
                }

                //Delete Book From Database
                await _orderRepository.DeleteAsync(request.OrderId);

                //Save Changes using Unit of Work Pattern
                await UnitOfWork.SaveChangesAsync(cancellationToken);

                var response = new DeleteOrderResponse();

                return Result.Success(response);

            }
            catch (Exception e)
            {
                return Result.Failure<DeleteOrderResponse>(e);
            }

        }
    }
}
