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
    public class PelakChangeClass
    {
        public static SqlConnection cnn = new SqlConnection(CSharp.PublicFunction.cnstr());
        public static int insert(ClPelakChange c )

        {

            SqlCommand cmd = new SqlCommand("PRC_PelakChange_Insert", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

      
       cmd.Parameters.Add(new SqlParameter("FromCarID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.FromCarID);
cmd.Parameters.Add(new SqlParameter("ToCarID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.ToCarID);
cmd.Parameters.Add(new SqlParameter("sysDATE", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.sysDATE);
cmd.Parameters.Add(new SqlParameter("RequestUser", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.RequestUser);
cmd.Parameters.Add(new SqlParameter("NazarID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.NazarID);
cmd.Parameters.Add(new SqlParameter("CommentUser", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.CommentUser);
cmd.Parameters.Add(new SqlParameter("CommentNazar", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.CommentNazar);
cmd.Parameters.Add(new SqlParameter("RequestTrafficID", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestTrafficID);


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
        public static DataSet GetList(ClPelakChange c)
        {

            SqlCommand cmd = new SqlCommand("PRC_PelakChange_GetList", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

             cmd.Parameters.Add(new SqlParameter("PelakChangeID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PelakChangeID);
cmd.Parameters.Add(new SqlParameter("FromCarID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.FromCarID);
cmd.Parameters.Add(new SqlParameter("ToCarID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.ToCarID);
cmd.Parameters.Add(new SqlParameter("sysDATE", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.sysDATE);
cmd.Parameters.Add(new SqlParameter("RequestUser", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestUser);
cmd.Parameters.Add(new SqlParameter("NazarID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.NazarID);
cmd.Parameters.Add(new SqlParameter("CommentUser", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CommentUser);
cmd.Parameters.Add(new SqlParameter("CommentNazar", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CommentNazar);
cmd.Parameters.Add(new SqlParameter("Pelak", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Pelak);
cmd.Parameters.Add(new SqlParameter("RequestTrafficID", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestTrafficID);


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
        public static int Update(ClPelakChange c)
        {

            SqlCommand cmd = new SqlCommand("PRC_PelakChange_Update", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

	cmd.Parameters.Add(new SqlParameter("PelakChangeID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PelakChangeID);
cmd.Parameters.Add(new SqlParameter("FromCarID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.FromCarID);
cmd.Parameters.Add(new SqlParameter("ToCarID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.ToCarID);
cmd.Parameters.Add(new SqlParameter("sysDATE", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.sysDATE);
cmd.Parameters.Add(new SqlParameter("RequestUser", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestUser);
cmd.Parameters.Add(new SqlParameter("NazarID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.NazarID);
cmd.Parameters.Add(new SqlParameter("CommentUser", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CommentUser);
cmd.Parameters.Add(new SqlParameter("CommentNazar", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CommentNazar);
cmd.Parameters.Add(new SqlParameter("RequestTrafficID", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestTrafficID);
cmd.Parameters.Add(new SqlParameter("NazarDate", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.NazarDate);


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
        public static int Delete(string  PelakChangeID)
        {

            SqlCommand cmd = new SqlCommand("PRC_PelakChange_Delete", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

   	cmd.Parameters.Add(new SqlParameter("PelakChangeID", SqlDbType.Int)).Value =PelakChangeID ;
 
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

