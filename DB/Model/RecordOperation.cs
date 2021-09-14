using FluentNHibernate.Mapping;

namespace ConsoleApp2.DB
{
    public class RecordOperation
    {
        public virtual int Id { get; protected set; }
        public virtual string BeginTime { get; set; }
        public virtual string EndTime { get; set; }
        public virtual string OpContent { get; set; }
    }

    public class RecordOperationMap : ClassMap<RecordOperation>
    {
        public RecordOperationMap()
        {
            Id(x => x.Id);
            Map(x => x.BeginTime);
            Map(x => x.EndTime);
            Map(x => x.OpContent);
        }
    }
}