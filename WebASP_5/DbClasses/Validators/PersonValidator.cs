using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebASP_5.Models.ViewModels;

namespace WebASP_5.DbClasses.Validators
{
    public class PersonValidator : ModelValidator
    {
        public PersonValidator(ModelMetadata metadata, ControllerContext controllerContext) : base(metadata, controllerContext)
        {
        }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            List<ModelValidationResult> errors = new List<ModelValidationResult>();
            if(Metadata.Model is Person person)
            {
                if (person.Name=="John" && person.Surname=="Doe" && person.Year == 200)
                {
                    errors.Add(new ModelValidationResult { MemberName = "", Message = "Invalid entry" });
                }
                //...
            }
            return errors;
        }
    }
}