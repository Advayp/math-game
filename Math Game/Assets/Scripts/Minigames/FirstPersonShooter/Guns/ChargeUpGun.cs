using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.Guns
{

    public class ChargeUpGun : MonoBehaviour
    {
        [SerializeField, Header("Dependencies")]
        private Transform mainCamera;


        [SerializeField, Header("Config"), Space]
        private int damage;
        [SerializeField] private float maxChargeUpTime;
        [SerializeField] private float maxDistance;

        private float _currentChargeUpTime;
        private IGunInput _gunInput;
        private IChargeDamageCalculator _calculator;
        private IChargeAmountDisplayer _displayer;

        private float CurrentDamage => damage * _calculator.GetDamage(_currentChargeUpTime, maxChargeUpTime);

        private void Awake()
        {
            mainCamera.Require(this);
            _gunInput = GetComponent<IGunInput>();
            _calculator = new StandardChargeDamageCalculator();
            _displayer = GetComponent<IChargeAmountDisplayer>();
        }

        private void Start()
        {
            _displayer.Initialize(maxChargeUpTime);
        }

        private void Update()
        {
            if (_gunInput.GetInput())
            {
                _currentChargeUpTime += Time.deltaTime;
                _currentChargeUpTime = Mathf.Clamp(_currentChargeUpTime, 0, maxChargeUpTime);
                _displayer.HandleTime(_currentChargeUpTime);

            }
            if (!Input.GetButtonUp("Fire1") && !Input.GetKeyUp(KeyCode.E)) return;
            Shoot();
            _currentChargeUpTime = 0;
            _displayer.HandleTime(_currentChargeUpTime);
        }

        private void OnEnable()
        {
            _displayer.Show();
        }

        private void OnDisable()
        {
            _displayer.Hide();
        }

        private void Shoot()
        {

            if (!Physics.Raycast(mainCamera.position, mainCamera.forward, out var hit, maxDistance)) return;

            var damageable = hit.collider.GetComponent<IDamageable>();
            Debug.Log(CurrentDamage);
            damageable?.TakeDamage(CurrentDamage);

        }
        

    }
}