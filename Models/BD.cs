using System;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Http;

namespace Pizzas.API.Models;

public class BD
{
    private static string _connectionString = @"Server=A-PHZ2-AMI-016;DataBase=Pizzas;Trusted_Connection=True;";

    public static List<Pizzas> GetAll()
    {
        string sql = "SELECT * FROM Pizzas";
        List<Pizzas> l = new List<Pizzas>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            l = db.Query<Pizzas>(sql).ToList();
        }
        return l;
    }
    public static Pizzas GetById(int id)
    {
        string sql = "SELECT * FROM Pizzas WHERE id=@pid";
        Pizzas p = new Pizzas();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            p = db.QueryFirstOrDefault<Pizzas>(sql, new { pid = id });
        }
        return p;
    }

}