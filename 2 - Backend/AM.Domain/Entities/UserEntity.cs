using AM.Domain.Enum;
using AM.Domain.Interfaces.Validation;
using AM.Domain.Models.Validators;
using AM.Domain.Validation;

namespace AM.Domain.Models
{
  public class UserEntity : Entity, IValidable
  {
    public string Name { get; set; }

    public string Cpf { get; set; }

    public ValidationResult ValidationResult { get; private set; }
    public bool IsValid(CommandEnum.Type cmdType)
    {
        ValidationResult = new UserValidator(cmdType).Validate(this);
        return ValidationResult.IsValid; 
    }
  }
}
