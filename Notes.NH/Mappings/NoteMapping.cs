using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Notes.Domain;

namespace Notes.NH
{
    public class NoteMapping : ClassMapping<Note>
    {
        public NoteMapping()
        {
            Id(x => x.Id, map =>
                              {
                                  map.Generator(Generators.HighLow);
                              });

            Property(p => p.Text, a => a.NotNullable(true));
        }
    }
}
