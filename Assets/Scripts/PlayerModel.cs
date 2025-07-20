using UnityEngine;
using R3;

public class PlayerModel : MonoBehaviour
{
    CompositeDisposable _disposables = new CompositeDisposable();

    private void OnDestroy()
    {
        _disposables.Dispose();
    }
}
