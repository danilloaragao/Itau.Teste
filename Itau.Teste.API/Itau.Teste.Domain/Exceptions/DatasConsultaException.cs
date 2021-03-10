using System;

namespace Itau.Teste.Domain.Exceptions
{
    public class DatasConsultaException : Exception
    {
        public DatasConsultaException()
        {
        }

        public DatasConsultaException(string message)
            : base(message)
        {
        }

        public DatasConsultaException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
