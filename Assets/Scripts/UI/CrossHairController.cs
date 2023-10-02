using System;
using MyEvent;
using Player;
using UnityEngine;

namespace UI
{
    public class CrossHairController : MonoBehaviour
    {
        [SerializeField] private PlayerUltraHand playerUltraHand;
        [SerializeField] private GameObject crossHair;

        private void OnEnable()
        {
            EventManager.Register<OnUltraHandEnable>(UltraHandEnable);
            EventManager.Register<OnUltraHandDisable>(UltraHandDisable);
            EventManager.Register<OnCatchItem>(UltraHandSelectItem);
        }

        private void OnDisable()
        {
            EventManager.Unregister<OnUltraHandEnable>(UltraHandEnable);
            EventManager.Unregister<OnUltraHandDisable>(UltraHandDisable);
            EventManager.Unregister<OnCatchItem>(UltraHandSelectItem);
        }


        private void UltraHandEnable(OnUltraHandEnable e)
        {
            crossHair.SetActive(true);
        }


        private void UltraHandDisable(OnUltraHandDisable e)
        {
            crossHair.SetActive(false);
        }


        private void UltraHandSelectItem(OnCatchItem e)
        {
            crossHair.SetActive(false);
        }
    }
}