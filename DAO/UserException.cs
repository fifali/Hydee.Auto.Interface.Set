using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydee.Auto.Interface.Set.DAO
{
    public class UserException : Exception
    {
        private string message;

        public UserException(string userMessage)
            : base()
        {
            message = userMessage;
        }

        public override string Message
        {
            get
            {
                return message;
            }
        }

    }
}
