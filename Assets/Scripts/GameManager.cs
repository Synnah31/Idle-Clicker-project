using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text ClicksTotalText;
    private IdleGModel _model;
    [SerializeField] IntView _moneyView;
    [SerializeField] IntView _joyUpgradePriceView;
    [SerializeField] IntView _sadUpgradePriceView;
    [SerializeField] IntView _fearUpgradePriceView;
    [SerializeField] IntView _angerUpgradePriceView;

    [SerializeField] private GameObject _waypointsJoy;
    [SerializeField] private GameObject _waypointsSad;
    [SerializeField] private GameObject _waypointsFear;
    [SerializeField] private GameObject _waypointsDisgust;
    [SerializeField] private GameObject _waypointsAnger;
    [SerializeField] private GameObject _client;
    [SerializeField] Button _buttonSpawn;

    [SerializeField] private MachineTrigger _joyMachineTrigger;
    [SerializeField] private MachineTrigger _sadMachineTrigger;
    [SerializeField] private MachineTrigger _fearMachineTrigger;
    private bool _isJoy = false;
    private bool _isSad = false;
    private bool _isFear = false;

    float TotalClicks;
    bool HasUpgrade = false;

    public int AutoClicksPerSecond;
    public int MinimumClicksToUnlockUpgrade;
    

    public void AutoClickUpgrade()
    {
        if (!HasUpgrade && TotalClicks >= MinimumClicksToUnlockUpgrade)
        {
            TotalClicks -= MinimumClicksToUnlockUpgrade;
            HasUpgrade = true;

        }
    }
    private void Start()
    {
        _model = new IdleGModel();
        _model.GetMoney().Subscribe(_moneyView);
        _model.GetJoyPriceUpgrade().Subscribe(_joyUpgradePriceView);
        _model.GetSadPriceUpgrade().Subscribe(_sadUpgradePriceView);
        _model.GetFearPriceUpgrade().Subscribe(_fearUpgradePriceView);
        _model.GetAngerPriceUpgrade().Subscribe(_angerUpgradePriceView);
        _buttonSpawn.onClick.AddListener(spawnEmotion);
        _joyMachineTrigger.Subscribe(OnTriggerEnterJoyMachine);
        _sadMachineTrigger.Subscribe(OnTriggerEnterSadMachine);
        _fearMachineTrigger.Subscribe(OnTriggerEnterFearMachine);
    }

    private void OnTriggerEnterFearMachine(ClientControl clientControl)
    {
        Debug.Log("Une ame est rentrée dans la FearMachine");
        clientControl.TransformToFear();
        _model.AddMoney(400);
    }

    private void OnTriggerEnterSadMachine(ClientControl clientControl)
    {
        Debug.Log("Une ame est rentrée dans la SadMachine");
        clientControl.TransformToSad();
        _model.AddMoney(100);
    }

    private void OnTriggerEnterJoyMachine(ClientControl clientControl)
    {
        Debug.Log("Une ame est rentrée dans la JoyMachine");
        clientControl.TransformToJoy();
        _model.AddMoney(10);

    }

    private void spawnEmotion()
    {
        float posRandX;
        float posRandY;
        Vector2 posSpawn;

        _model.AddMoney(2);
        posRandX = Random.Range(-8, -6);
        posRandY = Random.Range(0, 3);
        posSpawn = new Vector2(posRandX, posRandY);
        GameObject client = Instantiate(_client, posSpawn, Quaternion.identity);
        client.GetComponent<ClientControl>().Init(_waypointsJoy, _waypointsSad, _waypointsFear, _waypointsDisgust, _waypointsAnger);
    }


    private void Update()
    {
        if (HasUpgrade)
        {
            TotalClicks += AutoClicksPerSecond * Time.deltaTime;
            ClicksTotalText.text = TotalClicks.ToString("0");

        }
    }

    public void BasicClick()
    {
        _model.AddMoney(1);
    }
    public void OnClickUpgradeJoy()
    {
        if (_model.GetMoney().GetValue() >= _model.GetJoyPriceUpgrade().GetValue())
        {
            _model.AddMoney(-_model.GetJoyPriceUpgrade().GetValue());
            _model.IncrementJoy();
        }

    }
    public void OnClickUpgradeSad()
    {
        _model.IncrementSad();
    }
    public void OnClickUpgradeFear()
    {
        _model.IncrementFear();
    }
    public void OnClickUpgradeAnger()
    {
        _model.IncrementAnger();
    }
}
