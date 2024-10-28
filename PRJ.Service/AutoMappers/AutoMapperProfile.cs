namespace PRJ.Service.AutoMapper;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<SYS_User, RegisterInputDTO>().ReverseMap();
        CreateMap<SYS_User, RegisterOutputDTO>().ReverseMap();

        CreateMap<SYS_User, LoginInputDTO>().ReverseMap();
        CreateMap<LoginOutputDTO, SYS_User>().ReverseMap().
            ForMember(des => des.Name, opts => opts.MapFrom(src => $"{src.FirstName}  {src.LastName}"));

        CreateMap<SYS_User, UserInputDTO>().ReverseMap();
        CreateMap<SYS_User, UserOutputDTO>().ReverseMap();
    }
}
