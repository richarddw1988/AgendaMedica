using DDDCore.Domain.Enum;
using DDDCore.Domain.Validation;

namespace DDDCore.Domain.Interfaces.Validation
{
  public interface IValidable
	{
		ValidationResult ValidationResult { get; }
    bool IsValid(CommandEnum.Type cmdType);
  }
}
