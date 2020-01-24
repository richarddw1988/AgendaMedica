using DDDCore.Domain.Validation;

namespace DDDCore.Domain.Interfaces.Validation
{
  public interface IValidator<in TEntity>
	{
		ValidationResult Validate(TEntity entity);
	}
}
