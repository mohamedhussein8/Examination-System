

delete from Exam_Question
delete from Exam

select * from Question
select * from Exam_Question
select * from Exam
select * from Course
select * from Choices
select * from _User
select * from Stud_Exam_Course


exec generate_Exam 200,3,3
exec generate_Exam 201,3,3

exec Insert_Student_EXAM_Course 1, 1009, 200
exec Insert_Student_EXAM_Course 1, 1010, 201

select IDENT_CURRENT('Exam')+IDENT_INCR('Exam')


alter proc generate_Exam  @cId int, @numOfTrueFalse  int , @numOfMCQ int
as
begin 


		declare @eId int
		declare @eDate date
		set @eId=IDENT_CURRENT('Exam')+IDENT_INCR('Exam')
		select @eDate= GETDATE()
		exec Insert_Exam @eId, 20, @eDate

		declare c1 cursor
		for select top (@numOfMCQ) QID
			from Question
			where CID=@cId and QType=1
			order by NEWID() 
		for read only   
		declare @QuestionID int

		open c1
		fetch c1 into @QuestionID
		while @@FETCH_STATUS=0	
			begin
			
				insert into Exam_Question values (@eId,@QuestionID)
				 fetch c1 into  @QuestionID
			end
		close c1
		deallocate c1


		declare c2 cursor
		for select top (@numOfTrueFalse) QID
			from Question
			where CID=@cId and QType=2
			order by NEWID() 
		for read only   
	
		open c2
		fetch c2 into @QuestionID
		while @@FETCH_STATUS=0	
			begin
				insert into Exam_Question values (@eId,@QuestionID)
				fetch c2 into  @QuestionID
			end
		close c2
		deallocate c2

end




select * from Exam_Question

select * from Question
select * from Choices


delete from Stud_Exam_Ques
delete from Exam_Question
delete from Exam


select * from Exam
select * from Exam_Question
select * from Stud_Exam_Course
Select * from Stud_Exam_Ques
SELECT * FROM Stud_Course
delete from Stud_Exam_Ques
delete from Stud_Exam_Course

exec generate_Exam 200,3,7

exec Exam_Answers 1001,1,'A','B','C','D','A',NULL, NULL, NULL, NULL, NULL


alter proc Exam_Answers @eID int, @stuId int,
					     @num1 char,@num2 char,@num3 char,@num4 char,@num5 char,
						@num6 char,@num7 char,@num8 char,@num9 char,@num10 char
as
begin
		declare c1 cursor
		for select  QID
			from Exam_Question
			where EID=@eID 
		for read only   
		declare @QuestionID int
		declare @count int
		set @count =0
		open c1
		fetch c1 into @QuestionID
		while @@FETCH_STATUS=0	
			begin
			if @count =0
				insert into Stud_Exam_Ques values (@stuId,@eId,@QuestionID,@num1)
			else if @count=1
				insert into Stud_Exam_Ques values (@stuId,@eId,@QuestionID,@num2)
			else if @count=2
				insert into Stud_Exam_Ques values (@stuId,@eId,@QuestionID,@num3)
			else if @count=3
				insert into Stud_Exam_Ques values (@stuId,@eId,@QuestionID,@num4)
			else if @count=4
				insert into Stud_Exam_Ques values (@stuId,@eId,@QuestionID,@num5)
			else if @count=5
				insert into Stud_Exam_Ques values (@stuId,@eId,@QuestionID,@num6)
			else if @count=6
				insert into Stud_Exam_Ques values (@stuId,@eId,@QuestionID,@num7)
			else if @count=7
				insert into Stud_Exam_Ques values (@stuId,@eId,@QuestionID,@num8)
			else if @count=8
				insert into Stud_Exam_Ques values (@stuId,@eId,@QuestionID,@num9)
			else
				insert into Stud_Exam_Ques values (@stuId,@eId,@QuestionID,@num10)
			set @count =@count+1
		    fetch c1 into  @QuestionID
			end
		close c1
		deallocate c1



end


select * from _User
select * from Student
select * from Instructor

select * from Exam
select * from Exam_Question

Select * from Stud_Exam_Ques
select * from Question


declare @score int
exec ExamCorrection 1001,1
exec ExamCorrection 1032,1,@score output

select @score

alter proc ExamCorrection @eID int , @studID int, @CID int
as
begin
	declare @grade int
	set @grade = 0
	select @grade = COUNT(*)
	from Stud_Exam_Ques,Question
	where Stud_Exam_Ques.QID=Question.QID
		 and Stud_Exam_Ques.SID=@studID and
		 Stud_Exam_Ques.EID=@eID and
		 Stud_Exam_Ques.St_Answer=Question.Model_Answer


	update Stud_Course set Grade = @grade where Stud_Course.CID = @CID and Stud_Course.SID = @studID

	select @grade
end






