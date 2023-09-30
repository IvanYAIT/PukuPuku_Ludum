using Player;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private CharacterData characterData;

        public override void InstallBindings()
        {
            Container.Bind<Player.CharacterController>().AsSingle().NonLazy();
            Container.Bind<CharacterData>().FromInstance(characterData).AsSingle().NonLazy();
            
        }
    }
}