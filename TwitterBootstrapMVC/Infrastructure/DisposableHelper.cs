using System;

namespace TwitterBootstrapMVC.Infrastructure
{
    class DisposableHelper : IDisposable
    {
        private Action end;
        // When the object is create, write "begin" function
        // make this public so it can be accessible
        public DisposableHelper(Action begin, Action end)
        {
            this.end = end;
            begin();
        }
        // When the object is disposed (end of using block), write "end" function
        public void Dispose()
        {
            end();
        }
    }
}
