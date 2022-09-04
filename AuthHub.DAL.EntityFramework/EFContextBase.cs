namespace AuthHub.DAL.EntityFramework
{
    public abstract class EFContextBase<T>
        where T : class
    {

        public virtual async Task Save(T source)
        {

        }

    }
}
