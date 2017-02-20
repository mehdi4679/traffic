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
    public class CarClass
    {
        public static SqlConnection cnn = new SqlConnection(CSharp.PublicFunction.cnstr());
        public static int insert(ClCar c )

        {

            SqlCommand cmd = new SqlCommand("PRC_Car_Insert", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

      
        cmd.Parameters.Add(new SqlParameter("Pelak", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.Pelak);
        cmd.Parameters.Add(new SqlParameter("CarType", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CarType);
        cmd.Parameters.Add(new SqlParameter("CarModel", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CarModel);
        cmd.Parameters.Add(new SqlParameter("CarColor", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.CarColor);
        cmd.Parameters.Add(new SqlParameter("CarCapacity", SqlDbType.Int)).Value =Securenamespace.SecureData.CheckSecurity(c.CarCapacity);
        cmd.Parameters.Add(new SqlParameter("VIN", SqlDbType.NVarChar)).Value =Securenamespace.SecureData.CheckSecurity(c.VIN);
        cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonID);

        cmd.Parameters.Add(new SqlParameter("CarOFcompanyID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CarOFcompanyID);
        cmd.Parameters.Add(new SqlParameter("SacrificeName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.SacrificeName);
        cmd.Parameters.Add(new SqlParameter("SacrificePercent", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.SacrificePercent);

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
        public static DataSet CheckPelak(ClCar c)
        {

            SqlCommand cmd = new SqlCommand("Prc_CehckAgance", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

 
 cmd.Parameters.Add(new SqlParameter("Pelak", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Pelak);
 

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
        public static DataSet GetList(ClCar c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Car_GetList", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

             cmd.Parameters.Add(new SqlParameter("CarID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CarID);
cmd.Parameters.Add(new SqlParameter("Pelak", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Pelak);
cmd.Parameters.Add(new SqlParameter("CarType", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CarType);
cmd.Parameters.Add(new SqlParameter("CarModel", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CarModel);
cmd.Parameters.Add(new SqlParameter("CarColor", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CarColor);
cmd.Parameters.Add(new SqlParameter("CarCapacity", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CarCapacity);
cmd.Parameters.Add(new SqlParameter("VIN", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.VIN);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonID);


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
        public static DataSet GetListCarInYear(ClCar c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Car_GetListInYear", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
            cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
            cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
            cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
            cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

             cmd.Parameters.Add(new SqlParameter("CarID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CarID);
cmd.Parameters.Add(new SqlParameter("Pelak", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Pelak);
cmd.Parameters.Add(new SqlParameter("CarType", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CarType);
cmd.Parameters.Add(new SqlParameter("CarModel", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CarModel);
cmd.Parameters.Add(new SqlParameter("CarColor", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CarColor);
cmd.Parameters.Add(new SqlParameter("CarCapacity", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CarCapacity);
cmd.Parameters.Add(new SqlParameter("VIN", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.VIN);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonID);
cmd.Parameters.Add(new SqlParameter("yearID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.yearID);


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
        public static int Update(ClCar c)
        {

            SqlCommand cmd = new SqlCommand("PRC_Car_Update", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

	cmd.Parameters.Add(new SqlParameter("CarID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CarID);
cmd.Parameters.Add(new SqlParameter("Pelak", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.Pelak);
cmd.Parameters.Add(new SqlParameter("CarType", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CarType);
cmd.Parameters.Add(new SqlParameter("CarModel", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CarModel);
cmd.Parameters.Add(new SqlParameter("CarColor", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.CarColor);
cmd.Parameters.Add(new SqlParameter("CarCapacity", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CarCapacity);
cmd.Parameters.Add(new SqlParameter("VIN", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.VIN);
cmd.Parameters.Add(new SqlParameter("PersonalID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.PersonID);

cmd.Parameters.Add(new SqlParameter("CarOFcompanyID", SqlDbType.Int)).Value = Securenamespace.SecureData.CheckSecurity(c.CarOFcompanyID);
cmd.Parameters.Add(new SqlParameter("SacrificeName", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.SacrificeName);
cmd.Parameters.Add(new SqlParameter("SacrificePercent", SqlDbType.NVarChar)).Value = Securenamespace.SecureData.CheckSecurity(c.SacrificePercent);

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
        public static int Delete(string  CarID,int personalID  )
        {

            SqlCommand cmd = new SqlCommand("PRC_Car_Delete", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("UserIDLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetUserID();
        cmd.Parameters.Add(new SqlParameter("IpLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetIPAddress();
        cmd.Parameters.Add(new SqlParameter("OSLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetOS();
        cmd.Parameters.Add(new SqlParameter("OSVerLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetBrowser() + CSharp.PublicFunction.GetBrowserVersion();
        cmd.Parameters.Add(new SqlParameter("URLLog", SqlDbType.NVarChar)).Value = CSharp.PublicFunction.GetURL();

   	cmd.Parameters.Add(new SqlParameter("CarID", SqlDbType.Int)).Value =CarID ;
    cmd.Parameters.Add(new SqlParameter("personalID", SqlDbType.Int)).Value = personalID;
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

