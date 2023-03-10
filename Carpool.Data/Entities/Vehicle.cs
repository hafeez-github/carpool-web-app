using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carpool.Data.Entities
{
    [Table("Vehicle")]
    public class Vehicle
	{
		
		public int Id { get; set; }

        public string Number { get; set; }

        public int Type { get; set; }

        public int OwnerId { get; set; }

        public Vehicle()
        {
        }

    }
}

