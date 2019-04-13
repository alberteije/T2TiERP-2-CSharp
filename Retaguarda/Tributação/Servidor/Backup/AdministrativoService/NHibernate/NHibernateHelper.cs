using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace AdministrativoService.NHibernate
{
    public class NHibernateHelper
    {
        private static ISessionFactory sessionFactory;

        public static ISessionFactory getSessionFactory()
        {
            try
            {
                if (sessionFactory == null)
                {
                    lock(typeof (NHibernateHelper))
                    {
                        Configuration config = new Configuration();
                        config.Configure();
                        config.AddAssembly("AdministrativoService");
                        sessionFactory = config.BuildSessionFactory();
                    }
                }
                return sessionFactory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
