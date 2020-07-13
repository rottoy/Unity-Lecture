namespace RPG.Core
{
    public interface IAction {
        
        void Cancel();
        void TakeDamage(float damage);
    }
    
}