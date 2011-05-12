using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

using IBatisNet.DataMapper;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Scope;

//using log4net;
//using log4net.Config;

namespace TRE.DataAccess.DAOs
{
    public class AlertingDAO //: IAlertingDAO
    {
        // private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ISqlMapper mapper;

        public AlertingDAO()
        {
            // XmlConfigurator.Configure();
            mapper = Mapper.Instance();
            mapper.DataSource.ConnectionString = ConfigurationManager.AppSettings["DbConnectionString"];

        }

        public IList<AlertRule> AlertRuleSelectAll()
        {
            return mapper.QueryForList<AlertRule>("AlertRuleSelectAll", new Hashtable());
        }
    }
}
