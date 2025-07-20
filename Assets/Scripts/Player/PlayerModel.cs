using UnityEngine;
using R3;

public class PlayerModel : ModelBase
{
    CompositeDisposable _disposables = new CompositeDisposable();

    private void OnDestroy()
    {
        _disposables.Dispose();
    }
}
