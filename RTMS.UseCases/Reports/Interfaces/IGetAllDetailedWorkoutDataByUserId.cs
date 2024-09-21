using RTMS.CoreBusiness;

namespace RTMS.UseCases.Reports.Interfaces;
public interface IGetAllDetailedWorkoutDataByUserId
{
    Task<List<Workout>> ExecuteAsync(Guid userId);
}