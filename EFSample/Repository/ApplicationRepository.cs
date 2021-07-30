using Microsoft.EntityFrameworkCore;

namespace EFSample.Repository
{
    public class ApplicationRepository : EFRepository, IApplicationRepository
    {

        public ApplicationRepository(DbContext context) : base(context)
        {
        }


    }


}
