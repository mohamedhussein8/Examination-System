/* START _USER PROCEDURES*/

create PROC [dbo].[Select_User] @U_ID int
as 
begin
 SET NOCOUNT ON;
	select * from _User where UID = @U_ID
end 
go


create PROC [dbo].[Select_User_All]
as 
begin
 SET NOCOUNT ON;
	select * from _User
end 
go

create PROC [dbo].[Insert_User]
(
	@userName varchar(20),
	@password varchar(20),
	@Fname varchar(20),
	@Lname varchar(20),
	@address varchar(30),
	@Date_Birth date,
	@User_Type char(1)
)
AS
BEGIN
	SET NOCOUNT ON;
		insert into _User values(@userName,@password,@Fname,@Lname,@address,@Date_Birth,@User_Type)
		declare @curr_Date date
		declare @U_ID int
		set @curr_Date = getdate()
		set @U_ID = IDENT_CURRENT('dbo._User')
		IF @User_Type = 's'
			exec Insert_Student @U_ID
		ELSE IF @User_Type = 'i'
			exec Insert_Instructor @U_ID, 0, @curr_Date
END
GO


CREATE PROC [dbo].[Update_User]  @userid int, @newname varchar(20), @newpass varchar(20), @fname varchar(20),
	@lname varchar(20), @addr varchar(30), @DB date, @t char(1)
as
begin
 SET NOCOUNT ON;
	if not exists(select [UID] from _User where [UID]=@userid)
		select 'cant update'
	else
		update _User
		set userName= isnull(@newname ,userName),
		password= isnull(@newpass,password),
		Fname= isnull(@fname,Fname),
		Lname= isnull(@lname,Lname),
		address= isnull(@addr,address),
		Date_Birth= isnull(@DB,Date_Birth),
		User_Type= isnull(@t,User_Type)
		where [UID]=@userid 
end 
go

create PROC [dbo].[Delete_User] @userid int
as 
begin
	SET NOCOUNT ON;
	if not exists(select [UID] from _User where [UID]=@userid)
		select 'cant delete'
	else
		declare @user_Type char
		select @user_Type=User_Type  from _User where UID = @userid
		IF @User_Type = 's'
				exec Delete_Student @userid
			ELSE IF @User_Type = 'i'
				exec Delete_Instructor @userid
		delete from [dbo].[_User] where [UID]=@userid

end 
go


/* END _USER PROCEDURES*/


/* START STUDENT PROCEDURES*/
CREATE PROC [dbo].[Select_Student] @S_ID int
AS
BEGIN
	SELECT * FROM Student WHERE SID = @S_ID
END

GO


CREATE PROC [dbo].[Select_Student_All] 
AS
BEGIN
	SELECT * FROM Student
END

GO

CREATE PROC [dbo].[Insert_Student] @S_ID int, @D_ID int = NULL
AS
BEGIN
	IF not EXISTS (SELECT Student.SID FROM Student WHERE SID = @S_ID)
		INSERT INTO Student values(@S_ID, @D_ID)
	ELSE
		SELECT CONCAT('Student # ', @S_ID, ' Already Exists')
END

GO

CREATE PROC [dbo].[Update_Student] @S_ID int, @D_ID int
AS
BEGIN
	IF EXISTS(SELECT Student.SID FROM Student WHERE SID = @S_ID)
		UPDATE Student 
			SET SID = ISNULL(@S_ID, SID),
				DID = ISNULL(@D_ID, DID)
			WHERE SID = @S_ID
	ELSE
		SELECT CONCAT(' Department # ', CAST(@D_ID AS varchar(20)) ,' Does not Exist')
END

GO


CREATE PROC [dbo].[Delete_Student] @S_ID int
AS
BEGIN
	
	IF EXISTS(SELECT Student.SID FROM Student WHERE SID = @S_ID)
	BEGIN
		IF	EXISTS (SELECT Stud_Course.SID FROM Stud_Course WHERE SID = @S_ID)
			SELECT CONCAT('Student # ', CAST(@S_ID AS varchar(20)), 'Cannot be Deleted')
		ELSE IF	EXISTS (SELECT Stud_Exam_Course.SID FROM Stud_Exam_Course WHERE SID = @S_ID)
			SELECT CONCAT('Student # ', CAST(@S_ID AS varchar(20)), 'Cannot be Deleted')
		ELSE IF	EXISTS (SELECT Stud_Exam_Ques.SID FROM Stud_Exam_Ques WHERE SID = @S_ID)
			SELECT CONCAT('Student # ', CAST(@S_ID AS varchar(20)), 'Cannot be Deleted')
		ELSE
			DELETE FROM Student WHERE SID = @S_ID
	END

END

GO
/* END STUDENT PROCEDURES*/


/* START INSTRUCTOR PROCEDURES*/
CREATE PROC [dbo].[Select_Instructor] @I_ID int
AS
BEGIN
	SELECT * FROM Instructor WHERE InsID = @I_ID
END

GO


CREATE PROC [dbo].[Select_Instructor_All] 
AS
BEGIN
	SELECT * FROM Instructor
END

GO

CREATE PROC [dbo].[Insert_Instructor] @Ins_ID int, @Salary int, @Hire_Date date, @DID int = NULL
AS
BEGIN
	IF not EXISTS (SELECT Instructor.InsID FROM Instructor WHERE InsID = @Ins_ID)
		INSERT INTO Instructor values(@Ins_ID, @Salary, @Hire_Date, @DID)
	ELSE
		SELECT CONCAT('Instructor # ', @Ins_ID, ' Already Exists')
END

GO

CREATE PROC [dbo].[Update_Instructor] @Ins_ID int, @Salary int, @Hire_Date date, @DID int
AS
BEGIN
	IF EXISTS(SELECT Instructor.InsID FROM Instructor WHERE InsID = @Ins_ID)
		UPDATE Instructor
			SET InsID = ISNULL(@Ins_ID, InsID),
				Salary = ISNULL(@Salary, Salary),
				Hire_Date = ISNULL(@Hire_Date, Hire_Date),
				DID = ISNULL(@DID, DID)
			WHERE InsID = @Ins_ID
	ELSE
		SELECT CONCAT(' Instructor # ', CAST(@Ins_ID AS varchar(20)) ,' Does not Exist')
END

GO


CREATE PROC [dbo].[Delete_Instructor] @Ins_ID int
AS
BEGIN
	
	IF EXISTS(SELECT Instructor.InsID FROM Instructor WHERE InsID = @Ins_ID)
	BEGIN
		IF	EXISTS (SELECT Ins_Course.InsID FROM Ins_Course WHERE InsID = @Ins_ID)
			SELECT CONCAT('Instructor # ', CAST(@Ins_ID AS varchar(20)), 'Cannot be Deleted')
		ELSE
			DELETE FROM Instructor WHERE InsID = @Ins_ID
	END
END

GO
/* END INSTRUCTOR PROCEDURES*/


/* START DEPARTMENT PROCEDURES*/

CREATE PROC [dbo].[Select_Department] @D_ID int
AS
BEGIN
	SELECT * FROM Department WHERE DID = @D_ID
END

GO


CREATE PROC [dbo].[Select_Department_All] 
AS
BEGIN
	SELECT * FROM Department
END

GO

CREATE PROC [dbo].[Insert_Department] @Dname varchar(20),@Dmanager int = NULL
AS
BEGIN
	IF not EXISTS (SELECT Department.DID FROM Department WHERE Dname = @Dname)
		INSERT INTO Department values(@Dname, @Dmanager)
	ELSE
		SELECT CONCAT('Department -> ', @Dname, ' Already Exists')
END

GO

CREATE PROC [dbo].[Update_Department] @D_ID int, @Dname varchar(20),@Dmanager int
AS
BEGIN
	IF EXISTS(SELECT * FROM Department WHERE DID = @D_ID)
		UPDATE Department 
			SET Dname = ISNULL(@Dname, Dname),
				Manager_ID = ISNULL(@Dmanager, Manager_ID)
			WHERE DID = @D_ID
	ELSE
		SELECT CONCAT(' Department # ', CAST(@D_ID AS varchar(20)) ,' Does not Exist')
END

GO


CREATE PROC [dbo].[Delete_Department] @D_ID int
AS
BEGIN
	
	IF EXISTS(SELECT Department.DID FROM Department WHERE DID = @D_ID)
	BEGIN
		IF	EXISTS (SELECT Student.DID FROM Student WHERE DID = @D_ID)
			SELECT CONCAT('Department # ', CAST(@D_ID AS varchar(20)), 'Cannot be Deleted')
		ELSE
			DELETE FROM Department WHERE DID = @D_ID
	END

END

GO
/* END DEPARTMENT PROCEDURES*/



/* START COURSE PROCEDURES*/

CREATE PROC [dbo].[Select_Course] @CR_ID int
AS
BEGIN
	SELECT * FROM Course WHERE CID = @CR_ID
END

GO



CREATE PROC [dbo].[Select_Course_All]
AS
BEGIN
	SELECT * FROM Course
END

GO



CREATE PROC [dbo].[Insert_Course] @CR_Name varchar(20), @CR_Duration int
AS
BEGIN
	IF not EXISTS (SELECT Course.CID FROM Course WHERE Course.Cname = @CR_Name)
		INSERT INTO Course
			VALUES (@CR_Name, @CR_Duration)
	ELSE
		SELECT CONCAT('COURSE -> ', @CR_Name, ' Already Exists')
END

GO


CREATE PROC [dbo].[Update_Course] @CR_ID int, @CR_Name varchar(20), @CR_Duration int
AS
BEGIN
	IF EXISTS(SELECT Course.CID FROM Course WHERE Course.CID = @CR_ID)
		UPDATE Course 
			SET Cname = @CR_Name, Cduration = @CR_Duration
			WHERE CID = @CR_ID
	ELSE
		SELECT CONCAT('COURSE # ', CAST(@CR_ID AS varchar(20)), ' Does not', 'Exist')
END

GO

CREATE PROC [dbo].[Delete_Course] @CR_ID int
AS
BEGIN
	
	IF EXISTS(SELECT Course.CID FROM Course WHERE Course.CID = @CR_ID)
	BEGIN
		IF	EXISTS (SELECT Topic.CID FROM Topic WHERE CID = @CR_ID)
			SELECT CONCAT('COURSE # ', CAST(@CR_ID AS varchar(20)), 'Cannot be Deleted')
		ELSE IF EXISTS(SELECT Question.CID FROM Question WHERE CID = @CR_ID)
			SELECT CONCAT('COURSE # ', CAST(@CR_ID AS varchar(20)), 'Cannot be Deleted')
		ELSE IF EXISTS(SELECT Stud_Course.CID FROM Stud_Course WHERE CID = @CR_ID)
			SELECT CONCAT('COURSE # ', CAST(@CR_ID AS varchar(20)), 'Cannot be Deleted')
		ELSE IF EXISTS(SELECT Ins_Course.CID FROM Ins_Course WHERE CID = @CR_ID)
			SELECT CONCAT('COURSE # ', CAST(@CR_ID AS varchar(20)), 'Cannot be Deleted')
		ELSE IF EXISTS(SELECT Stud_Exam_Course.CID FROM Stud_Exam_Course WHERE CID = @CR_ID)
			SELECT CONCAT('COURSE # ', CAST(@CR_ID AS varchar(20)), 'Cannot be Deleted')
		ELSE
			DELETE FROM Course WHERE CID = @CR_ID
	END

END

GO

/* END COURSE PROCEDURES*/

/* START TOPIC PROCEDURES*/

CREATE PROC [dbo].[Select_Topic] @TP_ID int, @TP_Name varchar(20)
AS
BEGIN
	SELECT * FROM Topic WHERE Topic.Tname = @TP_Name
END

GO


CREATE PROC [dbo].[Select_Topic_All]
AS
BEGIN
	SELECT * FROM Topic
END

GO

CREATE PROC [dbo].[Insert_Topic] @TP_ID int, @TP_Name varchar(20)
AS
BEGIN
	IF not EXISTS (SELECT Topic.Tname FROM Topic WHERE Topic.Tname = @TP_Name)
		INSERT INTO Topic
			VALUES (@TP_ID, @TP_Name)
	ELSE
		SELECT CONCAT('TOPIC -> ', @TP_Name, ' Already Exists')
END

GO


CREATE PROC [dbo].[Update_Topic] @TP_ID int, @Old_TP_Name varchar(20), @TP_Name varchar(20)
AS
BEGIN
	IF EXISTS(SELECT Topic.CID FROM Topic WHERE Topic.Tname = @Old_TP_Name)
		UPDATE Topic 
			SET Tname = @TP_Name
			WHERE Tname = @Old_TP_Name
	ELSE
		SELECT CONCAT('TOPIC ', @Old_TP_Name, ' Does not Exist')
END

GO


CREATE PROC [dbo].[Delete_Topic] @TP_ID int, @TP_Name varchar(20)
AS
BEGIN
	IF EXISTS(SELECT Topic.Tname FROM Topic WHERE Topic.CID = @TP_ID and Topic.Tname = @TP_Name)
		DELETE FROM Topic 
			WHERE	Topic.CID = @TP_ID 
					and 
					Topic.Tname = @TP_Name
END

GO

/* END TOPIC PROCEDURES*/


/* START QUESTION PROCEDURES*/

CREATE PROC [dbo].[Select_Question] @Q_ID int
AS
BEGIN
	SELECT * FROM Question WHERE Question.QID = @Q_ID
END

GO


CREATE PROC [dbo].[Select_Question_All]
AS
BEGIN
	SELECT * FROM Question
END

GO


CREATE PROC [dbo].[Insert_Question] @Q_Desc varchar(max), @Q_Type char, @Q_Model_Answer char, @CR_ID int = NULL
AS
BEGIN
	IF not EXISTS (SELECT Question.QID FROM Question WHERE QDescription = @Q_Desc)
		INSERT INTO Question
			VALUES (@Q_Desc, @Q_Type, @Q_Model_Answer, @CR_ID)
	ELSE
		SELECT CONCAT('Question -> ', @Q_Desc, ' Already Exists')
END

GO


CREATE PROC [dbo].[Update_Question] @Q_ID int, @Q_Desc varchar(max), @Q_Type char, @Q_Model_Answer char, @CR_ID int = NULL
AS
BEGIN
	IF EXISTS(SELECT Question.QID FROM Question WHERE QID = @Q_ID)
		UPDATE Question 
			SET QDescription = ISNULL(@Q_Desc, QDescription), 
				QType = ISNULL(@Q_Type, QType), 
				Model_Answer = ISNULL(@Q_Model_Answer, Model_Answer), 
				CID = ISNULL(@CR_ID, QID)
			WHERE QID = @Q_ID
	ELSE
		SELECT CONCAT('Question # ', CAST(@Q_ID AS varchar(20)), ' Does not Exist')
END

GO


CREATE PROC [dbo].[Delete_Question] @Q_ID int
AS
BEGIN
	IF EXISTS(SELECT Question.QID FROM Question WHERE Question.QID = @Q_ID)
	BEGIN
		IF	EXISTS (SELECT Choices.QID FROM Choices WHERE QID = @Q_ID)
			SELECT CONCAT('Question # ', CAST(@Q_ID AS varchar(20)), 'Cannot be Deleted')
		ELSE IF EXISTS(SELECT Stud_Exam_Ques.QID FROM Stud_Exam_Ques WHERE QID = @Q_ID)
			SELECT CONCAT('Question # ', CAST(@Q_ID AS varchar(20)), 'Cannot be Deleted')
		ELSE IF EXISTS(SELECT Exam_Question.QID FROM Exam_Question WHERE QID = @Q_ID)
			SELECT CONCAT('Question # ', CAST(@Q_ID AS varchar(20)), 'Cannot be Deleted')
		ELSE
			DELETE FROM Question WHERE QID = @Q_ID
	END
END

GO
/* END QUESTION PROCEDURES*/

/* START CHOICES PROCEDURES*/

CREATE PROC [dbo].[Select_Choices] @Q_ID int
AS
BEGIN
	SELECT * FROM Choices WHERE QID = @Q_ID
END

GO


CREATE PROC [dbo].[Select_Choices_All]
AS
BEGIN
	SELECT * FROM Choices
END

GO


CREATE PROC [dbo].[Insert_Choices] @Q_ID int, @Choice_Num char, @Desc varchar(150)
AS
BEGIN
	IF not EXISTS (SELECT Choices.QID FROM Choices WHERE QID = @Q_ID and ChoiceNum = @Choice_Num)
		INSERT INTO Choices
			VALUES (@Q_ID, @Choice_Num, @Desc)
	ELSE
		SELECT CONCAT('Choice # ', @Choice_Num , 'For Question # ', @Q_ID, ' Already Exists')
END

GO


CREATE PROC [dbo].[Update_Choice] @Q_ID int, @Choice_Num char, @Desc varchar(150)
AS
BEGIN
	IF EXISTS(SELECT Choices.QID FROM Choices WHERE QID = @Q_ID and ChoiceNum = @Choice_Num)
		UPDATE Choices 
			SET QID = ISNULL(@Q_ID, QID), 
				ChoiceNum = ISNULL(@Choice_Num, ChoiceNum), 
				Description = ISNULL(@Desc, Description)
			WHERE QID = @Q_ID and ChoiceNum = @Choice_Num
	ELSE
		SELECT CONCAT('Choice # ', @Choice_Num , 'For Question # ', @Q_ID, ' Does not Exist')
END

GO


CREATE PROC [dbo].[Delete_Choice] @Q_ID int, @Choice_Num char
AS
BEGIN
	IF EXISTS(SELECT Choices.QID FROM Choices WHERE QID = @Q_ID and ChoiceNum = @Choice_Num)
		DELETE FROM Choices WHERE QID = @Q_ID and ChoiceNum = @Choice_Num
END

GO
/* END CHOICES PROCEDURES*/

/* START EXAM PROCEDURES*/
CREATE PROC [dbo].[Select_Exam] @E_ID int
AS
BEGIN
	SELECT * FROM Exam WHERE EID = @E_ID
END

GO


CREATE PROC [dbo].[Select_Exam_All]
AS
BEGIN
	SELECT * FROM Exam
END

GO


CREATE PROC [dbo].[Insert_Exam] @E_ID int, @E_Duration int, @E_Date date
AS
BEGIN
	IF not EXISTS (SELECT Exam.EID FROM Exam WHERE EID = @E_ID)
		INSERT INTO Exam
			VALUES (@E_Duration, @E_Date)
	ELSE
		SELECT CONCAT('Exam # ', CAST(@E_ID AS varchar(20)), ' Already Exists')
END

GO


CREATE PROC [dbo].[Update_Exam] @E_ID int, @E_Duration int, @E_Date date
AS
BEGIN
	IF EXISTS(SELECT Exam.EID FROM Exam WHERE EID = @E_ID)
		UPDATE Exam 
			SET Eduration = ISNULL(@E_Duration, Eduration),
				Exam_Date = ISNULL(@E_Date, Exam_Date)
			WHERE EID = @E_ID
	ELSE
		SELECT CONCAT('Exam # ', CAST(@E_ID AS varchar(20)), ' Does not Exist')
END

GO


CREATE PROC [dbo].[Delete_Exam] @E_ID int, @E_Duration int, @E_Date date
AS
BEGIN
	IF EXISTS(SELECT Exam.EID FROM Exam WHERE EID = @E_ID)
	BEGIN
		IF	EXISTS (SELECT Exam_Question.EID FROM Exam_Question WHERE EID = @E_ID)
			SELECT CONCAT('Exam # ', CAST(@E_ID AS varchar(20)), 'Cannot be Deleted')
		ELSE IF	EXISTS (SELECT Stud_Exam_Ques.EID FROM Stud_Exam_Ques WHERE EID = @E_ID)
			SELECT CONCAT('Exam # ', CAST(@E_ID AS varchar(20)), 'Cannot be Deleted')
		ELSE IF EXISTS(SELECT Stud_Exam_Course.EID FROM Stud_Exam_Course WHERE EID = @E_ID)
			SELECT CONCAT('Exam # ', CAST(@E_ID AS varchar(20)), 'Cannot be Deleted')
		ELSE
			DELETE FROM Exam WHERE EID = @E_ID
	END
END

GO

/* END EXAM PROCEDURES*/

/* START EXAM-QUESTION PROCEDURES*/
CREATE PROC [dbo].[Select_Exam_Question] @E_ID int, @Q_ID int
AS
BEGIN
	SELECT * FROM Exam_Question WHERE EID = @E_ID and QID = @Q_ID
END

GO


CREATE PROC [dbo].[Select_Exam_Question_All]
AS
BEGIN
	SELECT * FROM Exam_Question
END

GO


CREATE PROC [dbo].[Insert_Exam_Question] @E_ID int, @Q_ID int
AS
BEGIN
	IF not EXISTS (SELECT * FROM Exam_Question WHERE EID = @E_ID and QID = @Q_ID)
		INSERT INTO Exam_Question
			VALUES (@E_ID, @Q_ID)
	ELSE
		SELECT CONCAT(' Question # ', CAST(@Q_ID AS varchar(20)), 'For Exam #', CAST(@E_ID AS varchar(20)),' Already Exists')
END

GO


CREATE PROC [dbo].[Update_Exam_Question] @E_ID int, @Q_ID int
AS
BEGIN
	IF EXISTS(SELECT * FROM Exam_Question WHERE EID = @E_ID and QID = @Q_ID)
		UPDATE Exam_Question 
			SET EID = ISNULL(@E_ID, EID),
				QID = ISNULL(@Q_ID, QID)
			WHERE EID = @E_ID and QID = @Q_ID
	ELSE
		SELECT CONCAT(' Question # ', CAST(@Q_ID AS varchar(20)), 'For Exam #', CAST(@E_ID AS varchar(20)),' Does not Exist')
END

GO


CREATE PROC [dbo].[Delete_Exam_Question] @E_ID int, @Q_ID int
AS
BEGIN
	IF EXISTS(SELECT * FROM Exam_Question WHERE EID = @E_ID and QID = @Q_ID)
		DELETE FROM Exam_Question WHERE EID = @E_ID and QID = @Q_ID
END

GO

/* END EXAM-QUESTION PROCEDURES*/



/* START STUDENT-COURSE PROCEDURES*/
CREATE PROC [dbo].[Select_Student_Course] @S_ID int, @C_ID int
AS
BEGIN
	SELECT * FROM Stud_Course WHERE SID = @S_ID and CID = @C_ID
END

GO

CREATE PROC [dbo].[Select_Student_Course_All]
AS
BEGIN
	SELECT * FROM Stud_Course
END

GO


CREATE PROC [dbo].[Insert_Student_Course] @S_ID int, @C_ID int, @Grade int
AS
BEGIN
	IF not EXISTS (SELECT * FROM Stud_Course WHERE SID = @S_ID and CID = @C_ID)
		INSERT INTO Stud_Course
			VALUES (@S_ID, @C_ID, @Grade)
	ELSE
		SELECT CONCAT(' Student # ', CAST(@S_ID AS varchar(20)), 'For Course #', CAST(@C_ID AS varchar(20)),' Already Exists')
END

GO


CREATE PROC [dbo].[Update_Student_Course] @S_ID int, @C_ID int, @Grade int
AS
BEGIN
	IF EXISTS(SELECT * FROM Stud_Course WHERE SID = @S_ID and CID = @C_ID)
		UPDATE Stud_Course 
			SET SID = ISNULL(@S_ID, SID),
				CID = ISNULL(@C_ID, CID),
				Grade = ISNULL(@Grade, Grade)
			WHERE SID = @S_ID and CID = @C_ID
	ELSE
		SELECT CONCAT(' Student # ', CAST(@S_ID AS varchar(20)), 'For Course #', CAST(@C_ID AS varchar(20)),' Does not Exist')
END

GO


CREATE PROC [dbo].[Delete_Student_Course] @S_ID int, @C_ID int
AS
BEGIN
	IF EXISTS(SELECT * FROM Stud_Course WHERE SID = @S_ID and CID = @C_ID)
		DELETE FROM Stud_Course WHERE SID = @S_ID and CID = @C_ID
END

GO
/* END STUDENT-COURSE PROCEDURES*/


/* START INSTRUCTOR-COURSE PROCEDURES*/
CREATE PROC [dbo].[Select_Instructor_Course] @I_ID int, @C_ID int
AS
BEGIN
	SELECT * FROM Ins_Course WHERE InsID = @I_ID and CID = @C_ID
END

GO

CREATE PROC [dbo].[Select_Instructor_Course_All]
AS
BEGIN
	SELECT * FROM Ins_Course
END

GO


CREATE PROC [dbo].[Insert_Instructor_Course] @I_ID int, @C_ID int
AS
BEGIN
	IF not EXISTS (SELECT * FROM Ins_Course WHERE InsID = @I_ID and CID = @C_ID)
		INSERT INTO Ins_Course
			VALUES (@I_ID, @C_ID)
	ELSE
		SELECT CONCAT(' Instructor # ', CAST(@I_ID AS varchar(20)), 'For Course #', CAST(@C_ID AS varchar(20)),' Already Exists')
END

GO


CREATE PROC [dbo].[Update_Instructor_Course] @I_ID int, @C_ID int
AS
BEGIN
	IF EXISTS(SELECT * FROM Ins_Course WHERE InsID = @I_ID and CID = @C_ID)
		UPDATE Ins_Course 
			SET InsID = ISNULL(@I_ID, InsID),
				CID = ISNULL(@C_ID, CID)
			WHERE InsID = @I_ID and CID = @C_ID
	ELSE
		SELECT CONCAT(' Instructor # ', CAST(@I_ID AS varchar(20)), 'For Course #', CAST(@C_ID AS varchar(20)),' Does not Exist')
END

GO


CREATE PROC [dbo].[Delete_Instructor_Course] @I_ID int, @C_ID int
AS
BEGIN
	IF EXISTS(SELECT * FROM Ins_Course WHERE InsID = @I_ID and CID = @C_ID)
		DELETE FROM Ins_Course WHERE InsID = @I_ID and CID = @C_ID
END

GO
/* END INSTRUCTOR-COURSE PROCEDURES*/


/* START STUDENT_EXAM_COURSE PROCEDURES*/
CREATE PROC [dbo].[Select_Student_EXAM_Course] @S_ID int, @E_ID int, @C_ID int
AS
BEGIN
	SELECT * FROM Stud_Exam_Course WHERE SID = @S_ID and EID = @E_ID and CID = @C_ID
END

GO

CREATE PROC [dbo].[Select_Student_EXAM_Course_All]
AS
BEGIN
	SELECT * FROM Stud_Exam_Course
END

GO


CREATE PROC [dbo].[Insert_Student_EXAM_Course] @S_ID int, @E_ID int, @C_ID int
AS
BEGIN
	IF not EXISTS (SELECT * FROM Stud_Exam_Course WHERE SID = @S_ID and EID = @E_ID and CID = @C_ID)
		INSERT INTO Stud_Exam_Course
			VALUES (@S_ID, @E_ID, @C_ID)
	ELSE
		SELECT CONCAT(' Student # ', CAST(@S_ID AS varchar(20)), 'For Course #', CAST(@C_ID AS varchar(20)), 'For Exam #', CAST(@E_ID AS varchar(20)),' Already Exists')
END

GO


CREATE PROC [dbo].[Update_Student_EXAM_Course] @S_ID int, @E_ID int, @C_ID int
AS
BEGIN
	IF EXISTS(SELECT * FROM Stud_Exam_Course WHERE SID = @S_ID and EID = @E_ID and CID = @C_ID)
		UPDATE Stud_Exam_Course 
			SET SID = ISNULL(@S_ID, SID),
				EID = ISNULL(@E_ID, EID),
				CID = ISNULL(@C_ID, CID)
			WHERE SID = @S_ID and EID = @E_ID and CID = @C_ID
	ELSE
		SELECT CONCAT(' Student # ', CAST(@S_ID AS varchar(20)), 'For Course #', CAST(@C_ID AS varchar(20)), 'For Exam #', CAST(@E_ID AS varchar(20)),' Does not Exist')
END

GO


CREATE PROC [dbo].[Delete_Student_EXAM_Course] @S_ID int, @E_ID int, @C_ID int
AS
BEGIN
	IF EXISTS(SELECT * FROM Stud_Exam_Course WHERE SID = @S_ID and EID = @E_ID and CID = @C_ID)
		DELETE FROM Stud_Exam_Course WHERE SID = @S_ID and EID = @E_ID and CID = @C_ID
END

GO
/* END STUDENT_EXAM_COURSE PROCEDURES*/


/* START EXAM-QUESTION PROCEDURES*/
CREATE PROC [dbo].[Select_Student_Exam_Question] @S_ID int, @E_ID int, @Q_ID int
AS
BEGIN
	SELECT * FROM Stud_Exam_Ques WHERE SID = @S_ID and EID = @E_ID and QID = @Q_ID
END

GO

CREATE PROC [dbo].[Select_Student_Exam_Question_All]
AS
BEGIN
	SELECT * FROM Stud_Course
END

GO


CREATE PROC [dbo].[Insert_Student_Exam_Question] @S_ID int, @E_ID int, @Q_ID int, @S_Answer char
AS
BEGIN
	IF not EXISTS (SELECT * FROM Stud_Exam_Ques WHERE SID = @S_ID and EID = @E_ID and QID = @Q_ID)
		INSERT INTO Stud_Exam_Ques
			VALUES (@S_ID, @E_ID, @Q_ID, @S_Answer)
	ELSE
		SELECT CONCAT(' Student # ', CAST(@S_ID AS varchar(20)), 'For Exam #', CAST(@E_ID AS varchar(20)), 'For Question #', CAST(@Q_ID AS varchar(20)),' Already Exists')
END

GO


CREATE PROC [dbo].[Update_Student_Exam_Question] @S_ID int, @E_ID int, @Q_ID int
AS
BEGIN
	IF EXISTS (SELECT * FROM Stud_Exam_Ques WHERE SID = @S_ID and EID = @E_ID and QID = @Q_ID)
		UPDATE Stud_Exam_Ques 
			SET SID = ISNULL(@S_ID, SID),
				EID = ISNULL(@E_ID, EID),
				QID = ISNULL(@Q_ID, QID)
			WHERE SID = @S_ID and EID = @E_ID and QID = @Q_ID
	ELSE
		SELECT CONCAT(' Student # ', CAST(@S_ID AS varchar(20)), 'For Exam #', CAST(@E_ID AS varchar(20)), 'For Question #', CAST(@Q_ID AS varchar(20)),' Does not Exists')
END

GO


CREATE PROC [dbo].[Delete_Student_Exam_Question] @S_ID int, @E_ID int, @Q_ID int
AS
BEGIN
	IF EXISTS(SELECT * FROM Stud_Exam_Ques WHERE SID = @S_ID and EID = @E_ID and QID = @Q_ID)
		DELETE FROM Stud_Exam_Ques WHERE SID = @S_ID and EID = @E_ID and QID = @Q_ID
END

GO
/* END EXAM-QUESTION PROCEDURES*/

