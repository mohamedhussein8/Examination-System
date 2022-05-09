Alter Procedure Select_User_Course_Join
AS
BEGIN

	select Stud_Course.SID, Course.CID, userName, Cname, Grade 
		from _User inner join Stud_Course
		on _User.UID = Stud_Course.SID
		inner join Course
		on Course.CID = Stud_Course.CID


END

alter Procedure Select_User_Course_Exam_Join @S_ID int
AS
BEGIN

	select Stud_Exam_Course.SID, Stud_Exam_Course.EID, Stud_Exam_Course.CID, userName, Cname
		from _User inner join Stud_Exam_Course
		on _User.UID = Stud_Exam_Course.SID
		inner join Course
		on Course.CID = Stud_Exam_Course.CID
		inner join Exam
		on Exam.EID = Stud_Exam_Course.EID
		where _User.UID = @S_ID and (select COUNT(*) from Stud_Exam_Ques where Stud_Exam_Ques.EID = Exam.EID) = 0
END


create Procedure Check_Student_Exam @S_ID int, @C_ID int
AS
BEGIN

	select * from Stud_Exam_Course
	select * from Stud_Exam_Ques
		where Stud_Exam_Course.CID = @C_ID and Stud_Exam_Course.SID = @S_ID

END


alter Procedure Exam_Details @E_ID int
AS
BEGIN

	select Exam.EID, Question.QID, CID, QDescription, QType, Model_Answer from 
		Exam inner join Exam_Question
		on Exam.EID = Exam_Question.EID
		inner join Question
		on Question.QID = Exam_Question.QID
		where Exam.EID = @E_ID
END



execute Exam_Details 1010
execute Select_User_Course_Exam_Join 1
execute Select_Student_Course_All
execute Select_User_Course_Join
execute Select_Student_EXAM_Course_All
execute Select_Student_Exam_Question_All
execute Select_Choices 306


select * from Stud_Course
select * from _User
execute Select_Exam_Question_All
select * from Exam_Question
select * from Question
select * from Choices