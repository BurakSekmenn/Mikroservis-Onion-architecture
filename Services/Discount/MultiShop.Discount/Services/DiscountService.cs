using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto) // dapper kullanarak ekeleme işlemi yapılır 
        {
            string query = "INSERT INTO Coupons (Code, Rate, IsActive,ValidDate) VALUES (@Code, @Rate, @IsActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@Code", createCouponDto.Code);
            parameters.Add("@Rate", createCouponDto.Rate);
            parameters.Add("@IsActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);// ekleme işlemi yapılır
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "DELETE FROM Coupons WHERE CouponId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); // silme işlemi yapılır
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            string query = "SELECT * FROM Coupons WHERE CouponId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query, parameters);
                return result!;
            }
        }

        public async Task<List<ResultCouponDto>> GettAllCouponAsync()
        {
            string query = "SELECT * FROM Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query); // tüm verileri getirmesi için queryAsync kullanılır
                return values.ToList();
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "UPDATE Coupons SET Code = @code, Rate = @rate, IsActive = @isActive, ValidDate = @validDate WHERE CouponId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@id", updateCouponDto.CouponId);
            using (var connection = _context.CreateConnection())
            {
                 await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
