namespace TranslationManagement.Domain.Entities
{
    public interface IId<T>
    {
        public T Id { get; set; }
    }
}
