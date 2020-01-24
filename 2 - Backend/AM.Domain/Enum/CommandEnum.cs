using System;
using System.Collections.Generic;
using System.Text;

namespace DDDCore.Domain.Enum
{
  public class CommandEnum
  {
    public enum Type {
      CREATE = 1,
      UPDATE = 2,
      DELETE = 3
    }
  }
}
