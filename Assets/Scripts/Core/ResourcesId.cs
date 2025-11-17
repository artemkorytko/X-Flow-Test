using System;


namespace Core
{
    [Serializable]
    public readonly struct ResourceId : IEquatable<ResourceId>
    {
        public readonly string Domain; // e.g. "Health", "Gold", "Location", "VIP"
        public readonly string Key;    // e.g. "Current", "Max", "Name"

        public ResourceId(string domain, string key)
        {
            Domain = domain ?? throw new ArgumentNullException(nameof(domain));
            Key = key ?? throw new ArgumentNullException(nameof(key));
        }

        public override int GetHashCode() => HashCode.Combine(Domain, Key);
        public bool Equals(ResourceId other) => Domain == other.Domain && Key == other.Key;
        public override bool Equals(object obj) => obj is ResourceId r && Equals(r);
        public override string ToString() => $"{Domain}:{Key}";
    }
}