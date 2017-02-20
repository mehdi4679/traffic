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
    public class SharjClass
    {
        public static SqlConnection cnn = new SqlConnection(CSharp.PublicFunction.cnstr());
        public static int insert(ClSharj c )

        {

            SqlCommand cmd = new SqlCommand("PRC_Sharj_Insert", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

      
       cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.PersonalID);
       cmd.Parameters.Add(new SqlParameter("ShariPrice", SqlDbType.BigInt)).Value = Securenamespace.SecureData.CheckSecurity(c.ShariPrice);
cmd.Parameters.Add(new SqlParameter("ShajComment", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.ShajComment);
cmd.Parameters.Add(new SqlParameter("SharjDate", SqlDbType.SmallDateTime)).Value =Securenamespace.SecureData.CheckSecurity(c.SharjDate);
cmd.Parameters.Add(new SqlParameter("ISExpire", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.ISExpire);
cmd.Parameters.Add(new SqlParameter("IsZero", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.IsZero);
cmd.Parameters.Add(new SqlParameter("Mobile", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Mobile);
cmd.Parameters.Add(new SqlParameter("CodeMelli", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CodeMelli);


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
        public static DataSet GetList(ClSharj c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Sharj_GetList", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();
            
            cmd.Parameters.Add(new SqlParameter("SharjID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.SharjID);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalID);
cmd.Parameters.Add(new SqlParameter("ShariPrice", SqlDbType.BigInt)).Value = Securenamespace.SecureData.CheckSecurity(c.ShariPrice);
cmd.Parameters.Add(new SqlParameter("ShajComment", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.ShajComment);
cmd.Parameters.Add(new SqlParameter("SharjDate", SqlDbType.SmallDateTime)).Value = Securenamespace.SecureData.CheckSecurity(c.SharjDate);
cmd.Parameters.Add(new SqlParameter("ISExpire", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.ISExpire);
cmd.Parameters.Add(new SqlParameter("IsZero", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.IsZero);


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
        public static int Update(ClSharj c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Sharj_Update", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

	cmd.Parameters.Add(new SqlParameter("SharjID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.SharjID);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalID);
cmd.Parameters.Add(new SqlParameter("ShariPrice", SqlDbType.BigInt)).Value = Securenamespace.SecureData.CheckSecurity(c.ShariPrice);
cmd.Parameters.Add(new SqlParameter("ShajComment", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.ShajComment);
cmd.Parameters.Add(new SqlParameter("SharjDate", SqlDbType.SmallDateTime)).Value = Securenamespace.SecureData.CheckSecurity(c.SharjDate);
cmd.Parameters.Add(new SqlParameter("ISExpire", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.ISExpire);
cmd.Parameters.Add(new SqlParameter("IsZero", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.IsZero);


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
        public static int Delete(string  SharjID)
        {

            SqlCommand cmd = new SqlCommand("PRC_Sharj_Delete", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

   	cmd.Parameters.Add(new SqlParameter("SharjID", SqlDbType.Int)).Value =SharjID ;
 
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

