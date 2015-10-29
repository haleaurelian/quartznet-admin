using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuartzAdmin.web.Models
{
    public class ConnectionParameterModel : IValidatingModel
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public bool IsValid
        {
            get { return this.GetRuleViolations().Count() == 0; }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(this.Key))
            {
                yield return new RuleViolation("Parameter key required", "Key");
            }

            if (String.IsNullOrEmpty(this.Value))
            {
                yield return new RuleViolation("Parameter value required", "Value");
            }
        }

        public static List<ConnectionParameterModel> FromFormCollection(FormCollection formCollection)
        {
            List<ConnectionParameterModel> connectionParameterList = new List<ConnectionParameterModel>();
            string keyPrefix = "ConnectionParameterKey";
            string valuePrefix = "ConnectionParameterValue";

            string parameterIndex = null;
            string parameterKey = null;
            string parameterValue = null;

            //formCollection["ConnectionParameterKey1"] = "key1";
            //formCollection["ConnectionParameterValue1"] = "value1";

            foreach (string key in formCollection.AllKeys)
            {
                if (key.StartsWith(keyPrefix))
                {
                    parameterIndex = key.Remove(0, keyPrefix.Length);
                    parameterKey = formCollection[key];
                    parameterValue = formCollection[valuePrefix + parameterIndex];
                    connectionParameterList.Add(new ConnectionParameterModel() { Key = parameterKey, Value = parameterValue });
                }
            }

            return connectionParameterList;
        }
    }
}
