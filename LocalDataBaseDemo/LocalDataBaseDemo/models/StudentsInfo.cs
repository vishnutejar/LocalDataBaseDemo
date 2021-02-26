using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalDataBaseDemo.models
{
    public class StudentsInfo
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string RoleNumber{ get; set; }
        public string Age{ get; set; }
        public string PhNumber{ get; set; }
        public string Email{ get; set; }
        public string Branch{ get; set; }
        public string profileImage{ get; set; }
        public string Password{ get; set; }
    }
}
