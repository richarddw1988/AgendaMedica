using DDDCore.Domain.Interfaces.Validation;

namespace DDDCore.Domain.Validation
{
  public class ValidationRule<TEntity> : IValidationRule<TEntity>
	{
		protected readonly ISpecification<TEntity> specification;

		public string ErrorMessage { get; private set; }

		public bool Valid(TEntity entity)
		{
			return specification.IsSatisfiedBy(entity);
		}

		public ValidationRule(ISpecification<TEntity> specification, string errorMessage)
		{
			this.specification = specification;
			ErrorMessage = errorMessage;
		}
	}
}
