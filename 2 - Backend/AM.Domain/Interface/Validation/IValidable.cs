using AM.Domain.Enum;
using AM.Domain.Validation;

namespace AM.Domain.Interfaces.Validation
{
  public interface IValidable
	{
		ValidationResult ValidationResult { get; }
    bool IsValid(CommandEnum.Type cmdType);
  }
}
