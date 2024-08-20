using _Project.Scripts.Data;
using _Project.Scripts.Levels;
using _Project.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private UserInterface _ui;
        [SerializeField] private SharedData _data;
        
        public override void InstallBindings()
        {
            Container.Bind<SharedData>().FromInstance(_data).AsSingle();
            
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
            Container.Bind<RuntimeData>().AsSingle();
            Container.Bind<UserInterfaceInputEventBus>().AsSingle();
            
            UserInterface ui = Container.InstantiatePrefabForComponent<UserInterface>(_ui);
            Container.Bind<UserInterface>().FromInstance(ui).AsSingle();
            
            Container.Bind<VfxFactory>().AsSingle();
        }
    }
}