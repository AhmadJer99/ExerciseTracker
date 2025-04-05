using AutoMapper;
using ExerciseTracker.Helper;

namespace ExerciseTracker.Controllers;

public class BaseController
{
    private readonly IMapper _mapper;

    public BaseController(IMapper mapper)
    {
        _mapper = mapper;
    }
}