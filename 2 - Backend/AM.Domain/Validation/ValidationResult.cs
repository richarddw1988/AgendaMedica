﻿using System.Collections.Generic;

namespace DDDCore.Domain.Validation
{
  public class ValidationResult
	{
		protected readonly List<string> errors;

		public IEnumerable<string> Errors
		{
			get { return errors; }
		}

		public bool IsValid
		{
			get { return errors.Count == 0; }
		}

		public ValidationResult()
		{
			errors = new List<string>();
		}

		public void Add(string errorMessage)
		{
			errors.Add(errorMessage);
		}

		public void Remove(string errorMessage)
		{
			if (errors.Contains(errorMessage)) errors.Remove(errorMessage);
		}
	}
}
