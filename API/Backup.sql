CREATE TABLE [Courses] (
    [CourseId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Code] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Courses] PRIMARY KEY ([CourseId])
);
GO


CREATE TABLE [Students] (
    [StudentId] nvarchar(450) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Classification] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY ([StudentId])
);
GO


CREATE TABLE [Assignments] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [TotalAvailablePoints] float NOT NULL,
    [DueDate] datetime2 NOT NULL,
    [CourseInfoCourseId] int NULL,
    CONSTRAINT [PK_Assignments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Assignments_Courses_CourseInfoCourseId] FOREIGN KEY ([CourseInfoCourseId]) REFERENCES [Courses] ([CourseId])
);
GO


CREATE TABLE [Modules] (
    [ModuleId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [CourseInfoCourseId] int NULL,
    CONSTRAINT [PK_Modules] PRIMARY KEY ([ModuleId]),
    CONSTRAINT [FK_Modules_Courses_CourseInfoCourseId] FOREIGN KEY ([CourseInfoCourseId]) REFERENCES [Courses] ([CourseId])
);
GO


CREATE TABLE [CourseStudentEnrollment] (
    [CourseInfoCourseId] int NOT NULL,
    [RosterStudentId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_CourseStudentEnrollment] PRIMARY KEY ([CourseInfoCourseId], [RosterStudentId]),
    CONSTRAINT [FK_CourseStudentEnrollment_Courses_CourseInfoCourseId] FOREIGN KEY ([CourseInfoCourseId]) REFERENCES [Courses] ([CourseId]) ON DELETE CASCADE,
    CONSTRAINT [FK_CourseStudentEnrollment_Students_RosterStudentId] FOREIGN KEY ([RosterStudentId]) REFERENCES [Students] ([StudentId]) ON DELETE CASCADE
);
GO


CREATE TABLE [AssignmentSubmissions] (
    [SubmissionId] nvarchar(450) NOT NULL,
    [StudentId] nvarchar(max) NOT NULL,
    [AssignmentId] nvarchar(450) NOT NULL,
    [SubmissionText] nvarchar(max) NOT NULL,
    [SubmissionDate] datetime2 NOT NULL,
    [Grade] float NOT NULL,
    [IsGraded] bit NOT NULL,
    CONSTRAINT [PK_AssignmentSubmissions] PRIMARY KEY ([SubmissionId]),
    CONSTRAINT [FK_AssignmentSubmissions_Assignments_AssignmentId] FOREIGN KEY ([AssignmentId]) REFERENCES [Assignments] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [ContentItems] (
    [ContentItemId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [ModuleId] int NULL,
    CONSTRAINT [PK_ContentItems] PRIMARY KEY ([ContentItemId]),
    CONSTRAINT [FK_ContentItems_Modules_ModuleId] FOREIGN KEY ([ModuleId]) REFERENCES [Modules] ([ModuleId])
);
GO


CREATE INDEX [IX_Assignments_CourseInfoCourseId] ON [Assignments] ([CourseInfoCourseId]);
GO


CREATE INDEX [IX_AssignmentSubmissions_AssignmentId] ON [AssignmentSubmissions] ([AssignmentId]);
GO


CREATE INDEX [IX_ContentItems_ModuleId] ON [ContentItems] ([ModuleId]);
GO


CREATE INDEX [IX_CourseStudentEnrollment_RosterStudentId] ON [CourseStudentEnrollment] ([RosterStudentId]);
GO


CREATE INDEX [IX_Modules_CourseInfoCourseId] ON [Modules] ([CourseInfoCourseId]);
GO


