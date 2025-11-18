using System;
using Core;
using Core;


namespace UI
{
    [Serializable]
    public class TopRowEntry
    {
        public ResourceDefinition resource;
        public int addInt;
        public float addFloat;
        public string addString;

        /// <summary>
        /// Опциональное действие, выполняемое при нажатии на кнопку "+".
        /// Если задано, то используется оно; если нет — используется legacy-логика addInt/addFloat/addString.
        /// </summary>
        public RewardAction plusAction;

        public bool showAddButton = true;
    }
}