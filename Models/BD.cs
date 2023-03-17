using System;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Http;

namespace Pizzas.API.Models;

public class BD
{
    private static string _connectionString = @"Server=A-PHZ2-AMI-016;DataBase=Pizzas;Trusted_Connection=True;";

    public static List<Pizza> GetAll()
    {
        string sql = "SELECT * FROM Pizzas";
        List<Pizza> l = new List<Pizza>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            l = db.Query<Pizza>(sql).ToList();
        }
        return l;
    }
    public static Pizza GetById(int id)
    {
        string sql = "SELECT * FROM Pizzas WHERE id=@pid";
        Pizza p = new Pizza();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            p = db.QueryFirstOrDefault<Pizza>(sql, new { pid = id });
        }
        return p;
    }

    public static int Craete(Pizza pizza)
    {
        int cambiosAfectados = 0;
        string sql = "INSERT INTO Pizzas VALUES (@pNombre,@pLibreGluten,@pImporte,@pDescripcion)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
          cambiosAfectados = db.Execute(sql, new { pNombre=pizza.nombre,pLibreGluten=pizza.libreGluten,pImporte=pizza.importe,pDescripcion = pizza.descripcion });
        }
        return cambiosAfectados;
    }
    public static int Update(int id, Pizza pizza)
    {
        int cambiosAfectados = 0;
        string sql = "UPDATE Pizzas SET nombre = @pNombre, libreGluten = @pLibreGluten, importe = @pImporte, descripcion = @pDescripcion WHERE id=@pId";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            cambiosAfectados = db.Execute(sql, new { pId = pizza.id, pNombre = pizza.nombre, pLibreGluten = pizza.libreGluten, pImporte = pizza.importe, pDescripcion = pizza.descripcion });
        }
        return cambiosAfectados;
    }

    public static int DeleteById(int id){
        int cambiosAfectados = 0;
        string sql = "DELETE FROM Pizzas WHERE id=@pId";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            cambiosAfectados = db.Execute(sql, new {pId = id });
        }
        return cambiosAfectados;
    }

}