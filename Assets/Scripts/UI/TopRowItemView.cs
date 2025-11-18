using Core;
using Shop;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace UI
{
    public class TopRowItemView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private TextMeshProUGUI valueText;
        [SerializeField] private Button addButton;

        private TopRowEntry entry;

        public void Setup(TopRowEntry entry)
        {
            this.entry = entry;

            addButton.gameObject.SetActive(entry.showAddButton);
            addButton.onClick.AddListener(OnAddClicked);
        }

        public void Refresh()
        {
            var pd = PlayerData.Instance;
            var id = entry.resource.Id;
            descriptionText.text = entry.resource.id;
            switch (entry.resource.type)
            {
                case ResourceType.Int:
                    valueText.text = pd.GetInt(id).ToString();
                    break;

                case ResourceType.Float:
                    valueText.text = pd.GetFloat(id).ToString("0");
                    break;

                case ResourceType.String:
                    valueText.text = pd.GetString(id);
                    break;
            }
        }

        private void OnAddClicked()
        {
            var pd = PlayerData.Instance;
            var id = entry.resource.Id;

            switch (entry.resource.type)
            {
                case ResourceType.Int:
                    pd.ModifyInt(id, entry.addInt);
                    break;

                case ResourceType.Float:
                    pd.ModifyFloat(id, entry.addFloat);
                    break;

                case ResourceType.String:
                    pd.SetString(id, entry.addString);
                    break;
            }

            ShopUIEvents.BroadcastPlayerDataChanged();
        }
    }
}