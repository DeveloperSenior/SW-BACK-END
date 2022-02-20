using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace CandidateElections.Models
{
	[Table("personas")]
	public class Person
    {
        public Person()
        {
        }
		[Column("cddocumento")]
		public string Id { get; set; }
		public string CdtipoDocumento { get; set; }
        public DateTime FeexpedicionDocumento { get; set; }
		public string CdciudadExpedicionDocto { get; set; }
		public string Cdciudad_expedicion_docto { get; set; }
		public string DsnombreCompleto { get; set; }
		public string Dsnombre1 { get; set; }
		public string Dsnombre2 { get; set; }
		public string Dsapellido1 { get; set; }
		public string Dsapellido2 { get; set; }
		public string Dstelefono { get; set; }
		public string Dscelular { get; set; }
		public string Dsdireccion { get; set; }
		public string Dsemail { get; set; }
		public DateTime Fenacimiento { get; set; }
		public string SntratamientoDatos { get; set; }
		public string SncomunicadosEmail { get; set; }
		public string SncomunicadosTextos { get; set; }


	}
}
