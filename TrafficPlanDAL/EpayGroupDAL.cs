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
    public class EpayGroupClass
    {
        public static SqlConnection cnn = new SqlConnection(CSharp.PublicFunction.cnstr());
        public static int insert(ClEpayGroup c )

        {

            SqlCommand cmd = new SqlCommand("PRC_EpayGroup_Insert", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

      
       cmd.Parameters.Add(new SqlParameter("GroupID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.GroupID);
cmd.Parameters.Add(new SqlParameter("ReqID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.ReqID);
cmd.Parameters.Add(new SqlParameter("DareReg", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.DareReg);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.PersonalID);


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
        public static int insertAllReq(ClEpayGroup c )

        {

            SqlCommand cmd = new SqlCommand("PRC_EpayGroup_InsertAllREq", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

      
       cmd.Parameters.Add(new SqlParameter("GroupID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.GroupID);
cmd.Parameters.Add(new SqlParameter("ReqID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.ReqID);
cmd.Parameters.Add(new SqlParameter("DareReg", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.DareReg);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.PersonalID);
 cmd.Parameters.Add(new SqlParameter("AllReq", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.AllReq);


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
        public static DataSet GetList(ClEpayGroup c)
        {

            SqlCommand cmd = new SqlCommand("PRC_EpayGroup_GetList", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();
            
            cmd.Parameters.Add(new SqlParameter("EpayGroupID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.EpayGroupID);
cmd.Parameters.Add(new SqlParameter("GroupID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.GroupID);
cmd.Parameters.Add(new SqlParameter("ReqID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.ReqID);
cmd.Parameters.Add(new SqlParameter("DareReg", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.DareReg);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalID);


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
        public static int Update(ClEpayGroup c)
        {

            SqlCommand cmd = new SqlCommand("PRC_EpayGroup_Update", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

	cmd.Parameters.Add(new SqlParameter("EpayGroupID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.EpayGroupID);
cmd.Parameters.Add(new SqlParameter("GroupID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.GroupID);
cmd.Parameters.Add(new SqlParameter("ReqID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.ReqID);
cmd.Parameters.Add(new SqlParameter("DareReg", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.DareReg);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalID);


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
        public static int Delete(string  EpayGroupID)
        {

            SqlCommand cmd = new SqlCommand("PRC_EpayGroup_Delete", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

   	cmd.Parameters.Add(new SqlParameter("EpayGroupID", SqlDbType.Int)).Value =EpayGroupID ;
 
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

