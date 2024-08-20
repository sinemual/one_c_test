using System;
using _Project.Scripts.Data;
using _Project.Scripts.Enemy;
using _Project.Scripts.Player;
using _Project.Scripts.UI;

namespace _Project.Scripts.Levels
{
    public class Level
    {
        private LevelView _view;
        private LevelData _data;
        
        public Action<int> EnemyGetPlayer;

        private readonly EnemySetupManager enemySetupManager;
        private readonly LevelStateController levelStateController;
        private readonly PlayerSetupManager playerSetupManager;
        public LevelView View => _view;
        public LevelData Data => _data;
        public int LevelEnemyAmount { get; set; }
        public int DiedEnemyCounter { get; set; }
        public LevelStateController LevelStateController => levelStateController;
        public EnemySetupManager EnemySetupManager => enemySetupManager;
        public PlayerSetupManager PlayerSetupManager => playerSetupManager;

        public Level(SharedData sharedData, RuntimeData runtimeData, UserInterface userInterface, EnemyFactory enemyFactory, PlayerFactory playerFactory)
        {
            enemySetupManager = new EnemySetupManager(this, enemyFactory);
            playerSetupManager = new PlayerSetupManager(this, playerFactory, userInterface, runtimeData, sharedData);
            levelStateController = new LevelStateController(this, userInterface, runtimeData, sharedData);
        }

        public void Init(LevelView view, LevelData data)
        {
            _view = view;
            _data = data;
            DiedEnemyCounter = 0;
        }

        public void Setup()
        {
            PlayerSetupManager.CalculatePlayerGetDamageBorder();
            var playerUnit = PlayerSetupManager.PlayerUnitSetup();
            LevelStateController.SetPlayerUnit(playerUnit);
            EnemySetupManager.EnemyUnitsInit();
        }
    }
}