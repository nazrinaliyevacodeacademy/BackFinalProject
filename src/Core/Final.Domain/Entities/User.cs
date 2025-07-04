using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Domain.Entities.Common;
using Final.Domain.Enums;

namespace Final.Domain.Entities;

public class User : BaseEntity
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; } 

    // Навигация к рецептам как пациент и как врач
    public ICollection<Prescription> DoctorPrescriptions { get; set; } = new List<Prescription>();
        public ICollection<Prescription> PatientPrescriptions { get; set; } =new List<Prescription>();
    }



