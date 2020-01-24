using DDDCore.Domain.Enum;
using DDDCore.Domain.Models.Specs.User;
using DDDCore.Domain.Validation;
using TestePratico.Domain.Validation;

namespace DDDCore.Domain.Models.Validators
{
  public class UserValidator : Validator<UserEntity>
  {
    public UserValidator(CommandEnum.Type cmdEnumType)
    {
      switch (cmdEnumType)
      {
        case CommandEnum.Type.CREATE:
          AddRule(new ValidationRule<UserEntity>(new CreateUserSpec(), "Teste 1"));
          break;
        case CommandEnum.Type.UPDATE:
          AddRule(new ValidationRule<UserEntity>(new UpdateUserSpec(), "Teste 2"));
          break;
        case CommandEnum.Type.DELETE:
          AddRule(new ValidationRule<UserEntity>(new RemoveUserSpec(), "Teste 3"));
          break;
      }
    }
  }
}
