using System;
using _Project.Scripts.Enemy;
using _Project.Scripts.Levels;
using _Project.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Core
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            PlayerFactory playerFactory = Container.Instantiate<PlayerFactory>();
            Container.Bind<PlayerFactory>().FromInstance(playerFactory).AsSingle();
            
            EnemyFactory enemyFactory = Container.Instantiate<EnemyFactory>();
            Container.Bind<EnemyFactory>().FromInstance(enemyFactory).AsSingle();
            
            Container.Bind<LevelFactory>().AsSingle();
            
            LevelCreator _levelCreator = Container.Instantiate<LevelCreator>();
            Container.Bind<LevelCreator>().FromInstance(_levelCreator).AsSingle();
            
            _levelCreator.Initialize();
        }
    }
}