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
    public class AttachClass
    {
        public static SqlConnection cnn = new SqlConnection(CSharp.PublicFunction.cnstr());
        public static int insert(ClAttach c )

        {

            SqlCommand cmd = new SqlCommand("PRC_Attach_Insert", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

      
       cmd.Parameters.Add(new SqlParameter("AttachName", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.AttachName);
cmd.Parameters.Add(new SqlParameter("ForTable", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.ForTable);
cmd.Parameters.Add(new SqlParameter("ForID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.ForID);
cmd.Parameters.Add(new SqlParameter("ForCatalogType", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.ForCatalogType);
cmd.Parameters.Add(new SqlParameter("ForCatalogValue", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.ForCatalogValue);
cmd.Parameters.Add(new SqlParameter("CreateUser", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.CreateUser);
cmd.Parameters.Add(new SqlParameter("createDate", SqlDbType.SmallDateTime)).Value =Securenamespace.SecureData.CheckSecurity(c.createDate);
cmd.Parameters.Add(new SqlParameter("Compelete", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.Compelete);
cmd.Parameters.Add(new SqlParameter("MelliCode", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Mellicode);


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
        public static DataSet GetList(ClAttach c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Attach_GetList", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("PageIndex", SqlDbType.NVarChar)).Value = c.PageIndex;
            cmd.Parameters.Add(new SqlParameter("PageSize", SqlDbType.NVarChar)).Value = c.PageSize;
            cmd.Parameters.Add(new SqlParameter("Order", SqlDbType.NVarChar)).Value = c.OrderDirection;
            cmd.Parameters.Add(new SqlParameter("OrderBy", SqlDbType.NVarChar)).Value = c.OrderBy;
		 
             cmd.Parameters.Add(new SqlParameter("AttachID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.AttachID);
cmd.Parameters.Add(new SqlParameter("AttachName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.AttachName);
cmd.Parameters.Add(new SqlParameter("ForTable", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.ForTable);
cmd.Parameters.Add(new SqlParameter("ForID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.ForID);
cmd.Parameters.Add(new SqlParameter("ForCatalogType", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.ForCatalogType);
cmd.Parameters.Add(new SqlParameter("ForCatalogValue", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.ForCatalogValue);
cmd.Parameters.Add(new SqlParameter("CreateUser", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CreateUser);
cmd.Parameters.Add(new SqlParameter("createDate", SqlDbType.SmallDateTime)).Value = Securenamespace.SecureData.CheckSecurity(c.createDate);
cmd.Parameters.Add(new SqlParameter("Compelete", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.Compelete);


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
        public static DataSet GetListAll(ClAttach c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Attach_GetListAll", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("PageIndex", SqlDbType.NVarChar)).Value = c.PageIndex;
            cmd.Parameters.Add(new SqlParameter("PageSize", SqlDbType.NVarChar)).Value = c.PageSize;
            cmd.Parameters.Add(new SqlParameter("Order", SqlDbType.NVarChar)).Value = c.OrderDirection;
            cmd.Parameters.Add(new SqlParameter("OrderBy", SqlDbType.NVarChar)).Value = c.OrderBy;
		 
             cmd.Parameters.Add(new SqlParameter("AttachID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.AttachID);
cmd.Parameters.Add(new SqlParameter("AttachName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.AttachName);
cmd.Parameters.Add(new SqlParameter("ForTable", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.ForTable);
cmd.Parameters.Add(new SqlParameter("ForID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.ForID);
cmd.Parameters.Add(new SqlParameter("ForCatalogType", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.ForCatalogType);
cmd.Parameters.Add(new SqlParameter("ForCatalogValue", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.ForCatalogValue);
cmd.Parameters.Add(new SqlParameter("CreateUser", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CreateUser);
cmd.Parameters.Add(new SqlParameter("createDate", SqlDbType.SmallDateTime)).Value = Securenamespace.SecureData.CheckSecurity(c.createDate);
cmd.Parameters.Add(new SqlParameter("Compelete", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.Compelete);
 

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
        public static int Update(ClAttach c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Attach_Update", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

	cmd.Parameters.Add(new SqlParameter("AttachID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.AttachID);
cmd.Parameters.Add(new SqlParameter("AttachName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.AttachName);
cmd.Parameters.Add(new SqlParameter("ForTable", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.ForTable);
cmd.Parameters.Add(new SqlParameter("ForID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.ForID);
cmd.Parameters.Add(new SqlParameter("ForCatalogType", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.ForCatalogType);
cmd.Parameters.Add(new SqlParameter("ForCatalogValue", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.ForCatalogValue);
cmd.Parameters.Add(new SqlParameter("CreateUser", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CreateUser);
cmd.Parameters.Add(new SqlParameter("createDate", SqlDbType.SmallDateTime)).Value = Securenamespace.SecureData.CheckSecurity(c.createDate);
cmd.Parameters.Add(new SqlParameter("Compelete", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.Compelete);


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
        public static int Delete(string  AttachID)
        {

            SqlCommand cmd = new SqlCommand("PRC_Attach_Delete", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

   	cmd.Parameters.Add(new SqlParameter("AttachID", SqlDbType.Int)).Value =AttachID ;
 
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

