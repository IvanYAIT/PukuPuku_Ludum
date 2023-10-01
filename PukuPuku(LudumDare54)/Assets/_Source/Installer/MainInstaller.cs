using Player;
using UnityEngine;
using Zenject;
using Claustrophobia;

namespace Core
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private CharacterData characterData;
        [SerializeField] private ClaustrophobiaSettings settings;
        [SerializeField] private ClaustrophobiaView view;

        public override void InstallBindings()
        {
            Container.Bind<Player.CharacterController>().AsSingle().NonLazy();
            Container.Bind<CharacterData>().FromInstance(characterData).AsSingle().NonLazy();
            Container.Bind<ClaustrophobiaSettings>().FromInstance(settings).AsSingle().NonLazy();
            Container.Bind<ClaustrophobiaView>().FromInstance(view).AsSingle().NonLazy();
            Container.Bind<ClaustrophobiaController>().AsSingle().NonLazy();
            

        }
    }
}