using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuartzAdmin.web.Models;
using System.Web.Mvc;

namespace QuartzAdmin.web.Helpers
{
    public static class ControllerHelpers
    {
        public static void AddRuleViolations(this ModelStateDictionary modelState, IEnumerable<RuleViolation> ruleViolations)
        {
            foreach (RuleViolation ruleViolation in ruleViolations)
            {
                modelState.AddModelError(ruleViolation.PropertyName ?? Guid.NewGuid().ToString(), ruleViolation.ErrorMessage);
            }
        }
    }
}
