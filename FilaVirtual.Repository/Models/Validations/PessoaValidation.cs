//using FluentValidation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PPA.Business.Models.Validations
//{
//    public class PessoaValidation : AbstractValidator<Pessoa>
//    {
//        public PessoaValidation()
//        {
//            RuleFor(p => p.Nome)
//                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
//                .Length(2, 100)
//                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

//            RuleFor(p => p.Cpf.Length).Equal(CpfValidacao.TamanhoCpf)
//                .WithMessage("O CPF precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
//            RuleFor(p => CpfValidacao.Validar(p.Cpf)).Equal(true)
//                .WithMessage("O CPF fornecido é inválido.");
//            RuleFor(p => p.DataNascimento)
//                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
//            RuleFor(p => p.MunicipioID)
//               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

//        }
//    }
//}
