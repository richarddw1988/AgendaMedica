using DDDCore.Domain.Interfaces.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDCore.Domain.Models.Specs.User
{
  public class UpdateUserSpec : ISpecification<UserEntity>
  {
    public bool IsSatisfiedBy(UserEntity entity)
    {
      throw new NotImplementedException();
    }
  }
}
