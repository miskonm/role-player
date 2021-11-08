using UnityEngine;

namespace Course.Managers.CameraManager
{
    public interface ICamera
    {
        GameObject GameObject { get; }
        int PlayerIndex { get; }
    }
}
