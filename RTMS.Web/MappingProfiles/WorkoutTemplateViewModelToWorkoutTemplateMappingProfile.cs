using AutoMapper;
using RTMS.CoreBusiness.WorkoutTemplate;
using RTMS.Web.ViewModels.WorkoutTemplate;

namespace RTMS.Web.MappingProfiles;

public class WorkoutTemplateViewModelToWorkoutTemplateMappingProfile : Profile
{
    public WorkoutTemplateViewModelToWorkoutTemplateMappingProfile()
    {
        CreateMap<WorkoutTemplateViewModel, WorkoutTemplate>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<ExerciseTemplateViewModel, ExerciseTemplate>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.WorkoutTemplateId, opt => opt.Ignore());

        CreateMap<ExerciseSetTemplateViewModel, ExerciseSetTemplate>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ExerciseTemplateId, opt => opt.Ignore());
    }
}
