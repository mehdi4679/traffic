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
    public class RequestTrafficClass
    {
        public static SqlConnection cnn = new SqlConnection(CSharp.PublicFunction.cnstr());
        public static int insert(ClRequestTraffic c )

        {

            SqlCommand cmd = new SqlCommand("PRC_RequestTraffic_Insert", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

      
       cmd.Parameters.Add(new SqlParameter("OwnerType", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.OwnerType);
cmd.Parameters.Add(new SqlParameter("TrackingCode", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.TrackingCode);
cmd.Parameters.Add(new SqlParameter("DiscountType", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.DiscountType);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.PersonalID);
cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.CompanyID);
cmd.Parameters.Add(new SqlParameter("CarID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.CarID);


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
            public static int insertGroup(ClRequestTraffic c )

        {

            SqlCommand cmd = new SqlCommand("PRC_RequestTraffic_InsertGroup", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

      
       cmd.Parameters.Add(new SqlParameter("OwnerType", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.OwnerType);
cmd.Parameters.Add(new SqlParameter("TrackingCode", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.TrackingCode);
cmd.Parameters.Add(new SqlParameter("DiscountType", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.DiscountType);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.PersonalID);
cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.CompanyID);
cmd.Parameters.Add(new SqlParameter("CarID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.CarID);

cmd.Parameters.Add(new SqlParameter("RepeatTypeID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RepeatTypeID);
cmd.Parameters.Add(new SqlParameter("RepeatTypeValues", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RepeatTypeValues);
cmd.Parameters.Add(new SqlParameter("SahmID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.SahmID);

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
    public static int insertDiscount(ClRequestTraffic c )

        {

            SqlCommand cmd = new SqlCommand("PRC_RequestTraffic_Insert_Discount", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

      
       cmd.Parameters.Add(new SqlParameter("OwnerType", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.OwnerType);
cmd.Parameters.Add(new SqlParameter("TrackingCode", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.TrackingCode);
cmd.Parameters.Add(new SqlParameter("DiscountType", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.DiscountType);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.PersonalID);
cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.CompanyID);
cmd.Parameters.Add(new SqlParameter("CarID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.CarID);
cmd.Parameters.Add(new SqlParameter("SahmID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.SahmID);
cmd.Parameters.Add(new SqlParameter("DarsadJanbazi", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.DarsadJanbazi);
cmd.Parameters.Add(new SqlParameter("YearID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.YearID);


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

        public static int insertNew(ClRequestTraffic c )

        {

            SqlCommand cmd = new SqlCommand("PRC_RequestTraffic_InsertNew", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

      
       cmd.Parameters.Add(new SqlParameter("OwnerType", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.OwnerType);
cmd.Parameters.Add(new SqlParameter("TrackingCode", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.TrackingCode);
cmd.Parameters.Add(new SqlParameter("DiscountType", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.DiscountType);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.PersonalID);
cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.CompanyID);
cmd.Parameters.Add(new SqlParameter("CarID", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.CarID);

cmd.Parameters.Add(new SqlParameter("Pelak", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.Pelak);
cmd.Parameters.Add(new SqlParameter("ModelCar", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.ModelCar);
cmd.Parameters.Add(new SqlParameter("NationalCode", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.NationalCode);
cmd.Parameters.Add(new SqlParameter("Mobile", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.Mobile);
cmd.Parameters.Add(new SqlParameter("RepeatTypeID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RepeatTypeID);
cmd.Parameters.Add(new SqlParameter("RepeatTypeValues", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RepeatTypeValues);
cmd.Parameters.Add(new SqlParameter("PriceRequest", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.PriceRequest);

cmd.Parameters.Add(new SqlParameter("Firstname", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Firstname);
cmd.Parameters.Add(new SqlParameter("LastName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.LastName);
cmd.Parameters.Add(new SqlParameter("Adress", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Adress);
cmd.Parameters.Add(new SqlParameter("PersonalType", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalType);
cmd.Parameters.Add(new SqlParameter("CodePosti", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CodePosti);


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
        public static DataSet GetList(ClRequestTraffic c)
        {

            SqlCommand cmd = new SqlCommand("PRC_RequestTraffic_GetList", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

cmd.Parameters.Add(new SqlParameter("RequestTrafficID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestTrafficID);
cmd.Parameters.Add(new SqlParameter("OwnerType", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.OwnerType);
cmd.Parameters.Add(new SqlParameter("TrackingCode", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.TrackingCode);
cmd.Parameters.Add(new SqlParameter("DiscountType", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountType);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalID);
cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyID);
cmd.Parameters.Add(new SqlParameter("CarID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CarID);
cmd.Parameters.Add(new SqlParameter("PersonalMobile", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Mobile);
cmd.Parameters.Add(new SqlParameter("RepeatTypeID", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RepeatTypeID);


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
        public static DataSet GetListWS(ClRequestTraffic c)
        {

            SqlCommand cmd = new SqlCommand("PRC_RequestTraffic_SendWS", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

cmd.Parameters.Add(new SqlParameter("RequestTrafficID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestTrafficID);
cmd.Parameters.Add(new SqlParameter("OwnerType", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.OwnerType);
cmd.Parameters.Add(new SqlParameter("TrackingCode", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.TrackingCode);
cmd.Parameters.Add(new SqlParameter("DiscountType", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountType);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalID);
cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyID);
cmd.Parameters.Add(new SqlParameter("CarID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CarID);
cmd.Parameters.Add(new SqlParameter("PersonalMobile", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Mobile);
cmd.Parameters.Add(new SqlParameter("RepeatTypeID", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RepeatTypeID);


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
       public static DataSet GetListPrice(ClRequestTraffic c)
        {

            SqlCommand cmd = new SqlCommand("PRC_RequestPrice_GetList", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
 
cmd.Parameters.Add(new SqlParameter("RequestTrafficID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestTrafficID);
 

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
        public static int GetPrice(ClRequestTraffic c)
        {

            SqlCommand cmd = new SqlCommand("PRC_GetPrice", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

             cmd.Parameters.Add(new SqlParameter("Pelak", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Pelak);
             cmd.Parameters.Add(new SqlParameter("RepeatID", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RepeatTypeID);


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

        public static DataSet GetListCode(ClRequestTraffic c)
        {

            SqlCommand cmd = new SqlCommand("PRC_RequestTraffic_GetListCode", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

            cmd.Parameters.Add(new SqlParameter("RequestTrafficID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestTrafficID);
            cmd.Parameters.Add(new SqlParameter("OwnerType", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.OwnerType);
            cmd.Parameters.Add(new SqlParameter("TrackingCode", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.TrackingCode);
            cmd.Parameters.Add(new SqlParameter("DiscountType", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountType);
            cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalID);
            cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyID);
            cmd.Parameters.Add(new SqlParameter("CarID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CarID);


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
        public static DataSet GetListCodeManagee(ClRequestTraffic c)
        {

            SqlCommand cmd = new SqlCommand("PRC_RequestTraffic_ManageReport", cnn);

            cmd.Parameters.Add(new SqlParameter("FromDate", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.fromDate);
            cmd.Parameters.Add(new SqlParameter("ToDate", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.ToDate);


 
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

          public static DataSet GetListCode2(ClRequestTraffic c)
        {

            SqlCommand cmd = new SqlCommand("PRC_RequestTraffic_GetListCode2", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

            cmd.Parameters.Add(new SqlParameter("RequestTrafficID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestTrafficID);
            cmd.Parameters.Add(new SqlParameter("OwnerType", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.OwnerType);
            cmd.Parameters.Add(new SqlParameter("TrackingCode", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.TrackingCode);
            cmd.Parameters.Add(new SqlParameter("DiscountType", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountType);
            cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalID);
            cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyID);
            cmd.Parameters.Add(new SqlParameter("CarID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CarID);


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
           public static DataSet GetListManage(ClRequestTraffic c)
        {

            SqlCommand cmd = new SqlCommand("PRC_RequestTraffic_GetListManage", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

            cmd.Parameters.Add(new SqlParameter("RequestTrafficID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestTrafficID);
            cmd.Parameters.Add(new SqlParameter("OwnerType", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.OwnerType);
            cmd.Parameters.Add(new SqlParameter("TrackingCode", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.TrackingCode);
            cmd.Parameters.Add(new SqlParameter("DiscountType", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountType==0 ?null:c.DiscountType);
            cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalID);
            cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyID);
            cmd.Parameters.Add(new SqlParameter("CarID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CarID);
             cmd.Parameters.Add(new SqlParameter("FirtName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Firstname);
            cmd.Parameters.Add(new SqlParameter("LastName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.LastName);
            cmd.Parameters.Add(new SqlParameter("FromDate", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.fromDate);
            cmd.Parameters.Add(new SqlParameter("ToDate", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.ToDate);
            cmd.Parameters.Add(new SqlParameter("Pelak", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Pelak);
            cmd.Parameters.Add(new SqlParameter("RequestStatus", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestStatus);
            cmd.Parameters.Add(new SqlParameter("MelliCode", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.MelliCode);
            cmd.Parameters.Add(new SqlParameter("RepeatTypeID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RepeatTypeID);

            cmd.Parameters.Add(new SqlParameter("FRomOrderDateStart", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.FRomOrderDateStart);
            cmd.Parameters.Add(new SqlParameter("ToOrderDateStart", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.ToOrderDateStart);
            cmd.Parameters.Add(new SqlParameter("GetConfilict", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.GetConfilict);

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
        public static int Update(ClRequestTraffic c)
        {

            SqlCommand cmd = new SqlCommand("PRC_RequestTraffic_Update", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

	cmd.Parameters.Add(new SqlParameter("RequestTrafficID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestTrafficID);
cmd.Parameters.Add(new SqlParameter("OwnerType", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.OwnerType);
cmd.Parameters.Add(new SqlParameter("TrackingCode", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.TrackingCode);
cmd.Parameters.Add(new SqlParameter("DiscountType", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountType);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalID);
cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyID);
cmd.Parameters.Add(new SqlParameter("CarID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CarID);
cmd.Parameters.Add(new SqlParameter("RequestStatus", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestStatus);
cmd.Parameters.Add(new SqlParameter("RequestStatusComment", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestStatusComment);
cmd.Parameters.Add(new SqlParameter("WsMojaz", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.WsMojaz);
cmd.Parameters.Add(new SqlParameter("PriceRequest", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PriceRequest);

             
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
        public static int UpdateAllReqPayForShaj(ClRequestTraffic c)
        {

            SqlCommand cmd = new SqlCommand("PRC_RequestTraffic_UpdatePayForShaj", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

	cmd.Parameters.Add(new SqlParameter("RequestTrafficID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestTrafficID);
cmd.Parameters.Add(new SqlParameter("OwnerType", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.OwnerType);
cmd.Parameters.Add(new SqlParameter("TrackingCode", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.TrackingCode);
cmd.Parameters.Add(new SqlParameter("DiscountType", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.DiscountType);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonalID);
cmd.Parameters.Add(new SqlParameter("CompanyID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CompanyID);
cmd.Parameters.Add(new SqlParameter("CarID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CarID);
cmd.Parameters.Add(new SqlParameter("RequestStatus", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestStatus);
cmd.Parameters.Add(new SqlParameter("RequestStatusComment", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.RequestStatusComment);
cmd.Parameters.Add(new SqlParameter("ALlRequest", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.ALlRequest);
cmd.Parameters.Add(new SqlParameter("PayForShajDate", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity("");
cmd.Parameters.Add(new SqlParameter("AllPrice", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.AllPrice);


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
        public static int DeleteReal(string  RequestTrafficID)
        {

            SqlCommand cmd = new SqlCommand("PRC_RequestTraffic_Delete2", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

   	cmd.Parameters.Add(new SqlParameter("RequestTrafficID", SqlDbType.Int)).Value =RequestTrafficID ;
 
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
        public static int Delete(string  RequestTrafficID)
        {

            SqlCommand cmd = new SqlCommand("PRC_RequestTraffic_Delete2", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

   	cmd.Parameters.Add(new SqlParameter("RequestTrafficID", SqlDbType.Int)).Value =RequestTrafficID ;
 
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

