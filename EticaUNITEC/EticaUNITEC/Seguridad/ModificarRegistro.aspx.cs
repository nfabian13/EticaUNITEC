﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using EticaUNITEC;

namespace Etica_Unitec
{
    public partial class ModificarRegistro : EticaPage
    {
        string cmstring = System.Configuration.ConfigurationManager.ConnectionStrings["DBLocalConnectionString"].ConnectionString;
        string userid ;
         DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            userid = Request.QueryString["userid"];
            if (!IsPostBack)
            {
                Data();
            }
            TextBox1.Enabled = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cmstring);
            con.Open();
            string sql = "UPDATE Privilegios SET PrivilegioLlave='"+txtLlave.Text +"', PrivilegioDescripcion='"+txtDes.Text+"' WHERE PrivilegioId='"+userid+"'";


            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
         
            cmd.ExecuteNonQuery();

            con.Close();
            if (txtLlave.Text != "" && txtDes.Text != "")
            {
                Response.Redirect("~/Seguridad/PrivilegioInicio.aspx");
            }
            //CargarGrid();
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Seguridad/PrivilegioInicio.aspx");
        }

        void Data()
        {
            SqlConnection con = new SqlConnection(cmstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrivilegioId,PrivilegioLlave,PrivilegioDescripcion FROM Privilegios WHERE PrivilegioId=" + userid, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
           
            da.Fill(dt);
            if(dt.Rows.Count>0){
            TextBox1.Text = userid;
            txtLlave.Text = dt.Rows[0][1].ToString();
            txtDes.Text = dt.Rows[0][2].ToString();
            }
            con.Close();
        }
    }
}