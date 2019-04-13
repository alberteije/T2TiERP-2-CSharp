using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace Servidor.NHibernate
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
                        Configuration config = new Configuration();
                        config.Configure();
                        config.AddAssembly("Servidor");
                        SessionFactory = config.BuildSessionFactory();
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
