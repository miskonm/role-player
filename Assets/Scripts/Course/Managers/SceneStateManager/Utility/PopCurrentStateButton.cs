using Course.Managers.SceneStateManager.State;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Course.Managers.SceneStateManager.Utility
{
    [RequireComponent(typeof(Button))]
    public sealed class PopCurrentStateButton : MonoBehaviour
    {
        [Inject] ISceneStateManager manager = default;
        [Inject] ISceneState state = default;

        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() => manager.Pop(state));
        }
    }
}
