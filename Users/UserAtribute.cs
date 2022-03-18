using FluentValidation;
using FluentValidation.Results;
using Part_3_Lesson_4.Controllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_3_Lesson_4
{
    public class UserAtribute:AbstractValidator<User>
    {
        /// <summary>
        /// тут представлена логи на ограничения по вводиму тексту в поля для регистрации
        /// </summary>
        private readonly InterfaceForCheaking interfaceFor;
        public UserAtribute(InterfaceForCheaking forCheaking)
        {
            interfaceFor = forCheaking;
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Имя не должно быть пустым").WithErrorCode("001");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("фамилия не может быть пустая").WithErrorCode("002");
            RuleFor(x => x.FirstName).Custom((ExistName, context) =>
              {
                  if (!forCheaking.IsUserNameAlreadyExist(ExistName))
                  {
                      context.AddFailure(new ValidationFailure(nameof(User.FirstName), "Уже существует") { ErrorCode = "003" });
                  }
              });
        }
    }
}
