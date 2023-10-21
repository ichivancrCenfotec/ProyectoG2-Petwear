using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class SqlDao
    {

        private string _connectionString;

        //Pasos Construccion del Patrón Singleton
        //Patrón Singleton Paso 1: Crear instancia privada de la misma clase
        private static SqlDao? _instance;

        //Patrón Singleton Paso 2:Definir un constructor privado
        private SqlDao()
        {
            _connectionString = "Data Source=dcordoba-ucenfotec202303-server.database.windows.net;" +
                "Initial Catalog=dcordoba-ucenfotec202303;Persist Security Info=True;" +
                "User ID=sysman;Password=Cenfotec123!";
        }

        //Patrón Singleton Paso 3: Definir un metodo que expone la instancia 
        //de la clase SqlDao
        public static SqlDao GetInstance()
        {

            //Aqui nos aseguramos la existencia de solo una instancia de la clase
            if (_instance == null)
            {
                _instance = new SqlDao();
            }

            return _instance;

        }


        //Metodo para ejecutar Store Procedure en la base de datos y enviar informacion.
        public void ExecuteProcedure(SqlOperation sqlOperation)
        {
            //Para ejecutar un SP necesitamos:
            // El nombre del SP
            // Los parametros que necesita.

            //Aqui indicamos con cual BD trabajamos
            using (var conn = new SqlConnection(_connectionString))
            {
                //Aqui indicamos cual SP voy a utilizar
                using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    //Recorremos la lista de parametros y los agregamos a la ejecucion
                    foreach (var param in sqlOperation.Parameters)
                    {
                        command.Parameters.Add(param);

                    }

                    //Ejecutamos "contra" la base datos
                    conn.Open();
                    command.ExecuteNonQuery();
                }

            }


        }


        //Metodo para recuperar informacion de la base de datos.
        public List<Dictionary<string, object>> ExecuteQueryProcedure(SqlOperation sqlOperation)
        {

            var lstResults = new List<Dictionary<string, object>>();


            //Aqui indicamos con cual BD trabajamos
            using (var conn = new SqlConnection(_connectionString))
            {
                //Aqui indicamos cual SP voy a utilizar
                using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    //Recorremos la lista de parametros y los agregamos a la ejecucion
                    foreach (var param in sqlOperation.Parameters)
                    {
                        command.Parameters.Add(param);

                    }

                    //Ejecutamos "contra" la base datos
                    conn.Open();

                    //Levantar el proceso de extraccion de data
                    var reader = command.ExecuteReader();

                    //Validar que tenga registros
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            //Un diccionario por cada fila
                            var row = new Dictionary<string, object>();

                            for (var index = 0; index < reader.FieldCount; index++)
                            {
                                var key = reader.GetName(index);
                                var value = reader.GetValue(index);

                                row[key] = value;
                            }
                            lstResults.Add(row);
                        }
                    }

                }

            }

            return lstResults;

        }

    }
}
