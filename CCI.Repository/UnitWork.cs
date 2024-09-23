using CCI.Domain;
using CCI.Repository.Contractors;
using System.Data.Common;
namespace CCI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private readonly IdentityContext _identityContext;

        public UnitOfWork(DataContext dataContext,
            IdentityContext identityContext)
        {
            _dataContext = dataContext;
            _identityContext = identityContext;

            #region DataContext

            CompanyRepository = new CompanyRepository(dataContext);
            DepartmentRepository = new DepartmentRepository(dataContext);
            JobPostRepository = new JobPostRepository(dataContext);
            RequirementRepository = new RequirementRepository(dataContext);
            UserDepartmentRepository = new UserDepartmentRepository(dataContext);

            #endregion

            #region IdentityContext

            UserRepository = new UserRepository(identityContext);

            #endregion
        }

        public DbConnection DbConnection()
        {
            return _dataContext.GetDbConnect();
        }

        public DbConnection IdentityDbConnection()
        {
            return _identityContext.GetDbConnect();
        }

        #region Register Repositories

        public ICompanyRepository CompanyRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
        public IJobPostRepository JobPostRepository { get; }
        public IRequirementRepository RequirementRepository { get; }
        public IUserDepartmentRepository UserDepartmentRepository { get; }
        public IUserRepository UserRepository { get; }
        #endregion
    }
}
