using FluentValidation.Results;
using Part_3_Lesson_4.Controllers.Interfaces;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace Part_3_Lesson_4
{
    public class Foo
    {
        public readonly InterfaceForCheaking interfaceFor;
        public Foo(InterfaceForCheaking forCheaking)
        {
            interfaceFor = forCheaking;
        }
        public void Validate()
        {
            User user = new User()
            {
                FirstName = "Василий",
                LastName = "Пупкин"
            };
            UserAtribute userValidationService = new UserAtribute(interfaceFor);
            ValidationResult result = userValidationService.Validate(user);
            if (result.IsValid)
            {
                return;
            }
            foreach (ValidationFailure failure in result.Errors)
            {
                Console.WriteLine($"{failure.ErrorCode} = {failure.PropertyName} {failure.ErrorMessage}");
            }
        }

    }
}
