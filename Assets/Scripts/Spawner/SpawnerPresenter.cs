using UnityEngine;
using Cysharp.Threading.Tasks;

public class SpawnerPresenter : PresenterBase
{
    [SerializeField] BlockPresenter[] _blockPresenters = null;

    private void Start()
    {
        Initialize().Forget();
    }

    protected override async UniTask Initialize()
    {
        IsInitialized = true;
        await UniTask.CompletedTask;
    }

    public BlockPresenter SpawnBlock()
    {
        BlockPresenter block = Instantiate(GetRandomBlock(), transform.position, Quaternion.identity);

        if (block)
        {
            return block;
        }
        else
        {
            return null;
        }
    }

    BlockPresenter GetRandomBlock()
    {
        int i = Random.Range(0, _blockPresenters.Length);
        return _blockPresenters[i];
    }
}
