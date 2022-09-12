using System.Data;
using Dapper;
using HolidayChatAgent.Repository.DbConnection;
using HolidayChatAgent.Repository.DTOs;
using HolidayChatAgent.Repository.Interfaces;

namespace HolidayChatAgent.Repository.Repositories
{
    public class HolidayRepository : IHolidayRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public HolidayRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory ?? throw new ArgumentNullException(nameof(dbConnectionFactory));
        }

        public async Task<IEnumerable<HolidayDto>> GetAllHolidaysAsync()
        {
            using var connection = _dbConnectionFactory.Create();

            return await connection.QueryAsync<HolidayDto>("dbo.Holidays_GetAll",
                commandType: CommandType.StoredProcedure);
        }
    }
}
