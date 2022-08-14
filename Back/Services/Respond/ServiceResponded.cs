using System;
namespace Services.Respond
{
    public class ServiceResponded<T>
    {
        public string Message { get; set; }
        public bool Result { get; set; } 
        public T Data { get; set; }
    }
}