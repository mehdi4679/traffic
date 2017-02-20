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
    public class RequestRepeatClass
    {
        public static SqlConnection cnn = new SqlConnection(CSharp.PublicFunction.cnstr());
        public static int insert(    ClRequestRepeat c )

        {

            SqlCommand cmd = new SqlCommand("PRC_RequestRepeat_Insert", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

      
       cmd.Parameters.Add(new SqlParameter("RequestID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.RequestID);
cmd.Parameters.Add(new SqlParameter("RepeatTypeID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.RepeatTypeID);
cmd.Parameters.Add(new SqlParameter("RepeatDate", SqlDbType.SmallDateTime)).Value =Securenamespace.SecureData.CheckSecurity(c.RepeatDate);
cmd.Parameters.Add(new SqlParameter("YearMonthSeasonID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.YearMonthSeasonID);


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
        public static DataSet GetList(ClRequestRepeat c)
        {

            SqlCommand cmd = new SqlCommand("PRC_RequestRepeat_GetList", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

             cmd.Parameters.Add(new SqlParameter("RequestRepeatID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestRepeatID);
cmd.Parameters.Add(new SqlParameter("RequestID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestID);
cmd.Parameters.Add(new SqlParameter("RepeatTypeID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RepeatTypeID);
cmd.Parameters.Add(new SqlParameter("RepeatDate", SqlDbType.SmallDateTime)).Value = Securenamespace.SecureData.CheckSecurity(c.RepeatDate);
cmd.Parameters.Add(new SqlParameter("YearMonthSeasonID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.YearMonthSeasonID);


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
        public static int Update(ClRequestRepeat c)
        {

            SqlCommand cmd = new SqlCommand("PRC_RequestRepeat_Update", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

	cmd.Parameters.Add(new SqlParameter("RequestRepeatID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestRepeatID);
cmd.Parameters.Add(new SqlParameter("RequestID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestID);
cmd.Parameters.Add(new SqlParameter("RepeatTypeID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RepeatTypeID);
cmd.Parameters.Add(new SqlParameter("RepeatDate", SqlDbType.SmallDateTime)).Value = Securenamespace.SecureData.CheckSecurity(c.RepeatDate);
cmd.Parameters.Add(new SqlParameter("YearMonthSeasonID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.YearMonthSeasonID);


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
        public static int Delete(string  RequestRepeatID)
        {

            SqlCommand cmd = new SqlCommand("PRC_RequestRepeat_Delete", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

   	cmd.Parameters.Add(new SqlParameter("RequestRepeatID", SqlDbType.Int)).Value =RequestRepeatID ;
 
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

