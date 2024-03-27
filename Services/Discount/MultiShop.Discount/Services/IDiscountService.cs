using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GettAllCouponAsync();

        Task CreateCouponAsync(CreateCouponDto createCouponDto);

        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);

        Task DeleteCouponAsync(int id);
        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);


    }
}
