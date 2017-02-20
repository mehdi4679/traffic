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
    public class CompanyClass
    {
        public static SqlConnection cnn = new SqlConnection(CSharp.PublicFunction.cnstr());
        public static int insert(ClCompany c )

        {

            SqlCommand cmd = new SqlCommand("PRC_Company_Insert", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

      
       cmd.Parameters.Add(new SqlParameter("CompanyName", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.CompanyName);
cmd.Parameters.Add(new SqlParameter("ManageName", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.ManageName);
cmd.Parameters.Add(new SqlParameter("CompanyTel", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.CompanyTel);
cmd.Parameters.Add(new SqlParameter("ComapnyAdress", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.ComapnyAdress);
cmd.Parameters.Add(new SqlParameter("RepresentativeName", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.RepresentativeName);
cmd.Parameters.Add(new SqlParameter("RepresentativeMobile", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.RepresentativeMobile);
cmd.Parameters.Add(new SqlParameter("CompanyEmail", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.CompanyEmail);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalID);
cmd.Parameters.Add(new SqlParameter("CompanyTypeID", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyTypeID);


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
        public static DataSet GetList(ClCompany c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Company_GetList", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

             cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyID==0?null:c.CompanyID);
cmd.Parameters.Add(new SqlParameter("CompanyName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyName);
cmd.Parameters.Add(new SqlParameter("ManageName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.ManageName);
cmd.Parameters.Add(new SqlParameter("CompanyTel", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyTel);
cmd.Parameters.Add(new SqlParameter("ComapnyAdress", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.ComapnyAdress);
cmd.Parameters.Add(new SqlParameter("RepresentativeName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RepresentativeName);
cmd.Parameters.Add(new SqlParameter("RepresentativeMobile", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RepresentativeMobile);
cmd.Parameters.Add(new SqlParameter("CompanyEmail", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyEmail);


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

        public static DataSet GetListCompanyRequest(ClCompany c)
        {

            SqlCommand cmd = new SqlCommand("Prc_RequestTraffic_GetListCompanyGroup", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

 

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

        public static DataSet GetListPersonl(ClCompany c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Company_GetListPersonal", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

             cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyID);
cmd.Parameters.Add(new SqlParameter("CompanyName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyName);
cmd.Parameters.Add(new SqlParameter("ManageName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.ManageName);
cmd.Parameters.Add(new SqlParameter("CompanyTel", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyTel);
cmd.Parameters.Add(new SqlParameter("ComapnyAdress", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.ComapnyAdress);
cmd.Parameters.Add(new SqlParameter("RepresentativeName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RepresentativeName);
cmd.Parameters.Add(new SqlParameter("RepresentativeMobile", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RepresentativeMobile);
cmd.Parameters.Add(new SqlParameter("CompanyEmail", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyEmail);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalID);


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
        public static int Update(ClCompany c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Company_Update", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

	cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyID);
cmd.Parameters.Add(new SqlParameter("CompanyName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyName);
cmd.Parameters.Add(new SqlParameter("ManageName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.ManageName);
cmd.Parameters.Add(new SqlParameter("CompanyTel", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyTel);
cmd.Parameters.Add(new SqlParameter("ComapnyAdress", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.ComapnyAdress);
cmd.Parameters.Add(new SqlParameter("RepresentativeName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RepresentativeName);
cmd.Parameters.Add(new SqlParameter("RepresentativeMobile", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RepresentativeMobile);
cmd.Parameters.Add(new SqlParameter("CompanyEmail", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyEmail);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalID);
cmd.Parameters.Add(new SqlParameter("CompanyTypeID", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyTypeID);


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
        public static int Delete(string  CompanyID)
        {

            SqlCommand cmd = new SqlCommand("PRC_Company_Delete", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

   	cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.Int)).Value =CompanyID ;
 
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

