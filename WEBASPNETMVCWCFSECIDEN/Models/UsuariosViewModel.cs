using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WEBASPNETMVCWCFSECIDEN.Models
{
    public class UsuariosViewModel
    {
        [Key]
        [ScaffoldColumn(false)]
        [DisplayName("Id")]
        public int UsuId { get; set; }

        [ScaffoldColumn(false)]
        [Display(GroupName = "Usuarios")]
        [DisplayName("Nombre")]
        [Required]
        public string UsuNombre { get; set; }

        [ScaffoldColumn(false)]
        [Display(GroupName = "Usuarios")]
        [DisplayName("Password")]
        [Required]
        public string UsuPassword { get; set; }

        public UsuariosViewModel(int usuarioId, string usuarioNombre, string usuarioPassword)
        {
            UsuId = usuarioId;
            UsuNombre = usuarioNombre;
            UsuPassword = usuarioPassword;
        }
        public UsuariosViewModel()
        {
        }
    }
}