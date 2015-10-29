using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuartzAdmin.web.Models
{
    public class ConnectionModel: IValidatingModel
    {
        public int ConnectionId { get; set; }
        public string Name { get; set; }

        private List<ConnectionParameterModel> _connectionParameters = new List<ConnectionParameterModel>();
        public List<ConnectionParameterModel> ConnectionParameters
        {
            get { return this._connectionParameters; }
        }

        public bool IsValid
        {
            get { return this.GetRuleViolations().Count() == 0; }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(this.Name))
            {
                yield return new RuleViolation("Name required", "Name" );
            }

            if (this._connectionParameters.Count == 0)
            {
                yield return new RuleViolation("At least one connection parameter required");
            }


            foreach (ConnectionParameterModel connectionParameter in this._connectionParameters)
            {
                foreach( RuleViolation ruleViolation in connectionParameter.GetRuleViolations() )
                {
                    yield return ruleViolation;
                }
            }


            yield break;
        }

    }
}
