--------------------------------------------------------
--  DDL for Table AUTOR
--------------------------------------------------------

  CREATE TABLE "NEXOS"."AUTOR" 
   (	"IDAUTOR" NUMBER, 
	"NOMBRE" VARCHAR2(100 BYTE), 
	"FECHANACI" VARCHAR2(10 BYTE), 
	"CIUDAD" VARCHAR2(100 BYTE), 
	"CORREO" VARCHAR2(100 BYTE)
   );
   ALTER TABLE "NEXOS"."AUTOR" ADD CONSTRAINT "AUTOR_PK" PRIMARY KEY ("IDAUTOR");
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table LIBRO
--------------------------------------------------------

  CREATE TABLE "NEXOS"."LIBRO" 
   (	"IDLIBRO" NUMBER, 
	"TITULO" VARCHAR2(100 BYTE), 
	"ANO" NUMBER(4,0), 
	"GENERO" VARCHAR2(20 BYTE), 
	"NUMPAG" NUMBER, 
	"AUTOR" VARCHAR2(50 BYTE)
   ); 
     ALTER TABLE "NEXOS"."LIBRO" ADD CONSTRAINT "LIBRO_PK" PRIMARY KEY ("IDLIBRO");
