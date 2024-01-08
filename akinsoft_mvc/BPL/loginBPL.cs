using akinsoft_mvc.Models;
using akinsoft_mvc.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace akinsoft_mvc.BPL
{
    public class loginBPL
    {
        Connect con;
      
        public loginBPL() { 
        
        con = new Connect();
        }

        public Task<int> user_validate(login_page lgn)
        {
            
            try
            {
                con.Open_Connection();
                con.Sql_Query(@"Select * From USERS
                                Where username=@username AND password=@password LIMIT 1");
                con.Add_Param("@username",lgn.username);
                con.Add_Param("@password",lgn.password);
                if (con.Get_Table().Rows.Count>0)
                {
                    int user_id = Convert.ToInt32(con.Get_Table().Rows[0][0].ToString());
                  
                    return Task.FromResult(user_id);
                }
                else
                {
                    return Task.FromResult(0);
                }
          
            }
            catch (Exception)
            {
                return Task.FromResult(0);
                throw;
            }
            finally
            {
                con.Close_Connection();
            }

        }

        public Task<bool> save_user(register_user mdl)
        {
            try
            {

                con.Open_Connection();
                con.Sql_Query(@"INSERT INTO USERS (
                                         username,
                                         password)
                                     VALUES (
                                         @username,
                                         @password);");
                con.Add_Param("@username", mdl.username);
                con.Add_Param("@password", mdl.password);
                if (con.NonExec_Query() > 0)
                {
                    return Task.FromResult(true);
                }
                else
                {
                    return Task.FromResult(false);
                }


            }
            catch (Exception)
            {
                return Task.FromResult(false);
                throw;
            }
            finally
            {
                con.Close_Connection();
            }
        }
    }
}