using _Project.Scripts.Data;
using _Project.Scripts.Player;
using _Project.Scripts.UI;

namespace _Project.Scripts.Levels
{
    public class PlayerSetupManager
    {
        private readonly Level _level;
        private readonly PlayerFactory _playerFactory;
        private readonly UserInterface _userInterface;
        private readonly RuntimeData _runtimeData;
        private readonly SharedData _sharedData;

        public PlayerSetupManager(Level level, PlayerFactory playerFactory, UserInterface userInterface, RuntimeData runtimeData, SharedData sharedData)
        {
            _level = level;
            _playerFactory = playerFactory;
            _userInterface = userInterface;
            _runtimeData = runtimeData;
            _sharedData = sharedData;
        }

        public void CalculatePlayerGetDamageBorder()
        {
            _userInterface.BorderScreen.SetTopBorder(_level.Data.PlayerFlyRange);
            _runtimeData.PlayerGetDamageBorderPosition = _userInterface.BorderScreen.GetTopRightCorner();
        }

        public PlayerUnit PlayerUnitSetup()
        {
            var playerUnit = _playerFactory.Create(_sharedData.PlayerUnitData, _level.View.PlayerSpawnPoint.gameObject.transform);
            playerUnit.SetWeapon(_sharedData.PlayerUnitData.DefaultWeapon);
                
            playerUnit.Movement.SetBorders(_userInterface.BorderScreen.GetTopRightCorner(), _userInterface.BorderScreen.GetLeftBottomCorner());
            playerUnit.Health.UpdateHealth += (health) => _userInterface.PlayerHealthScreen.SetHealthPointText($"{health}");

            playerUnit.Health.Die += _level.LevelStateController.OnLevelFailed;

            _userInterface.PlayerHealthScreen.SetHealthPointText($"{_sharedData.PlayerUnitData.Health}");

            _level.EnemyGetPlayer += (damage) => { playerUnit.Health.TakeDamage(damage); };
            return playerUnit;
        }

        public void OnEnemyGetPlayer(int damage) => _level.EnemyGetPlayer?.Invoke(damage);
    }
}