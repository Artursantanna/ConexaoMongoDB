using MongoDB.Driver;
using MongoDataAccess.DataAccess;
using MongoDataAccess.Models;

ClienteDataAccess db = new ClienteDataAccess();

await db.adicionar(cliente: new ClienteModel() { Nome = "Rafael Cordeiro", Email = "rafael.cordeiro@email.com.br" });

var users = await db.ObterTodos();
foreach (var cliente in users)
{
    Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}, Email: {cliente.Email}");
}