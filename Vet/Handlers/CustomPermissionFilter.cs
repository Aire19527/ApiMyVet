using Common.Utils.Enums;
using Common.Utils.Exceptions;
using Common.Utils.Helpers;
using Common.Utils.Resorces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyVet.Domain.Services.Interface;
using System;
using static Common.Utils.Constant.Const;

namespace Vet.Handlers
{
    public class CustomPermissionFilter : TypeFilterAttribute
    {
        public CustomPermissionFilter(Enums.Permission permission) : base(typeof(CustomPermissionFilterImplement))
        {
            Arguments = new object[] { permission };
        }

        private class CustomPermissionFilterImplement : IActionFilter
        {
            private readonly IPermissionServices _permissionServices;
            private readonly Enums.Permission _permission;

            public CustomPermissionFilterImplement(IPermissionServices permissionServices, Enums.Permission permission)
            {
                _permissionServices = permissionServices;
                _permission = permission;
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
                
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                string token = context.HttpContext.Request.Headers["Authorization"];
                string idUser = Utils.GetClaimValue(token, TypeClaims.IdUser);
                bool result = _permissionServices.ValidatePermissionByUser(_permission, Convert.ToInt32(idUser));
                if (!result)
                    throw new BusinessException(GeneralMessages.WithoutPermission);
            }
        }
    }
}
