using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EclipsisTransactionProtocol;
using System.Windows.Forms;
using EISUserManagement;

namespace Eclipsis
{
    public class SQLRequestProcessor
    {
        SQLConnector sql_connector = new SQLConnector();


        public EISTransactionObject ProcessRequest(EISTransactionObject request)
        {
            switch (request.ActionType)
            {
                case SQLActionType.Select:
                    request = ProcesSelect(request);
                    break;
            }
            return request;
        }

        private EISTransactionObject ProcesSelect(EISTransactionObject request)
        {
            request.Content = sql_connector.PerformSelect(request.Tablename, request.SelectCondition, request.Content);
            return request;
        }

        public User GetUser(string name, string hash)
        {

            return null;
        }

        public DataGrid GetAllUsers()
        {
            return null;
        }

    }

}
