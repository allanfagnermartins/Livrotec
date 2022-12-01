using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorBD
{

    [Serializable]
    public class BDException : Exception
    {
        public BDException() { }
        public BDException(string message) : base(message) { }
        public BDException(string message, Exception inner) : base(message, inner) { }
        protected BDException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
