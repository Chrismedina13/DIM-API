/*
 * ER/Studio Data Architect SQL Code Generation
 * Project :      Model1.DM1
 *
 * Date Created : Saturday, September 11, 2021 17:07:17
 * Target DBMS : Microsoft SQL Server 2016
 */

/* 
 * TABLE: Campania 
 */

CREATE TABLE Campania(
    CampaniaID          bigint           NOT NULL,
    CuposDisponibles    numeric(3, 0)    NOT NULL,
    Descripcion         varchar(250)     NOT NULL,
    Tipo                smallint         NOT NULL,
    Nombre              varchar(50)      NOT NULL,
    Contacto            varchar(100)     NULL,
    UsuarioID           int              NOT NULL,
    CONSTRAINT PK6 PRIMARY KEY NONCLUSTERED (CampaniaID)
)
go



IF OBJECT_ID('Campania') IS NOT NULL
    PRINT '<<< CREATED TABLE Campania >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Campania >>>'
go

/* 
 * TABLE: CampaniaMascota 
 */

CREATE TABLE CampaniaMascota(
    CampaniaID    bigint    NOT NULL,
    MascotaID     bigint    NOT NULL,
    CONSTRAINT PK12 PRIMARY KEY NONCLUSTERED (CampaniaID, MascotaID)
)
go



IF OBJECT_ID('CampaniaMascota') IS NOT NULL
    PRINT '<<< CREATED TABLE CampaniaMascota >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE CampaniaMascota >>>'
go

/* 
 * TABLE: CampaniaRaza 
 */

CREATE TABLE CampaniaRaza(
    CampaniaID    bigint         NOT NULL,
    RazaID        varchar(30)    NOT NULL,
    CONSTRAINT PK8 PRIMARY KEY NONCLUSTERED (CampaniaID, RazaID)
)
go



IF OBJECT_ID('CampaniaRaza') IS NOT NULL
    PRINT '<<< CREATED TABLE CampaniaRaza >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE CampaniaRaza >>>'
go

/* 
 * TABLE: Direccion 
 */

CREATE TABLE Direccion(
    DireccionID     bigint           NOT NULL,
    Calle           varchar(30)      NOT NULL,
    Numero          numeric(8, 0)    NOT NULL,
    Piso            numeric(3, 0)    NULL,
    Departamento    varchar(1)       NULL,
    Localidad       varchar(50)      NOT NULL,
    Provincia       varchar(30)      NOT NULL,
    CampaniaID      bigint           NULL,
    UsuarioID       int              NULL,
    MascotaID       bigint           NULL,
    CONSTRAINT PK18 PRIMARY KEY NONCLUSTERED (DireccionID)
)
go



IF OBJECT_ID('Direccion') IS NOT NULL
    PRINT '<<< CREATED TABLE Direccion >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Direccion >>>'
go

/* 
 * TABLE: Especie 
 */

CREATE TABLE Especie(
    EspecieID      varchar(30)     NOT NULL,
    Nombre         varchar(50)     NOT NULL,
    Descripcion    varchar(100)    NULL,
    CONSTRAINT PK10 PRIMARY KEY NONCLUSTERED (EspecieID)
)
go



IF OBJECT_ID('Especie') IS NOT NULL
    PRINT '<<< CREATED TABLE Especie >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Especie >>>'
go

/* 
 * TABLE: Fallecimiento 
 */

CREATE TABLE Fallecimiento(
    MascotaID                             bigint          NOT NULL,
    Modo                                  smallint        NULL,
    Certificado                           varchar(max)    NULL,
    Lugar                                 varchar(100)    NULL,
    EspecificacionRiesgoEpidemiologico    varchar(100)    NULL,
    Fecha                                 datetime        NOT NULL,
    Causa                                 varchar(150)    NOT NULL,
    RiesgoEpidemiologico                  tinyint         NOT NULL,
    RenglonVisita                         int             NULL,
    CONSTRAINT PK9 PRIMARY KEY NONCLUSTERED (MascotaID)
)
go



IF OBJECT_ID('Fallecimiento') IS NOT NULL
    PRINT '<<< CREATED TABLE Fallecimiento >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Fallecimiento >>>'
go

/* 
 * TABLE: Mascota 
 */

CREATE TABLE Mascota(
    MascotaID                     bigint          NOT NULL,
    ImagenChapita                 varchar(max)    NULL,
    Peso                          int             NULL,
    Imagen                        varchar(max)    NULL,
    FechaDeNacimiento             datetime        NULL,
    FechaValidacion               datetime        NULL,
    NroIdentificadorCriadero      varchar(30)     NULL,
    CodigoDeChip                  varchar(30)     NULL,
    DIeta                         varchar(250)    NULL,
    OtrosMedicamentos             varchar(100)    NULL,
    Pelaje                        varchar(30)     NULL,
    Sexo                          smallint        NOT NULL,
    CondicionDeSalud              smallint        NOT NULL,
    OtrosDatosDeSalud             varchar(250)    NULL,
    Tamanio                       smallint        NOT NULL,
    CertificadoAntirrabica        varchar(max)    NULL,
    SeguroResponsabilidadCivil    varchar(max)    NULL,
    Nombre                        varchar(50)     NOT NULL,
    UsuarioID                     int             NOT NULL,
    RazaID                        varchar(30)     NOT NULL,
    CONSTRAINT PK3 PRIMARY KEY NONCLUSTERED (MascotaID)
)
go



IF OBJECT_ID('Mascota') IS NOT NULL
    PRINT '<<< CREATED TABLE Mascota >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Mascota >>>'
go

/* 
 * TABLE: Medicamento 
 */

CREATE TABLE Medicamento(
    MedicamentoID    varchar(50)     NOT NULL,
    Descripcion      varchar(200)    NOT NULL,
    Utilizable       tinyint         NOT NULL,
    CONSTRAINT PK5 PRIMARY KEY NONCLUSTERED (MedicamentoID)
)
go



IF OBJECT_ID('Medicamento') IS NOT NULL
    PRINT '<<< CREATED TABLE Medicamento >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Medicamento >>>'
go

/* 
 * TABLE: MedicamentosMascotas 
 */

CREATE TABLE MedicamentosMascotas(
    MascotaID        bigint            NOT NULL,
    MedicamentID     varchar(50)       NOT NULL,
    Dosis            decimal(10, 4)    NOT NULL,
    Frecuencia       time(7)           NOT NULL,
    RenglonVisita    int               NULL,
    CONSTRAINT PK19 PRIMARY KEY NONCLUSTERED (MascotaID, MedicamentID)
)
go



IF OBJECT_ID('MedicamentosMascotas') IS NOT NULL
    PRINT '<<< CREATED TABLE MedicamentosMascotas >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE MedicamentosMascotas >>>'
go

/* 
 * TABLE: Raza 
 */

CREATE TABLE Raza(
    RazaID             varchar(30)     NOT NULL,
    Descripcion        varchar(100)    NULL,
    EsRazaPeligrosa    tinyint         NULL,
    EspecieID          varchar(30)     NOT NULL,
    CONSTRAINT PK4 PRIMARY KEY NONCLUSTERED (RazaID)
)
go



IF OBJECT_ID('Raza') IS NOT NULL
    PRINT '<<< CREATED TABLE Raza >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Raza >>>'
go

/* 
 * TABLE: TipoVacuna 
 */

CREATE TABLE TipoVacuna(
    VacunaID       int             NOT NULL,
    Nombre         varchar(50)     NOT NULL,
    Descripcion    varchar(100)    NULL,
    CONSTRAINT PK20 PRIMARY KEY NONCLUSTERED (VacunaID)
)
go



IF OBJECT_ID('TipoVacuna') IS NOT NULL
    PRINT '<<< CREATED TABLE TipoVacuna >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE TipoVacuna >>>'
go

/* 
 * TABLE: TipoVisita 
 */

CREATE TABLE TipoVisita(
    TipoID         varchar(10)     NOT NULL,
    Nombre         varchar(25)     NOT NULL,
    Descripcion    varchar(100)    NOT NULL,
    CONSTRAINT PK16 PRIMARY KEY NONCLUSTERED (TipoID)
)
go



IF OBJECT_ID('TipoVisita') IS NOT NULL
    PRINT '<<< CREATED TABLE TipoVisita >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE TipoVisita >>>'
go

/* 
 * TABLE: Usuarios 
 */

CREATE TABLE Usuarios(
    UsuarioID                int               NOT NULL,
    Apellido                 varchar(50)       NOT NULL,
    FechaConfirmacionAlta    datetime          NULL,
    Nombre                   varchar(50)       NOT NULL,
    TipoUsuario              varchar(3)        NOT NULL,
    Telefono                 varchar(20)       NOT NULL,
    ImagenDNI                varchar(max)      NULL,
    FechaAlta                datetime          NOT NULL,
    Password                 varchar(100)      NOT NULL,
    Email                    varchar(50)       NOT NULL,
    TipoDocumento            smallint          NOT NULL,
    NumeroDocumento          decimal(13, 0)    NOT NULL,
    CodigoVerificacion       varchar(6)        NOT NULL,
    CONSTRAINT PK1 PRIMARY KEY NONCLUSTERED (UsuarioID)
)
go



IF OBJECT_ID('Usuarios') IS NOT NULL
    PRINT '<<< CREATED TABLE Usuarios >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Usuarios >>>'
go

/* 
 * TABLE: Vacunacion 
 */

CREATE TABLE Vacunacion(
    MascotaID            bigint         NOT NULL,
    RenglonVacuna        int            NOT NULL,
    FechaRevacunacion    datetime       NULL,
    FechaAplicacion      datetime       NOT NULL,
    CodigoSENASA         varchar(50)    NOT NULL,
    Lote                 varchar(20)    NULL,
    Serie                varchar(50)    NULL,
    Dosis                varchar(50)    NULL,
    VacunaID             int            NOT NULL,
    RenglonVisita        int            NULL,
    CONSTRAINT PK17 PRIMARY KEY NONCLUSTERED (MascotaID, RenglonVacuna)
)
go



IF OBJECT_ID('Vacunacion') IS NOT NULL
    PRINT '<<< CREATED TABLE Vacunacion >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Vacunacion >>>'
go

/* 
 * TABLE: Veterinario 
 */

CREATE TABLE Veterinario(
    VeterinarioID                 int               NOT NULL,
    NumeroMatricula               decimal(10, 0)    NOT NULL,
    FechaVerificacionMatricula    datetime          NULL,
    CONSTRAINT PK2 PRIMARY KEY NONCLUSTERED (VeterinarioID)
)
go



IF OBJECT_ID('Veterinario') IS NOT NULL
    PRINT '<<< CREATED TABLE Veterinario >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Veterinario >>>'
go

/* 
 * TABLE: VeterinarioMascota 
 */

CREATE TABLE VeterinarioMascota(
    MascotaID        bigint          NOT NULL,
    RenglonVisita    int             NOT NULL,
    FechaConsulta    datetime        NOT NULL,
    Descripcion      varchar(200)    NULL,
    Peso             int             NULL,
    ReportoENO       tinyint         NOT NULL,
    TipoID           varchar(10)     NOT NULL,
    VeterinarioID    int             NOT NULL,
    CONSTRAINT PK14 PRIMARY KEY NONCLUSTERED (MascotaID, RenglonVisita)
)
go



IF OBJECT_ID('VeterinarioMascota') IS NOT NULL
    PRINT '<<< CREATED TABLE VeterinarioMascota >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE VeterinarioMascota >>>'
go

/* 
 * TABLE: Campania 
 */

ALTER TABLE Campania ADD CONSTRAINT RefUsuarios11 
    FOREIGN KEY (UsuarioID)
    REFERENCES Usuarios(UsuarioID)
go


/* 
 * TABLE: CampaniaMascota 
 */

ALTER TABLE CampaniaMascota ADD CONSTRAINT RefCampania28 
    FOREIGN KEY (CampaniaID)
    REFERENCES Campania(CampaniaID)
go

ALTER TABLE CampaniaMascota ADD CONSTRAINT RefMascota29 
    FOREIGN KEY (MascotaID)
    REFERENCES Mascota(MascotaID)
go


/* 
 * TABLE: CampaniaRaza 
 */

ALTER TABLE CampaniaRaza ADD CONSTRAINT RefCampania12 
    FOREIGN KEY (CampaniaID)
    REFERENCES Campania(CampaniaID)
go

ALTER TABLE CampaniaRaza ADD CONSTRAINT RefRaza51 
    FOREIGN KEY (RazaID)
    REFERENCES Raza(RazaID)
go


/* 
 * TABLE: Direccion 
 */

ALTER TABLE Direccion ADD CONSTRAINT RefCampania37 
    FOREIGN KEY (CampaniaID)
    REFERENCES Campania(CampaniaID)
go

ALTER TABLE Direccion ADD CONSTRAINT RefUsuarios38 
    FOREIGN KEY (UsuarioID)
    REFERENCES Usuarios(UsuarioID)
go

ALTER TABLE Direccion ADD CONSTRAINT RefMascota42 
    FOREIGN KEY (MascotaID)
    REFERENCES Mascota(MascotaID)
go


/* 
 * TABLE: Fallecimiento 
 */

ALTER TABLE Fallecimiento ADD CONSTRAINT RefMascota14 
    FOREIGN KEY (MascotaID)
    REFERENCES Mascota(MascotaID)
go

ALTER TABLE Fallecimiento ADD CONSTRAINT RefVeterinarioMascota45 
    FOREIGN KEY (MascotaID, RenglonVisita)
    REFERENCES VeterinarioMascota(MascotaID, RenglonVisita)
go


/* 
 * TABLE: Mascota 
 */

ALTER TABLE Mascota ADD CONSTRAINT RefUsuarios10 
    FOREIGN KEY (UsuarioID)
    REFERENCES Usuarios(UsuarioID)
go

ALTER TABLE Mascota ADD CONSTRAINT RefRaza50 
    FOREIGN KEY (RazaID)
    REFERENCES Raza(RazaID)
go


/* 
 * TABLE: MedicamentosMascotas 
 */

ALTER TABLE MedicamentosMascotas ADD CONSTRAINT RefMascota23 
    FOREIGN KEY (MascotaID)
    REFERENCES Mascota(MascotaID)
go

ALTER TABLE MedicamentosMascotas ADD CONSTRAINT RefMedicamento24 
    FOREIGN KEY (MedicamentID)
    REFERENCES Medicamento(MedicamentoID)
go

ALTER TABLE MedicamentosMascotas ADD CONSTRAINT RefVeterinarioMascota46 
    FOREIGN KEY (MascotaID, RenglonVisita)
    REFERENCES VeterinarioMascota(MascotaID, RenglonVisita)
go


/* 
 * TABLE: Raza 
 */

ALTER TABLE Raza ADD CONSTRAINT RefEspecie49 
    FOREIGN KEY (EspecieID)
    REFERENCES Especie(EspecieID)
go


/* 
 * TABLE: Vacunacion 
 */

ALTER TABLE Vacunacion ADD CONSTRAINT RefMascota21 
    FOREIGN KEY (MascotaID)
    REFERENCES Mascota(MascotaID)
go

ALTER TABLE Vacunacion ADD CONSTRAINT RefTipoVacuna41 
    FOREIGN KEY (VacunaID)
    REFERENCES TipoVacuna(VacunaID)
go

ALTER TABLE Vacunacion ADD CONSTRAINT RefVeterinarioMascota47 
    FOREIGN KEY (MascotaID, RenglonVisita)
    REFERENCES VeterinarioMascota(MascotaID, RenglonVisita)
go


/* 
 * TABLE: Veterinario 
 */

ALTER TABLE Veterinario ADD CONSTRAINT RefUsuarios1 
    FOREIGN KEY (VeterinarioID)
    REFERENCES Usuarios(UsuarioID)
go


/* 
 * TABLE: VeterinarioMascota 
 */

ALTER TABLE VeterinarioMascota ADD CONSTRAINT RefMascota20 
    FOREIGN KEY (MascotaID)
    REFERENCES Mascota(MascotaID)
go

ALTER TABLE VeterinarioMascota ADD CONSTRAINT RefTipoVisita27 
    FOREIGN KEY (TipoID)
    REFERENCES TipoVisita(TipoID)
go

ALTER TABLE VeterinarioMascota ADD CONSTRAINT RefVeterinario39 
    FOREIGN KEY (VeterinarioID)
    REFERENCES Veterinario(VeterinarioID)
go


