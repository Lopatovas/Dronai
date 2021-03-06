﻿using Dronai.Packages.Users.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dronai.Packages.Users.Services
{
    public class UsersServices
    {
        private MySqlConnection _connection;
        public UsersServices(MySqlConnection conn)
        {
            _connection = conn;
        }

        public User RegisterUser(User user)
        {
            _connection.Open();
            var insertQuerry = $"INSERT INTO users (name, surname, phoneNumber, email, password, status) VALUES(\"{user.Name}\", \"{user.Surname}\", \"{user.PhoneNumber}\", \"{user.Email}\", \"{user.Password}\", \"{ConsumerState.Active.Value}\"); ";
            MySqlCommand cmd = new MySqlCommand(insertQuerry, _connection);
            var updated = cmd.ExecuteNonQuery();
            _connection.Close();
            if (updated > 0)
            {
                return user;
            }
            return null;
        }

        public User AuthenticateUser(User user)
        {
            _connection.Open();
            var insertQuerry = $"select * from users where email=\"{user.Email}\" and password=\"{user.Password}\" and status=\"Aktyvus\";";
            Employee authenticatedEmployee = null;
            MySqlCommand cmd = new MySqlCommand(insertQuerry, _connection);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {

                    authenticatedEmployee = new Employee()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        PersonalId = Convert.ToString(reader["personalId"]),
                        Email = Convert.ToString(reader["email"]),
                    };

                }
            }
            _connection.Close();
            return authenticatedEmployee;
        }
    }
}
