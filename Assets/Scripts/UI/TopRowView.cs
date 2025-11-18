using Shop;
using UnityEngine;


namespace UI
{
    public class TopRowView : MonoBehaviour
    {
        [SerializeField] private TopRowConfig config;
        [SerializeField] private Transform container;
        [SerializeField] private TopRowItemView itemPrefab;

        private void Start()
        {
            Build();
            ShopUIEvents.OnPlayerDataChanged += Refresh;
            Refresh();
        }

        private void OnDestroy()
        {
            ShopUIEvents.OnPlayerDataChanged -= Refresh;
        }

        private void Build()
        {
            foreach (Transform ch in container)
                Destroy(ch.gameObject);

            foreach (var entry in config.entries)
            {
                var view = Instantiate(itemPrefab, container);
                view.Setup(entry);
            }
        }

        private void Refresh()
        {
            foreach (Transform ch in container)
            {
                var item = ch.GetComponent<TopRowItemView>();
                item.Refresh();
            }
        }
    }
}