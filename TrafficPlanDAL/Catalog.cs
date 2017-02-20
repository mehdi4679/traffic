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
    public class CatalogClass
    {
        public static SqlConnection cnn = new SqlConnection(CSharp.PublicFunction.cnstr());
        public static int insert(ClCatalog c )

        {

            SqlCommand cmd = new SqlCommand("PRC_Catalog_Insert", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

        cmd.Parameters.Add(new SqlParameter("CaID", SqlDbType.NVarChar)).Value = c.CID;
        cmd.Parameters.Add(new SqlParameter("CatalogName", SqlDbType.NVarChar)).Value = c.CatalogName;
        cmd.Parameters.Add(new SqlParameter("CatalogValue", SqlDbType.NVarChar)).Value = c.CatalogValue;
        cmd.Parameters.Add(new SqlParameter("parentID", SqlDbType.NVarChar)).Value = c.parentID;
        cmd.Parameters.Add(new SqlParameter("OrderID", SqlDbType.NVarChar)).Value = c.OrderID;
        cmd.Parameters.Add(new SqlParameter("CatalogTypeID", SqlDbType.NVarChar)).Value = c.CatalogTypeID;

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
        public static DataSet GetListDiscountType()
        {

            SqlCommand cmd = new SqlCommand("PRC_GetListDiscountType_GetList", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


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
        public static DataSet GetList(TrafficPlanCL.ClCatalog c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Catalog_GetList", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            cmd.Parameters.Add(new SqlParameter("PageIndex", SqlDbType.NVarChar)).Value = c.PageIndex;
            cmd.Parameters.Add(new SqlParameter("PageSize", SqlDbType.NVarChar)).Value = c.PageSize;
            cmd.Parameters.Add(new SqlParameter("Order", SqlDbType.NVarChar)).Value = c.OrderDirection;
            cmd.Parameters.Add(new SqlParameter("OrderBy", SqlDbType.NVarChar)).Value = c.OrderBy;


            cmd.Parameters.Add(new SqlParameter("CaID", SqlDbType.NVarChar)).Value = c.CID;
            cmd.Parameters.Add(new SqlParameter("CatalogName", SqlDbType.NVarChar)).Value = c.CatalogName;
            cmd.Parameters.Add(new SqlParameter("CatalogValue", SqlDbType.NVarChar)).Value = c.CatalogValue;
            cmd.Parameters.Add(new SqlParameter("parentID", SqlDbType.NVarChar)).Value = c.parentID ;
            cmd.Parameters.Add(new SqlParameter("OrderID", SqlDbType.NVarChar)).Value = c.OrderID;
            cmd.Parameters.Add(new SqlParameter("CatalogTypeID", SqlDbType.NVarChar)).Value =c.CatalogTypeID;
            cmd.Parameters.Add(new SqlParameter("ISSelect", SqlDbType.NVarChar)).Value = c.Select;



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

        public static DataSet GetList2(TrafficPlanCL.ClCatalog c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Catalog_GetList22", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            cmd.Parameters.Add(new SqlParameter("PageIndex", SqlDbType.NVarChar)).Value = c.PageIndex;
            cmd.Parameters.Add(new SqlParameter("PageSize", SqlDbType.NVarChar)).Value = c.PageSize;
            cmd.Parameters.Add(new SqlParameter("Order", SqlDbType.NVarChar)).Value = c.OrderDirection;
            cmd.Parameters.Add(new SqlParameter("OrderBy", SqlDbType.NVarChar)).Value = c.OrderBy;


            cmd.Parameters.Add(new SqlParameter("CaID", SqlDbType.NVarChar)).Value = c.CID;
            cmd.Parameters.Add(new SqlParameter("CatalogName", SqlDbType.NVarChar)).Value = c.CatalogName;
            cmd.Parameters.Add(new SqlParameter("CatalogValue", SqlDbType.NVarChar)).Value = c.CatalogValue;
            cmd.Parameters.Add(new SqlParameter("parentID", SqlDbType.NVarChar)).Value = c.parentID ;
            cmd.Parameters.Add(new SqlParameter("OrderID", SqlDbType.NVarChar)).Value = c.OrderID;
            cmd.Parameters.Add(new SqlParameter("CatalogTypeID", SqlDbType.NVarChar)).Value =c.CatalogTypeID;



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
        public static int Update(ClCatalog c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Catalog_Update", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();


        cmd.Parameters.Add(new SqlParameter("CaID", SqlDbType.NVarChar)).Value = c.CID;
        cmd.Parameters.Add(new SqlParameter("CatalogName", SqlDbType.NVarChar)).Value = c.CatalogName;
        cmd.Parameters.Add(new SqlParameter("CatalogValue", SqlDbType.NVarChar)).Value = c.CatalogValue;
        cmd.Parameters.Add(new SqlParameter("parentID", SqlDbType.NVarChar)).Value = c.parentID;
        cmd.Parameters.Add(new SqlParameter("OrderID", SqlDbType.NVarChar)).Value = c.OrderID;
        cmd.Parameters.Add(new SqlParameter("CatalogTypeID", SqlDbType.NVarChar)).Value = c.CatalogTypeID;
        cmd.Parameters.Add(new SqlParameter("ISSelect", SqlDbType.NVarChar)).Value = c.ISSelect;

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
        public static int Delete(string  CaID)
        {

            SqlCommand cmd = new SqlCommand("PRC_Catalog_Delete", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();


            SqlParameter prmCaID = new SqlParameter("CaID", SqlDbType.Int);
            prmCaID.Value =CaID;
            cmd.Parameters.Add(prmCaID);
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
  public static int Default(string  CaID)
        {

            SqlCommand cmd = new SqlCommand("PRC_Catalog_Default", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();


            SqlParameter prmCaID = new SqlParameter("CaID", SqlDbType.Int);
            prmCaID.Value =CaID;
            cmd.Parameters.Add(prmCaID);
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
        public static DataSet GetListTypeID(string  CatlogtypID)
        {
            ClCatalog c = new ClCatalog();
            c.CatalogTypeID = Convert.ToInt32(CatlogtypID);
            SqlCommand cmd = new SqlCommand("PRC_Catalog_GetList", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            cmd.Parameters.Add(new SqlParameter("PageIndex", SqlDbType.NVarChar)).Value = c.PageIndex;
            cmd.Parameters.Add(new SqlParameter("PageSize", SqlDbType.NVarChar)).Value = c.PageSize;
            cmd.Parameters.Add(new SqlParameter("Order", SqlDbType.NVarChar)).Value = c.OrderDirection;
            cmd.Parameters.Add(new SqlParameter("OrderBy", SqlDbType.NVarChar)).Value = c.OrderBy;


            cmd.Parameters.Add(new SqlParameter("CaID", SqlDbType.NVarChar)).Value = c.CID;
            cmd.Parameters.Add(new SqlParameter("CatalogName", SqlDbType.NVarChar)).Value = c.CatalogName;
            cmd.Parameters.Add(new SqlParameter("CatalogValue", SqlDbType.NVarChar)).Value = c.CatalogValue;
            cmd.Parameters.Add(new SqlParameter("parentID", SqlDbType.NVarChar)).Value = c.parentID;
            cmd.Parameters.Add(new SqlParameter("OrderID", SqlDbType.NVarChar)).Value = c.OrderID;
            cmd.Parameters.Add(new SqlParameter("CatalogTypeID", SqlDbType.NVarChar)).Value = c.CatalogTypeID;



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

    }

    //---------------------------------------------------------------------------------------------------------
}
