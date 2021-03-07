using System;

namespace Itau.Teste.Domain.Exceptions
{
    public class LancamentoConciliadoException : Exception
    {
        public LancamentoConciliadoException()
        {
        }

        public LancamentoConciliadoException(string message)
            : base(message)
        {
        }

        public LancamentoConciliadoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
