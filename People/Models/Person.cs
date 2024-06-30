using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.Models
{
    [SQLite.Table("people")]
    public class Person
    {

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [SQLite.MaxLength(250), Unique]
        public string name { get; set; }
    }
}
