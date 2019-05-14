using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;
using Data.Models;
using System.Data;

namespace Data.Repositories
{
    public class DepartmentRepository
    {
        public List<DepartmentModel> SelectDepartments()
        {
            List<DepartmentModel> departments = new List<DepartmentModel>();
            using (SqlConnection connection = new SqlConnection(Route.CONNECTION_STRING))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException e)
                {
                    Debug.WriteLine(e.Message);
                }
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT dep1.ID
                                              ,dep1.Code 
                                              ,dep1.Name
                                              ,dep1.Hierarchy
                                              ,dep1.ParentDepartmentID
                                              ,dep1.HeadEmployeeID
											  ,dep2.Name
											  ,emp.LastName+ ' '+ emp.FirstName+ ' '+ emp.Title as  'HeadEmployeeName'
                                              FROM Department as dep1
											  left join Department as dep2
											  on dep1.ParentDepartmentID = dep2.ID
											  left join Employee as emp
											  on dep1.HeadEmployeeID = emp.ID
                                              ORDER BY dep1.ParentDepartmentID asc";
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            {
                                while (reader.Read())
                                {
                                    DepartmentModel department = new DepartmentModel
                                    {
                                        ID = reader.GetInt32(0),
                                        Code = reader.GetString(1),
                                        Name = reader.GetString(2),
                                        Hierarchy = (EHierarchy)(reader.GetInt32(3)),
                                        ParentDepartmentID = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                                        HeadEmployeeID = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                                        ParentDepartmentName = reader.IsDBNull(6) ? null : reader.GetString(6),
                                        HeadEmployeeName = reader.IsDBNull(7) ? null : reader.GetString(7)
                                    };
                                    departments.Add(department);
                                }
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        Debug.WriteLine(e.Message);
                    }
                }
                return departments;
            }
        }


        public bool InsertDepartment(DepartmentModel department)
        {
            using (SqlConnection connection = new SqlConnection(Route.CONNECTION_STRING))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException e)
                {
                    Debug.WriteLine(e.Message);
                    return false;
                }
                using (SqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"INSERT INTO [Department]
                                               ([Code]
                                               ,[Name]
                                               ,[Hierarchy]
                                               ,[ParentDepartmentID]
                                               ,[HeadEmployeeID])
                                         VALUES
                                               (@Code
                                               ,@Name
                                               ,@Hierarchy
                                               ,@ParentDepartmentID
                                               ,@HeadEmployeeID)";

                        command.Parameters.Add("@Code", SqlDbType.NVarChar).Value = department.Code;
                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = department.Name;
                        command.Parameters.Add("@Hierarchy", SqlDbType.Int).Value = (int)department.Hierarchy;
                        
                        if (department.ParentDepartmentID != 0)
                        {
                            command.Parameters.Add("@ParentDepartmentID", SqlDbType.Int).Value = department.ParentDepartmentID;
                        }
                        else
                        {
                            command.Parameters.Add("@ParentDepartmentID", SqlDbType.Int).Value = DBNull.Value;
                        }
                        if (department.HeadEmployeeID != 0)
                        {
                            command.Parameters.Add("@HeadEmployeeID", SqlDbType.Int).Value = department.HeadEmployeeID;
                        }
                        else
                        {
                            command.Parameters.Add("@HeadEmployeeID", SqlDbType.Int).Value = DBNull.Value;
                        }


                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (SqlException e)
                    {
                        Debug.WriteLine(e.Message);
                        return false;
                    }
                }
            }
        }

        public bool UpdateDepartment(DepartmentModel department)
        {
            using (SqlConnection connection = new SqlConnection(Route.CONNECTION_STRING))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException e)
                {
                    Debug.WriteLine(e.Message);
                    return false;
                }
                using (SqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"UPDATE [Department]
                                                   SET [Code] = @Code
                                                      ,[Name] = @Name
                                                      ,[Hierarchy] = @Hierarchy
                                                      ,[ParentDepartmentID] = @ParentDepartmentID
                                                      ,[HeadEmployeeID] = @HeadEmployeeID
                                                 WHERE [ID] = @ID";

                        command.Parameters.Add("@ID", SqlDbType.NVarChar).Value = department.ID;
                        command.Parameters.Add("@Code", SqlDbType.NVarChar).Value = department.Code;
                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = department.Name;
                        command.Parameters.Add("@Hierarchy", SqlDbType.Int).Value = (int)department.Hierarchy;
                        if (department.ParentDepartmentID != 0)
                        {
                            command.Parameters.Add("@ParentDepartmentID", SqlDbType.Int).Value = department.ParentDepartmentID;
                        }
                        else
                        {
                            command.Parameters.Add("@ParentDepartmentID", SqlDbType.Int).Value = DBNull.Value;
                        }
                        if (department.HeadEmployeeID != 0)
                        {
                            command.Parameters.Add("@HeadEmployeeID", SqlDbType.Int).Value = department.HeadEmployeeID;
                        }
                        else
                        {
                            command.Parameters.Add("@HeadEmployeeID", SqlDbType.Int).Value = DBNull.Value;
                        }

                        return command.ExecuteNonQuery() > 0;
                    }

                    catch (SqlException e)
                    {
                        Debug.WriteLine(e.Message);
                        return false;
                    }
                }
            }
        }

        public List<string> UserExistInDepartment(int idUser)
        {
            List<string> firms = new List<string>();
            using (SqlConnection connection = new SqlConnection(Route.CONNECTION_STRING))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException e)
                {
                    Debug.WriteLine(e.Message);
                }
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT dep1.Name
                                            FROM Department as dep1
                                            WHERE HeadEmployeeID = @idUser";
                    command.Parameters.Add("@idUser", SqlDbType.Int).Value = idUser;

                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            {
                                while (reader.Read())
                                {
                                    firms.Add(reader.GetString(0));
                                }
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        Debug.WriteLine(e.Message);
                    }
                }
                return firms;
            }
        }
    }
}
