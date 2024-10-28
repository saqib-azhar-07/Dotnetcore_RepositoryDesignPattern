namespace PRJ.Service.Services.CommonService;

public interface ICommonService<T, K,  L, U> where T : class
{
    public Task<OutputDTO<U>> Save(T? obj , long? userId , int? roleId);

    public Task<OutputDTO<U>> Get(K? id , int? roleId);
    public Task<OutputDTO<List<U>>> GetAll(long? userId , int? roleId);

    public Task<OutputDTO<L>> Delete(K? id);
}
