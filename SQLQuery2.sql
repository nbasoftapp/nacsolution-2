ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Answers] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Questions] ([QuestionID])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Answers]
GO
ALTER TABLE [dbo].[Choices]  WITH CHECK ADD  CONSTRAINT [FK_Choices_Questions] FOREIGN KEY([ChoiceID])
REFERENCES [dbo].[Questions] ([QuestionID])
GO
ALTER TABLE [dbo].[Choices] CHECK CONSTRAINT [FK_Choices_Questions]
GO
ALTER TABLE [dbo].[NBA_Agwy]  WITH CHECK ADD  CONSTRAINT [FK_NBA_Agwy_NBA_Agwy] FOREIGN KEY([messageInquiry])
REFERENCES [dbo].[NBA_MessageID] ([MessageID])
GO
ALTER TABLE [dbo].[NBA_Agwy] CHECK CONSTRAINT [FK_NBA_Agwy_NBA_Agwy]
GO
ALTER TABLE [dbo].[NBA_Agwy]  WITH CHECK ADD  CONSTRAINT [FK_NBA_Agwy_NBA_Core] FOREIGN KEY([Core_ID])
REFERENCES [dbo].[NBA_Core] ([CORE_ID])
GO
ALTER TABLE [dbo].[NBA_Agwy] CHECK CONSTRAINT [FK_NBA_Agwy_NBA_Core]
GO
ALTER TABLE [dbo].[NBA_Agwy]  WITH CHECK ADD  CONSTRAINT [FK_NBA_Agwy_NBA_Documents] FOREIGN KEY([DOCUMENT_ID])
REFERENCES [dbo].[NBA_Documents] ([DOCUMENT_ID])
GO
ALTER TABLE [dbo].[NBA_Agwy] CHECK CONSTRAINT [FK_NBA_Agwy_NBA_Documents]
GO
ALTER TABLE [dbo].[NBA_Agwy]  WITH CHECK ADD  CONSTRAINT [FK_NBA_Agwy_NBA_Entry_Points] FOREIGN KEY([EntryPoint_ID])
REFERENCES [dbo].[NBA_Entry_Points] ([ENTRY_ID])
GO
ALTER TABLE [dbo].[NBA_Agwy] CHECK CONSTRAINT [FK_NBA_Agwy_NBA_Entry_Points]
GO
ALTER TABLE [dbo].[NBA_Agwy]  WITH CHECK ADD  CONSTRAINT [FK_NBA_Agwy_NBA_Gender] FOREIGN KEY([gender])
REFERENCES [dbo].[NBA_Gender] ([GenderID])
GO
ALTER TABLE [dbo].[NBA_Agwy] CHECK CONSTRAINT [FK_NBA_Agwy_NBA_Gender]
GO
ALTER TABLE [dbo].[NBA_Agwy]  WITH CHECK ADD  CONSTRAINT [FK_NBA_Agwy_NBA_Grade] FOREIGN KEY([higest_grade_passed])
REFERENCES [dbo].[NBA_Grade] ([Grade_ID])
GO
ALTER TABLE [dbo].[NBA_Agwy] CHECK CONSTRAINT [FK_NBA_Agwy_NBA_Grade]
GO
ALTER TABLE [dbo].[NBA_Agwy]  WITH CHECK ADD  CONSTRAINT [FK_NBA_Agwy_NBA_HighSchoolQuizz] FOREIGN KEY([HighSchoolQuizz_ID])
REFERENCES [dbo].[NBA_HighSchoolQuizz] ([HighSchoolQuiz_ID])
GO
ALTER TABLE [dbo].[NBA_Agwy] CHECK CONSTRAINT [FK_NBA_Agwy_NBA_HighSchoolQuizz]
GO
ALTER TABLE [dbo].[NBA_Agwy]  WITH CHECK ADD  CONSTRAINT [FK_NBA_Agwy_NBA_Identification] FOREIGN KEY([type_of_identification])
REFERENCES [dbo].[NBA_Identification] ([Identification_ID])
GO
ALTER TABLE [dbo].[NBA_Agwy] CHECK CONSTRAINT [FK_NBA_Agwy_NBA_Identification]
GO
ALTER TABLE [dbo].[NBA_Agwy]  WITH CHECK ADD  CONSTRAINT [FK_NBA_Agwy_NBA_Occupation] FOREIGN KEY([currrent_occupation])
REFERENCES [dbo].[NBA_Occupation] ([Occupation_ID])
GO
ALTER TABLE [dbo].[NBA_Agwy] CHECK CONSTRAINT [FK_NBA_Agwy_NBA_Occupation]
GO
ALTER TABLE [dbo].[NBA_Agwy]  WITH CHECK ADD  CONSTRAINT [FK_NBA_Agwy_NBA_SYS_Users] FOREIGN KEY([SYS_USER_ID])
REFERENCES [dbo].[NBA_SYS_Users] ([SYS_USER_ID])
GO
ALTER TABLE [dbo].[NBA_Agwy] CHECK CONSTRAINT [FK_NBA_Agwy_NBA_SYS_Users]
GO
ALTER TABLE [dbo].[NBA_Entry_Points]  WITH CHECK ADD  CONSTRAINT [FK_NBA_Entry_Points_NBA_PR] FOREIGN KEY([ID])
REFERENCES [dbo].[NBA_PR] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NBA_Entry_Points] CHECK CONSTRAINT [FK_NBA_Entry_Points_NBA_PR]
GO
ALTER TABLE [dbo].[NBA_Period_Maintenance]  WITH CHECK ADD  CONSTRAINT [FK_NBA_period_Maintenance_NBA_period_Maintenance] FOREIGN KEY([Period_ID])
REFERENCES [dbo].[NBA_Period_Maintenance] ([Period_ID])
GO
ALTER TABLE [dbo].[NBA_Period_Maintenance] CHECK CONSTRAINT [FK_NBA_period_Maintenance_NBA_period_Maintenance]
GO
ALTER TABLE [dbo].[NBA_SYS_Users]  WITH CHECK ADD  CONSTRAINT [FK_NBA_SYS_Users_NBA_PR] FOREIGN KEY([ID])
REFERENCES [dbo].[NBA_PR] ([ID])
GO
ALTER TABLE [dbo].[NBA_SYS_Users] CHECK CONSTRAINT [FK_NBA_SYS_Users_NBA_PR]
GO
ALTER TABLE [dbo].[NBA_SYS_Users]  WITH CHECK ADD  CONSTRAINT [FK_NBA_SYS_Users_NBA_Role] FOREIGN KEY([ROLE_ID])
REFERENCES [dbo].[NBA_Role] ([ROLE_ID])
GO
ALTER TABLE [dbo].[NBA_SYS_Users] CHECK CONSTRAINT [FK_NBA_SYS_Users_NBA_Role]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Quiz] FOREIGN KEY([QuizID])
REFERENCES [dbo].[Quiz] ([QuizID])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Quiz]
GO