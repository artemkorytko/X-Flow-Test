using System;


namespace Core
{
    /// <summary>
    /// Типобезопасный ключ для обмена временными данными между сценами через DataBus.
    /// </summary>
    /// <typeparam name="T">Тип значения, ожидаемого по данному ключу.</typeparam>
    [Serializable]
    public readonly struct DataBusKey<T>
    {
        public readonly string Id;

        public DataBusKey(string id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}


