using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation
{
    public interface IAttacker
    {
        IPlayer Player { get; }
    }
}
