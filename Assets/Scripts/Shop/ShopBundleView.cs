using System.Collections;
using Core;
using UnityEngine;
using UnityEngine.UI;


namespace Shop
{
    public class ShopBundleView : MonoBehaviour
    {
        [SerializeField] private Text titleText;
        [SerializeField] private Button infoButton; // "i"
        [SerializeField] private Button buyButton;
        [SerializeField] private Text buyButtonText;

        private ShopBundle bundle;

        public void Setup(ShopBundle b)
        {
            bundle = b;
            titleText.text = b.Title;
            UpdateInteractable();
            buyButton.onClick.RemoveAllListeners();
            buyButton.onClick.AddListener(OnBuyClicked);
            infoButton.onClick.RemoveAllListeners();
            infoButton.onClick.AddListener(OnInfoClicked);
        }

        public void UpdateInteractable()
        {
            if (bundle == null) return;
            buyButton.interactable = bundle.CanBuy(PlayerData.Instance);
            buyButtonText.text = "Купить";
        }

        private void OnInfoClicked()
        {
            // открываем сцену с карточкой (передаём ссылку через простой static или SceneManager + временный хранилище)
            ShopSceneRouter.OpenBundleDetail(bundle);
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