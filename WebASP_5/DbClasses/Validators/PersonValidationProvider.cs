using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebASP_5.Models.ViewModels;

namespace WebASP_5.DbClasses.Validators
{
    public class PersonValidationProvider : ModelValidatorProvider
    {
        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            if(metadata.ContainerType == typeof(Person))
            {
                return new ModelValidator[] { new PersonPropertyValidator(metadata, context) };
            }

            if (metadata.ModelType == typeof(Person))
            {
                return new ModelValidator[] { new PersonValidator(metadata, context) };
            }

            return Enumerable.Empty<ModelValidator>();
        }
    }
}