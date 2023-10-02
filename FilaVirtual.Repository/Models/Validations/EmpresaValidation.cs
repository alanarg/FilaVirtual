using FilaVirtual.Business.Models;
using FluentValidation;

namespace PPA.Business.Models.Validations
{
	class EmpresaValidation : AbstractValidator<Empresa>
	{
		public EmpresaValidation()
		{
			RuleFor(i => i.AspNetUsersID)
				.NotNull().WithMessage("A Proposta deve estar vinculada à alguem");

		}
	}
}
