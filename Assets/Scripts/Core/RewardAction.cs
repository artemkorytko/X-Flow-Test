using System;
using UnityEngine;


namespace Core
{
    public class RewardAction : ScriptableObject, IShopAction
    {
        public ResourceDefinition resource;
        public ResourceType resourceType;

        public int addInt;
        public float addFloat;
        public string addString;

        public bool CanExecute(PlayerData pd) => resource != null;

        public void Execute(PlayerData pd)
        {
            switch (resourceType)
            {
                case ResourceType.Int:
                    pd.ModifyInt(resource.Id, addInt);
                    break;
                case ResourceType.Float:
                    pd.ModifyFloat(resource.Id, addFloat);
                    break;
                case ResourceType.String:
                    pd.SetString(resource.Id, addString);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}