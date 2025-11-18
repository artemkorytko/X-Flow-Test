using System;


namespace Core
{
    [Serializable]
    public readonly struct ResourceId : IEquatable<ResourceId>
    {
        public readonly string Value;

        public ResourceId(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public bool Equals(ResourceId other) => string.Equals(Value, other.Value, StringComparison.Ordinal);
        public override bool Equals(object obj) => obj is ResourceId r && Equals(r);
        public override int GetHashCode() => Value != null ? Value.GetHashCode(StringComparison.Ordinal) : 0;
        public override string ToString() => Value;

        public static implicit operator ResourceId(string v) => new ResourceId(v);
        public static implicit operator string(ResourceId id) => id.Value;
    }
}