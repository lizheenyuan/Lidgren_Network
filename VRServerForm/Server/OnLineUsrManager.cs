using System.Collections.Generic;
using System.Linq;

namespace LidgrenTest
{
    public class OnLineUsrManager
    {

        public static OnLineUsrManager Instance
        {
            get
            {
                if (_instance==null)
                {
                    _instance = new OnLineUsrManager();
                }

                return _instance;
            }
        }
        private static OnLineUsrManager _instance;
        private List<Usr> _usrs;
        public OnLineUsrManager()
        {
            _usrs = new List<Usr>();
            _instance = this;
        }

        public List<Usr> GetOnlineUsrs()
        {
            return new List<Usr>(_usrs);
        }

        public int GetOnlineUsrCount()
        {
            return _usrs.Count;
        }
        //添加或更新
        public Usr AddUsr(Usr u)
        {
            var usr = _usrs.FirstOrDefault(_ => _.Uid == u.Uid);
            if (usr != null)
            {
                usr = u;
            }
            else
            {
                _usrs.Add(u);
            }

            return u;
        }
        public Usr RmUsr(Usr u)
        {
            return RmUsr(u.Uid);
        }

        public Usr RmUsr(int uid)
        {
            var u = _usrs.FirstOrDefault(_ => _.Uid == uid);
            if (u != null)
            {
                _usrs.Remove(u);
            }

            return u;
        }
    }
}