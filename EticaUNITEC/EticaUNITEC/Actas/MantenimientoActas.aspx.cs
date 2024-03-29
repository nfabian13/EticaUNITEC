﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace EticaUNITEC
{
    public partial class MantenimientoActas : System.Web.UI.Page
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBLocalConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void txtArticuloNumero_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                BuscarArticulo(con, trans);
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Session["error"] = ex.StackTrace;
                Response.Redirect("~/Seguridad/Error.aspx");
            }
            con.Close();
        }

        void BuscarArticulo(SqlConnection con, SqlTransaction trans)
        {
            string sql = @"SELECT *
                           FROM Articulos
                           WHERE ArticuloId=@ArticuloId";

            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            adp.SelectCommand.Parameters.Add(new SqlParameter("ArticuloId", txtArticuloNumero.Text));
            adp.SelectCommand.Transaction = trans;
            adp.Fill(dt);

            if (dt.Rows.Count > 0) //existe
            {
                Session["ArticuloId"] = dt.Rows[0]["ArticuloId"].ToString();
                cmbCategoria.SelectedValue = dt.Rows[0]["CategoriaId"].ToString();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                GuardarArticulo(con,trans);
                GuardarInciso(con,trans);               

                trans.Commit();
                Limpiar();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Session["error"] = ex.StackTrace;
                Response.Redirect("~/Seguridad/Error.aspx");
            }
            con.Close();
        }

        void GuardarArticulo(SqlConnection con, SqlTransaction trans)
        {

            if (Session["ArticuloId"] == null) //hacer un insert
            {
                string sql = @"INSERT INTO Articulos(ArticuloNumero,CategoriaId)
                               VALUES (@artNumero,@catId)";
                string artId = txtArticuloNumero.Text;
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("artNumero", txtArticuloNumero.Text));
                cmd.Parameters.Add(new SqlParameter("catId", cmbCategoria.SelectedValue));
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();

                string identity = "SELECT @@identity as Codigo";
                SqlDataAdapter adp = new SqlDataAdapter(identity, con);
                DataTable tab = new DataTable();
                adp.SelectCommand.Transaction = trans;
                adp.Fill(tab);

                Session["ArticuloId"] = tab.Rows[0]["Codigo"].ToString();
            }
            else //hacer update 
            {
                string articuloID = Session["ArticuloId"].ToString();

                string sql = @"UPDATE Articulos
                               SET ArticuloNumero=@artNumero,CategoriaId=@catId
                               WHERE ArticuloId=@ArticuloId";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("artNumero", txtArticuloNumero.Text));
                cmd.Parameters.Add(new SqlParameter("catId", cmbCategoria.SelectedValue));
                cmd.Parameters.Add(new SqlParameter("ArticuloId", articuloID));
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
            }
        }

        void GuardarInciso(SqlConnection con, SqlTransaction trans)
        {
            string articuloId = Session["ArticuloId"].ToString();

            string sql = @"INSERT INTO Incisos(IncisoLetra,IncisoContenido,ArticuloId,IncisoDescripcion)
                        VALUES (@IncisoLetra,@IncisoContenido,@ArticuloId,@IncisoDescripcion)";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("IncisoLetra", txtIncisoLetra.Text));
            cmd.Parameters.Add(new SqlParameter("IncisoContenido", txtIncisoContenido.Text));
            cmd.Parameters.Add(new SqlParameter("ArticuloId", articuloId));
            cmd.Parameters.Add(new SqlParameter("IncisoDescripcion", txtIncisoDescripcion.Text));
            cmd.Transaction = trans;
            cmd.ExecuteNonQuery();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        void Limpiar()
        {
            txtArticuloNumero.Text = "";
            cmbCategoria.SelectedIndex = 0;
            txtIncisoLetra.Text = "";
            txtIncisoDescripcion.Text = "";
            txtIncisoContenido.Text = "";
            Session["ArticuloId"] = null;
        }

        
    }
}