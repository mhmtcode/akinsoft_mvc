using akinsoft_mvc.Models;
using akinsoft_mvc.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace akinsoft_mvc.BPL
{
    public class ItemBPL
    {
        Connect con;
       
        public ItemBPL()
        {
            con = new Connect();
           
        }

        public Task<bool> Category_Saved(catagory mdl)
        {
            try
            {
                con.Open_Connection();
                con.Sql_Query(@"INSERT INTO CATEGORY (Catagory_Name,User_id)
                                VALUES (@Catagory_Name,@User_id);");
                con.Add_Param("@Catagory_Name", mdl.Catagory_Name);
                con.Add_Param("@User_id", mdl.User_id);
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
        public Task<List<catagory>> get_category_list(int userid)
        {
            List<catagory> catagories = new List<catagory>();
            try
            {
                con.Open_Connection();
                con.Sql_Query("Select * From CATEGORY WHERE User_id=@User_id");
                con.Add_Param("@User_id", userid);
                catagories = Converter.ConvertDataTable.ConvertToList<catagory>(con.Get_Table());
                return Task.FromResult(catagories);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close_Connection();
            }

        }

        public Task<List<Items>> Item_List(int user_id)
        {
            List<Items> signups = new List<Items>();
            try
            {
                con.Open_Connection();
                con.Sql_Query("Select * From REGISTER_VW WHERE User_id=@User_id");
                con.Add_Param("@User_id", user_id);
                signups = Converter.ConvertDataTable.ConvertToList<Items>(con.Get_Table());
                return Task.FromResult(signups);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close_Connection();
            }
        }
        public Task<bool> Item_Saved(Item_Saved mdl)
        {
            if (mdl.ID>0) //update
            {
                try
                {
                    con.Open_Connection();
                    con.Sql_Query(@"UPDATE REGISTER SET 
                                         registername= @registername,
                                         urladress=@urladress,
                                         category_id=@category_id,
                                         username=@username,
                                         password=@password
                                        WHERE ID=@ID;");
                    con.Add_Param("@ID", mdl.ID);
                    con.Add_Param("@registername", mdl.registername);
                    con.Add_Param("@urladress", mdl.urladress);
                    con.Add_Param("@category_id", mdl.category_id);
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
            else    // Saved
            {

                try
                {
                    con.Open_Connection();
                    con.Sql_Query(@"INSERT INTO REGISTER (
                                         registername,
                                         urladress,
                                         category_id,
                                         username,
                                         password,
                                         User_id)
                                     VALUES (
                                         @registername,
                                         @urladress,
                                         @category_id,
                                         @username,
                                         @password,
                                         @User_id);");
                    con.Add_Param("@registername", mdl.registername);
                    con.Add_Param("@urladress", mdl.urladress);
                    con.Add_Param("@category_id", mdl.category_id);
                    con.Add_Param("@username", mdl.username);
                    con.Add_Param("@password", mdl.password);
                    con.Add_Param("@User_id", mdl.User_id);
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
        public Task<bool> Item_Delete(string id)
        {
            try
            {
                con.Open_Connection();
                con.Sql_Query(@"DELETE FROM REGISTER 
                                WHERE ID=@ID");
                con.Add_Param("@ID", id);
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

        public Task<Item_Saved> Get_Item(string id)
        {
            List<Item_Saved> Item = new List<Item_Saved>();
            try
            {
                con.Open_Connection();
                con.Sql_Query("Select * From REGISTER WHERE ID=@ID");
                con.Add_Param("@ID", id);
                Item = Converter.ConvertDataTable.ConvertToList<Item_Saved>(con.Get_Table());
                return Task.FromResult(Item.FirstOrDefault());
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close_Connection();
            }
        }
    }
}