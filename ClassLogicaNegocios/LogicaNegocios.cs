using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassAD;
using ClassEntidades;
using System.Data;
using System.Data.SqlClient;

namespace ClassLogicaNegocios
{
    public class LogicaNegocios
    {
        //Cadena de Conexión.
        private ClassAccesoSQL ccbd = new ClassAccesoSQL(@"Data Source=ISMARI; Initial Catalog=Bitacora2021LabsUTP; Integrated Security = true;");


        //----------------------------Insertar Profesor--------------------------------------------------------------------------------------
        public Boolean InsertarProfe(Profesor newProf, ref string msjSalida)
        {
            SqlParameter[] param1 = new SqlParameter[9];
            param1[0] = new SqlParameter
            {
                ParameterName = "regEmp",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = newProf.RegistroEmpleado

            };
            param1[1] = new SqlParameter
            {
                ParameterName = "nom",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = newProf.Nombre

            };
            param1[2] = new SqlParameter
            {
                ParameterName = "app",
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input,
                Value = newProf.App

            };
            param1[3] = new SqlParameter
            {
                ParameterName = "apm",
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input,
                Value = newProf.Apm

            };
            param1[4] = new SqlParameter
            {
                ParameterName = "gen",
                SqlDbType = SqlDbType.VarChar,
                Size = 10,
                Direction = ParameterDirection.Input,
                Value = newProf.Genero

            };
            param1[5] = new SqlParameter
            {
                ParameterName = "cate",
                SqlDbType = SqlDbType.VarChar,
                Size = 5,
                Direction = ParameterDirection.Input,
                Value = newProf.Categria

            };
            param1[6] = new SqlParameter
            {
                ParameterName = "correoP",
                SqlDbType = SqlDbType.VarChar,
                Size = 200,
                Direction = ParameterDirection.Input,
                Value = newProf.Correo

            };
            param1[7] = new SqlParameter
            {
                ParameterName = "cel",
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = newProf.Cel

            };
            param1[8] = new SqlParameter
            {
                ParameterName = "f_edoCiv",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = newProf.fEstadoCivil

            };
            string sentenciaSql = "insert into Profesor values (@regEmp,@nom,@app,@apm,@gen,@cate,@correoP,@cel,@f_edoCiv);";

            Boolean salida = false;
            salida = ccbd.ModificaBDMasSegura(sentenciaSql, ccbd.AbrirConexion(ref msjSalida), ref msjSalida, param1);

            return salida;
        }

        //-----------------Actualizar---------------------------------
        public string EditarProf( string newNom, string newApp, string newApm, string newGen, string newCat,
            string newMail, string newCel, int newF_edoCivil, int reg, ref string msjSalida)
        {
            string sentenciaSql = "update Profesor set  Nombre='" + newNom + "', Ap_pat='" + newApp + "'," +
             " Ap_Mat='" + newApm + "', Genero='" + newGen + "', Categoria='" + newCat + "', Correo='" + newMail + "', Celular='" + newCel + "', " +
             "F_EdoCivil='" + newF_edoCivil + "'where RegistroEmpleado ='" + reg + "'";

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
                ParameterName = "RegistroEmpleado",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = re
            };

            string sentencia = "delete from Profesor where RegistroEmpleado='" + re + "'";

            ccbd.ModificaBDMasSegura(sentencia, ccbd.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);
            return mensajeSalida;
        }




        //--------------------------------------GradoEspecialidad--------------------------------------------------------------------------------------
        public Boolean InsertarGradEsp(GradoEspecialidad newGE, ref string msjSalida)
        {
            SqlParameter[] param1 = new SqlParameter[4];
            param1[0] = new SqlParameter
            {
                ParameterName = "titu",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = newGE.Titulo

            };
            param1[1] = new SqlParameter
            {
                ParameterName = "insti",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = newGE.Institucion

            };
            param1[2] = new SqlParameter
            {
                ParameterName = "pais",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = newGE.Pais

            };
            param1[3] = new SqlParameter
            {
                ParameterName = "extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = newGE.Extra

            };
            string sentenciaSql = "insert into GradoEspecialidad values(@titu,@insti,@pais,@extra);";

            Boolean salida = false;
            salida = ccbd.ModificaBDMasSegura(sentenciaSql, ccbd.AbrirConexion(ref msjSalida), ref msjSalida, param1);

            return salida;
        }

        //========================------EXTRAS----------===============================//
        //-----------------Devuelve EstadoCivil---------------------------------
        public List<EstadoCivil> DevuelveEstadoCivil(ref string msj)
        {
            SqlConnection conextemp = null;
            string query = "select * from EstadoCivil";

            conextemp = ccbd.AbrirConexion(ref msj);

            SqlDataReader datos = null;
            datos = ccbd.ConsultaReader(query, conextemp, ref msj);

            List<EstadoCivil> listaSalida = new List<EstadoCivil>();
            if (datos != null)
            {
                while (datos.Read())
                {
                    listaSalida.Add(new EstadoCivil
                    {
                        id_edoCiv = (byte)datos[0],
                        Estado = (string)datos[1]
                    }
                    );
                }

            }
            else
            {
                listaSalida = null;
            }
            conextemp.Close();
            conextemp.Dispose();

            return listaSalida;

        }

        //-----------------Devuelve EstadoCivil---------------------------------
        public List<GrupoCuatrimestree> DevuelveGruCua(ref string msj)
        {
            SqlConnection conextemp = null;
            string query = "select * from GrupoCuatrimestre";

            conextemp = ccbd.AbrirConexion(ref msj);

            SqlDataReader datos = null;
            datos = ccbd.ConsultaReader(query, conextemp, ref msj);

            List<GrupoCuatrimestree> listaGruCua = new List<GrupoCuatrimestree>();
            if (datos != null)
            {
                while (datos.Read())
                {
                    listaGruCua.Add(new GrupoCuatrimestree
                    {
                        idGruCua = (int)datos[0],
                        f_proEd = (byte)datos[1],
                        f_Grup = (short)datos[2],
                        f_Cuatri = (short)datos[3],
                        Turno = (string)datos[4],
                        Modalidad = (string)datos[5],
                        Extra = (string)datos[6]
                    }
                    );
                }

            }
            else
            {
                listaGruCua = null;
            }
            conextemp.Close();
            conextemp.Dispose();

            return listaGruCua;

        }

        //-----GDV---------------------
        public DataTable DtTablas(ref string mens_salida)
        {
            string query2 = "select RegistroEmpleado, Nombre, Ap_pat,Ap_Mat,Genero,Categoria,Correo, ec.Estado from Profesor as p inner join EstadoCivil as ec on  ec.Id_Edo=p.F_EdoCivil";

            DataSet DtTab = null;
            DataTable M_tab = null;

            DtTab = ccbd.ConsultaDS(query2, ccbd.AbrirConexion(ref mens_salida), ref mens_salida);

            if (DtTab != null)
            {
                M_tab = DtTab.Tables[0];
            }
            return M_tab;
        }
    }
}
