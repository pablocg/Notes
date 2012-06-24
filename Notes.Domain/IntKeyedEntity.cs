namespace Notes.Domain
{
    public abstract class IntKeyedEntity
    {
        public virtual int Id { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as IntKeyedEntity;

            if (other == null) return false;

            if (Id == 0 && other.Id == 0)
                return this == other;
            else
                return Id == other.Id;
        }

        public override int GetHashCode()
        {
            if (Id == 0) return base.GetHashCode();

            var stringRepresentation =
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "#" + Id.ToString();

            return stringRepresentation.GetHashCode();
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}