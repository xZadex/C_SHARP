#pragma warning disable CS8618
namespace TheWall.Models;
public class MyViewModel
{
    public User? User {get;set;}
    public List<User>? AllUsers {get;set;}

    public Message? Message {get;set;}
    public List<Message>? AllMessages {get;set;}
}