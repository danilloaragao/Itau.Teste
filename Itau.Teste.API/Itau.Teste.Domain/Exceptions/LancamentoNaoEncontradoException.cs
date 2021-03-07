using System;

namespace Itau.Teste.Domain.Exceptions
{
    public class LancamentoNaoEncontradoException : Exception
    {
        public LancamentoNaoEncontradoException()
        {
        }

        public LancamentoNaoEncontradoException(string message)
            : base(message)
        {
        }

        public LancamentoNaoEncontradoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
