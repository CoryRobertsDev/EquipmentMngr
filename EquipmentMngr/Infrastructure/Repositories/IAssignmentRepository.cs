using EquipmentMngr.Data.Entities;

namespace EquipmentMngr.Infrastructure.Repositories
{
    public interface IAssignmentRepository : IGenericRepository<Assignment>
    {
        // If you need to customize your entity actions you can put here
        new Assignment Get(int assignmentId);


    }
}

