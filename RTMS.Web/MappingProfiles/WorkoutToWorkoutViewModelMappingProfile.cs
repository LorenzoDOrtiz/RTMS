using AutoMapper;
using RTMS.CoreBusiness;
using RTMS.Web.ViewModels;

namespace RTMS.Web.MappingProfiles
{
    public class WorkoutToWorkoutViewModelMappingProfile : Profile
    {
        public WorkoutToWorkoutViewModelMappingProfile()
        {
            CreateMap<Workout, WorkoutViewModel>();

            CreateMap<Exercise, ExerciseViewModel>();

            CreateMap<ExerciseSet, ExerciseSetViewModel>();
        }
    }
}
