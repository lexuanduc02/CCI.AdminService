using CCI.Model;
using CCI.Model.CommonModels;

namespace CCI.Service;

public interface IRequirementService
{
    Task<BaseResponseModel<List<RequirementViewModel>>> GetByTypeAsync(Common.RequirementType requirementType);
    Task<BaseResponseModel<bool>> UpdateStatusAsync(UpdateRequirementStatusRequest request);
}
