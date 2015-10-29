using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuartzAdmin.web.Models
{
    public interface IInstanceRepository
    {
        void Save(InstanceModel instance);
        void Delete(InstanceModel instance);
        InstanceModel GetByName(string name);
        List<InstanceModel> GetAll();
    }
}
