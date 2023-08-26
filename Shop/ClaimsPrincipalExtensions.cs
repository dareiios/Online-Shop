using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shop
{
    //тк thhpcontext возвращает объект с множеством данных, нужно взять только определенные данные от туда
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal user) 
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

    }
}
