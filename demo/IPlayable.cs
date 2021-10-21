using System;
using System.Collections.Generic;
using System.Text;

namespace Packt.Shared
{
    public interface IPlayable
    {
        void Play();
        void Pause();
        void Stop()
        {
            Console.WriteLine("Default implementation of stop");
        }
    }
}
