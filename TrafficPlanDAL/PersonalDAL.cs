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
    public class PersonalClass
    {
        public static SqlConnection cnn = new SqlConnection(CSharp.PublicFunction.cnstr());
        public static int insert(ClPersonal c )

        {

            SqlCommand cmd = new SqlCommand("PRC_Personal_Insert", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

      
       cmd.Parameters.Add(new SqlParameter("NationalCode", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.NationalCode);
cmd.Parameters.Add(new SqlParameter("FirstName", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.FirstName);
cmd.Parameters.Add(new SqlParameter("LastName", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.LastName);
cmd.Parameters.Add(new SqlParameter("PersonalAdress", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.PersonalAdress);
cmd.Parameters.Add(new SqlParameter("PostiCode", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.PostiCode);
cmd.Parameters.Add(new SqlParameter("PersonalTel", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.PersonalTel);
cmd.Parameters.Add(new SqlParameter("PersonalMobile", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.PersonalMobile);
cmd.Parameters.Add(new SqlParameter("JobName", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.JobName);
cmd.Parameters.Add(new SqlParameter("Email", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.Email);
cmd.Parameters.Add(new SqlParameter("PassWord", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Pass);
 

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
        public static DataSet GetList(ClPersonal c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Personal_GetList", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

             cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalID==0 ? null:c.PersonalID);
cmd.Parameters.Add(new SqlParameter("NationalCode", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.NationalCode);
cmd.Parameters.Add(new SqlParameter("FirstName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.FirstName);
cmd.Parameters.Add(new SqlParameter("LastName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.LastName);
cmd.Parameters.Add(new SqlParameter("PersonalAdress", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalAdress);
cmd.Parameters.Add(new SqlParameter("PostiCode", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.PostiCode);
cmd.Parameters.Add(new SqlParameter("PersonalTel", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalTel);
cmd.Parameters.Add(new SqlParameter("PersonalMobile", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalMobile);
cmd.Parameters.Add(new SqlParameter("JobName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.JobName);
cmd.Parameters.Add(new SqlParameter("Email", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Email);
cmd.Parameters.Add(new SqlParameter("PassWord", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Pass);


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
        public static int UpdatePass(ClPersonal c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Personal_UpdatePass", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

            cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalID);
            cmd.Parameters.Add(new SqlParameter("NationalCode", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.NationalCode);
            cmd.Parameters.Add(new SqlParameter("FirstName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.FirstName);
            cmd.Parameters.Add(new SqlParameter("LastName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.LastName);
            cmd.Parameters.Add(new SqlParameter("PersonalAdress", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalAdress);
            cmd.Parameters.Add(new SqlParameter("PostiCode", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.PostiCode);
            cmd.Parameters.Add(new SqlParameter("PersonalTel", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalTel);
            cmd.Parameters.Add(new SqlParameter("PersonalMobile", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalMobile);
            cmd.Parameters.Add(new SqlParameter("JobName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.JobName);
            cmd.Parameters.Add(new SqlParameter("Email", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Email);
            cmd.Parameters.Add(new SqlParameter("Pass", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Pass);


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
        public static int   Update(ClPersonal c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Personal_Update", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

	cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalID);
cmd.Parameters.Add(new SqlParameter("NationalCode", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.NationalCode);
cmd.Parameters.Add(new SqlParameter("FirstName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.FirstName);
cmd.Parameters.Add(new SqlParameter("LastName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.LastName);
cmd.Parameters.Add(new SqlParameter("PersonalAdress", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalAdress);
cmd.Parameters.Add(new SqlParameter("PostiCode", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.PostiCode);
cmd.Parameters.Add(new SqlParameter("PersonalTel", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalTel);
cmd.Parameters.Add(new SqlParameter("PersonalMobile", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalMobile);
cmd.Parameters.Add(new SqlParameter("JobName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.JobName);
cmd.Parameters.Add(new SqlParameter("Email", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Email);
cmd.Parameters.Add(new SqlParameter("Pass", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Pass);
cmd.Parameters.Add(new SqlParameter("IsInActive", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.IsInActive);
cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyID);

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
        public static int Delete(string  PersonalID)
        {

            SqlCommand cmd = new SqlCommand("PRC_Personal_Delete", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

   	cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value =PersonalID ;
 
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

