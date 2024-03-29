﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EticaUNITEC;
using System.Data;
using System.Data.SqlClient;

namespace EticaUNITEC.Seguridad
{
    public partial class ListaTemplateActas : EticaPage
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBLocalConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            privilegio = "Consultar Plantillas";
            SetPrivilegiosToActualUser();

            CargarGrid();
            //grid.Columns[0].Visible = false;
            grid.Columns[2].Visible = false;
            grid.Columns[4].Visible = false;
        }

        private void CargarGrid()
        {
            bool exito = true;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            try
            {
                string sql = @"SELECT *
                               FROM Templates"; //InformacionTemplates

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                grid.DataSource = reader;
                grid.DataBind();

            }
            catch (Exception ex)
            {
                Session["error"] = ex.StackTrace;
                exito = false;
            }
            con.Close();
            if (!exito)
                Response.Redirect("~/Seguridad/Error.aspx");
        }

        private void SetPrivilegiosToActualUser()
        {
            if (!currentUser.TienePrivilegio("Modificar Plantillas"))
                grid.Columns[6].Visible = false;
            if (!currentUser.TienePrivilegio("Modificar Plantillas"))
                grid.Columns[7].Visible = false;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!currentUser.ValidarPrivilegio("Insertar Plantillas"))
                return;
            Response.Redirect("TemplateActas.aspx");
        }

        protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int a = e.RowIndex;
            GridViewRow row = grid.Rows[a];
            string faltaId = row.Cells[0].Text;


            string aas = row.Cells[1].Text;
            aas = row.Cells[2].Text;
            aas = row.Cells[3].Text;
            aas = row.Cells[4].Text;
            aas = row.Cells[5].Text;

            bool exito = true;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            try
            {

                string sql = @"DELETE FROM Templates
                               WHERE TemplateId=" + int.Parse(faltaId);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Session["error"] = ex.StackTrace;
                exito = false;
            }
            con.Close();
            if (!exito)
                Response.Redirect("~/Seguridad/Error.aspx");
            else
                Response.Redirect("ListaTemplateActas.aspx");
        }

    }
}