using DAL.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly string _connectionString;

        public PersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Person item)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "INSERT INTO Person (name, dateofbirth, ismarried, phone_number, salary) VALUES (@Name, @DateOfBirth, @Married, @Phone, @Salary)";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", item.Name);
                    command.Parameters.AddWithValue("@DateOfBirth", item.DateOfBirth);
                    command.Parameters.AddWithValue("@Married", item.IsMarried);
                    command.Parameters.AddWithValue("@Phone", item.PhoneNumber);
                    command.Parameters.AddWithValue("@Salary", item.Salary);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Person Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "SELECT * FROM Person WHERE id = @Id";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Person
                            {
                                Id = (int)reader["id"],
                                Name = reader["name"].ToString(),
                                DateOfBirth = DateOnly.Parse(((DateTime)reader["dateofbirth"]).ToShortDateString()),
                                IsMarried = (bool)reader["ismarried"],
                                PhoneNumber = reader["phone_number"].ToString(),
                                Salary = (decimal)reader["salary"],
                                RowInsertTime= (DateTime)reader["row_insert_time"],
                                RowUpdateTime= (DateTime)reader["row_update_time"]
                            };
                        }
                    }
                }
            }
            return null; // Return null if person with specified id is not found
        }

        public IEnumerable<Person> GetAll()
        {
            var people = new List<Person>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "SELECT * FROM Person";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            people.Add(new Person
                            {
                                Id = (int)reader["id"],
                                Name = reader["name"].ToString(),
                                DateOfBirth = DateOnly.Parse(((DateTime)reader["dateofbirth"]).ToShortDateString()),
                                IsMarried = (bool)reader["ismarried"],
                                PhoneNumber = reader["phone_number"].ToString(),
                                Salary = (decimal)reader["salary"],
                                RowInsertTime = (DateTime)reader["row_insert_time"],
                                RowUpdateTime = (DateTime)reader["row_update_time"]

                            });
                        }
                    }
                }
            }

            return people;
        }

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "DELETE FROM Person WHERE id = @Id";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Person item)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "UPDATE Person SET name = @Name, dateofbirth = @DateOfBirth, ismarried = @Married, phone_number = @Phone, salary = @Salary, row_update_time = @UpdateTime WHERE id = @Id";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", item.Id);
                    command.Parameters.AddWithValue("@Name", item.Name);
                    command.Parameters.AddWithValue("@DateOfBirth", item.DateOfBirth);
                    command.Parameters.AddWithValue("@Married", item.IsMarried);
                    command.Parameters.AddWithValue("@Phone", item.PhoneNumber);
                    command.Parameters.AddWithValue("@Salary", item.Salary);
                    command.Parameters.AddWithValue("@UpdateTime", DateTime.Now);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
