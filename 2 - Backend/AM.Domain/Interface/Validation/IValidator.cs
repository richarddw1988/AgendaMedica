using AM.Domain.Validation;

namespace AM.Domain.Interfaces.Validation
{
  public interface IValidator<in TEntity>
	{
		ValidationResult Validate(TEntity entity);
	}
}
