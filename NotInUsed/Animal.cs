using System;
using System.Collections.Generic;
using System.Text;

namespace NotInUsed
{
    public  class Animal: IDisposable
    {
        public Animal()
        {
            // allocate any unmanaged resources
        }
        ~Animal()//Finalizer
        {
            if (disposed) return;
            Dispose(false);
            // deallocate any unmanaged resources
        }
        bool disposed = false;// have resources been released?
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            // deallocate the *unmanaged* resource
            // ...
            if (disposing)
            {
                // deallocate any other *managed* resources
                // ...
            }
            disposed = true;
        }
    }
}
