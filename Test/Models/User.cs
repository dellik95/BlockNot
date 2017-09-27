
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Test
{
    public class Users
    {
        public Users()
        {
            this.Phones = new HashSet<Phones>();
        }
        [Key]
        public short User_ID { get; set; }
        public string UserName { get; set; }
        public string UserSname { get; set; }
        public string UserEmail { get; set; }
        
        public virtual ICollection<Phones> Phones { get; set; }
    }


    public class Phones
    {
        [Key]
        public short Phone_ID { get; set; }
        public int? Phone { get; set; }
        public short User_ID { get; set; }

    }
    public class UserContext : DbContext
    {
        public UserContext() : base("UserDB")
        { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Phones> Phones { get; set; }
    }
}