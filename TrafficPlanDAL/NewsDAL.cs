using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Data.SqlClient;
using TrafficPlanCL;

namespace TrafficPlanDAL
{
    public class NewsClass
    {
        public static SqlConnection cnn = new SqlConnection(CSharp.PublicFunction.cnstr());
        public static int insert(ClNews c )

        {

            SqlCommand cmd = new SqlCommand("PRC_News_Insert", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

      
       cmd.Parameters.Add(new SqlParameter("ForCatalogID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.ForCatalogID);
cmd.Parameters.Add(new SqlParameter("Title", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.Title);
cmd.Parameters.Add(new SqlParameter("Comment", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.Comment);
cmd.Parameters.Add(new SqlParameter("RegDate", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.RegDate);
cmd.Parameters.Add(new SqlParameter("RegUser", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.RegUser);


           SqlParameter prmResult = new SqlParameter("Result", SqlDbType.Int);
            prmResult.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(prmResult);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(prmResult.Value);
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                cnn.Close();
            }

        }

        //---------------------------------------------------------------------------------------------------------
        public static DataSet GetList(ClNews c)
        {

            SqlCommand cmd = new SqlCommand("PRC_News_GetList", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();


             cmd.Parameters.Add(new SqlParameter("NewID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.NewID);
cmd.Parameters.Add(new SqlParameter("ForCatalogID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.ForCatalogID);
cmd.Parameters.Add(new SqlParameter("Title", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Title);
cmd.Parameters.Add(new SqlParameter("Comment", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Comment);
cmd.Parameters.Add(new SqlParameter("RegDate", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RegDate);
cmd.Parameters.Add(new SqlParameter("RegUser", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RegUser);


           SqlParameter prmResult = new SqlParameter("Result", SqlDbType.Int);
            prmResult.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(prmResult);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                cnn.Open();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                cnn.Close();
            }

        }

        //---------------------------------------------------------------------------------------------------------
        public static int Update(ClNews c)
        {

            SqlCommand cmd = new SqlCommand("PRC_News_Update", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

	cmd.Parameters.Add(new SqlParameter("NewID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.NewID);
cmd.Parameters.Add(new SqlParameter("ForCatalogID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.ForCatalogID);
cmd.Parameters.Add(new SqlParameter("Title", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Title);
cmd.Parameters.Add(new SqlParameter("Comment", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Comment);
cmd.Parameters.Add(new SqlParameter("RegDate", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RegDate);
cmd.Parameters.Add(new SqlParameter("RegUser", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RegUser);


            SqlParameter prmResult = new SqlParameter("Result", SqlDbType.Int);
            prmResult.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(prmResult);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(prmResult.Value);
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                cnn.Close();
            }

        }

        //---------------------------------------------------------------------------------------------------------
        public static int Delete(string  NewID)
        {

            SqlCommand cmd = new SqlCommand("PRC_News_Delete", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

   	cmd.Parameters.Add(new SqlParameter("NewID", SqlDbType.Int)).Value =NewID ;
 
            SqlParameter prmResult = new SqlParameter("Result", SqlDbType.Int);
            prmResult.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(prmResult);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(prmResult.Value);
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                cnn.Close();
            }

        }
    }

    //---------------------------------------------------------------------------------------------------------
}

