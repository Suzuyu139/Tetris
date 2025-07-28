using UnityEngine;

public class InGameUiModel : ModelBase
{
    [SerializeField] GameObject _gameOverObj = null;
    public GameObject GameOverObj => _gameOverObj;
}
