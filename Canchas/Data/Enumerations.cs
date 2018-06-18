using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canchas.Data
{
    public class AccountType
    {
        public const int User = 0;
        public const int Operator = 1;
        public const int Admin = 2;
        public const int SystemAdmin = 3;
    }
    public class Erased
    {
        public const int NO = 0;
        public const int YES = 1;
    }
    public class Status
    {
        public const int ACTIVE = 0;
        public const int INACTIVE = 1;
    }
}
