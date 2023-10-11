using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebASP_5.Models.ViewModels;

namespace WebASP_5.DbClasses.Validators
{
    public class PersonPropertyValidator : ModelValidator
    {
        public PersonPropertyValidator(ModelMetadata metadata, ControllerContext controllerContext) : base(metadata, controllerContext)
        {
        }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            List<ModelValidationResult> errors = new List<ModelValidationResult>();

            if(container is Person person)
            {
                switch(Metadata.PropertyName)
                {
                    case "Name":
                        if(string.IsNullOrEmpty(person.Name))
                        {
                            errors.Add(new ModelValidationResult { Message = "Name is required" });
                        }
                        break;
                    case "Surname":
                        if (string.IsNullOrEmpty(person.Surname))
                        {
                            errors.Add(new ModelValidationResult { Message = "Surname is required" });
                        }
                        break;
                    case "Year":
                        if(person.Year > 2000 || person.Year < 1700)
                        {
                            errors.Add(new ModelValidationResult { Message = "InvalidYear" });
                        }
                        break;
                }
            }

            return errors;
        }
    }
}