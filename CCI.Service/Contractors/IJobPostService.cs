using CCI.Model.CommonModels;

namespace CCI.Service.Contractors;

public interface IJobPostService
{
    Task<BaseResponseModel<bool>> DetectJobPost(Guid idJobPost);
    Task<BaseResponseModel<bool>> UnDetectJobPost(Guid idJobPost);
}
