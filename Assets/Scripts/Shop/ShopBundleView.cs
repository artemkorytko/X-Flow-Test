using System.Collections;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Shop
{
    public class ShopBundleView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private Button infoButton; // "i"
        [SerializeField] private Button buyButton;
        [SerializeField] private TextMeshProUGUI buyButtonText;

        private ShopBundle bundle;
        private ShopBundleViewMode mode;

        public void Setup(ShopBundle bundle, ShopBundleViewMode mode)
        {
            this.bundle = bundle;
            this.mode = mode;
            titleText.text = bundle.Title;

            UpdateInteractable();
            buyButton.onClick.RemoveAllListeners();
            buyButton.onClick.AddListener(OnBuyClicked);
            if (mode == ShopBundleViewMode.InDetail)
            {
                infoButton.gameObject.SetActive(false);
            }
            else
            {
                infoButton.onClick.RemoveAllListeners();
                infoButton.onClick.AddListener(OnInfoClicked);
            }
        }

        public void UpdateInteractable()
        {
            if (bundle == null) return;

            buyButton.interactable = bundle.CanBuy(PlayerData.Instance);
            buyButtonText.text = "Купить";
        }

        private void OnInfoClicked()
        {
            DataBus.Push(ShopDataKeys.SelectedBundle, bundle);
            NavigationService.OpenAdditive("ShopBundleScene");
        }

        private void OnBuyClicked()
        {
            StartCoroutine(BuyCoroutine());
        }

        private IEnumerator BuyCoroutine()
        {
            buyButton.interactable = false;
            buyButtonText.text = "Обработка...";
            yield return new WaitForSeconds(3f);

            bundle.Buy(PlayerData.Instance);

            // обновляем UI после изменения ресурсов
            buyButtonText.text = "Купить";
            UpdateInteractable();
            // уведомить глобально UI (через event или polling) - допустимо сделать simple broadcast
            ShopUIEvents.BroadcastPlayerDataChanged();
        }
    }
}