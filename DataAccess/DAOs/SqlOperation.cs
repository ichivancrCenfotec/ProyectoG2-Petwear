using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class SqlOperation
    {
        public string ProcedureName { get; set; }

        public List<SqlParameter> Parameters { get; set; }

        public SqlOperation()
        {
            Parameters = new List<SqlParameter>();
        }

        /*Metodos utilitarios para agregar parametros*/
        public void AddVarcharParam(string paramName, string paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));
        }

        public void AddIntParam(string paramName, int paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));
        }

        public void AddDateTimeParam(string paramName, DateTime paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));
        }

        public void AddBoolParam(string paramName, bool paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));

        }
        public void AddFloatParam(string paramName, float paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));

        }

    }
}
