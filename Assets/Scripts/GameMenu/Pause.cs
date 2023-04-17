using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    internal bool isPaused { get; private set; }

    public static Pause instance { get; private set; }

    private void Awake()
    {
        if(instance != null && instance != this) Destroy(this);
        else instance = this;
    }

    private void Start() => InputSystem.input.UI.Pause.performed += context => SetPause();   

    public void SetPause()
    {
        //if(GameControl.Instance.isLoosed) return;
        isPaused = !isPaused;

        if(isPaused) InputSystem.instance.SwitchInputMap("UI");
        if(!isPaused) InputSystem.instance.SwitchInputMap("Game");

        //GameControl.Instance.SetBlackPanel(isPaused);
        _pausePanel.SetActive(isPaused);
    }
    
    private void OnDestroy() { if(instance == this) instance = null; }
}