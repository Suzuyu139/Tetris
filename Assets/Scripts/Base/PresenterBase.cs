    using UnityEngine;
    using Cysharp.Threading.Tasks;

    public abstract class PresenterBase : MonoBehaviour
    {
        public bool IsInitialized { get; protected set; } = false;

        protected abstract UniTask Initialize();
    }
