using CCI.Domain.Entities;
using CCI.Model.CommonModels;

namespace CCI.Service.Contractors
{
    public interface ICompanyService
    {
        Task<BaseResponseModel<Company>> GetCompanyByIdAsync(Guid companyId);
        Task<BaseResponseModel<List<Company>>> GetAllAsync();
    }
}
