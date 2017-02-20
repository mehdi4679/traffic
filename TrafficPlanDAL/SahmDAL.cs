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
    public class SahmClass
    {
        public static SqlConnection cnn = new SqlConnection(CSharp.PublicFunction.cnstr());
        public static int insert(ClSahm c )

        {

            SqlCommand cmd = new SqlCommand("PRC_Sahm_Insert", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

      
       cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.CompanyID);
cmd.Parameters.Add(new SqlParameter("DiscountTypeID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.DiscountTypeID);
cmd.Parameters.Add(new SqlParameter("sahmNumbre", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.sahmNumbre);
cmd.Parameters.Add(new SqlParameter("DiscountPersent", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.DiscountPersent);
cmd.Parameters.Add(new SqlParameter("Comment", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.Comment);
cmd.Parameters.Add(new SqlParameter("RegDate", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RegDate);
cmd.Parameters.Add(new SqlParameter("RegUser", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.RegUser);
cmd.Parameters.Add(new SqlParameter("Year", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.Year);


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
        public static DataSet GetList(ClSahm c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Sahm_GetList", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();


             cmd.Parameters.Add(new SqlParameter("SahmID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.SahmID);
cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyID);
cmd.Parameters.Add(new SqlParameter("DiscountTypeID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountTypeID);
cmd.Parameters.Add(new SqlParameter("sahmNumbre", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.sahmNumbre);
cmd.Parameters.Add(new SqlParameter("DiscountPersent", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountPersent);
cmd.Parameters.Add(new SqlParameter("Comment", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Comment);
cmd.Parameters.Add(new SqlParameter("RegDate", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RegDate);
cmd.Parameters.Add(new SqlParameter("RegUser", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RegUser);
cmd.Parameters.Add(new SqlParameter("Year", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.Year);


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
        public static DataSet GetListWhithHaghighi(ClSahm c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Sahm_GetListWhithHaghighi", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

             cmd.Parameters.Add(new SqlParameter("SahmID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.SahmID);
cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyID);
cmd.Parameters.Add(new SqlParameter("DiscountTypeID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountTypeID);
cmd.Parameters.Add(new SqlParameter("sahmNumbre", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.sahmNumbre);
cmd.Parameters.Add(new SqlParameter("DiscountPersent", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountPersent);
cmd.Parameters.Add(new SqlParameter("Comment", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Comment);
cmd.Parameters.Add(new SqlParameter("RegDate", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RegDate);
cmd.Parameters.Add(new SqlParameter("RegUser", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RegUser);
cmd.Parameters.Add(new SqlParameter("Year", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.Year);


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
        public static int Update(ClSahm c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Sahm_Update", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

	cmd.Parameters.Add(new SqlParameter("SahmID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.SahmID);
cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyID);
cmd.Parameters.Add(new SqlParameter("DiscountTypeID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountTypeID);
cmd.Parameters.Add(new SqlParameter("sahmNumbre", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.sahmNumbre);
cmd.Parameters.Add(new SqlParameter("DiscountPersent", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountPersent);
cmd.Parameters.Add(new SqlParameter("Comment", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Comment);
cmd.Parameters.Add(new SqlParameter("RegDate", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RegDate);
cmd.Parameters.Add(new SqlParameter("RegUser", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RegUser);
cmd.Parameters.Add(new SqlParameter("Year", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.Year);


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
        public static int Delete(string  SahmID)
        {

            SqlCommand cmd = new SqlCommand("PRC_Sahm_Delete", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

   	cmd.Parameters.Add(new SqlParameter("SahmID", SqlDbType.Int)).Value =SahmID ;
 
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

