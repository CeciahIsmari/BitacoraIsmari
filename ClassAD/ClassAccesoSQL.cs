using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace ClassAD
{
    public class ClassAccesoSQL
    {
        private string CadenaConexion;

        public ClassAccesoSQL(string cadenaBD)
        {
            CadenaConexion = cadenaBD;
        }

        public SqlConnection AbrirConexion(ref string msj)
        {
            SqlConnection conexion1 = new SqlConnection();
            conexion1.ConnectionString = CadenaConexion;
            try
            {
                conexion1.Open();
                msj = "Conexión Abierta";
            }
            catch (Exception a)
            {
                conexion1 = null;
                msj = "¡Error!" + a.Message;
            }
            return conexion1;
        }

        public DataSet ConsultaDS(string querySQL, SqlConnection conexAbierta, ref string msj)
        {
            SqlCommand carrito = null;
            SqlDataAdapter trailer = null;
            DataSet DS_Salida = new DataSet();

            if (conexAbierta == null)
            {
                msj = "Sin conexión a la BD";
                DS_Salida = null;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySQL;
                carrito.Connection = conexAbierta;

                trailer = new SqlDataAdapter();
                trailer.SelectCommand = carrito;

                try
                {
                    trailer.Fill(DS_Salida, "Consulta1");
                    msj = "Consulta correcta en DataSet";
                }
                catch (Exception c)
                {
                    msj = "¡Error!" + c.Message;
                }
                conexAbierta.Close();
                conexAbierta.Dispose();
            }
            return DS_Salida;
        }

        public SqlDataReader ConsultaReader(string querySQL, SqlConnection conexAbierta, ref string msj)
        {
            SqlCommand carrito = null;
            SqlDataReader contenedor = null;

            if (conexAbierta == null)
            {
                msj = "Sin conexión a la BD";
                contenedor = null;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySQL;
                carrito.Connection = conexAbierta;

                try
                {
                    contenedor = carrito.ExecuteReader();
                    msj = "Consulta correcta DataReader";
                }
                catch (Exception a)
                {
                    contenedor = null;
                    msj = "¡Error!" + a.Message;
                }
            }
            return contenedor;
        }

        public Boolean MultiplesConsultasDS(string querySQL, SqlConnection conexAbierta, ref string msj, DataSet dataset1, string nomConsulta)
        {
            SqlCommand carrito = null;
            SqlDataAdapter trailer = null;
            Boolean salida = false;

            if (conexAbierta == null)
            {
                msj = "Sin conexión a la BD";
                salida = false;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySQL;
                carrito.Connection = conexAbierta;

                trailer = new SqlDataAdapter();
                trailer.SelectCommand = carrito;

                try
                {
                    trailer.Fill(dataset1, nomConsulta);
                    msj = "Consulta correcta en DataSet";
                    salida = true;
                }
                catch (Exception c)
                {
                    msj = "¡Error!" + c.Message;
                }
                conexAbierta.Close();
                conexAbierta.Dispose();
            }
            return salida;
        }

        public Boolean ModificaBDMasSegura(string SentenciaSql, SqlConnection conexAbierto, ref string msj, SqlParameter[] parametros)
        {
            Boolean salida = false;
            SqlCommand vocho = null;

            if (conexAbierto != null)
            {
                vocho = new SqlCommand();
                vocho.CommandText = SentenciaSql;
                vocho.Connection = conexAbierto;

                //Agregar parámetros.
                foreach (SqlParameter p in parametros)
                {
                    vocho.Parameters.Add(p);
                }
                try
                {
                    vocho.ExecuteNonQuery();
                    msj = "Modificación Correcta";
                    salida = true;
                }
                catch (Exception a)
                {
                    msj = "¡Error!" + a.Message;
                    salida = false;
                }
                conexAbierto.Close();
                conexAbierto.Dispose();
            }
            else
            {
                msj = "Sin conexión a la BD";
            }
            return salida;
        }
    }
}
