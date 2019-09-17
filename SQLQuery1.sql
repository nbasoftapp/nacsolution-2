CREATE TABLE [dbo].[Answers](
	[AnswerID] [int] IDENTITY(1,1) NOT NULL,
	[AnswerText] [varchar](max) NULL,
	[QuestionID] [int] NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[AnswerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Choices]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Choices](
	[ChoiceID] [int] IDENTITY(1,1) NOT NULL,
	[ChoiceText] [varchar](max) NULL,
	[QuestionID] [int] NULL,
 CONSTRAINT [PK_Choices] PRIMARY KEY CLUSTERED 
(
	[ChoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_ADMIN]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_ADMIN](
	[ADMIN_ID] [int] IDENTITY(1,1) NOT NULL,
	[Fname] [varchar](50) NOT NULL,
	[Lname] [varchar](50) NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[EmailID] [nvarchar](254) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[IsEmailVerified] [int] NOT NULL,
	[VerificationCode] [uniqueidentifier] NOT NULL,
	[ROLE_ID] [int] NOT NULL,
	[SYSUSER_ID] [int] NULL,
 CONSTRAINT [PK_NBA_ADMIN] PRIMARY KEY CLUSTERED 
(
	[ADMIN_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_Agwy]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_Agwy](
	[AGWY_ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[surname] [varchar](45) NULL,
	[known_as] [varchar](50) NULL,
	[gender] [int] NULL,
	[age] [varchar](20) NULL,
	[type_of_identification] [int] NULL,
	[idno] [varchar](20) NULL,
	[dateOfbirth] [datetime] NULL,
	[maiden_name] [varchar](50) NULL,
	[house_number] [varchar](20) NULL,
	[street_name] [varchar](50) NULL,
	[town_village_address] [varchar](50) NULL,
	[town_village] [varchar](20) NULL,
	[uic] [varchar](50) NULL,
	[email] [varchar](45) NULL,
	[phone_number] [int] NULL,
	[alternative_number] [int] NULL,
	[alternative_number_relationship] [varchar](50) NULL,
	[attended_school] [nchar](10) NULL,
	[name_of_school] [varchar](50) NULL,
	[grade] [varchar](50) NULL,
	[higest_grade_passed] [int] NULL,
	[currrent_occupation] [varchar](50) NULL,
	[approval_flag] [varchar](1) NULL,
	[concent_flag] [varchar](1) NULL,
	[mimetype] [varbinary](max) NULL,
	[imagedata] [varbinary](max) NULL,
	[describe_living] [varchar](100) NULL,
	[reg_date] [datetime] NULL,
	[last_updated] [datetime] NULL,
	[last_login] [datetime] NULL,
	[status] [varchar](50) NULL,
	[ID] [int] NULL,
	[SEMESTER_ID] [int] NULL,
	[SYS_USER_ID] [int] NULL,
	[DOCUMENT_ID] [int] NULL,
	[Core_ID] [int] NULL,
	[messageInquiry] [int] NULL,
	[EntryPoint_ID] [int] NULL,
	[HighSchoolQuizz_ID] [int] NULL,
	[RISK_ID] [int] NULL,
 CONSTRAINT [PK_NBA_Agwy] PRIMARY KEY CLUSTERED 
(
	[AGWY_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_Audit_trail]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_Audit_trail](
	[CHANGE_ID] [int] IDENTITY(1,1) NOT NULL,
	[tablename] [varchar](20) NULL,
	[fieldname] [varchar](20) NULL,
	[record_id] [int] NULL,
	[oldvalue] [varchar](100) NULL,
	[newvalue] [varchar](100) NULL,
	[changedate] [datetime] NULL,
	[changeby] [varchar](20) NULL,
	[SYS_USER_ID] [int] NULL,
 CONSTRAINT [PK_NBA_Audit_trail] PRIMARY KEY CLUSTERED 
(
	[CHANGE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_Core]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_Core](
	[CORE_ID] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](150) NULL,
	[TB_assess] [varchar](50) NULL,
	[HIV_assess] [varchar](50) NULL,
	[Condom_educate] [varchar](50) NULL,
	[STI_assess] [varchar](50) NULL,
	[RISK_ID] [int] NULL,
	[AGWY_ID] [int] NULL,
 CONSTRAINT [PK_NBA_Core] PRIMARY KEY CLUSTERED 
(
	[CORE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_Documents]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_Documents](
	[DOCUMENT_ID] [int] IDENTITY(1,1) NOT NULL,
	[doc_name] [varchar](150) NULL,
	[description] [varchar](500) NULL,
	[classification] [varchar](150) NULL,
	[doc_date] [datetime] NULL,
	[status] [varchar](150) NULL,
 CONSTRAINT [PK_NBA_Documents] PRIMARY KEY CLUSTERED 
(
	[DOCUMENT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_Entry_Points]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_Entry_Points](
	[ENTRY_ID] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](50) NULL,
	[x_cordinates] [varchar](100) NULL,
	[y_cordinates] [varchar](100) NULL,
	[ID] [int] NULL,
 CONSTRAINT [PK_NBA_Entry_Points] PRIMARY KEY CLUSTERED 
(
	[ENTRY_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_Gender]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_Gender](
	[GenderID] [int] NOT NULL,
	[GenderType] [varchar](50) NULL,
 CONSTRAINT [PK_NBA_Gender] PRIMARY KEY CLUSTERED 
(
	[GenderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_Grade]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_Grade](
	[Grade_ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NULL,
 CONSTRAINT [PK_Grade] PRIMARY KEY CLUSTERED 
(
	[Grade_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_HighSchoolQuizz]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_HighSchoolQuizz](
	[HighSchoolQuiz_ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_HighSchoolQuizz] PRIMARY KEY CLUSTERED 
(
	[HighSchoolQuiz_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_Identification]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_Identification](
	[Identification_ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_NBA_Identification] PRIMARY KEY CLUSTERED 
(
	[Identification_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_MessageID]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_MessageID](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nchar](10) NULL,
 CONSTRAINT [PK_MessageID] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_Occupation]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_Occupation](
	[Occupation_ID] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_NBA_Occupation] PRIMARY KEY CLUSTERED 
(
	[Occupation_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_Period_Maintenance]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_Period_Maintenance](
	[Period_ID] [int] IDENTITY(1,1) NOT NULL,
	[period_name] [varchar](50) NULL,
	[period_start_date] [datetime] NULL,
	[period_end_date] [datetime] NULL,
	[status] [varchar](50) NULL,
	[SERVICEPLAN_ID] [int] NOT NULL,
 CONSTRAINT [PK_NBA_period_Maintenance] PRIMARY KEY CLUSTERED 
(
	[Period_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_PR]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_PR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PR_SR_ID] [varchar](50) NULL,
	[PR_name] [varchar](50) NULL,
	[SR_name] [varchar](50) NULL,
	[province] [varchar](50) NULL,
	[district] [varchar](50) NULL,
	[subdistrict] [varchar](50) NULL,
	[date_entered] [datetime] NULL,
 CONSTRAINT [PK_NBA_PR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_RiskAssessment]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_RiskAssessment](
	[RISK_ID] [int] IDENTITY(1,1) NOT NULL,
	[QUESTION_ID] [int] NULL,
	[ANSWER_ID] [int] NULL,
	[risk_description] [varchar](500) NULL,
	[classification] [varchar](500) NULL,
	[SERVICE_PLAN_ID] [int] NULL,
	[SYS_USER_ID] [int] NULL,
	[SELF_ASSESS_ID] [int] NULL,
 CONSTRAINT [PK_NBA_RiskAssessment] PRIMARY KEY CLUSTERED 
(
	[RISK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_Role]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_Role](
	[ROLE_ID] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [varchar](20) NULL,
	[role_created_date] [date] NOT NULL,
 CONSTRAINT [PK_NBA_Role] PRIMARY KEY CLUSTERED 
(
	[ROLE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_SemesterMaintenance]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_SemesterMaintenance](
	[SEMESTER_ID] [int] IDENTITY(1,1) NOT NULL,
	[semester_name] [varchar](150) NULL,
	[uid] [varchar](50) NULL,
	[semester_start_date] [datetime] NULL,
	[semester_end_date] [datetime] NULL,
	[status] [varchar](150) NULL,
	[SERVICEPLAN_ID] [int] NULL,
 CONSTRAINT [PK_NBA_SemesterMaintenance] PRIMARY KEY CLUSTERED 
(
	[SEMESTER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_ServicePlan]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_ServicePlan](
	[SERVICEPLAN_ID] [int] IDENTITY(1,1) NOT NULL,
	[service_plan_description] [varchar](500) NULL,
	[DOCUMENT_ID] [int] NULL,
	[AGWY_ID] [int] NULL,
	[TASK_ID] [int] NULL,
	[SYS_USERS_ID] [int] NULL,
	[SEMESTER_ID] [int] NULL,
	[RISK_ID] [int] NULL,
	[CORE_ID] [int] NULL,
 CONSTRAINT [PK_NBA_ServicePlan] PRIMARY KEY CLUSTERED 
(
	[SERVICEPLAN_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_ServicePlanIntervention]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_ServicePlanIntervention](
	[INTERVENTION_ID] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](150) NULL,
	[service_ui] [varchar](50) NULL,
	[service_delivery_date] [datetime] NULL,
	[semester_end_date] [datetime] NULL,
	[status] [varchar](150) NULL,
	[SEMESTER_ID] [int] NULL,
	[SYS_USER_ID] [int] NULL,
 CONSTRAINT [PK_NBA_ServicePlanIntervention] PRIMARY KEY CLUSTERED 
(
	[INTERVENTION_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_Status]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_Status](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusValue] [varchar](max) NULL,
 CONSTRAINT [PK_NBA_Status] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_SYS_Users]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_SYS_Users](
	[SYS_USER_ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[surname] [varchar](50) NULL,
	[username] [varchar](45) NULL,
	[password] [nvarchar](245) NULL,
	[mobile] [int] NULL,
	[employee_id] [varchar](50) NULL,
	[organization] [varchar](45) NULL,
	[province] [varchar](50) NULL,
	[district] [varchar](50) NULL,
	[subdistrict] [varchar](50) NULL,
	[image] [varchar](50) NULL,
	[SR_name] [varchar](50) NULL,
	[Entry_ID] [int] NULL,
	[email] [varchar](50) NULL,
	[sys_IsEmailVerified] [bit] NULL,
	[sys_VerificationCode] [uniqueidentifier] NULL,
	[reg_date] [datetime] NULL,
	[last_updated] [datetime] NULL,
	[last_login] [datetime] NULL,
	[ROLE_ID] [int] NULL,
	[ID] [int] NULL,
 CONSTRAINT [PK_NBA_SYS_Users] PRIMARY KEY CLUSTERED 
(
	[SYS_USER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NBA_TaskDiary]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBA_TaskDiary](
	[TASK_ID] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](150) NULL,
	[datetime_scheduled] [datetime] NULL,
	[appointment_length] [varchar](150) NULL,
	[status] [varchar](150) NULL,
	[SYS_USER_ID] [int] NULL,
 CONSTRAINT [PK_NBA_TaskDiary] PRIMARY KEY CLUSTERED 
(
	[TASK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[QuestionID] [int] IDENTITY(1,1) NOT NULL,
	[QuestionText] [varchar](max) NULL,
	[QuizID] [int] NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[QuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quiz]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz](
	[QuizID] [int] IDENTITY(1,1) NOT NULL,
	[QuizName] [varchar](80) NULL,
 CONSTRAINT [PK_Quiz] PRIMARY KEY CLUSTERED 
(
	[QuizID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/9/2019 6:19:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](50) NULL,
	[ProfilImage] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO