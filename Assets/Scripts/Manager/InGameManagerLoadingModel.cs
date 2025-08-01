using UnityEngine;

public class InGameManagerLoadingModel : ModelBase
{
    [SerializeField] GameObject _inGameUiObj = null;
    public GameObject InGameUiObj => _inGameUiObj;

    [SerializeField] GameObject _playerObj = null;
    public GameObject PlayerObj => _playerObj;

    [SerializeField] GameObject _boardObj = null;
    public GameObject BoardObj => _boardObj;

    [SerializeField] GameObject _spwnerObj = null;
    public GameObject SpawnObj => _spwnerObj;
}
