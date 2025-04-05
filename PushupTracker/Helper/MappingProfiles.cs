using AutoMapper;
using ExerciseTracker.Dtos;
using ExerciseTracker.Models;

namespace ExerciseTracker.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Pushup, PushupDto>();
    }
}