drop table candidatos;
create table candidatos(
  	id serial,
   	cdcandidato character varying(50) NOT NULL,
	cdcampana character varying(15),
	cddocumento character varying(15),
	ptpresupuesto numeric(20,2),
  	dspath_foto character varying(30) NOT NULL,
	fecreacion date default current_timestamp,
	febaja date,
	CONSTRAINT candidatos_pk PRIMARY KEY (id)
);

drop table votantes;
create table votantes (
	id serial,
	cddocumento character varying(15),
	cdcampana character varying(15),
	cdmesa_asignada character varying(15),
	sn_voto character varying(1) default 'N',
	fecreacion date DEFAULT CURRENT_TIMESTAMP NOT NULL,
	febaja date,
	CONSTRAINT votantes_pk PRIMARY KEY (id)
);
drop table mesas;
create table mesas(
	id serial,
	cdmesa character varying(15),
	cdciudad character varying(3),
	fecreacion date DEFAULT CURRENT_TIMESTAMP NOT NULL,
	febaja date,
	CONSTRAINT mesa_pk PRIMARY KEY (id)
);

drop table personas;
create table personas (
    cddocumento character varying(15) NOT NULL,
	cdtipo_documento character varying(2) NOT NULL,
	feexpedicion_documento date NOT NULL,
	cdciudad_expedicion_docto character varying(3) NOT NULL,
  	dsnombre_completo character varying(100) NOT NULL,
	dsnombre1 character varying(100) NOT NULL,
	dsnombre2 character varying(60) ,
	dsapellido1 character varying(60) NOT NULL,
	dsapellido2 character varying(60),
	dstelefono character varying(15),
	dscelular character varying(15),
	dsdireccion character varying(60),
	dsemail character varying(60),
	fenacimiento date,
	sntratamiento_datos character varying(1),
	sncomunicados_email character varying(1),
	sncomunicados_textos character varying(1),
	fecreacion date DEFAULT CURRENT_TIMESTAMP NOT NULL,
	febaja date,
	CONSTRAINT personas_pk PRIMARY KEY (cddocumento)
);

drop table electos;
create table electos(
  	id serial,
   	cdcandidato character varying(50) NOT NULL,
	cdcampana character varying(15) NOT NULL,
	cddocumento character varying(15) NOT NULL,
  	feperiodo_inicio date NOT NULL,
	feperiodo_fin date NOT NULL,
	nmvotos numeric,
	fecreacion date default current_timestamp,
	febaja date,
	CONSTRAINT electos_pk PRIMARY KEY (id)
);

drop table campanas;
create table campanas(
  	id serial,
	cdcampana character varying(15) NOT NULL,
	dscampana character varying(60) NOT NULL,
	fecreacion date default current_timestamp,
	febaja date,
	CONSTRAINT campanas_pk PRIMARY KEY (id)
);

drop table votos_candidatos;
create table votos_candidatos(
  	id serial,
	cdcampana character varying(15) NOT NULL,
	cdcandidato character varying(15) NOT NULL,
	cddocumento_votante character varying(15),
	fecreacion date default current_timestamp,
	CONSTRAINT votos_candidatos_pk PRIMARY KEY (id),
	constraint chk_votante_camp_cand_UK UNIQUE (cdcampana,cdcandidato,cddocumento_votante)
);