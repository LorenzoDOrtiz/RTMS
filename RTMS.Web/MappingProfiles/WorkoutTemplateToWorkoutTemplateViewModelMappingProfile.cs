using AutoMapper;
using RTMS.CoreBusiness;
using RTMS.Web.ViewModels;

namespace RTMS.Web.MappingProfiles;

public class WorkoutTemplateToWorkoutTemplateViewModelMappingProfile : Profile
{
    public WorkoutTemplateToWorkoutTemplateViewModelMappingProfile()
    {
        CreateMap<WorkoutTemplate, WorkoutTemplateViewModel>();

        CreateMap<ExerciseTemplate, ExerciseTemplateViewModel>();

        CreateMap<ExerciseSetTemplate, ExerciseSetTemplateViewModel>();
    }
}


