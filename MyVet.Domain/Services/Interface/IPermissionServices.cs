using Common.Utils.Enums;

namespace MyVet.Domain.Services.Interface
{
    public interface IPermissionServices
    {
        bool ValidatePermissionByUser(Enums.Permission permission, int idUser);
    }
}
