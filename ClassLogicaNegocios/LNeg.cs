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


        //----------------------------Insertar Perfil Profesor--------------------------------------------------------------------------------------
        public Boolean InsertarPerProfe(PerfilProfe newPProf, ref string msjSalida)
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
        public string EditarPerfProf(int idPr, int IdGE, string est, DateTime fec, string Evi,int idPp, ref string msjSalida)
        {
            string sentenciaSql = "update PerfilProfe set  F_Profe='" + idPr + "', F_Grado='" + IdGE + "'," +
             " Estado='" + est + "', FechaObtencion='" + fec + "', Evidencia='" + Evi + "'where Id_Perfil ='" + idPp + "'";

            SqlDataReader salida = null;
            salida = ccbd.ConsultaReader(sentenciaSql, ccbd.AbrirConexion(ref msjSalida), ref msjSalida);

            return salida.ToString();
        }

        //-----------------Eliminar---------------------------------
        public string EliminarPerProf(int idper, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter
            {
                ParameterName = "PerfilProfe",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = idper
            };

            string sentencia = "delete from PerfilProfe where Id_Perfil='" + idper + "'";

            ccbd.ModificaBDMasSegura(sentencia, ccbd.AbrirConexion(ref mensajeSalida), ref mensajeSalida, parametros);
            return mensajeSalida;
        }


        //----------------------------Insertar Profesor--------------------------------------------------------------------------------------
        public Boolean InsAsPrMatCua(AsiProMatCua newPProf, ref string msjSalida)
        {
            SqlParameter[] param1 = new SqlParameter[4];
            param1[0] = new SqlParameter
            {
                ParameterName = "F_Profe",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = newPProf.F_Profe

            };
            param1[1] = new SqlParameter
            {
                ParameterName = "F_Materia",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = newPProf.F_Materia

            };
            param1[2] = new SqlParameter
            {
                ParameterName = "F_GrupoCuatri",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = newPProf.F_GrupCua

            };
            param1[3] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = newPProf.Extra

            };

            string sentenciaSql = "insert into AsignaProfeMateriaCuatri values (@F_Profe,@F_Materia,@F_GrupoCuatri,@Extra);";

            Boolean salida = false;
            salida = ccbd.ModificaBDMasSegura(sentenciaSql, ccbd.AbrirConexion(ref msjSalida), ref msjSalida, param1);

            return salida;
        }

        //-----------------Actualizar---------------------------------
        public string EditAsPrMatCua(int idPr, int IdMat,int idGC, string ext, int idPA, ref string msjSalida)
        {
            string sentenciaSql = "update AsignaProfeMateriaCuatri set  F_Profe='" + idPr + "', F_Materia='" + IdMat + "'," +
             " F_GrupoCuatri='" + idGC + "', Extra='" + ext + "'where Id_AsignaPro ='" + idPA + "'";

            SqlDataReader salida = null;
            salida = ccbd.ConsultaReader(sentenciaSql, ccbd.AbrirConexion(ref msjSalida), ref msjSalida);

            return salida.ToString();
        }

        //-----------------Eliminar---------------------------------
        public string ElimAsPrMatCua(int idAP, ref string mensajeSalida)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter
            {
                ParameterName = "AsignaProfeMateriaCuatri",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = idAP
            };

            string sentencia = "delete from AsignaProfeMateriaCuatri where Id_AsignaPro='" + idAP + "'";

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
                        id_Grado = (short)datos[0],
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

        public List<Materia> DevuelveMat(ref string msj)
        {
            SqlConnection conextemp = null;
            string query = "select * from Materia";

            conextemp = ccbd.AbrirConexion(ref msj);

            SqlDataReader datos = null;
            datos = ccbd.ConsultaReader(query, conextemp, ref msj);

            List<Materia> listaGrEsp = new List<Materia>();
            if (datos != null)
            {
                while (datos.Read())
                {
                    listaGrEsp.Add(new Materia
                    {
                        id_Mat = (short)datos[0],
                        NomMat = (string)datos[1]
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
                        id_Profe = (short)datos[0],
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

        //-----GDV---------------------
        public DataTable tablaPerfilPro(ref string mens_salida)
        {
            string query2 = "select pp.Id_Perfil, p.Nombre,p.Ap_pat,p.Ap_Mat,ge.Titulo, pp.Estado, pp.FechaObtencion, pp.Evidencia from PerfilProfe as pp inner join Profesor as p on pp.F_Profe=p.ID_Profe inner join GradoEspecialidad as ge on pp.F_Grado=ge.Id_Grado";

            DataSet DtTab = null;
            DataTable M_tab = null;

            DtTab = ccbd.ConsultaDS(query2, ccbd.AbrirConexion(ref mens_salida), ref mens_salida);

            if (DtTab != null)
            {
                M_tab = DtTab.Tables[0];
            }
            return M_tab;
        }
        public DataTable tablaAsPrMatCua(ref string mens_salida)
        {
            string query2 = "select aspmc.Id_AsignaPro, pr.Nombre, ma.NombeMateria, g.Grado,g.Letra,aspmc.Extra from Profesor as  pr inner join AsignaProfeMateriaCuatri as aspmc on aspmc.F_Profe = pr.ID_Profe inner join Materia as ma on ma.Id_Materia=aspmc.F_Materia inner join GrupoCuatrimestre as gc on gc.Id_GruCuat=aspmc.F_GrupoCuatri inner join Grupo as g on g.Id_grupo=gc.F_Grupo";

            DataSet DtTab = null;
            DataTable M_tab = null;

            DtTab = ccbd.ConsultaDS(query2, ccbd.AbrirConexion(ref mens_salida), ref mens_salida);

            if (DtTab != null)
            {
                M_tab = DtTab.Tables[0];
            }
            return M_tab;
        }

        public DataTable tablaGruCua(ref string mens_salida)
        {
            string query2 = "select gc.Id_GruCuat, g.Grado,g.Letra,cua.Periodo from GrupoCuatrimestre as gc inner join Grupo as g on g.Id_grupo=gc.F_Grupo inner join Cuatrimestre as cua on cua.id_Cuatrimestre=gc.F_Cuatri";

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
