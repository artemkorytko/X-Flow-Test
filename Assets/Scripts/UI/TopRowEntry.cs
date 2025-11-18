using System;
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

        public bool showAddButton = true;
    }
}