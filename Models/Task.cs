using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    public class Task
    {
        public string Title { get; set; }
        public string Status { get; set; } 
        public string Type { get; set; } 
        public string Category { get; set; } 
        public string BackgroundColor { get; set; } 
        public DateTime DateAssigned { get; set; }
        public DateTime DueDate { get; set; }
        public string Notes { get; set; }
    }
}