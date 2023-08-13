
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/10/2023 01:35:27
-- Generated from EDMX file: C:\Users\Huang\source\repos\WebDesign\WebDesign\Models\EntityModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-WebDesign-20230810120634];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PatientSet'
CREATE TABLE [dbo].[PatientSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [UserID] nvarchar(max)  NOT NULL,
    [Age] int  NOT NULL
);
GO

-- Creating table 'DoctorSet'
CREATE TABLE [dbo].[DoctorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [UserID] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AppointmentSet'
CREATE TABLE [dbo].[AppointmentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateTime] datetime  NOT NULL,
    [Time] nvarchar(max)  NOT NULL,
    [PatientId] int  NOT NULL,
    [DoctorId] int  NOT NULL
);
GO

-- Creating table 'RateSet'
CREATE TABLE [dbo].[RateSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RateStar] int  NOT NULL,
    [DoctorID] nvarchar(max)  NOT NULL,
    [Appointment_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PatientSet'
ALTER TABLE [dbo].[PatientSet]
ADD CONSTRAINT [PK_PatientSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DoctorSet'
ALTER TABLE [dbo].[DoctorSet]
ADD CONSTRAINT [PK_DoctorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AppointmentSet'
ALTER TABLE [dbo].[AppointmentSet]
ADD CONSTRAINT [PK_AppointmentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RateSet'
ALTER TABLE [dbo].[RateSet]
ADD CONSTRAINT [PK_RateSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PatientId] in table 'AppointmentSet'
ALTER TABLE [dbo].[AppointmentSet]
ADD CONSTRAINT [FK_AppointmentPatient]
    FOREIGN KEY ([PatientId])
    REFERENCES [dbo].[PatientSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AppointmentPatient'
CREATE INDEX [IX_FK_AppointmentPatient]
ON [dbo].[AppointmentSet]
    ([PatientId]);
GO

-- Creating foreign key on [DoctorId] in table 'AppointmentSet'
ALTER TABLE [dbo].[AppointmentSet]
ADD CONSTRAINT [FK_AppointmentDoctor]
    FOREIGN KEY ([DoctorId])
    REFERENCES [dbo].[DoctorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AppointmentDoctor'
CREATE INDEX [IX_FK_AppointmentDoctor]
ON [dbo].[AppointmentSet]
    ([DoctorId]);
GO

-- Creating foreign key on [Appointment_Id] in table 'RateSet'
ALTER TABLE [dbo].[RateSet]
ADD CONSTRAINT [FK_RateAppointment]
    FOREIGN KEY ([Appointment_Id])
    REFERENCES [dbo].[AppointmentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RateAppointment'
CREATE INDEX [IX_FK_RateAppointment]
ON [dbo].[RateSet]
    ([Appointment_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------