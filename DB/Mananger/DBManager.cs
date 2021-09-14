using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace DB
{
    public class DBManager : IDisposable
    {
        private static DBManager _instance;

        public static DBManager Instance => _instance ?? (_instance = new DBManager());
        private ISessionFactory _sessionFactory;
        private ISession _session;
        private List<User> _users;

        public DBManager()
        {
            _sessionFactory = CreateSessionFactory();
            OpenSession();
            LoadDBData();
        }

        public List<User> GetAllUser()
        {
            LoadDBData();
            return _users;
        }

        public User GetUserByName(string name)
        {
            return _users.FirstOrDefault(_ => _.UsrName == name);
        }

        public User GetUserByAccount(string account)
        {
            return _users.FirstOrDefault(_ => _.Account == account);
        }

        public User AddUser(User u)
        {
            var ut = _users.FirstOrDefault((_) => _.Account == u.Account);
            if (ut == null)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    _users.Add(u);
                    _session.Save(u);
                    transaction.Commit();
                }

                return u;
            }

            return null;
        }

        public User RemoveUser(User u)
        {
            var ut = _users.FirstOrDefault((_) => _.Id == u.Id);
            if (ut != null)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    _users.Add(u);
                    _session.Delete(u);
                    transaction.Commit();
                }
            }

            return ut;
        }

        public User ModifyUsr(User newUser)
        {
            var oldUser = _users.FirstOrDefault(_ => _.Id == newUser.Id);
            if (oldUser==null)
            {
                return null;
            }
            using (var transaction = _session.BeginTransaction())
            {
                oldUser = newUser;
                _session.Update(oldUser);
                transaction.Commit();
            }
            return oldUser;
        }
        private void LoadDBData()
        {
            using (var transation = _session.BeginTransaction())
            {
                _users = _session.CreateCriteria(typeof(User)).List<User>().ToList();
            }
        }

        private ISession OpenSession()
        {
            _session = _sessionFactory.OpenSession();
            return _session;
        }

        private void CloseSession()
        {
            _session?.Close();
            _sessionFactory.Close();
        }

        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            //if (File.Exists("firstProject.db"))
            //    File.Delete("firstProject.db");

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
                .Create(false, true);
        }

        private static ISessionFactory CreateSessionFactory(string name = "DB.db")
        {
            var cfg = Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard
                        .UsingFile(name)
                )
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<DBManager>());
            if (!File.Exists(name))
            {
                cfg.ExposeConfiguration(BuildSchema);
            }

            ISessionFactory sf = cfg.BuildSessionFactory();
            return sf;
        }

        public void Dispose()
        {
            CloseSession();
        }
    }
}