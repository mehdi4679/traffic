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
    public class RequestDiscountClass
    {
        public static SqlConnection cnn = new SqlConnection(CSharp.PublicFunction.cnstr());
        public static int insert(ClRequestDiscount c )

        {

            SqlCommand cmd = new SqlCommand("PRC_RequestDiscount_Insert", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

      
       cmd.Parameters.Add(new SqlParameter("RequestID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.RequestID);
cmd.Parameters.Add(new SqlParameter("DiscountPriceID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.DiscountPriceID);
cmd.Parameters.Add(new SqlParameter("DiscountCode", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.DiscountCode);
cmd.Parameters.Add(new SqlParameter("Adress", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.Adress);
cmd.Parameters.Add(new SqlParameter("DiscountComment", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.DiscountComment);
cmd.Parameters.Add(new SqlParameter("DiscountAttach", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountAttach);


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
        public static DataSet GetList(ClRequestDiscount c)
        {

            SqlCommand cmd = new SqlCommand("PRC_RequestDiscount_GetList", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

             cmd.Parameters.Add(new SqlParameter("DisCountRequestID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.DisCountRequestID);
cmd.Parameters.Add(new SqlParameter("RequestID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestID);
cmd.Parameters.Add(new SqlParameter("DiscountPriceID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountPriceID);
cmd.Parameters.Add(new SqlParameter("DiscountCode", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountCode);
cmd.Parameters.Add(new SqlParameter("Adress", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Adress);
cmd.Parameters.Add(new SqlParameter("DiscountComment", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountComment);
cmd.Parameters.Add(new SqlParameter("DiscountAttach", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountAttach);


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
        public static int Update(ClRequestDiscount c)
        {

            SqlCommand cmd = new SqlCommand("PRC_RequestDiscount_Update", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

	cmd.Parameters.Add(new SqlParameter("DisCountRequestID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.DisCountRequestID);
cmd.Parameters.Add(new SqlParameter("RequestID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestID);
cmd.Parameters.Add(new SqlParameter("DiscountPriceID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountPriceID);
cmd.Parameters.Add(new SqlParameter("DiscountCode", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountCode);
cmd.Parameters.Add(new SqlParameter("Adress", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Adress);
cmd.Parameters.Add(new SqlParameter("DiscountComment", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountComment);
cmd.Parameters.Add(new SqlParameter("DiscountAttach", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountAttach);


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
        public static int Delete(string  DisCountRequestID)
        {

            SqlCommand cmd = new SqlCommand("PRC_RequestDiscount_Delete", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

   	cmd.Parameters.Add(new SqlParameter("DisCountRequestID", SqlDbType.Int)).Value =DisCountRequestID ;
 
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

