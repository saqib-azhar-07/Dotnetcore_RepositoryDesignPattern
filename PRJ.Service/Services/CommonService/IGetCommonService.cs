namespace PRJ.Service.Services.CommonService
{
    public interface IGetCommonService<T, K> where T : class
    {
        public Task<OutputDTO<K>> Get(T? id, int? roleId);
        public Task<OutputDTO<List<K>>> GetAll(long? userId, int? roleId);
    }
}
