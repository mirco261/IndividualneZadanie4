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
    public class EmployeeRepository
    {

        public List<EmployeeModel> SelectEmployees()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
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
                    command.CommandText = @"SELECT e.[ID]
                                          ,[Title]
                                          ,[FirstName]
                                          ,[LastName]
                                          ,[Telephone]
                                          ,[Email]
                                          ,[DepartmentID]
										  ,d.[Name]
                                          FROM [Employee] as e
									      LEFT JOIN Department as d
									      ON e.[DepartmentID] = d.ID";
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            {
                                while (reader.Read())
                                {
                                    EmployeeModel employee = new EmployeeModel
                                    {
                                        ID = reader.GetInt32(0),
                                        Title = reader.GetString(1),
                                        FirstName = reader.GetString(2),
                                        Lastname = reader.GetString(3),
                                        Telephone = reader.GetString(4),
                                        Email = reader.GetString(5),
                                        DepartmentID = reader.GetInt32(6),
                                        DepartmentName = reader.GetString(7)
                                    };
                                    employees.Add(employee);
                                                                        
                                 }
                            
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        Debug.WriteLine(e.Message);
                    }
                }
                return employees;
            }
        }



        public bool InsertEmployee(EmployeeModel employee)
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
                        command.CommandText = @"INSERT INTO [Employee]
                                               ([Title]
                                               ,[FirstName]
                                               ,[LastName]
                                               ,[Telephone]
                                               ,[Email]
                                               ,[DepartmentID])
                                                VALUES
                                               (@Title
                                               ,@FirstName
                                               ,@LastName
                                               ,@Telephone
                                               ,@Email
                                               ,@DepartmentID)";

                        command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = employee.Title;
                        command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = employee.FirstName;
                        command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = employee.Lastname;
                        command.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = employee.Telephone;
                        command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = employee.Email;
                        command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = employee.DepartmentID;

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




        public bool UpdateEmployee(EmployeeModel employee)
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
                        command.CommandText = @"UPDATE [Employee]
                                               SET [Title] = @Title
                                                  ,[FirstName] = @FirstName
                                                  ,[LastName] = @LastName
                                                  ,[Telephone] = @Telephone
                                                  ,[Email] = @Email
                                                  ,[DepartmentID] = @DepartmentID
                                                 WHERE [ID] = @ID";

                        command.Parameters.Add("@ID", SqlDbType.Int).Value = employee.ID;
                        command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = employee.Title;
                        command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = employee.FirstName;
                        command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = employee.Lastname;
                        command.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = employee.Telephone;
                        command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = employee.Email;
                        command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = employee.DepartmentID;

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
