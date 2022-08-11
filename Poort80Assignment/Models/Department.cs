﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poort80Assignment.Models
{
    public class Department : DepartmentSimple
    {
        public List<Employee> employees { get; set; } = new List<Employee>();
    }
}
