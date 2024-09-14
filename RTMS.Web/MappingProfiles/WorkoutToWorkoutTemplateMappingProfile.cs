using AutoMapper;
using RTMS.CoreBusiness;

namespace RTMS.Web.MappingProfiles;

public class WorkoutToWorkoutTemplateMappingProfile : Profile
{
    public WorkoutToWorkoutTemplateMappingProfile()
    {
        CreateMap<Workout, WorkoutTemplate>();

        CreateMap<Exercise, ExerciseTemplate>();

        CreateMap<ExerciseSet, ExerciseSetTemplate>();
    }
}
