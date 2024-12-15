namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STUDENT")]
    public partial class STUDENT
    {
        [StringLength(50)]
        public string StudentID { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        public double AverageScore { get; set; }

        public int FacultyID { get; set; }

        public virtual FACULTY FACULTY { get; set; }
    }
}
