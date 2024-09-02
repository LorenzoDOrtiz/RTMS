using AutoMapper;
using RTMS.CoreBusiness.WorkoutTemplate;
using RTMS.Web.ViewModels.WorkoutTemplate;

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


