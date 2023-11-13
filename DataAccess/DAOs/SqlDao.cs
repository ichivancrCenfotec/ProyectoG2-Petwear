using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.DAOs
{
    /*
     Calse u objeto que sene encarga de camunicarse con la base de datos
    para ejecutar sentencias sql, en el caso de esta arquitectura ejecutar unicamente store procedures
     */

    public class SqlDao
    {
        private string _connectionString;

        //Pasos para la contrucción del Patrón Singleton 
        // Paso 1: Crear una isntancia privada de la misma clase

        private static SqlDao? _instance; // se puede o no poner nula o sea con el "?"

        // Paso 2: Definir un constructor privado
        private SqlDao()
        {
            _connectionString = "Data Source=iwucen-ucenfotec202303-server.database.windows.net;Initial Catalog=iwucen-ucenfotec202303;User ID=sysman;Password=Cenfotec123!";

        }

        //Paso 3: Definir un método que expone la instanciua de la clase SqlDao (último paso)

        public static SqlDao GetInstance()
        {

            //Aquí nos aseguramos la existencia de una sola intancia de la clase

            if (_instance == null)
            {

                _instance = new SqlDao();

            }
            return _instance;
        }

        //Método para ejecutar Store Procedure en la base de datos y enviar información
        public void ExecuteProcedure(SqlOperation sqlOperation)
        {

            //Para ejecutar un SP necesitamos: 1. Nombre del SP y 2. Parámetros que necesita

            //Aqui indicamos con cual BD trabajamo
            using (var conn = new SqlConnection(_connectionString))
            {

                using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
                {

                    CommandType = CommandType.StoredProcedure

                })
                {

                    //Recorremos la lista de parametros y los agregamos a la ejecución
                    foreach (var param in sqlOperation.Parameters)
                    {
                        command.Parameters.Add(param);

                    }

                    //Ejecutamos "contra" la base de datos
                    conn.Open();
                    command.ExecuteNonQuery();

                }

            }

        }


        //MÉTODO PARA RECUPERAR INFORMACIÓN DE LA BASE DE DATOS

        public List<Dictionary<string, object>> ExecuteQueryProcedure(SqlOperation sqlOperation)
        {


            var lstResults = new List<Dictionary<string, object>>();

            //Para ejecutar un SP necesitamos: 1. Nombre del SP y 2. Parámetros que necesita

            //Aqui indicamos con cual BD trabajamo
            using (var conn = new SqlConnection(_connectionString))
            {

                using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
                {

                    CommandType = CommandType.StoredProcedure

                })
                {

                    //Recorremos la lista de parametros y los agregamos a la ejecución
                    foreach (var param in sqlOperation.Parameters)
                    {
                        command.Parameters.Add(param);

                    }

                    //Ejecutamos "contra" la base de datos
                    conn.Open();

                    //Levantamos el proceso de extracción de datos

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
