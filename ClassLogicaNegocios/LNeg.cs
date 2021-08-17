using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClassAD;
using ClassEntidades;

namespace ClassLogicaNegocios
{
    public class LNeg
    {
        //Cadena de Conexión.
        private ClassAccesoSQL ccbd = new ClassAccesoSQL(@"Data Source=ISMARI; Initial Catalog=Bitacora2021LabsUTP; Integrated Security = true;");


        //----------------------------Insertar Profesor--------------------------------------------------------------------------------------
        public Boolean InsertarProfe(PerfilProfe newPProf, ref string msjSalida)
        {
            SqlParameter[] param1 = new SqlParameter[5];
            param1[0] = new SqlParameter
            {
                ParameterName = "F_Profe",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = newPProf.F_Profe

            };
            param1[1] = new SqlParameter
            {
                ParameterName = "F_Grado",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = newPProf.F_Grado

            };
            param1[2] = new SqlParameter
            {
                ParameterName = "Estado",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = newPProf.Estado

            };
            param1[3] = new SqlParameter
            {
                ParameterName = "FechaObtencion",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = newPProf.FechaObtencion

            };
            param1[4] = new SqlParameter
            {
                ParameterName = "Evidencia",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = newPProf.Evidencia

            };
            
            string sentenciaSql = "insert into PerfilProfe values (@F_Profe,@F_Grado,@Estado,@FechaObtencion,@Evidencia);";

            Boolean salida = false;
            salida = ccbd.ModificaBDMasSegura(sentenciaSql, ccbd.AbrirConexion(ref msjSalida), ref msjSalida, param1);

            return salida;
        }

        //-----------------Actualizar---------------------------------
        public string EditarPerfProf(int idPr, int IdGE, string est, DateTime fec, string Evi,int idPA, ref string msjSalida)
        {
            string sentenciaSql = "update PerfilProfe set  F_Profe='" + idPr + "', F_Grado='" + IdGE + "'," +
             " Estado='" + est + "', FechaObtencion='" + fec + "', Evidencia='" + Evi + "'where F_Profe ='" + idPA + "'";

            SqlDataReader salida = null;
            salida = ccbd.ConsultaReader(sentenciaSql, ccbd.AbrirConexion(ref msjSalida), ref msjSalida);

            return salida.ToString();
        }

        //-----------------Eliminar---------------------------------
        public string EliminarProf(int re, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter
            {
                ParameterName = "PerfilProfe",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = re
            };

            string sentencia = "delete from PerfilProfe where F_Profe='" + re + "'";

            ccbd.ModificaBDMasSegura(sentencia, ccbd.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);
            return mensajeSalida;
        }

        //========================------EXTRAS----------===============================//
        //-----------------Devuelve EstadoCivil---------------------------------
        public List<GradoEspecialidad> DevuelveGradEsp(ref string msj)
        {
            SqlConnection conextemp = null;
            string query = "select * from GradoEspecialidad";

            conextemp = ccbd.AbrirConexion(ref msj);

            SqlDataReader datos = null;
            datos = ccbd.ConsultaReader(query, conextemp, ref msj);

            List<GradoEspecialidad> listaGrEsp = new List<GradoEspecialidad>();
            if (datos != null)
            {
                while (datos.Read())
                {
                    listaGrEsp.Add(new GradoEspecialidad
                    {
                        id_Grado = (byte)datos[0],
                        Titulo = (string)datos[1]
                    }
                    );
                }

            }
            else
            {
                listaGrEsp = null;
            }
            conextemp.Close();
            conextemp.Dispose();

            return listaGrEsp;

        }

        public List<Profesor> DevuelveProfe(ref string msj)
        {
            SqlConnection conextemp = null;
            string query = "select * from Profesor";

            conextemp = ccbd.AbrirConexion(ref msj);

            SqlDataReader datos = null;
            datos = ccbd.ConsultaReader(query, conextemp, ref msj);

            List<Profesor> listaProfp = new List<Profesor>();
            if (datos != null)
            {
                while (datos.Read())
                {
                    listaProfp.Add(new Profesor
                    {
                        id_Profe = (byte)datos[0],
                        Nombre = (string)datos[1],
                        App = (string)datos[2],
                        Apm = (string)datos[3]
                    }
                    );
                }

            }
            else
            {
                listaProfp = null;
            }
            conextemp.Close();
            conextemp.Dispose();

            return listaProfp;

        }

    }
}
