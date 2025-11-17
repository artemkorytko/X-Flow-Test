using UnityEngine;


namespace Core
{
    public class ResourceValue
    {
        public int IntValue;
        public float FloatValue;
        public string StringValue;

        public ResourceValue(int i = 0, float f = 0f, string s = null)
        {
            IntValue = i;
            FloatValue = f;
            StringValue = s;
        }
    }
}