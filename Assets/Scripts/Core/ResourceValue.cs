namespace Core
{
    public struct ResourceValue
    {
        public int IntValue;
        public float FloatValue;
        public string StringValue;

        public ResourceValue(int i, float f, string s)
        {
            IntValue = i;
            FloatValue = f;
            StringValue = s;
        }
    }
}