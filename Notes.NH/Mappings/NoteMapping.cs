using NHibernate.Mapping.ByCode.Conformist;
using Notes.Domain;

namespace Notes.NH
{
    public class NoteMapping : ClassMapping<Note>
    {
        public NoteMapping()
        {
            Property(p => p.Text, a => a.NotNullable(true));
        }
    }
}
