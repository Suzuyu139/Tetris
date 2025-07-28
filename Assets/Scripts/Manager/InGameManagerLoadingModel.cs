using UnityEngine;

public class InGameManagerLoadingModel : ModelBase
{
    [SerializeField] GameObject _inGameUiObj = null;
    public GameObject InGameUiObj => _inGameUiObj;
}
