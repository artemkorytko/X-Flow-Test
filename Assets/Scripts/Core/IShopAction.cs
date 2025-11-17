namespace Core
{
    public interface IShopAction
    {
        bool CanExecute(PlayerData data);
        void Execute(PlayerData data);
    }
}