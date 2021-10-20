using System;
using System.Collections.Generic;
using System.Text;

namespace Packt.Shared
{
    [System.Flags]
    public enum WondersOfTheAncientWord : byte
    {
        None = 0b_0000_0000,
        CreatPyramidOfGiza = 0b_0000_0001,
        HangingGardensOfBabylon = 0b_0000_0010,
        StatueOfArtemisAtEphesus = 0b_0000_0100,
        MausoleumAtHalicarnassus = 0b_0000_1000,
        ColossusOfRhodes = 0b_0001_0000,
        LighthouseOfAlexandria = 0b_0010_0000,
        TempleOfArtemisAtEphesus = 0b_0100_0000
    }
}
