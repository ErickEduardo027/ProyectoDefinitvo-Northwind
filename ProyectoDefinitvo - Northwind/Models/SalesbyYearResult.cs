﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoDefinitvo___Northwind.Models
{
    public partial class SalesbyYearResult
    {
        public DateTime? ShippedDate { get; set; }
        public int OrderID { get; set; }
        public decimal? Subtotal { get; set; }
        public string Year { get; set; }
    }
}
