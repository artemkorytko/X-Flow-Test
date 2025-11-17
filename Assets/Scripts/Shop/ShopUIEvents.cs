using System;
using UnityEngine;


namespace Shop
{
    public static class ShopUIEvents
    {
        public static event Action OnPlayerDataChanged;

        public static void BroadcastPlayerDataChanged()
        {
            OnPlayerDataChanged?.Invoke();
        }
    }
}