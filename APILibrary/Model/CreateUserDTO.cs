using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APILibrary.Model
{
    public class CreateUserDTO : ICommonModel
    {
            public string Name { get; set; }
            public string Job { get; set; }
            public string Id { get; set; }
            public DateTimeOffset CreatedAt { get; set; }

    }
}
