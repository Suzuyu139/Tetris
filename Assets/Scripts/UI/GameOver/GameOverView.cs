using UnityEngine;
using UnityEngine.UI;
using R3;

public class GameOverView : ViewBase
{
    [SerializeField] Button _gameOverButton = null;
    public Observable<Unit> GameOverButtonObservable => _gameOverButton.OnClickAsObservable();

    [SerializeField] GameObject _gameOverUiObj = null;

    private void Start()
    {
        _gameOverUiObj.SetActive(false);
    }

    public void ChangeGameOverObjActive(bool isActive)
    {
        _gameOverUiObj.SetActive(isActive);
    }
}
