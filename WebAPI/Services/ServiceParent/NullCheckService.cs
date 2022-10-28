using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebAPI.Services.ServiceParent;

public abstract class NullCheckService
{
    protected static void NullCheck(object dto) //Reflection to check for null in dto fields
    {
        foreach (PropertyInfo prop in dto.GetType().GetProperties())
        {
            if(prop.GetValue(dto, null) == null)
                throw new ValidationException(prop.Name + " cannot be null");
        }
    }
}