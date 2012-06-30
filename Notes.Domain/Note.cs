namespace Notes.Domain
{
    public class Note : IntKeyedEntity
    {
        public virtual string Text { get; set; }
    }
}
