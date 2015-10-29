using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuartzAdmin.web.Models
{
    public interface IValidatingModel
    {
        bool IsValid { get; }
        IEnumerable<RuleViolation> GetRuleViolations(); 
    }
}
