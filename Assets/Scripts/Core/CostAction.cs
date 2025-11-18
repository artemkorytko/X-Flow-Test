using System;
using UnityEngine;


namespace Core
{
    public class CostAction : ScriptableObject, IShopAction
    {
        public ResourceDefinition resource;
        public ResourceType resourceType;
        public int spendInt;
        public float spendFloat;
        public string spendString;

        public bool CanExecute(PlayerData pd) => resource != null;

        public void Execute(PlayerData pd)
        {
            switch (resourceType)
            {
                case ResourceType.Int:
                    pd.ModifyInt(resource.Id, -spendInt);
                    break;
                case ResourceType.Float:
                    pd.ModifyFloat(resource.Id, -spendFloat);
                    break;
                case ResourceType.String:
                    pd.SetString(resource.Id, spendString);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}