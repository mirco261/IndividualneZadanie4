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
        public List<Department> SelectDepartments()
        {
            List<Department> departments = new List<Department>();
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
                    command.CommandText = @"SELECT [ID]
                                              ,[Code]
                                              ,[Name]
                                              ,[Hierarchy]
                                              ,[ParentDepartment]
                                              ,[HeadEmployeeID]
                                              FROM [Oddelenie]";
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            {
                                while (reader.Read())
                                {
                                    Department department = new Department();
                                    department.ID = reader.GetInt32(0);
                                    department.Code = reader.GetString(1);
                                    department.Name = reader.GetString(2);
                                    department.Hierarchy = (EHierarchy)(reader.GetInt32(3));
                                    department.ParentDepartment = reader.GetInt32(4);
                                    department.HeadEmployeeID = reader.GetInt32(5);
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

        public bool InsertDepartment(Department department)
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
                        command.CommandText = @"INSERT INTO [Oddelenie]
                                               ([ID]
                                               ,[Code]
                                               ,[Name]
                                               ,[Hierarchy]
                                               ,[ParentDepartment]
                                               ,[HeadEmployeeID])
                                         VALUES
                                               (@ID,
                                               ,@Code,
                                               ,@Name,
                                               ,@Hierarchy, 
                                               ,@ParentDepartment, 
                                               ,@HeadEmployeeID)";

                        command.Parameters.Add("@ID", SqlDbType.Int).Value = department.ID;
                        command.Parameters.Add("@Code", SqlDbType.NVarChar).Value = department.Code;
                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = department.Name;
                        command.Parameters.Add("@Hierarchy", SqlDbType.Int).Value = (int)department.Hierarchy;
                        command.Parameters.Add("@ParentDepartment", SqlDbType.Int).Value = department.ParentDepartment;
                        command.Parameters.Add("@HeadEmployeeID", SqlDbType.Int).Value = department.HeadEmployeeID;

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

        public bool UpdateDepartment(Department department)
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
                        command.CommandText = @"UPDATE [Oddelenie]
                                                   SET [Code] = @Code
                                                      ,[Name] = @Name
                                                      ,[Hierarchy] = @Hierarchy
                                                      ,[ParentDepartment] = @ParentDepartment
                                                      ,[HeadEmployeeID] = @HeadEmployeeID
                                                 WHERE [ID] = @ID";

                        command.Parameters.Add("@Code", SqlDbType.NVarChar).Value = department.Code;
                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = department.Name;
                        command.Parameters.Add("@Hierarchy", SqlDbType.Int).Value = (int)department.Hierarchy;
                        command.Parameters.Add("@ParentDepartment", SqlDbType.Int).Value = department.ParentDepartment;
                        command.Parameters.Add("@HeadEmployeeID", SqlDbType.Int).Value = department.HeadEmployeeID;

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
    }
}
