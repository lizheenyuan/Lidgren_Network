using System.Collections.Generic;
using ConsoleApp2.DB;
using FluentNHibernate.Mapping;

namespace DB.Model
{
    public class User
    {
        public virtual int Id{ get; protected set; }
        public virtual string UsrName { set; get; }
        public virtual string Psw { set; get; }
        public virtual string Account { get; set; }
        public virtual IList<RecordOperation> Operations { get; protected set; }
        
        public User()
        {
            Operations = new List<RecordOperation>();
        }

        public virtual void SetId(int id)
        {
            Id = id;
        }
    }

    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x=>x.Id);
            Map(x => x.UsrName);
            Map(x => x.Psw);
            Map(x => x.Account);
            HasMany<RecordOperation>(x => x.Operations)
                .Cascade.All();
            // .Table("UsrOp");
        }
    }
}
