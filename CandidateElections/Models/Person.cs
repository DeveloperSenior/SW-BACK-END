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
		[Column("cdtipo_documento")]
		public string CdTipoDocumento { get; set; }
		[Column("feexpedicion_documento")]
		public DateTime FeExpedicionDocumento { get; set; }
		[Column("cdciudad_expedicion_docto")]
		public string CdCiudadExpedicionDocto { get; set; }
		[Column("dsnombre_completo")]
		public string DsNombreCompleto { get; set; }
		[Column("dsnombre1")]
		public string DsNombre1 { get; set; }
		[Column("dsnombre2")]
		public string DsNombre2 { get; set; }
		[Column("dsapellido1")]
		public string DsApellido1 { get; set; }
		[Column("dsapellido2")]
		public string DsApellido2 { get; set; }
		[Column("dstelefono")]
		public string DsTelefono { get; set; }
		[Column("dscelular")]
		public string DsCelular { get; set; }
		[Column("dsdireccion")]
		public string DsDireccion { get; set; }
		[Column("dsemail")]
		public string DsEmail { get; set; }
		[Column("fenacimiento")]
		public DateTime FeNacimiento { get; set; }
		[Column("sntratamiento_datos")]
		public string SnTratamientoDatos { get; set; }
		[Column("sncomunicados_email")]
		public string SnComunicadosEmail { get; set; }
		[Column("sncomunicados_textos")]
		public string SnComunicadosTextos { get; set; }


	}
}
