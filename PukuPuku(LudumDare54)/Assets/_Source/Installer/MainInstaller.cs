using Player;
using UnityEngine;
using Zenject;
using Claustrophobia;
using UI;

namespace Core
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private CharacterData characterData;
        [SerializeField] private ClaustrophobiaSettings settings;
        [SerializeField] private ClaustrophobiaView view;
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private WinMenuView winMenuView;

        public override void InstallBindings()
        {
            Container.Bind<Animator>().FromInstance(playerAnimator).AsSingle().NonLazy();
            Container.Bind<WinMenuView>().FromInstance(winMenuView).AsSingle().NonLazy();
            Container.Bind<CharacterAnimationController>().AsSingle().NonLazy();
            Container.Bind<Player.CharacterController>().AsSingle().NonLazy();
            Container.Bind<CharacterData>().FromInstance(characterData).AsSingle().NonLazy();
            Container.Bind<ClaustrophobiaSettings>().FromInstance(settings).AsSingle().NonLazy();
            Container.Bind<ClaustrophobiaView>().FromInstance(view).AsSingle().NonLazy();
            Container.Bind<ClaustrophobiaController>().AsSingle().NonLazy();
            Container.Bind<WinMenuController>().AsSingle().NonLazy();
        }
    }
}