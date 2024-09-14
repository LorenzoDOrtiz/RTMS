using AutoMapper;
using RTMS.CoreBusiness;
using RTMS.Web.ViewModels;

namespace RTMS.Web.MappingProfiles;

public class WorkoutViewModelToWorkoutMappingProfile : Profile
{
    public WorkoutViewModelToWorkoutMappingProfile()
    {
        CreateMap<WorkoutViewModel, Workout>();

        CreateMap<ExerciseViewModel, Exercise>();

        CreateMap<ExerciseSetViewModel, ExerciseSet>();
    }
}
