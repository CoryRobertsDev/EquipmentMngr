using EquipmentMngr.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentMngr.Helpers
{
    public interface ICurrentUserService
    {
        string GetCurrentUsername();
    }
}