using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuartzAdmin.web.Models
{
    public interface IConnectionRepository
    {
        int Count { get; }

        void AddConnection(ConnectionModel connection);
        ConnectionModel GetConnection(int connectionId);
        bool IsValid(ConnectionModel connection, out IEnumerable<RuleViolation> ruleViolations);
        void RemoveConnection(ConnectionModel connection);
        IEnumerable<ConnectionModel> GetConnections();
        void Save();

    }
}
