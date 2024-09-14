using AutoMapper;
using RTMS.CoreBusiness;
using RTMS.Web.ViewModels;

namespace RTMS.Web.MappingProfiles;

public class WorkoutTemplateViewModelToWorkoutTemplateMappingProfile : Profile
{
    public WorkoutTemplateViewModelToWorkoutTemplateMappingProfile()
    {
        CreateMap<WorkoutTemplateViewModel, WorkoutTemplate>();

        CreateMap<ExerciseTemplateViewModel, ExerciseTemplate>();

        CreateMap<ExerciseSetTemplateViewModel, ExerciseSetTemplate>();
    }
}
