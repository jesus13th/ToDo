using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace ToDo.App.Models {
    public class ToDoItem {
        [AutoIncrement, PrimaryKey, Unique]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
    }
}
