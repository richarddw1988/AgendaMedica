using DDDCore.Domain.Enum;
using DDDCore.Domain.Interfaces.Validation;
using DDDCore.Domain.Models.Validators;
using DDDCore.Domain.Validation;

namespace DDDCore.Domain.Models
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
