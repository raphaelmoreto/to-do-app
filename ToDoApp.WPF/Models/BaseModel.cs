using System;

namespace ToDoApp.WPF.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; protected set; }
    }
}
