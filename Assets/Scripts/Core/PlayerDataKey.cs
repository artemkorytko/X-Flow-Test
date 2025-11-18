using System;


namespace Core
{
    /// <summary>
    /// Типобезопасный ключ для доступа к данным игрока.
    /// Домены могут объявлять свои статические ключи, не изменяя PlayerData.
    /// </summary>
    /// <typeparam name="T">Тип значения, хранимого под этим ключом.</typeparam>
    [Serializable]
    public readonly struct PlayerDataKey<T>
    {
        public readonly ResourceId Id;

        public PlayerDataKey(ResourceId id)
        {
            Id = id;
        }
    }
}


