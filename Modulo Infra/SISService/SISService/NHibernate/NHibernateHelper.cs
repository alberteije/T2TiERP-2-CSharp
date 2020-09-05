using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace SISService.NHibernate
{
    public class NHibernateHelper
    {
        private static ISessionFactory SessionFactory;

        public static ISessionFactory GetSessionFactory()
        {
            try
            {
                if (SessionFactory == null)
                {
                    lock(typeof (NHibernateHelper))
                    {
                        Configuration Config = new Configuration();
                        Config.Configure();
                        Config.AddAssembly("SISService");
                        SessionFactory = Config.BuildSessionFactory();
                    }
                }
                return SessionFactory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
