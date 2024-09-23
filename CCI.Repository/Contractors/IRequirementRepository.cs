using CCI.Domain;
using CCI.Model;
using CCI.Repository.Contractors;
using RequirementType = CCI.Common.RequirementType;

namespace CCI.Repository;

public interface IRequirementRepository : IRepository<Requirement, int, DataContext>
{
    Task<List<RequirementViewModel>> GetAllAsync();
    Task<List<RequirementViewModel>> GetByTypeAsync(RequirementType requirementType);
    Task<int> UpdateRequirementStatus(UpdateRequirementStatusRequest request);
}
