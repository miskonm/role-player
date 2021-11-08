using System.Collections.Generic;
using Course.Managers.CameraManager.FirstPerson;
using Course.Managers.CameraManager.ThirdPerson;

namespace Course.Managers.CameraManager
{
    public interface ICameraManager
    {
        ICollection<ICamera> AllCameras { get; }

        void ToggleFirstThirdPersonCamera(int playerIndex);

        void AddFirstPersonCamera(IFirstPersonCamera camera);
        void RemoveFirstPersonCamera(IFirstPersonCamera camera);

        void AddThirdPersonCamera(IThirdPersonCamera camera);
        void RemoveThirdPersonCamera(IThirdPersonCamera camera);
    }
}
