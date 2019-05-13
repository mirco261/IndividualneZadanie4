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
                    command.CommandText = @"SELECT o1.ID
                                              ,o1.Code 
                                              ,o1.Name
                                              ,o1.Hierarchy
                                              ,o1.ParentDepartmentID
                                              ,o1.HeadEmployeeID
											  ,o2.Name
											  ,e.LastName+ ' '+ e.FirstName+ ' '+ e.Title as  'HeadEmployeeName'
                                              FROM Department as o1
											  left join Department as o2
											  on o1.ParentDepartment = o2.ID
											  left join Employee as e
											  on o1.HeadEmployeeID = e.ID";
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            {
                                while (reader.Read())
                                {
                                    DepartmentModel department = new DepartmentModel();
                                    department.ID = reader.GetInt32(0);
                                    department.Code = reader.GetString(1);
                                    department.Name = reader.GetString(2);
                                    department.Hierarchy = (EHierarchy)(reader.GetInt32(3));
                                    department.ParentDepartmentID = reader.GetInt32(4);
                                    department.HeadEmployeeID = reader.GetInt32(5);
                                    department.ParentDepartmentName = reader.IsDBNull(6) ? null : reader.GetString(6);
                                    department.HeadEmployeeName = reader.IsDBNull(7) ? null : reader.GetString(7);
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
                        command.Parameters.Add("@ParentDepartmentID", SqlDbType.Int).Value = department.ParentDepartmentID;
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
                                                      ,[ParentDepartmentID] = @ParentDepartment
                                                      ,[HeadEmployeeID] = @HeadEmployeeID
                                                 WHERE [ID] = @ID";

                        command.Parameters.Add("@ID", SqlDbType.NVarChar).Value = department.ID;
                        command.Parameters.Add("@Code", SqlDbType.NVarChar).Value = department.Code;
                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = department.Name;
                        command.Parameters.Add("@Hierarchy", SqlDbType.Int).Value = (int)department.Hierarchy;
                        command.Parameters.Add("@ParentDepartmentID", SqlDbType.Int).Value = department.ParentDepartmentID;
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
