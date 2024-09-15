using AutoMapper;
using RTMS.CoreBusiness;

namespace RTMS.Web.MappingProfiles
{
    public class WorkoutTemplateToWorkoutMappingProfile : Profile
    {
        public WorkoutTemplateToWorkoutMappingProfile()
        {
            // Map WorkoutTemplate to Workout
            CreateMap<WorkoutTemplate, Workout>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())  // Ignore the Id of the Workout
                .ForMember(dest => dest.WorkoutTemplateId, opt => opt.MapFrom(src => src.Id))  // Map WorkoutTemplate.Id to Workout.WorkoutTemplateId
                .ForMember(dest => dest.WorkoutTemplate, opt => opt.Ignore())  // Ignore the WorkoutTemplate navigation property
                .ForMember(dest => dest.StartTime, opt => opt.Ignore())  // Ignore StartTime as it should be set when creating the workout
                .ForMember(dest => dest.EndTime, opt => opt.Ignore())  // Ignore EndTime as it should be set when ending the workout
                .ForMember(dest => dest.IsCompleted, opt => opt.Ignore())  // Ignore IsCompleted as it should be set separately
                .AfterMap((src, dest) =>
                {
                    dest.WorkoutTemplateId = src.Id;
                    dest.UserId = src.UserId;
                });

            // Map ExerciseTemplate to Exercise
            CreateMap<ExerciseTemplate, Exercise>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())  // Ignore the Id of the Exercise
                .ForMember(dest => dest.ExerciseTemplateId, opt => opt.MapFrom(src => src.Id));  // Map ExerciseTemplate.Id to Exercise.ExerciseTemplateId

            // Map ExerciseSetTemplate to ExerciseSet
            CreateMap<ExerciseSetTemplate, ExerciseSet>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())  // Ignore the Id of the ExerciseSet
                .ForMember(dest => dest.SetTemplateId, opt => opt.MapFrom(src => src.Id));
        }
    }
}